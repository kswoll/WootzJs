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

namespace System.Linq.Expressions
{
    public class ConditionalExpression : Expression
    {
        public Expression Test { get; private set; }
        public Expression IfTrue { get; private set; }
        public Expression IfFalse { get; private set; }
        
        private Type type;

        public ConditionalExpression(Expression test, Expression ifTrue, Expression ifFalse) : 
            base(ExpressionType.Conditional)
        {
            Test = test;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
        }

        public ConditionalExpression(Expression test, Expression ifTrue, Expression ifFalse, Type type) : 
            base(ExpressionType.Conditional)
        {
            Test = test;
            IfTrue = ifTrue;
            IfFalse = ifFalse;
            this.type = type;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitConditional(this);
        }

        public override Type Type
        {
            get { return type ?? IfTrue.Type; }
        }

        public Expression Update(Expression test, Expression ifTrue, Expression ifFalse)
        {
            return this;
        }
    }
}
