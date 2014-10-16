using System;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class State
    {
        public int Index { get; set; }
        public State Parent { get; set; }
        public State CurrentState { get; set; }
        public IEnumerable<JsStatement> Statements { get; private set; }
        public State Next { get; set; }
        public List<State> Substates { get; set; }
        public Func<JsSwitchStatement, JsStatement> Wrap { get; set; }
            
        public State()
        {
            Statements = new List<JsStatement>();
            Substates = new List<State>();
            Wrap = switchStatement => switchStatement;
        }

        public IEnumerable<State> GetAllSubstates()
        {
            foreach (var state in Substates)
            {
                yield return state;
                foreach (var current in state.GetAllSubstates())
                {
                    yield return current;
                }
            }
        }

        public IEnumerable<int> GetAllIndices()
        {
            yield return Index;
            foreach (var substate in Substates)
            {
                foreach (var index in substate.GetAllIndices())
                {
                    yield return index;
                }
            }
        }

        public void Add(JsStatement statement)
        {
            if (Substates.Any())
                throw new Exception("Cannot add a statement to a state that contains substates");

            InternalAdd(statement);
        }

        internal void InternalAdd(JsStatement statement)
        {
            ((List<JsStatement>)Statements).Add(statement);        
        }

        public override string ToString()
        {
            return Index + ": " + string.Join(" ", Statements);
        }
    }
}