using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class SymbolNameCompiler
    {
        public static SymbolNameMap CompileSymbolNames(Compilation compilation)
        {
            var mainAssembly = Tuple.Create(compilation.Assembly, compilation.References.Select(x => compilation.GetReferencedAssemblySymbol(x)).ToArray());
            var referencedAssemblies = mainAssembly.Item2.Select(x => Tuple.Create(x, AssembliesSorter.GetReferencedAssemblies(x).ToArray()));
            var assemblies = new[] { mainAssembly }.Concat(referencedAssemblies).ToArray();

            var sortedAssemblies = AssembliesSorter.Sort(assemblies);

            var names = new Dictionary<Symbol, string>();
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