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

using Microsoft.CodeAnalysis;

namespace WootzJs.Compiler
{
    public class SymbolWalker : SymbolVisitor
    {
        public override void VisitAlias(IAliasSymbol symbol)
        {
            base.VisitAlias(symbol);
        }

        public override void VisitArrayType(IArrayTypeSymbol symbol)
        {
            base.VisitArrayType(symbol);
        }

        public override void VisitAssembly(IAssemblySymbol symbol)
        {
            base.VisitAssembly(symbol);
            symbol.GlobalNamespace.Accept(this);
        }

        public override void VisitDynamicType(IDynamicTypeSymbol symbol)
        {
            base.VisitDynamicType(symbol);
        }

        public override void VisitEvent(IEventSymbol symbol)
        {
            base.VisitEvent(symbol);
        }

        public override void VisitField(IFieldSymbol symbol)
        {
            base.VisitField(symbol);
        }

        public override void VisitLabel(ILabelSymbol symbol)
        {
            base.VisitLabel(symbol);
        }

        public override void VisitLocal(ILocalSymbol symbol)
        {
            base.VisitLocal(symbol);
        }

        public override void VisitMethod(IMethodSymbol symbol)
        {
            base.VisitMethod(symbol);
        }

        public override void VisitModule(IModuleSymbol symbol)
        {
            base.VisitModule(symbol);
        }

        public override void VisitNamedType(INamedTypeSymbol symbol)
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

        public override void VisitNamespace(INamespaceSymbol symbol)
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

        public override void VisitParameter(IParameterSymbol symbol)
        {
            base.VisitParameter(symbol);
        }

        public override void VisitPointerType(IPointerTypeSymbol symbol)
        {
            base.VisitPointerType(symbol);
        }

        public override void VisitProperty(IPropertySymbol symbol)
        {
            base.VisitProperty(symbol);
        }

        public override void VisitRangeVariable(IRangeVariableSymbol symbol)
        {
            base.VisitRangeVariable(symbol);
        }

        public override void VisitTypeParameter(ITypeParameterSymbol symbol)
        {
            base.VisitTypeParameter(symbol);
        }
    }
}
