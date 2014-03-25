using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class StateGenerator : SyntaxWalker
    {
        public const string stateFieldName = "$state";

        protected Compilation compilation;
        private MethodDeclarationSyntax node;
        internal List<State> states = new List<State>();
        protected State currentState;
        protected int exceptionNameCounter = 1;
        private Dictionary<string, TypeSyntax> hoistedVariables = new Dictionary<string, TypeSyntax>();
        protected Dictionary<object, State> labelStates = new Dictionary<object, State>();

        public const string state = stateFieldName;
        
        public StateGenerator(Compilation compilation, MethodDeclarationSyntax node)
        {
            this.compilation = compilation;
            this.node = node;
        }

        private string GenerateNewName(SyntaxToken identifier)
        {
            var counter = 2;
            do
            {
                var currentName = identifier.ToString() + counter++;
                if (!hoistedVariables.ContainsKey(currentName))
                {
                    return currentName;
                }
            }
            while (true);
        }

        protected SyntaxNode HoistVariable(SyntaxNode node, SyntaxToken identifier, TypeSyntax type)
        {
            if (hoistedVariables.ContainsKey(identifier.ToString()))
            {
                var newName = GenerateNewName(identifier);
                var newIdentifier = Syntax.Identifier(newName);
                node = IdentifierRenamer.RenameIdentifier(node, identifier, newIdentifier);
                identifier = newIdentifier;
            }
            hoistedVariables[identifier.ToString()] = type;
            return node;
        }

        public void GenerateStates()
        {
            var lastState = new State(this);
            lastState.Statements.Add(Cs.Return(Cs.False()));

            currentState = new State(this) { NextState = lastState };
            node.Accept(this);

            // Post-process goto statements
            if (labelStates.Any())
            {
                var gotoSubstituter = new GotoSubstituter(compilation, labelStates);
                foreach (var state in states)
                {
                    state.Statements = state.Statements.Select(x => (StatementSyntax)x.Accept(gotoSubstituter)).ToList();
                }
            }
        }

        public State[] States
        {
            get { return states.ToArray(); }
        }

        public Tuple<SyntaxToken, TypeSyntax>[] HoistedVariables
        {
            get { return hoistedVariables.Select(x => Tuple.Create(Syntax.Identifier(x.Key), x.Value)).ToArray(); }
        }

        protected State GetNextState(StatementSyntax node)
        {
            var nextState = currentState.NextState;
            var next = node.GetNextStatement();
            if (next != null && !(next is EmptyStatementSyntax))
            {
                nextState = new State(this) { NextState = currentState.NextState, Germ = currentState.Germ };
            }
            return nextState;
        }

        protected void SetClosed(State state)
        {
            state.IsClosed = true;
            if (state.Germ != null)
                state.Germ(state);
        }

        public void Close(State state)
        {
            CloseTo(state, state.NextState);
        }

        public void CloseTo(State fromState, State toState)
        {
            if (fromState.IsClosed)
                return;
            if (toState == null)
                throw new ArgumentNullException("toState");

            fromState.Add(ChangeState(toState));
            fromState.Add(GotoTop());                        
            SetClosed(fromState);
        }

        public static StatementSyntax ChangeState(State newState)
        {
            return Cs.Express(Cs.This().Member(state).Assign(Cs.Integer(newState.Index)));
        }

        protected StatementSyntax GotoTop()
        {
            return Syntax.GotoStatement(SyntaxKind.GotoStatement, Syntax.IdentifierName("$top"));
        }

        protected void MaybeCreateNewState()
        {
            if (currentState.Statements.Any())
            {
                var thisState = new State(this);
                var oldNextState = currentState.NextState;
                thisState.NextState = oldNextState;
                currentState.NextState = thisState;
                Close(currentState);
                currentState = thisState;
            }
        }

        protected StatementSyntax[] CaptureState(SyntaxNode node, State nextState, State breakState)
        {
            var catchBatch = new State(this, true) { NextState = nextState };
            var oldState = currentState;
            currentState = catchBatch;
            node.Accept(this);
            // If after walking the node, it might leave the current state in an unclosed state.  We want to make sure it's closed.
            if (currentState != breakState && currentState != catchBatch && currentState != nextState && currentState != oldState)
            {
                Close(currentState);
            }
            return catchBatch.Statements.ToArray();
        }
    }
}