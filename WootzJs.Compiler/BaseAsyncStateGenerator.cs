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
        protected SemanticModel semanticModel;
        protected MethodDeclarationSyntax node;
        internal List<AsyncState> states = new List<AsyncState>();
        protected AsyncState currentState;
        protected int exceptionNameCounter = 1;
        protected Dictionary<object, State> labelStates = new Dictionary<object, State>();

        public const string state = stateFieldName;
        
        public BaseAsyncStateGenerator(Compilation compilation, MethodDeclarationSyntax node)
        {
            this.compilation = compilation;
            this.node = node;

            semanticModel = compilation.GetSemanticModel(node.SyntaxTree);
        }

        protected virtual StatementSyntax ReturnOutOfState()
        {
            return Cs.Return();
        }

        public void GenerateStates()
        {
            currentState = NewState();
            node.Accept(this);
            OnBaseStateGenerated();

            foreach (var state in states)
            {
                var lastStatement = state.Statements.LastOrDefault();
                if (lastStatement == null || (!(lastStatement is BreakStatementSyntax) && !(lastStatement is ReturnStatementSyntax) && !(lastStatement is GotoStatementSyntax)))
                    state.Statements.Add(Cs.Return());
            }
        }

        protected virtual void OnBaseStateGenerated()
        {
        }

        public AsyncState[] States
        {
            get { return states.ToArray(); }
        }

        protected AsyncState NewState(AsyncState nextState = null)
        {
            var newState = new AsyncState();
            newState.Index = states.Count;
            newState.Next = nextState;
            states.Add(newState);            
            return newState;
        }

        protected AsyncState GetNextState()
        {
            if (currentState.Next != null)
            {
                return currentState.Next;
            }
            else
            {
                var nextState = NewState();
                return nextState;                
            }
        }

        protected AsyncState InsertState()
        {
            var nextState = NewState();
            nextState.Next = currentState.Next;
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

        public BlockSyntax GotoState(AsyncState newState)
        {
            return Cs.Block(
                ChangeState(newState),
                GotoTop()
            );
        }
    }
}