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

using System.Collections.Generic;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class NamespaceTransformer : SyntaxWalker
    {
        private Context context;
        private JsBlockStatement body;
        private HashSet<string> processedNamespaces = new HashSet<string>();

        public NamespaceTransformer(Context context, JsBlockStatement body) 
        {
            this.context = context;
            this.body = body;
        }

        private void ProcessNamespace(string ns)
        {
            if (processedNamespaces.Contains(ns))
                return;
            processedNamespaces.Add(ns);

            var lastDotIndex = ns.LastIndexOf('.');
            var parentNamespace = lastDotIndex != -1 ? ns.Substring(0, lastDotIndex) : null;
            if (parentNamespace != null)
                ProcessNamespace(parentNamespace);

            if (lastDotIndex == -1)
                body.Assign(Js.Reference("window").Member(ns), Js.Object());
            else
                body.Assign(Js.Reference(ns), Js.Object());
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            var semanticModel = context.Compilation.GetSemanticModel(node.SyntaxTree);
            var symbol = semanticModel.GetDeclaredSymbol(node);
            var fullName = context.SymbolNames[symbol, symbol.GetFullName()];
            ProcessNamespace(fullName);
        }
    }
}
