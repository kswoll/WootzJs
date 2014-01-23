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

using System.Runtime.WootzJs;

namespace System.Linq.Expressions
{
    public class TypeBinaryExpression : Expression
    {
        public Expression Expression { get; private set; }

        private Type typeOperand;

        public TypeBinaryExpression(Expression expression, Type typeOperand, ExpressionType nodeKind) : base(nodeKind)
        {
            Expression = expression;

            this.typeOperand = typeOperand;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitTypeBinary(this);
        }

        public Type TypeOperand
        {
            get { return typeOperand; }
        }

        public override Type Type
        {
            get
            {
                switch (NodeType)
                {
                    case ExpressionType.TypeAs:
                        return TypeOperand;
                    case ExpressionType.TypeIs:
                        return typeof(bool).As<Type>();
                    default:
                        throw new Exception("Unexpected NodeType: " + NodeType);
                }
            }
        }

        public Expression Update(Expression expression)
        {
            return this;
        }
    }
}
