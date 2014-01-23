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

using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class Scope
    {
        private Symbol symbol;
        private List<IJsDeclaration> declarations = new List<IJsDeclaration>();
        private Dictionary<string, IJsDeclaration> declarationsByName = new Dictionary<string, IJsDeclaration>();
        private int currentAnonymousNameIndex = 1;

        public Scope(Symbol symbol)
        {
            this.symbol = symbol;
        }

        public void AddDeclarations(params IJsDeclaration[] declarations)
        {
            foreach (var declaration in declarations)
            {
                if (declarationsByName.ContainsKey(declaration.Name))
                    throw new InvalidOperationException("Declaration already declared in this scope: " + declaration);
                declarationsByName[UnwrapName(declaration)] = declaration;
            }
            this.declarations.AddRange(declarations);
        }

        private string UnwrapName(IJsDeclaration declaration)
        {
            var current = declaration;
            while (current is Idioms.WrappedParent)
            {
                current = ((Idioms.WrappedParent)current).Parent;
            }
            return current.Name;
        }

        public IJsDeclaration this[string name]
        {
            get
            {
                IJsDeclaration result;
                declarationsByName.TryGetValue(name, out result);
                return result;
            }
        }

        public IReadOnlyCollection<IJsDeclaration> Declarations
        {
            get { return declarations; }
        }
    }
}
