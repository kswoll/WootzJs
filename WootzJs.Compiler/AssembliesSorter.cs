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
    public class AssembliesSorter
    {
/*
        public static IAssemblySymbol[] GetReferencedAssemblies(IAssemblySymbol assembly)
        {
            var result = assembly.GetType().GetMethod("GetLinkedReferencedAssemblies", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(assembly, new object[0]);
            if (result == null)
                return new IAssemblySymbol[0];
            return result.ToArray();
        }
*/

        public static IAssemblySymbol[] Sort(Tuple<IAssemblySymbol, IAssemblySymbol[]>[] assemblies)
        {
            var currentList = assemblies.ToList();

            var prepend = new HashSet<Tuple<IAssemblySymbol, IAssemblySymbol[]>>();
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
