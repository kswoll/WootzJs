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

using System.Collections.Generic;

namespace System.Linq.Expressions
{
    public abstract class LambdaExpression : Expression
    {
        private string name;
        private Expression body;
        private List<ParameterExpression> parameters;
        private Type delegateType;
        private bool tailCall;

        internal LambdaExpression(Type delegateType, string name, Expression body, bool tailCall, ParameterExpression[] parameters) : base(ExpressionType.Lambda)
        {
            this.name = name;
            this.body = body;
            this.parameters = parameters.ToList();
            this.delegateType = delegateType;
            this.tailCall = tailCall;
        }

        public override Type Type
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { return name; }
        }

        public Expression Body
        {
            get { return body; }
        }

        public List<ParameterExpression> Parameters
        {
            get { return parameters; }
        }

        public Type DelegateType
        {
            get { return delegateType; }
        }

        public bool TailCall
        {
            get { return tailCall; }
        }

        public LambdaExpression Update(Expression body, List<ParameterExpression> parameters)
        {
            return this;
        }

        /// <summary>
        /// Produces a delegate that represents the lambda expression.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Delegate"/> that contains the compiled version of the lambda expression.
        /// </returns>
        public Delegate Compile()
        {
            throw new NotImplementedException(); // Will be implemented by passing the unexpression-tree'd function into the constructor
        }
    }
}