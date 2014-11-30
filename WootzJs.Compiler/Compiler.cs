#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.WootzJs;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nito.AsyncEx;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class Compiler
    {
        public static void Main(string[] args)
        {
            if (args.Length > 2)
            {
                Profiler.Output = new StreamWriter(args[2]);
            }

            var fileInfo = new FileInfo(args[0]);
            var fileFolder = fileInfo.Directory.FullName;
            AsyncContext.Run(async () =>
            {
                if (fileInfo.Extension.Equals(".sln", StringComparison.InvariantCultureIgnoreCase))
                {
                    var result = await Profiler.Time("Total Time", async () => await new Compiler().CompileSolution(args[0]));                    
                    var output = result.Item1;
                    var solution = result.Item2;
                    var solutionName = fileInfo.Name.Substring(0, fileInfo.Name.Length - ".sln".Length);
                    var outputFolder = args[1];
                    File.WriteAllText(fileFolder + "\\" + outputFolder + solutionName + ".js", output);
                }
                else
                {
                    var result = await Profiler.Time("Total Time", async () => await new Compiler().CompileProject(args[0]));
                    var output = result.Item1;
                    var project = result.Item2;
                    var projectName = project.AssemblyName;
                    var outputFolder = args[1];

                    File.WriteAllText(fileFolder + "\\" + outputFolder + projectName + ".js", output);
                }
            });
        }

        public async Task<Tuple<string, Microsoft.CodeAnalysis.Solution>> CompileSolution(string solutionFile)
        {
//            var solutionFileInfo = new FileInfo(solutionFile);
//            var solutionFolder = solutionFileInfo.Directory.FullName;
            var solution = await Profiler.Time("Loading Project", async () => await Microsoft.CodeAnalysis.MSBuild.MSBuildWorkspace.Create().OpenSolutionAsync(solutionFile));
            var jsCompilationUnit = new JsCompilationUnit { UseStrict = true };

            foreach (var project in SortProjectsByDependencies(solution))
            {
                await CompileProject(project, jsCompilationUnit);
            }

            // Write out the compiled Javascript file to the target location.
            var renderer = new JsRenderer();
            Profiler.Time("Rendering javascript", () => jsCompilationUnit.Accept(renderer));

//            solution.Projects
            return Tuple.Create(renderer.Output, solution);
        }

        private IEnumerable<Project> SortProjectsByDependencies(Solution solution)
        {
            var projects = solution.Projects.Select((x, i) => new { Index = i, Project = x }).ToList();
            var prepend = projects.Take(0).ToHashSet();
            do
            {
                if (prepend.Any())
                    projects = prepend.Concat(projects.Except(prepend)).Select((x, i) => new { Index = i, x.Project }).ToList();
                prepend.Clear();
                var mscorlib = projects.Single(x => x.Project.AssemblyName == "mscorlib");
                foreach (var item in projects)
                {
                    var referencedProjects = item.Project.ProjectReferences.Where(x => solution.ProjectIds.Contains(x.ProjectId)).Select(x => projects.Single(y => y.Project.Id == x.ProjectId)).ToList();
                    if (item.Project.Id != mscorlib.Project.Id)
                        referencedProjects.Add(mscorlib);
                    foreach (var referencedProject in referencedProjects)
                    {
                        if (referencedProject.Index > item.Index)
                        {
                            prepend.Add(referencedProject);
                        }
                    }
                }
            } while (prepend.Any());

            return projects.Select(x => x.Project).ToArray();
        }

        public async Task<Tuple<string, Microsoft.CodeAnalysis.Project>> CompileProject(string projectFile)
        {
//            var projectFileInfo = new FileInfo(projectFile);
//            var projectFolder = projectFileInfo.Directory.FullName;

            // These two lines are just a weird hack because you get no files back from compilation.SyntaxTrees
            // if the user file isn't modified.  Not sure why that's happening.
//            var projectUserFile = projectFolder + "\\" + projectFileInfo.Name + ".user";
//            if (File.Exists(projectUserFile))
//                File.SetLastWriteTime(projectUserFile, DateTime.Now);

            var jsCompilationUnit = new JsCompilationUnit { UseStrict = true };
            var project = await Profiler.Time("Loading Project", async () => await Microsoft.CodeAnalysis.MSBuild.MSBuildWorkspace.Create().OpenProjectAsync(projectFile));
            await CompileProject(project, jsCompilationUnit);

            // Write out the compiled Javascript file to the target location.
            var renderer = new JsRenderer();
//            renderer.Builder.IsCompacting = true;
            Profiler.Time("Rendering javascript", () => jsCompilationUnit.Accept(renderer));

            return Tuple.Create(renderer.Output, project);
        }

        public async Task CompileProject(Project project, JsCompilationUnit jsCompilationUnit) 
        {
            var projectName = project.AssemblyName;
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

            // Iterate through all the syntax trees and add entries into `actions` that correspond to type
            // declarations.
            Profiler.Time("Preparing for core transformation process", () => 
            {
                foreach (var syntaxTree in compilation.SyntaxTrees)
                {
                    var semanticModel = compilation.GetSemanticModel(syntaxTree);
                    var compilationUnit = (CompilationUnitSyntax)syntaxTree.GetRoot();
                    var transformer = new JsTransformer(syntaxTree, semanticModel);

                    var typeDeclarations = GetTypeDeclarations(compilationUnit);
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
                    var delegateDeclarations = GetDelegates(compilationUnit);
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
            Profiler.Time("Sorting transformers", () => SweepSort(actions));
            Profiler.Time("Applying core transformation", () =>
            {
                foreach (var item in actions)
                    item.Item2();
            });

            // Create cultures based on installed .NET cultures.  Presumably this is the same regardless 
            // of the platform that compiled this assembly.  Only do this for the standard library.
            if (projectName == "mscorlib")
            {
/*
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
*/
            }

            // If the project type is a console application, then invoke the Main method at the very
            // end of the file.
            var entryPoint = compilation.GetEntryPoint(CancellationToken.None);
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
        private void SweepSort(List<Tuple<INamedTypeSymbol, Action>> list)
        {
            var prepend = new HashSet<Tuple<INamedTypeSymbol, Action>>();
            do 
            {
                prepend.Clear();
                var indices = list.Select((x, i) => new { Item = x, Index = i }).ToDictionary(x => x.Item.Item1, x => x.Index);
                for (var i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    if (Equals(item.Item1, Context.Instance.SpecialFunctions))
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

                    var baseType = item.Item1.BaseType;
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
                    foreach (var innerType in item.Item1.GetAllInnerTypes())
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

                    var precedes = item.Item1.GetAttributeValue<ITypeSymbol>(Context.Instance.PrecedesAttribute, "Type");
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

        /// <summary>
        /// Get all the type declarations in a compilation 
        /// </summary>
        private IEnumerable<BaseTypeDeclarationSyntax> GetTypeDeclarations(CompilationUnitSyntax compilationUnit)
        {
            foreach (var member in compilationUnit.Members)
            {
                if (member is BaseTypeDeclarationSyntax)
                {
                    yield return (BaseTypeDeclarationSyntax)member;
                }
                else if (member is NamespaceDeclarationSyntax)
                {
                    foreach (var item in GetTypeDeclarations((NamespaceDeclarationSyntax)member))
                    {
                        yield return item;
                    }
                }
            }
        }

        /// <summary>
        /// Get all the type declarations in a given namespace
        /// </summary>
        private IEnumerable<BaseTypeDeclarationSyntax> GetTypeDeclarations(NamespaceDeclarationSyntax ns)
        {
            foreach (var member in ns.Members)
            {
                if (member is BaseTypeDeclarationSyntax)
                {
                    yield return (BaseTypeDeclarationSyntax)member;
                }
                else if (member is NamespaceDeclarationSyntax)
                {
                    foreach (var item in GetTypeDeclarations((NamespaceDeclarationSyntax)member))
                    {
                        yield return item;
                    }
                }
            }
        }

        /// <summary>
        /// Get all the delegates in a given type member.
        /// </summary>
        private IEnumerable<DelegateDeclarationSyntax> GetDelegates(MemberDeclarationSyntax member)
        {
            if (member is ClassDeclarationSyntax)
            {
                foreach (var item in GetDelegates((ClassDeclarationSyntax)member))
                {
                    yield return item;
                }
            }
            else if (member is NamespaceDeclarationSyntax)
            {
                foreach (var item in GetDelegates((NamespaceDeclarationSyntax)member))
                {
                    yield return item;
                }
            }
            else if (member is DelegateDeclarationSyntax)
            {
                yield return (DelegateDeclarationSyntax)member;
            }
        }

        private IEnumerable<DelegateDeclarationSyntax> GetDelegates(CompilationUnitSyntax compilationUnit)
        {
            foreach (var member in compilationUnit.Members)
            {
                foreach (var item in GetDelegates(member))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<DelegateDeclarationSyntax> GetDelegates(ClassDeclarationSyntax type)
        {
            foreach (var member in type.Members)
            {
                foreach (var item in GetDelegates(member))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<DelegateDeclarationSyntax> GetDelegates(NamespaceDeclarationSyntax ns)
        {
            foreach (var member in ns.Members)
            {
                foreach (var item in GetDelegates(member))
                {
                    yield return item;
                }
            }
        }
    }
}
