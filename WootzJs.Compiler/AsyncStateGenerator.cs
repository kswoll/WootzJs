using System.Collections.Generic;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class AsyncStateGenerator : StateGenerator
    {
        public AsyncStateGenerator(Compilation compilation, MethodDeclarationSyntax node) : base(compilation, node)
        {
        }
    }
}