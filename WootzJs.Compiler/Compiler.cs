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
using System.IO;
using System.Linq;
using System.Runtime.WootzJs;
using System.Threading;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class Compiler
    {
        public static void Main(string[] args)
        {
            var projectFileInfo = new FileInfo(args[0]);
            var projectFolder = projectFileInfo.Directory.FullName;
            IProject project;
            var output = new Compiler().Compile(args[0], out project);
            var projectName = project.AssemblyName;
            var outputFolder = args[1];

            File.WriteAllText(projectFolder + "\\" + outputFolder + projectName + ".js", output);
        }

        public string Compile(string projectFile)
        {
            IProject project;
            return Compile(projectFile, out project);
        }

        public string Compile(string projectFile, out IProject project)
        {
            var projectFileInfo = new FileInfo(projectFile);
            var projectFolder = projectFileInfo.Directory.FullName;

            // These two lines are just a weird hack because you get no files back from compilation.SyntaxTrees
            // if the user file isn't modified.  Not sure why that's happening.
            var projectUserFile = projectFolder + "\\" + projectFileInfo.Name + ".user";
            if (File.Exists(projectUserFile))
                File.SetLastWriteTime(projectUserFile, DateTime.Now);

            project = Solution.LoadStandAloneProject(projectFile);
            var projectName = project.AssemblyName;
            var compilation = (Compilation)project.GetCompilation();
            Context.Update(project.Solution, project, compilation);

            // Check for yield
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var compilationUnit = syntaxTree.GetRoot();
                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var yieldGenerator = new YieldGenerator(compilation, syntaxTree, semanticModel);
                compilationUnit = (CompilationUnitSyntax)compilationUnit.Accept(yieldGenerator);
                compilation = compilation.ReplaceSyntaxTree(syntaxTree, SyntaxTree.Create(compilationUnit, syntaxTree.FilePath));
            }
            Context.Update(project.Solution, project, compilation);
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var compilationUnit = syntaxTree.GetRoot();
                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var yieldFixer = new YieldGeneratorFixer(compilation, syntaxTree, semanticModel);
                compilationUnit = (CompilationUnitSyntax)compilationUnit.Accept(yieldFixer);
                compilation = compilation.ReplaceSyntaxTree(syntaxTree, SyntaxTree.Create(compilationUnit, syntaxTree.FilePath));
            }
            Context.Update(project.Solution, project, compilation);

            var jsCompilationUnit = new JsCompilationUnit { UseStrict = true };

            // If the runtime prjoect, declare the array to hold all the GetAssembly functions
            if (projectName == "mscorlib")
            {
                var assemblies = Js.Variable(SpecialNames.Assemblies, Js.Array());
                jsCompilationUnit.Body.Local(assemblies);
            }

            // Declare assembly variable
            var assemblyVariable = Js.Variable("$" + projectName.MaskSpecialCharacters() + "$Assembly", Js.Null());
            jsCompilationUnit.Body.Local(assemblyVariable);

            // Declare array to store all the type functions in the assembly
            var assemblyTypes = Js.Variable(compilation.Assembly.GetAssemblyTypesArray(), Js.Array());
            jsCompilationUnit.Body.Local(assemblyTypes);

            // Build $GetAssemblyMethod, which lazily creates a new Assembly instance
            var globalIdioms = new Idioms(null);
            var getAssembly = Js.Function();
            getAssembly.Body.If(
                assemblyVariable.GetReference().EqualTo(Js.Null()), 
                Js.Assign(
                    assemblyVariable.GetReference(), 
                    globalIdioms.CreateAssembly(compilation.Assembly, assemblyTypes.GetReference())
                )
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
            var namespaceTransformer = new NamespaceTransformer(jsCompilationUnit.Body);
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var compilationUnit = syntaxTree.GetRoot();
                compilationUnit.Accept(namespaceTransformer);
            }

            var actions = new List<Tuple<NamedTypeSymbol, Action>>();

            // Scan all syntax trees for anonymous type creation expressions.  We transform them into class
            // declarations with a series of auto implemented properties.
            var anonymousTypeTransformer = new AnonymousTypeTransformer(jsCompilationUnit.Body, actions);
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var compilationUnit = syntaxTree.GetRoot();
                compilationUnit.Accept(anonymousTypeTransformer);
            }

/*
            var diagnostics = compilation.GetDiagnostics();
            foreach (var diagnostic in diagnostics)
            {
                Console.WriteLine("// " + diagnostic);
            }
*/

            // Iterate through all the syntax trees and add entries into `actions` that correspond to type
            // declarations.
            foreach (var syntaxTree in compilation.SyntaxTrees)
            {
                var semanticModel = compilation.GetSemanticModel(syntaxTree);
                var compilationUnit = syntaxTree.GetRoot();
                var transformer = new JsTransformer(syntaxTree, semanticModel);

                var typeDeclarations = GetTypeDeclarations(compilationUnit);
                foreach (var type in typeDeclarations)
                {
                    Action action = () =>
                    {
                        var statements = (JsBlockStatement)type.Accept(transformer);
                        jsCompilationUnit.Body.Aggregate(statements);
                    };
                    actions.Add(Tuple.Create(semanticModel.GetDeclaredSymbol(type), action));
                }
                var delegateDeclarations = GetDelegates(compilationUnit);
                foreach (var type in delegateDeclarations)
                {
                    Action action = () =>
                    {
                        var statements = (JsBlockStatement)type.Accept(transformer);
                        jsCompilationUnit.Body.Aggregate(statements);
                    };
                    actions.Add(Tuple.Create(semanticModel.GetDeclaredSymbol(type), action));
                }
            }

//            var diagnostics = compilation.GetDiagnostics();

            // Sort all the type declarations such that base types always come before subtypes.
            SweepSort(actions);
            foreach (var item in actions)
                item.Item2();

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

            // Write out the compiled Javascript file to the target location.
            var renderer = new JsRenderer();
            jsCompilationUnit.Accept(renderer);
            return renderer.Output;
        } 

        /// <summary>
        /// Long story short, this method ensures base types always come before subtypes.
        /// </summary>
        private void SweepSort(List<Tuple<NamedTypeSymbol, Action>> list)
        {
            var prepend = new HashSet<Tuple<NamedTypeSymbol, Action>>();
            do 
            {
                prepend.Clear();
                var indices = list.Select((x, i) => new { Item = x, Index = i }).ToDictionary(x => x.Item.Item1, x => x.Index);
                for (var i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    if (item.Item1 == Context.Instance.SpecialFunctions)
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
                        if (baseType.OriginalDefinition != baseType)
                            baseType = (NamedTypeSymbol)baseType.OriginalDefinition;
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
                            if (innerBaseType.OriginalDefinition != innerBaseType)
                                innerBaseType = (NamedTypeSymbol)innerBaseType.OriginalDefinition;
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

/*
                    foreach (var interfaceType in item.Item1.AllInterfaces)
                    {
                        int baseIndex;
                        if (indices.TryGetValue(interfaceType, out baseIndex))
                        {
                            var baseTypeItem = list[baseIndex];
                            if (baseIndex > i)
                            {
                                prepend.Add(baseTypeItem);
                            }
                        }                        
                    }
*/
                    var precedes = item.Item1.GetAttributeValue<TypeSymbol>(Context.Instance.PrecedesAttribute, "Type");
                    if (precedes != null)
                    {
                        int precedesIndex;
                        if (indices.TryGetValue((NamedTypeSymbol)precedes.OriginalDefinition, out precedesIndex))
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
