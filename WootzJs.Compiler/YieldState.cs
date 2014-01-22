using System;
using System.Collections.Generic;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class YieldState
    {
        public int Index { get; private set; }
        public List<StatementSyntax> Statements { get; set; }
        public YieldState NextState { get; set; }
        public YieldState BreakState { get; set; }
        public bool IsClosed { get; set; }
        public Action<YieldState> Germ { get; set; }
            
        public YieldState(YieldStateGenerator generator, bool isFakeState = false)
        {
            Statements = new List<StatementSyntax>();
            if (!isFakeState)
            {
                Index = generator.states.Count;
                generator.states.Add(this);
            }
            else
            {
                Index = -1;
            }
        }

        public void Add(StatementSyntax statement)
        {
            Statements.Add(statement);
        }

        public override string ToString()
        {
            return Index + ": " + string.Join(" ", Statements);
        }
    }
}