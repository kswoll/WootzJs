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
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace WootzJs.Compiler
{
    public class SymbolNameCompiler
    {
        public static SymbolNameMap CompileSymbolNames(Microsoft.CodeAnalysis.Project project, Compilation compilation)
        {
/*
            var assemblyInfoByAssemblySymbol = project.MetadataReferences
                .ToDictionary(x => compilation.GetReferencedAssemblySymbol(x), x => Assembly.ReflectionOnlyLoadFrom(x.Display));
            var referencedAssembliesByAssemblySymbol = assemblyInfoByAssemblySymbol
                .ToDictionary(x => x.Key, x => x.Value.GetReferencedAssemblies().Select(y => y.Name));
*/

/*
            foreach (var metadataReference in project.MetadataReferences)
            {
                var assemblyLocation = metadataReference.Display;
                var assemblySymbol = compilation.GetReferencedAssemblySymbol(metadataReference);
                var reflectionAssembly = Assembly.ReflectionOnlyLoadFrom(assemblyLocation);
                var referencedAssemblies = reflectionAssembly.GetReferencedAssemblies();
            }
*/

            var mainAssembly = Tuple.Create(compilation.Assembly, (IAssemblySymbol[])null);//compilation.References.Select(x => compilation.GetReferencedAssemblySymbol(x)).ToArray());
//            var referencedAssemblies = mainAssembly.Item2.Select(x => Tuple.Create(x, AssembliesSorter.GetReferencedAssemblies(x).ToArray()));
            var assemblies = new[] { mainAssembly };//.Concat(referencedAssemblies).ToArray();

            var sortedAssemblies = AssembliesSorter.Sort(assemblies);

            var names = new Dictionary<ISymbol, string>();
            foreach (var assembly in sortedAssemblies)
            {
                var collector = new SymbolCollector();
                assembly.Accept(collector);

                var counter = 1;
//                var types = collector.Symbols.Where(x => x.Kind == SymbolKind.NamedType).OrderBy(x => x.DeclaredAccessibility == Accessibility.Public ? -1 : 1);
//                foreach (var type in types)
//                {
//                    names[type] = "$" + counter++;
//                }
/*
                var namespaces = collector.Symbols.Where(x => x.Kind == SymbolKind.Namespace);
                foreach (var ns in namespaces)
                {
                    names[ns] = "$" + counter++;
                }
*/
            }
            var map = new SymbolNameMap(names);
            return map;                
        } 
    }
}
