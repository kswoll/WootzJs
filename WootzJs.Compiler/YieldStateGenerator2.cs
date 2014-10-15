using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class YieldStateGenerator2 : BaseAsyncStateGenerator
    {
        public const string clone = "$clone";

        public YieldStateGenerator2(Func<BaseAsyncStateGenerator, JsTransformer> transformer, CSharpSyntaxNode node, JsBlockStatement stateMachineBody, Idioms idioms, IMethodSymbol method) : base(transformer, node, stateMachineBody, idioms, method)
        {
        }
    }
}