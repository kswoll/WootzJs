using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace WootzJs.Mvc.ExpressionTrees
{
    public class Evaluator : ExpressionVisitor
    {
        private Expression expression;
        private Stack<object> stack = new Stack<object>();

        public Evaluator(Expression expression)
        {
            this.expression = expression;
        }

        public object Evaluate()
        {
            Visit(expression);
            return stack.Peek();
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            base.VisitConstant(node);
            
            stack.Push(node.Value);

            return node;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            base.VisitBinary(node);

            var right = stack.Pop();
            var left = stack.Pop();

            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    stack.Push(GenericMath.Add(left, right));
                    break;
                case ExpressionType.Subtract:
                    stack.Push(GenericMath.Subtract(left, right));
                    break;
                case ExpressionType.Multiply:
                    stack.Push(GenericMath.Multiply(left, right));
                    break;
                case ExpressionType.Divide:
                    stack.Push(GenericMath.Divide(left, right));
                    break;
                case ExpressionType.Modulo:
                    stack.Push(GenericMath.Modulus(left, right));
                    break;
                case ExpressionType.ArrayIndex:
                    var array = (Array)left;
                    var index = (long)Convert.ChangeType(right, typeof(long));
                    var value = array.GetValue(index);
                    stack.Push(value);
                    break;
            }

            return node;
        }

        protected override Expression VisitConditional(ConditionalExpression node)
        {
            base.VisitConditional(node);

            var ifFalse = stack.Pop();
            var ifTrue = stack.Pop();
            var test = (bool)stack.Pop();

            stack.Push(test ? ifTrue : ifFalse);

            return node;
        }

/*
        protected override void VisitIndex(IndexExpression node)
        {
            base.VisitIndex(node);

            var args = node.Arguments.Select(_ => stack.Pop()).Reverse().ToArray();
            var obj = stack.Pop();

            if (node.Indexer != null)
            {
                var value = node.Indexer.GetValue(obj, args);
                stack.Push(value);
            }
            else
            {
                var array = (Array)obj;
                if (args.First() is int)
                    stack.Push(array.GetValue(args.Cast<int>().ToArray()));
                else
                    stack.Push(array.GetValue(args.Cast<long>().ToArray()));
            }

            return result;
        }
*/

        protected override Expression VisitMember(MemberExpression node)
        {
            base.VisitMember(node);

            var obj = stack.Pop();

            var fieldInfo = node.Member as FieldInfo;
            if (fieldInfo != null)
            {
                var field = fieldInfo;
                var value = field.GetValue(obj);
                stack.Push(value);
            }
            else
            {
                var property = (PropertyInfo)node.Member;
                var value = property.GetValue(obj, null);
                stack.Push(value);
            }
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            base.VisitMethodCall(node);

            var args = node.Arguments.Select(_ => stack.Pop()).Reverse().ToArray();
            var obj = stack.Pop();
            var value = node.Method.Invoke(obj, args);
            stack.Push(value);
            return node;
        }

        protected override Expression VisitNew(NewExpression node)
        {
            base.VisitNew(node);

            var args = node.Arguments.Select(_ => stack.Pop()).Reverse().ToArray();
            var obj = node.Constructor.Invoke(args);
            stack.Push(obj);
            return node;
        }

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            base.VisitMemberInit(node);

            var bindings = node.Bindings.Select(_ => stack.Pop()).Reverse().ToArray();
            var obj = stack.Pop();

            for (int i = 0; i < node.Bindings.Count; i++)
            {
                var binding = node.Bindings[i];
                var fieldInfo = binding.Member as FieldInfo;
                if (fieldInfo != null)
                {
                    fieldInfo.SetValue(obj, bindings[i]);
                }
                else
                {
                    var propertyInfo = binding.Member as PropertyInfo;
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(obj, bindings[i], null);
                    }
                }
            }

            stack.Push(obj);
            return node;
        }

        protected override Expression VisitListInit(ListInitExpression node)
        {
            base.VisitListInit(node);

            var args = node.Initializers.Select(init => init.Arguments.Select(_ => stack.Pop()).Reverse().ToArray()).Reverse().ToArray();
            var list = stack.Pop();

            for (int i = 0; i < node.Initializers.Count; i++)
            {
                var binding = node.Initializers[i];
                var argument = args[i];
                binding.AddMethod.Invoke(list, argument);
            }

            stack.Push(list);
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            base.VisitUnary(node);

            var value = stack.Pop();

            switch (node.NodeType)
            {
                case ExpressionType.Not:
                    stack.Push(!(bool)value);
                    break;
                case ExpressionType.Convert:
                    stack.Push(Convert.ChangeType(value, node.Type));
                    break;
                case ExpressionType.TypeAs:
                    stack.Push(node.Type.IsInstanceOfType(value) ? value : null);
                    break;
            }
            return node;
        }

        protected override Expression VisitInvocation(InvocationExpression node)
        {
            base.VisitInvocation(node);

            var args = node.Arguments.Select(_ => stack.Pop()).Reverse().ToArray();
            var lambda = (Delegate)stack.Pop();
            var value = lambda.DynamicInvoke(args);
            stack.Push(value);
            return node;
        }

        protected override Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            base.VisitTypeBinary(node);

            var expression = stack.Pop();
            var value = node.TypeOperand.IsInstanceOfType(expression);
            stack.Push(value);
            return node;
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            base.VisitNewArray(node);

            var args = node.Expressions.Select(_ => stack.Pop()).Reverse().ToArray();
            var array = Array.CreateInstance(node.Type.GetElementType(), node.Expressions.Count);
            for (var i = 0; i < array.Length; i++)
            {
                array.SetValue(args[i], i);
            }
            stack.Push(array);
            return node;
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            stack.Push(node.Compile());

            return node;
        }

/*

        protected override MemberBinding VisitMemberBinding(MemberBinding node)
        {
            var result = base.VisitMemberBinding(node);

            var memberAssignment = node as MemberAssignment;
            if (memberAssignment != null)
            {
                memberAssignment.Expression
            }

            return result;
        }
*/
    }
}