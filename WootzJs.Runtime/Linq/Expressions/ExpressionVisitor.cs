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
    public class ExpressionVisitor
    {
        protected ExpressionVisitor()
        {
        }

        public virtual Expression Visit(Expression node)
        {
            if (node != null)
            {
                return node.Accept(this);
            }
            return null;
        }

        public List<Expression> Visit(List<Expression> nodes)
        {
            Expression[] newNodes = null;
            for (int i = 0, n = nodes.Count; i < n; i++)
            {
                Expression node = Visit(nodes[i]);

                if (newNodes != null)
                {
                    newNodes[i] = node;
                }
                else if (!ReferenceEquals(node, nodes[i]))
                {
                    newNodes = new Expression[n];
                    for (int j = 0; j < i; j++)
                    {
                        newNodes[j] = nodes[j];
                    }
                    newNodes[i] = node;
                }
            }
            if (newNodes == null)
            {
                return nodes;
            }
            return new List<Expression>(newNodes);
        }

        internal Expression[] VisitArguments(IArgumentProvider nodes)
        {
            Expression[] newNodes = null;
            for (int i = 0, n = nodes.Arguments.Count; i < n; i++)
            {
                Expression curNode = nodes.Arguments[i];
                Expression node = Visit(curNode);

                if (newNodes != null)
                {
                    newNodes[i] = node;
                }
                else if (!ReferenceEquals(node, curNode))
                {
                    newNodes = new Expression[n];
                    for (int j = 0; j < i; j++)
                    {
                        newNodes[j] = nodes.Arguments[j];
                    }
                    newNodes[i] = node;
                }
            }
            return newNodes;
        }

        public static List<T> Visit<T>(List<T> nodes, Func<T, T> elementVisitor)
        {
            T[] newNodes = null;
            for (int i = 0, n = nodes.Count; i < n; i++)
            {
                T node = elementVisitor(nodes[i]);
                if (newNodes != null)
                {
                    newNodes[i] = node;
                }
                else if (!ReferenceEquals(node, nodes[i]))
                {
                    newNodes = new T[n];
                    for (int j = 0; j < i; j++)
                    {
                        newNodes[j] = nodes[j];
                    }
                    newNodes[i] = node;
                }
            }
            if (newNodes == null)
            {
                return nodes;
            }
            return new List<T>(newNodes);
        }

        public T VisitAndConvert<T>(T node, string callerName) where T : Expression
        {
            if (node == null)
            {
                return null;
            }
            node = Visit(node) as T;
            if (node == null)
            {
                throw new Exception("MustRewriteToSameNode");
            }
            return node;
        }

        public List<T> VisitAndConvert<T>(List<T> nodes, string callerName) where T : Expression
        {
            T[] newNodes = null;
            for (int i = 0, n = nodes.Count; i < n; i++)
            {
                var node = Visit(nodes[i]) as T;
                if (node == null)
                {
                    throw new Exception("MustRewriteToSameNode");
                }

                if (newNodes != null)
                {
                    newNodes[i] = node;
                }
                else if (!ReferenceEquals(node, nodes[i]))
                {
                    newNodes = new T[n];
                    for (int j = 0; j < i; j++)
                    {
                        newNodes[j] = nodes[j];
                    }
                    newNodes[i] = node;
                }
            }
            if (newNodes == null)
            {
                return nodes;
            }
            return new List<T>(newNodes);
        }

        protected internal virtual Expression VisitBinary(BinaryExpression node)
        {
            // Walk children in evaluation order: left, conversion, right
            return ValidateBinary(
                node,
                node.Update(
                    Visit(node.Left),
                    VisitAndConvert(node.Conversion, "VisitBinary"),
                    Visit(node.Right)
                    )
                );
        }

        protected internal virtual Expression VisitConditional(ConditionalExpression node)
        {
            return node.Update(Visit(node.Test), Visit(node.IfTrue), Visit(node.IfFalse));
        }

        protected internal virtual Expression VisitConstant(ConstantExpression node)
        {
            return node;
        }

        protected internal virtual Expression VisitDefault(DefaultExpression node)
        {
            return node;
        }

        protected internal virtual Expression VisitInvocation(InvocationExpression node)
        {
            Expression e = Visit(node.Expression);
            Expression[] a = VisitArguments(node);
            if (e == node.Expression && a == null)
            {
                return node;
            }

            return node.Rewrite(e, a);
        }

        protected internal virtual Expression VisitLambda<T>(Expression<T> node)
        {
            return node.Update(Visit(node.Body), VisitAndConvert(node.Parameters, "VisitLambda"));
        }

        protected internal virtual Expression VisitMember(MemberExpression node)
        {
            return node.Update(Visit(node.Expression));
        }

        protected internal virtual Expression VisitIndex(IndexExpression node)
        {
            Expression o = Visit(node.Object);
            Expression[] a = VisitArguments(node);
            if (o == node.Object && a == null)
            {
                return node;
            }

            return node;//node.Rewrite(o, a);
        }

        protected internal virtual Expression VisitMethodCall(MethodCallExpression node)
        {
            Expression o = Visit(node.Object);
            Expression[] a = VisitArguments(node);
            if (o == node.Object && a == null)
            {
                return node;
            }

            return node;//node.Rewrite(o, a);
        }

        protected internal virtual Expression VisitNewArray(NewArrayExpression node)
        {
            return node.Update(Visit(node.Expressions));
        }

        protected internal virtual Expression VisitNew(NewExpression node)
        {
            return node.Update(Visit(node.Arguments));
        }

        protected internal virtual Expression VisitParameter(ParameterExpression node)
        {
            return node;
        }

        protected internal virtual Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            return node.Update(Visit(node.Expression));
        }

        protected internal virtual Expression VisitUnary(UnaryExpression node)
        {
            return ValidateUnary(node, node.Update(Visit(node.Operand)));
        }

        protected internal virtual Expression VisitMemberInit(MemberInitExpression node)
        {
            return node.Update
            (
                VisitAndConvert(node.NewExpression, "VisitMemberInit"),
                Visit(node.Bindings, VisitMemberBinding)
            );
        }

        protected internal virtual Expression VisitListInit(ListInitExpression node)
        {
            return node.Update
            (
                VisitAndConvert(node.NewExpression, "VisitListInit"),
                Visit(node.Initializers, VisitElementInit)
            );
        }

        protected virtual ElementInit VisitElementInit(ElementInit node)
        {
            return node.Update(Visit(node.Arguments));
        }

        protected virtual MemberBinding VisitMemberBinding(MemberBinding node)
        {
            switch (node.BindingType)
            {
                case MemberBindingType.Assignment:
                    return VisitMemberAssignment((MemberAssignment)node);
                case MemberBindingType.MemberBinding:
                    return VisitMemberMemberBinding((MemberMemberBinding)node);
                case MemberBindingType.ListBinding:
                    return VisitMemberListBinding((MemberListBinding)node);
                default:
                    throw new Exception("UnhandledBindingType");
            }
        }

        protected virtual MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            return node.Update(Visit(node.Expression));
        }

        protected virtual MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
        {
            return node.Update(Visit(node.Bindings, VisitMemberBinding));
        }

        protected virtual MemberListBinding VisitMemberListBinding(MemberListBinding node)
        {
            return node.Update(Visit(node.Initializers, VisitElementInit));
        }

        private static UnaryExpression ValidateUnary(UnaryExpression before, UnaryExpression after)
        {
            if (before != after && before.Method == null)
            {
                if (after.Method != null)
                {
                    throw new Exception("MustRewriteWithoutMethod");
                }

                // rethrow has null operand
                if (before.Operand != null && after.Operand != null)
                {
                    ValidateChildType(before.Operand.Type, after.Operand.Type, "VisitUnary");
                }
            }
            return after;
        }

        private static BinaryExpression ValidateBinary(BinaryExpression before, BinaryExpression after)
        {
            if (before != after && before.Method == null)
            {
                if (after.Method != null)
                {
                    throw new Exception("MustRewriteWithoutMethod");
                }

                ValidateChildType(before.Left.Type, after.Left.Type, "VisitBinary");
                ValidateChildType(before.Right.Type, after.Right.Type, "VisitBinary");
            }
            return after;
        }

        private static void ValidateChildType(Type before, Type after, string methodName)
        {
            if (before.IsValueType)
            {
                if (before == after)
                {
                    // types are the same value type
                    return;
                }
            }
            else if (!after.IsValueType)
            {
                // both are reference types
                return;
            }

            // Otherwise, it's an invalid type change.
            throw new Exception("MustRewriteChildToSameType");
        }
