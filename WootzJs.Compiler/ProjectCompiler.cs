using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.WootzJs;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class ProjectCompiler
    {
        private Project project;
        private JsCompilationUnit jsCompilationUnit;
        private string projectName;

        public ProjectCompiler(Project project, JsCompilationUnit jsCompilationUnit, string[] defines)
        {
            this.project = project.WithParseOptions(new CSharpParseOptions(preprocessorSymbols: defines));
            this.jsCompilationUnit = jsCompilationUnit;
        }

        public async Task Compile()
        {
            projectName = project.AssemblyName;
            Compilation compilation = await Profiler.Time("Getting initial project compilation", async() => await project.GetCompilationAsync());
            Context.Update(project.Solution, project, compilation, new ReflectionCache(project, compilation));

            // If this is the runtime prjoect, declare the array to hold all the GetAssembly functions (this .js file 
            // will be loaded first, and we only want to bother creating the array once.) 
            if (projectName == "mscorlib")
            {
                var assemblies = Js.Variable(SpecialNames.Assemblies, Js.Array());
                jsCompilationUnit.Body.Local(assemblies);

                // This ensures that Function.$typeName returns `Function` -- this is important when using
                // a type function as a generic argument, since otherwise when we try to get a 
                // unique key for the permuatation of type args including a type function, we would get
                // an empty string for that arg, which would break the cache.
                jsCompilationUnit.Body.Assign(Js.Reference("Function").Member(SpecialNames.TypeName), Js.Primitive("Function"));
            }

            // Declare assembly variable
            var assemblyVariable = Js.Variable("$" + projectName.MaskSpecialCharacters() + "$Assembly", Js.Null());
            jsCompilationUnit.Body.Local(assemblyVariable);

            // Declare array to store all anonymous types
            var anonymousTypes = Js.Variable(compilation.Assembly.GetAssemblyAnonymousTypesArray(), Js.Array());
            jsCompilationUnit.Body.Local(anonymousTypes);

            // Declare array to store all the type functions in the assembly
            var assemblyTypes = Js.Variable(compilation.Assembly.GetAssemblyTypesArray(), Js.Array());
            jsCompilationUnit.Body.Local(assemblyTypes);

            // Build $GetAssemblyMethod, which lazily creates a new Assembly instance
            var globalIdioms = new Idioms(null);
            var getAssembly = Js.Function();
            getAssembly.Body.If(
                assemblyVariable.GetReference().EqualTo(Js.Null()), 
                assemblyVariable.GetReference().Assign(globalIdioms.CreateAssembly(compilation.Assembly, assemblyTypes.GetReference()))
            );
            getAssembly.Body.Return(assemblyVariable.GetReference());
            jsCompilationUnit.Body.Assign(
                Js.Reference(compilation.Assembly.GetAssemblyMethodName()),
                getAssembly);

            // Add $GetAssemblyMethod to global assemblies array
            jsCompilationUnit.Body.Express(Js.Reference("$assemblies").Member("push").Invoke(Js.Reference(compilation.Assembly.GetAssemblyMethodName())));

            // Builds out all the namespace objects.  Types live inside namepsaces, which are represented as 
            // nested Javascript objects.  For example, System.Text.StringBuilder is represented (in part) as:
            //
            // System = {};
            // System.Text = {};
            // System.Text.StringBuilder = function() { ... }
            //
            // This allows access to classes using dot notation in the expected way.
            Profiler.Time("Transforming namespaces", () =>
            {
                var namespaceTransformer = new NamespaceTransformer(jsCompilationUnit.Body);
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                    compilationUnit.Accept(namespaceTransformer);
                }                
            });

            var actions = new List<Tuple<INamedTypeSymbol, Action>>();

            Profiler.Time("Get diagnostics", () =>
            {
                var diagnostics = compilation.GetDiagnostics();
                foreach (var diagnostic in diagnostics)
                {
                    if (diagnostic.Severity == DiagnosticSeverity.Error)
                        Console.WriteLine("// " + diagnostic);
                }                
            });

            // Check for partial classes
            Profiler.Time("Reassemble partial classes", () =>
            {
                var partialClassReassembler = new PartialClassReassembler(project, compilation);
                compilation = partialClassReassembler.UnifyPartialTypes();
            });

/*
            // Write out all type functions in inheritance order.  This allows for complex references between types and
            // nested types.
            Profiler.Time("Write out type function declarations", () =>
            {
                var allTypeDeclarations = new List<INamedTypeSymbol>();
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    var semanticModel = compilation.GetSemanticModel(syntaxTree);
                    var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                    var typeDeclarations = GetTypeDeclarations(compilationUnit);
                    var types = typeDeclarations.Select(x => semanticModel.GetDeclaredSymbol(x)).ToArray();
                    allTypeDeclarations.AddRange(types);
                }
                SweepSort(allTypeDeclarations, x => x);

                jsCompilationUnit.Body.Express(Js.Reference(Context.Instance.SymbolNames[classType.ContainingNamespace, classType.ContainingNamespace.GetFullName()]).Member(classType.GetShortTypeName()), 
                        Js.Reference(SpecialNames.Define).Invoke(Js.Primitive(displayName), baseType));
                jsCompilationUnit.Assign(Js.Reference(Context.Instance.SymbolNames[classType.ContainingNamespace, classType.ContainingNamespace.GetFullName()]).Member(classType.GetShortTypeName()), 
                        Js.Reference(SpecialNames.Define).Invoke(Js.Primitive(displayName), baseType));
            });
*/

            // Scan all syntax trees for anonymous type creation expressions.  We transform them into class
            // declarations with a series of auto implemented properties.
            Profiler.Time("Running AnonymousTypeTransformer", () => 
            {
                var anonymousTypeTransformer = new AnonymousTypeTransformer(jsCompilationUnit.Body, actions);
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                    compilationUnit.Accept(anonymousTypeTransformer);
                }
            });

            // Iterate through all the syntax trees and add entries into `actions` that correspond to type
            // declarations.
            Profiler.Time("Preparing for core transformation process", () => 
            {
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    var semanticModel = compilation.GetSemanticModel(syntaxTree);
                    var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                    var transformer = new JsTransformer(syntaxTree, semanticModel);

                    var typeCollector = new TypeCollector();
                    compilationUnit.Accept(typeCollector);
                    var typeDeclarations = typeCollector.TypeDeclarations.Where(x => x.GetContainingTypeDeclaration() == null);
                    var delegateDeclarations = typeCollector.DelegateDeclarations.Where(x => x.GetContainingTypeDeclaration() == null);

                    foreach (var type in typeDeclarations)
                    {
                        var _type = type;
                        var typeSymbol = semanticModel.GetDeclaredSymbol(type);
                        Action action = () =>
                        {
                            var statements = (JsBlockStatement)_type.Accept(transformer);
                            jsCompilationUnit.Body.Aggregate(statements);
                        };
                        actions.Add(Tuple.Create(typeSymbol, action));
                    }
                    foreach (var type in delegateDeclarations)
                    {
                        var _type = type;
                        Action action = () =>
                        {
                            var statements = (JsBlockStatement)_type.Accept(transformer);
                            jsCompilationUnit.Body.Aggregate(statements);
                        };
                        actions.Add(Tuple.Create((INamedTypeSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, type), action));
                    }
                }
            });

            // Sort all the type declarations such that base types always come before subtypes.
            Profiler.Time("Sorting transformers", () => SweepSort(actions, x => x.Item1));
            
            var transformationActions = actions.Select(x => x.Item2).ToArray();

            Profiler.Time("Applying core transformation", () =>
            {
                foreach (var item in transformationActions)
                    item();
            });

            // Create cultures based on installed .NET cultures.  Presumably this is the same regardless 
            // of the platform that compiled this assembly.  Only do this for the standard library.
            if (projectName == "mscorlib" && !Context.Instance.Compilation.Assembly.IsCultureInfoExportDisabled())
            {
                foreach (var culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
                {
                    JsExpression target = new JsVariableReferenceExpression(Context.Instance.CultureInfo.GetTypeName()).Member("RegisterCulture");
                    jsCompilationUnit.Body.Add(target.Invoke(new[]
                    {
                        Js.Literal(culture.Name),
                        Js.Literal(culture.DateTimeFormat.ShortDatePattern),
                        Js.Literal(culture.DateTimeFormat.LongDatePattern),
                        Js.Literal(culture.DateTimeFormat.ShortTimePattern),
                        Js.Literal(culture.DateTimeFormat.LongTimePattern),
                        Js.Literal(culture.DateTimeFormat.FullDateTimePattern),
                        Js.Literal(culture.DateTimeFormat.YearMonthPattern),
                        Js.Array(culture.DateTimeFormat.MonthNames.Select(x => Js.Literal(x)).ToArray()),
                        Js.Array(culture.DateTimeFormat.AbbreviatedMonthNames.Select(x => Js.Literal(x)).ToArray()),
                        Js.Array(culture.DateTimeFormat.DayNames.Select(x => Js.Literal(x)).ToArray())
                    }).Express());
                }
            }

            // If the project type is a console application, then invoke the Main method at the very
            // end of the file.
            var entryPoint = Context.Instance.Compilation.GetEntryPoint(CancellationToken.None);
            if (entryPoint != null)
            {
                jsCompilationUnit.Body.Express(globalIdioms.InvokeStatic(entryPoint));
            }

            // Test minification
//            var minifier = new JsMinifier();
//            jsCompilationUnit.Accept(minifier);

        } 

        /// <summary>
        /// Long story short, this method ensures base types always come before subtypes.
        /// </summary>
        private void SweepSort<T>(List<T> list, Func<T, INamedTypeSymbol> getType)
        {
            var prepend = new HashSet<T>();
            do 
            {
                prepend.Clear();
                var indices = list.Select((x, i) => new { Item = x, Index = i }).ToDictionary(x => getType(x.Item), x => x.Index);
                for (var i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    if (Equals(getType(item), Context.Instance.SpecialFunctions))
                    {
                        if (i != 0)
                        {
                            prepend.Add(item);
                            continue;
                        }
                        else if (i == 0)
                        {
                            continue;
                        }
                    }

                    var baseType = getType(item).BaseType;
                    if (baseType != null)
                    {
                        if (!Equals(baseType.OriginalDefinition, baseType))
                            baseType = baseType.OriginalDefinition;
                        int baseIndex;
                        if (indices.TryGetValue(baseType, out baseIndex))
                        {
                            var baseTypeItem = list[baseIndex];
                            if (baseIndex > i)
                            {
                                prepend.Add(baseTypeItem);
                            }
                        }
                    }

                    // Get all base types of inner classes
                    foreach (var innerType in getType(item).GetAllInnerTypes())
                    {
                        var innerBaseType = innerType.BaseType;
                        if (innerBaseType != null)
                        {
                            if (!Equals(innerBaseType.OriginalDefinition, innerBaseType))
                                innerBaseType = innerBaseType.OriginalDefinition;
                            int baseIndex;
                            if (indices.TryGetValue(innerBaseType, out baseIndex))
                            {
                                var baseTypeItem = list[baseIndex];
                                if (baseIndex > i)
                                {
                                    prepend.Add(baseTypeItem);
                                }
                            }
                        }
                    }

                    var precedes = getType(item).GetAttributeValue<ITypeSymbol>(Context.Instance.PrecedesAttribute, "Type");
                    if (precedes != null)
                    {
                        int precedesIndex;
                        if (indices.TryGetValue((INamedTypeSymbol)precedes.OriginalDefinition, out precedesIndex))
                        {
                            var precedesItem = list[precedesIndex];
                            if (precedesIndex > i)
                            {
                                prepend.Add(precedesItem);
                            }
                        }
                    }
                }
                if (prepend.Any())
                {
                    var newItems = prepend.Concat(list.Where(x => !prepend.Contains(x))).ToArray();
                    list.Clear();
                    list.AddRange(newItems);
                }
            }
            while (prepend.Any());
        }
    }
}