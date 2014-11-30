using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace WootzJs.Compiler
{
    public class ReflectionCache
    {
        private Dictionary<string, Assembly> assemblies;

        public ReflectionCache(Project project, Compilation compilation)
        {
//            assemblies = project.MetadataReferences
//                .ToDictionary(x => compilation.GetAssemblyOrModuleSymbol(x).MetadataName, x => Assembly.ReflectionOnlyLoadFrom(x.Display));
        }

        public Type GetReflectedType(INamedTypeSymbol type)
        {
            if (type.ContainingAssembly.Name == "mscorlib")
                return null;
            var assemblyInfo = assemblies[type.ContainingAssembly.MetadataName];
            var result = assemblyInfo.GetType(type.GetFullName(), false);
            return result;
        }
    }
}