/*
        private static SwitchExpression ValidateSwitch(SwitchExpression before, SwitchExpression after)
        {
            // If we did not have a method, we don't want to bind to one,
            // it might not be the right thing.
            if (before.Comparison == null && after.Comparison != null)
            {
                throw Error.MustRewriteWithoutMethod(after.Comparison, "VisitSwitch");
            }
            return after;
        }

        protected internal virtual Expression VisitBlock(BlockExpression node)
        {
            int count = node.ExpressionCount;
            Expression[] nodes = null;
            for (int i = 0; i < count; i++)
            {
                Expression oldNode = node.GetExpression(i);
                Expression newNode = Visit(oldNode);

                if (oldNode != newNode)
                {
                    if (nodes == null)
                    {
                        nodes = new Expression[count];
                    }
                    nodes[i] = newNode;
                }
            }
            var v = VisitAndConvert(node.Variables, "VisitBlock");

            if (v == node.Variables && nodes == null)
            {
                return node;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (nodes[i] == null)
                    {
                        nodes[i] = node.GetExpression(i);
                    }
                }
            }

            return node.Rewrite(v, nodes);
        }

        protected internal virtual Expression VisitDynamic(DynamicExpression node)
        {
            Expression[] a = VisitArguments((IArgumentProvider)node);
            if (a == null)
            {
                return node;
            }

            return node.Rewrite(a);
        }
 
        protected internal virtual Expression VisitDebugInfo(DebugInfoExpression node)
        {
            return node;
        }
 * 
        protected internal virtual Expression VisitExtension(Expression node)
        {
            return node.VisitChildren(this);
        }

        protected internal virtual Expression VisitGoto(GotoExpression node)
        {
            return node.Update(VisitLabelTarget(node.Target), Visit(node.Value));
        }

        protected virtual LabelTarget VisitLabelTarget(LabelTarget node)
        {
            return node;
        }

        protected internal virtual Expression VisitLabel(LabelExpression node)
        {
            return node.Update(VisitLabelTarget(node.Target), Visit(node.DefaultValue));
        }

        protected internal virtual Expression VisitLoop(LoopExpression node)
        {
            return node.Update(VisitLabelTarget(node.BreakLabel), VisitLabelTarget(node.ContinueLabel), Visit(node.Body));
        }

        protected internal virtual Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
        {
            return node.Update(VisitAndConvert(node.Variables, "VisitRuntimeVariables"));
        }

        protected virtual SwitchCase VisitSwitchCase(SwitchCase node)
        {
            return node.Update(Visit(node.TestValues), Visit(node.Body));
        }

        protected internal virtual Expression VisitSwitch(SwitchExpression node)
        {
            return ValidateSwitch(
                node,
                node.Update(
                    Visit(node.SwitchValue),
                    Visit(node.Cases, VisitSwitchCase),
                    Visit(node.DefaultBody)
                    )
                );
        }

        protected virtual CatchBlock VisitCatchBlock(CatchBlock node)
        {
            return node.Update(VisitAndConvert(node.Variable, "VisitCatchBlock"), Visit(node.Filter), Visit(node.Body));
        }

        protected internal virtual Expression VisitTry(TryExpression node)
        {
            return node.Update(
                Visit(node.Body),
                Visit(node.Handlers, VisitCatchBlock),
                Visit(node.Finally),
                Visit(node.Fault)
                );
        }



*/
    }
}
