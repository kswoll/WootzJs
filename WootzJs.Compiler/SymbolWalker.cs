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

using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class SymbolWalker : SymbolVisitor
    {
        public override void VisitAlias(AliasSymbol symbol)
        {
            base.VisitAlias(symbol);
        }

        public override void VisitArrayType(ArrayTypeSymbol symbol)
        {
            base.VisitArrayType(symbol);
        }

        public override void VisitAssembly(AssemblySymbol symbol)
        {
            base.VisitAssembly(symbol);
            symbol.GlobalNamespace.Accept(this);
        }

        public override void VisitDynamicType(DynamicTypeSymbol symbol)
        {
            base.VisitDynamicType(symbol);
        }

        public override void VisitEvent(EventSymbol symbol)
        {
            base.VisitEvent(symbol);
        }

        public override void VisitField(FieldSymbol symbol)
        {
            base.VisitField(symbol);
        }

        public override void VisitLabel(LabelSymbol symbol)
        {
            base.VisitLabel(symbol);
        }

        public override void VisitLocal(LocalSymbol symbol)
        {
            base.VisitLocal(symbol);
        }

        public override void VisitMethod(MethodSymbol symbol)
        {
            base.VisitMethod(symbol);
        }

        public override void VisitModule(ModuleSymbol symbol)
        {
            base.VisitModule(symbol);
        }

        public override void VisitNamedType(NamedTypeSymbol symbol)
        {
            base.VisitNamedType(symbol);
            foreach (var item in symbol.GetMembers())
            {
                item.Accept(this);
            }
            foreach (var item in symbol.GetTypeMembers())
            {
                item.Accept(this);
            }
        }

        public override void VisitNamespace(NamespaceSymbol symbol)
        {
            base.VisitNamespace(symbol);
            foreach (var item in symbol.GetTypeMembers())
            {
                item.Accept(this);
            }
            foreach (var item in symbol.GetNamespaceMembers())
            {
                item.Accept(this);
            }
        }

        public override void VisitParameter(ParameterSymbol symbol)
        {
            base.VisitParameter(symbol);
        }

        public override void VisitPointerType(PointerTypeSymbol symbol)
        {
            base.VisitPointerType(symbol);
        }

        public override void VisitProperty(PropertySymbol symbol)
        {
            base.VisitProperty(symbol);
        }

        public override void VisitRangeVariable(RangeVariableSymbol symbol)
        {
            base.VisitRangeVariable(symbol);
        }

        public override void VisitTypeParameter(TypeParameterSymbol symbol)
        {
            base.VisitTypeParameter(symbol);
        }
    }
}
