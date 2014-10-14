using System;
using Microsoft.CodeAnalysis.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class YieldStateGenerator2 : BaseAsyncStateGenerator
    {
        public YieldStateGenerator2(Func<BaseAsyncStateGenerator, JsTransformer> transformer, CSharpSyntaxNode node, JsBlockStatement stateMachineBody) : base(transformer, node, stateMachineBody)
        {
        }
    }
}