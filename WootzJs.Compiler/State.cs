#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class State
    {
        public int Index { get; private set; }
        public List<StatementSyntax> Statements { get; set; }
        public State NextState { get; set; }
        public State BreakState { get; set; }
        public bool IsClosed { get; set; }
        public Action<State> Germ { get; set; }
            
        public State(StateGenerator generator, bool isFakeState = false)
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
