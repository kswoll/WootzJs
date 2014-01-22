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