using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class YieldStateGenerator : BaseStateGenerator
    {
        public const string clone = "$clone";
//        public const string current = "$current";

        public YieldStateGenerator(Func<BaseStateGenerator, JsTransformer> transformer, CSharpSyntaxNode node, JsBlockStatement stateMachineBody, Idioms idioms, IMethodSymbol method) : base(transformer, node, stateMachineBody, idioms, method)
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
            CurrentState = nextState;
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            base.VisitIfStatement(node);
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            base.VisitWhileStatement(node);
        }

        protected override void OnBaseStateGenerated()
        {
            var lastStatement = CurrentState.Statements.LastOrDefault();
            if (lastStatement is JsContinueStatement || lastStatement is JsBreakStatement || lastStatement is JsReturnStatement)
                return;
            CurrentState.Add(Js.Return(Js.Primitive(false)));
        }
    }
}