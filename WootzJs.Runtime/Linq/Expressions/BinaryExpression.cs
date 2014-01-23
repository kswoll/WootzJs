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

using System.Reflection;
using System.Runtime.WootzJs;

namespace System.Linq.Expressions
{
    public class BinaryExpression : Expression
    {
        public Expression Left { get; private set; }
        public Expression Right { get; private set; }
        public MethodInfo Method { get; private set; }
        public LambdaExpression Conversion { get; private set; }
        public bool IsLifted { get; private set; }

        public BinaryExpression(Expression left, Expression right, ExpressionType nodeType)
            : base(nodeType)
        {
            Left = left;
            Right = right;
        }

        public BinaryExpression(Expression left, Expression right, ExpressionType nodeType, 
            bool liftToNull, MethodInfo method) : base(nodeType)
        {
            Left = left;
            Right = right;
            Method = method;
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitBinary(this);
        }

        public override Type Type
        {
            get
            {
                switch (NodeType)
                {
                    case ExpressionType.Add:
                    case ExpressionType.AddAssign:
                    case ExpressionType.AddAssignChecked:
                    case ExpressionType.AddChecked:
                    case ExpressionType.And:
                    case ExpressionType.AndAlso:
                    case ExpressionType.AndAssign:
                    case ExpressionType.Assign:
                    case ExpressionType.Divide:
                    case ExpressionType.DivideAssign:
                    case ExpressionType.ExclusiveOr:
                    case ExpressionType.ExclusiveOrAssign:
                    case ExpressionType.LeftShift:
                    case ExpressionType.LeftShiftAssign:
                    case ExpressionType.Modulo:
                    case ExpressionType.ModuloAssign:
                    case ExpressionType.Multiply:
                    case ExpressionType.MultiplyAssign:
                    case ExpressionType.MultiplyAssignChecked:
                    case ExpressionType.MultiplyChecked:
                    case ExpressionType.Or:
                    case ExpressionType.OrAssign:
                    case ExpressionType.OrElse:
                    case ExpressionType.RightShift:
                    case ExpressionType.RightShiftAssign:
                    case ExpressionType.Subtract:
                    case ExpressionType.SubtractAssign:
                    case ExpressionType.SubtractAssignChecked:
                    case ExpressionType.SubtractChecked:
                        return Left.Type;
                    case ExpressionType.Equal:
                    case ExpressionType.GreaterThan:
                    case ExpressionType.GreaterThanOrEqual:
                    case ExpressionType.LessThan:
                    case ExpressionType.LessThanOrEqual:
                    case ExpressionType.NotEqual:
                    case ExpressionType.TypeIs:
                        return typeof(bool).As<Type>();
                    case ExpressionType.ArrayIndex:
                        return typeof(object).As<Type>();
                    default:
                        throw new Exception("Unexpected node type: " + NodeType);
                }
            }
        }

        public BinaryExpression Update(Expression left, LambdaExpression conversion,
            Expression right)
        {
            return this;
/*
            if (left == this.Left && right == this.Right && conversion == this.Conversion)
                return this;
            if (!this.IsReferenceComparison)
                return Expression.MakeBinary(this.NodeType, left, right, this.IsLiftedToNull, this.Method, 
                    conversion);
            if (this.NodeType == ExpressionType.Equal)
                return Expression.ReferenceEqual(left, right);
            else
                return Expression.ReferenceNotEqual(left, right);
*/
        }

        internal bool IsReferenceComparison
        {
            get
            {
                Type type1 = Left.Type;
                Type type2 = Right.Type;
                MethodInfo method = Method;
                switch (this.NodeType)
                {
                    case ExpressionType.Equal:
                    case ExpressionType.NotEqual:
                        if (method == null && !type1.IsValueType)
                            return !type2.IsValueType;
                        else
                            break;
                }
                return false;
            }
        }

        public bool IsLiftedToNull
        {
            get
            {
                if (this.IsLifted)
                    return this.Type == typeof(Nullable<>).As<Type>();
                else
                    return false;
            }
        }
    }
}
