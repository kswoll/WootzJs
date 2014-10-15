using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class YieldStateGenerator2 : BaseAsyncStateGenerator
    {
        public const string clone = "$clone";
//        public const string current = "$current";

        public YieldStateGenerator2(Func<BaseAsyncStateGenerator, JsTransformer> transformer, CSharpSyntaxNode node, JsBlockStatement stateMachineBody, Idioms idioms, IMethodSymbol method) : base(transformer, node, stateMachineBody, idioms, method)
        {
        }

        public override void VisitYieldStatement(YieldStatementSyntax node)
        {
            var nextState = GetNextState();

            if (node.ReturnOrBreakKeyword.IsKind(SyntaxKind.BreakKeyword))
            {
                CurrentState.Add(ChangeState(nextState));
                CurrentState.Add(Js.Primitive(false).Return());
            }
            else
            {
                CurrentState.Add(ChangeState(nextState));
                CurrentState.Add(Js.Reference(stateMachine).Member("set_Current").Invoke((JsExpression)node.Expression.Accept(Transformer)).Express());
                CurrentState.Add(Js.Primitive(true).Return());
            }
        }
    }
}