using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class BaseAsyncStateGenerator : CSharpSyntaxWalker
    {
        public const string stateFieldName = "$state";

        private int currentStateIndex;
        protected Compilation compilation;
        protected SemanticModel semanticModel;
        protected CSharpSyntaxNode node;
        internal AsyncState topState = new AsyncState();
        protected int exceptionNameCounter = 1;

        public const string state = stateFieldName;
        
        public BaseAsyncStateGenerator(Compilation compilation, CSharpSyntaxNode node)
        {
            this.compilation = compilation;
            this.node = node;

            semanticModel = compilation.GetSemanticModel(node.SyntaxTree);
        }

        public void GenerateStates()
        {
            topState.CurrentState = NewState();
            node.Accept(this);
            OnBaseStateGenerated();

/*
            foreach (var state in topState.GetAllSubstates())
            {
                var lastStatement = state.Statements.LastOrDefault();
                if (lastStatement == null || (!(lastStatement is BreakStatementSyntax) && !(lastStatement is ReturnStatementSyntax) && !(lastStatement is GotoStatementSyntax)))
                    state.InternalAdd(Cs.Return());
            }
*/
        }

        protected virtual void OnBaseStateGenerated()
        {
        }

        public AsyncState TopState
        {
            get { return topState; }
        }

        protected AsyncState NewState(AsyncState nextState = null)
        {
            var newState = new AsyncState();
            newState.Parent = topState;
            newState.Index = currentStateIndex++;
            newState.Next = nextState;
            topState.Substates.Add(newState);            
            return newState;
        }

        protected AsyncState NewSubstate()
        {
            var newState = NewState();
            return newState;
        }

        protected void StartSubstate(AsyncState substate)
        {
            topState = substate;
            CurrentState = NewState();            
        }

        protected void EndSubstate()
        {
            topState.InternalAdd(GenerateSwitch(topState));
            topState = topState.Parent;
        }

        protected AsyncState GetNextState()
        {
            if (topState.CurrentState.Next != null)
            {
                return topState.CurrentState.Next;
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
            nextState.Next = topState.CurrentState.Next;
            return nextState;
        }

        public AsyncState CurrentState
        {
            get { return topState.CurrentState; }
            set { topState.CurrentState = value; }
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
        protected JsStatement GotoTop()
        {
            return Js.Continue("$top");
        }

        public JsStatement ChangeState(AsyncState newState)
        {
            return Js.Reference(state).Assign(Js.Primitive(newState.Index)).Express();
        }

        public void GotoState(AsyncState newState)
        {
            var lastStatement = CurrentState.Statements.LastOrDefault();
            if (lastStatement is JsContinueStatement || lastStatement is JsBreakStatement)
                return;
            CurrentState.Add(ChangeState(newState));
            CurrentState.Add(GotoTop());
        }

        public JsBlockStatement GotoStateBlock(AsyncState newState)
        {
            return Js.Block(
                ChangeState(newState),
                GotoTop()
            );
        }

        public JsStatement[] GotoStateStatements(AsyncState newState)
        {
            return new[]
            {
                ChangeState(newState),
                GotoTop()                
            };
        }

        public JsStatement GenerateSwitch(AsyncState state)
        {
            var sections = new List<JsSwitchSection>();
            if (state.Parent != null)
            {
                var stateSection = Js.Section(Js.Primitive(state.Index));
                stateSection.Statements.AddRange(GotoStateStatements(state.Substates.First()));
                sections.Add(stateSection);
            }
            sections.AddRange(state.Substates.Select(substate =>
            {
                var section = Js.Section(substate.GetAllIndices().Select(index => Js.Primitive(index)).ToArray());
                section.Statements.AddRange(substate.Statements);
                return section;
            }));
            return state.Wrap(Js.Switch(Js.Reference(StateGenerator.state), sections.ToArray()));
        }
    }
}