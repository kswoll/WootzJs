using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class BaseAsyncStateGenerator : CSharpSyntaxWalker
    {
        public const string stateFieldName = "$state";

        protected Compilation compilation;
        private MethodDeclarationSyntax node;
        internal List<AsyncState> states = new List<AsyncState>();
        protected AsyncState currentState;
        protected int exceptionNameCounter = 1;
        protected Dictionary<object, State> labelStates = new Dictionary<object, State>();

        public const string state = stateFieldName;
        
        public BaseAsyncStateGenerator(Compilation compilation, MethodDeclarationSyntax node)
        {
            this.compilation = compilation;
            this.node = node;
        }

        protected virtual StatementSyntax ReturnOutOfState()
        {
            return Cs.Return();
        }

        public void GenerateStates()
        {
            currentState = new AsyncState(this);
            node.Accept(this);

            var lastStatement = states.Last().Statements.LastOrDefault();
            if (lastStatement == null || (!(lastStatement is BreakStatementSyntax) && !(lastStatement is ReturnStatementSyntax) && !(lastStatement is GotoStatementSyntax)))
                states.Last().Statements.Add(Cs.Break());
        }

        public AsyncState[] States
        {
            get { return states.ToArray(); }
        }

        protected AsyncState GetNextState()
        {
            var nextState = new AsyncState(this);
            return nextState;
        }

/*
        public void CloseTo(AsyncState fromState, AsyncState toState)
        {
            if (fromState.IsClosed)
                return;
            if (toState == null)
                throw new ArgumentNullException("toState");

            fromState.Add(ChangeState(toState));
            fromState.Add(SyntaxFactory.GotoStatement(SyntaxKind.GotoCaseStatement, SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(toState.Index))));                        
            SetClosed(fromState);
        }


*/
        protected StatementSyntax GotoTop()
        {
            return SyntaxFactory.GotoStatement(SyntaxKind.GotoStatement, SyntaxFactory.IdentifierName("$top"));
        }

        public StatementSyntax ChangeState(AsyncState newState)
        {
            return Cs.This().Member(state).Assign(Cs.Integer(newState.Index)).Express();
        }
    }
}