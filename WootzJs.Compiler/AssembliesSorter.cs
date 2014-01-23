using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class AssembliesSorter
    {
        public static AssemblySymbol[] GetReferencedAssemblies(AssemblySymbol assembly)
        {
            var result = (ReadOnlyArray<AssemblySymbol>)assembly.GetType().GetMethod("GetLinkedReferencedAssemblies", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(assembly, new object[0]);
            if (result == null)
                return new AssemblySymbol[0];
            return result.ToArray();
        }

        public static AssemblySymbol[] Sort(Tuple<AssemblySymbol, AssemblySymbol[]>[] assemblies)
        {
            var currentList = assemblies.ToList();

            var prepend = new HashSet<Tuple<AssemblySymbol, AssemblySymbol[]>>();
            do 
            {
                prepend.Clear();
                var indices = currentList.Select((x, i) => new { Item = x, Index = i }).ToDictionary(x => x.Item.Item1, x => x.Index);
                for (var i = 0; i < currentList.Count; i++)
                {
                    var item = currentList[i];
                    foreach (var referencedAssembly in item.Item2)
                    {
                        int assemblyIndex;
                        if (indices.TryGetValue(referencedAssembly, out assemblyIndex))
                        {
                            if (assemblyIndex > i)
                            {
                                var referencedAssemblyItem = currentList[assemblyIndex];
                                prepend.Add(referencedAssemblyItem);
                            }
                        }                        
                    }
                }
                if (prepend.Any())
                {
                    var newItems = prepend.Concat(currentList.Where(x => !prepend.Contains(x))).ToArray();
                    currentList.Clear();
                    currentList.AddRange(newItems);
                }
            }
            while (prepend.Any());

            return currentList.Select(x => x.Item1).ToArray();
        }
    }
}