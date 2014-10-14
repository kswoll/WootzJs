using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class BaseAsyncStateGenerator : CSharpSyntaxWalker
    {
        public const string stateMachine = "$stateMachine";
        public const string state = "$state";
        public const string moveNext = "$moveNext";
        public const string @this = "$this";

        private readonly JsTransformer transformer;

        private int currentStateIndex;
        private Dictionary<LiftedVariableKey, string> hoistedVariables = new Dictionary<LiftedVariableKey, string>();
        private JsBlockStatement stateMachineBody;
        private CSharpSyntaxNode node;
        internal AsyncState topState = new AsyncState();
        
        public BaseAsyncStateGenerator(Func<BaseAsyncStateGenerator, JsTransformer> transformer, CSharpSyntaxNode node, JsBlockStatement stateMachineBody)
        {
            this.transformer = transformer(this);
            this.node = node;
            this.stateMachineBody = stateMachineBody;
        }

        public JsTransformer Transformer
        {
            get { return transformer; }
        }

        private string GenerateNewNamePrivate(LiftedVariableKey symbol)
        {
            var counter = 2;
            do
            {
                var currentName = symbol.Identifier + counter++;
                if (!hoistedVariables.ContainsKey(new LiftedVariableKey(SyntaxFactory.Identifier(currentName))))
                {
                    return currentName;
                }
            }
            while (true);
        }

        public JsVariableDeclarator HoistVariable(LiftedVariableKey symbol)
        {
            var identifier = symbol.Identifier;
            if (hoistedVariables.ContainsKey(symbol) || hoistedVariables.ContainsKey(new LiftedVariableKey(symbol.Identifier)))
            {
                identifier = GenerateNewNamePrivate(symbol);
                symbol = new LiftedVariableKey(identifier, symbol.Symbol);
            }
            
            // Register the variable so we avoid collisions.
            hoistedVariables[symbol] = identifier;
            if (symbol.Symbol == null)
                hoistedVariables[new LiftedVariableKey(symbol.Identifier)] = identifier;

            // Declare a local variable (of the top-level function so available as closures to the state
            // machine) to store the symbol.
            var declaration = stateMachineBody.Local(identifier, Js.Null());

            // If we have a true symbol associated with the key, then declare it in the base transformer
            if (symbol.Symbol != null)
                transformer.DeclareInCurrentScope(symbol.Symbol, declaration);

            return declaration;
        }

        protected string UniqueName(string identifier)
        {
            var key = new LiftedVariableKey(identifier);
            if (hoistedVariables.ContainsKey(key))
            {
                identifier = GenerateNewNamePrivate(key);
                hoistedVariables[key] = identifier;
            }
            return identifier;            
        }

        public void GenerateStates()
        {
            topState.CurrentState = NewState();
            node.Accept(this);
            OnBaseStateGenerated();
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

        public AsyncState InsertState()
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

        public JsStatement GotoTop()
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

        public struct LiftedVariableKey
        {
            private readonly string identifier;
            private readonly ISymbol symbol;

            public LiftedVariableKey(SyntaxToken identifier, ISymbol symbol)
            {
                this.identifier = identifier.ToString();
                this.symbol = symbol;
            }

            public LiftedVariableKey(string identifier, ISymbol symbol)
            {
                this.identifier = identifier;
                this.symbol = symbol;
            }

            public LiftedVariableKey(SyntaxToken identifier) : this()
            {
                this.identifier = identifier.ToString();
            }

            public LiftedVariableKey(string identifier) : this()
            {
                this.identifier = identifier;
            }

            public string Identifier
            {
                get { return identifier; }
            }

            public ISymbol Symbol
            {
                get { return symbol; }
            }

            public bool Equals(LiftedVariableKey other)
            {
                return string.Equals(identifier, other.identifier) && (Equals(symbol, other.symbol) || symbol == null || other.symbol == null);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is LiftedVariableKey && Equals((LiftedVariableKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return identifier.GetHashCode();
                }
            }
        }
     }
}