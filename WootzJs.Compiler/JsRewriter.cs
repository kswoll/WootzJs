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

using System;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class JsRewriter : IJsVisitor<JsNode>
    {
        protected virtual JsNode DefaultVisit<T>(T node, Func<T, JsNode> action) where T : JsNode
        {
            return action(node);
        }

        public virtual JsNode Visit(JsCompilationUnit node)
        {
            return DefaultVisit(node, x =>
            {
                node.Body = (JsBlockStatement)x.Body.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsBlockStatement node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Statements.Count; i++)
                {
                    x.Statements[i] = (JsStatement)x.Statements[i].Accept(this);
                }
                return x;
            });
        }

        public virtual JsNode Visit(JsExpressionStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        private JsNode VisitDeclaration(IJsDeclaration declaration)
        {
            if (declaration is JsParameter)
                return ((JsParameter)declaration).Accept(this);
            else if (declaration is JsVariableDeclarator)
                return ((JsVariableDeclarator)declaration).Accept(this);            
            else
                throw new Exception();
        }

        public virtual JsNode Visit(JsFunction node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Parameters.Count; i++)
                {
                    x.Parameters[i] = (IJsDeclaration)VisitDeclaration(x.Parameters[i]);
                }
                x.Body = (JsBlockStatement)x.Body.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsMemberReferenceExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Target = (JsExpression)x.Target.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsObjectExpression node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Items.Count; i++)
                {
                    x.Items[i] = (JsObjectItem)x.Items[i].Accept(this);
                }
                return x;
            });
        }

        public virtual JsNode Visit(JsParentheticalExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsReturnStatement node)
        {
            return DefaultVisit(node, x =>
            {
                if (x.Expression != null)
                    x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsVariableDeclarator node)
        {
            return DefaultVisit(node, x =>
            {
                if (x.Initializer != null)
                    x.Initializer = (JsExpression)x.Initializer.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsVariableDeclaration node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Declarations.Count; i++)
                {
                    x.Declarations[i] = (JsVariableDeclarator)x.Declarations[i].Accept(this);
                }
                return x;
            });
        }

        public virtual JsNode Visit(JsVariableReferenceExpression node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsObjectItem node)
        {
            return DefaultVisit(node, x =>
            {
                x.Value = (JsExpression)x.Value.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsInvocationExpression node)
        {
            return DefaultVisit(node, x =>
            {
                node.Target = (JsExpression)node.Target.Accept(this);
                for (var i = 0; i < node.Arguments.Count; i++)
                {
                    node.Arguments[i] = (JsExpression)node.Arguments[i].Accept(this);
                }
                return x;
            });
        }

        public virtual JsNode Visit(JsParameter node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsFunctionDeclaration node)
        {
            return DefaultVisit(node, x =>
            {
                x.Function = (JsFunction)x.Function.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsPrimitiveExpression node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsThisExpression node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsNewExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsIfStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Condition = (JsExpression)x.Condition.Accept(this);
                x.IfTrue = (JsStatement)x.IfTrue.Accept(this);
                if (x.IfFalse != null)
                    x.IfFalse = (JsStatement)x.IfFalse.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsBinaryExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Left = (JsExpression)x.Left.Accept(this);
                x.Right = (JsExpression)x.Right.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsUnaryExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Operand = (JsExpression)x.Operand.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsNativeStatement node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsNewArrayExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Size = (JsExpression)x.Size.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsForStatement node)
        {
            return DefaultVisit(node, x =>
            {
                if (x.Declaration != null)
                    x.Declaration = (JsVariableDeclaration)x.Declaration.Accept(this);
                if (x.Condition != null)
                    x.Condition = (JsExpression)x.Condition.Accept(this);
                for (var i = 0; i < x.Incrementors.Count; i++)
                {
                    x.Incrementors[i] = (JsExpression)x.Incrementors[i].Accept(this);
                }
                x.Body = (JsStatement)x.Body.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsIndexExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Target = (JsExpression)x.Target.Accept(this);
                x.Index = (JsExpression)x.Index.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsLocalVariableDeclaration node)
        {
            return DefaultVisit(node, x =>
            {
                x.Declaration = (JsVariableDeclaration)x.Declaration.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsRegexExpression node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsArrayExpression node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Elements.Count; i++)
                {
                    x.Elements[i] = (JsExpression)x.Elements[i].Accept(this);
                }
                return x;
            });
        }

        public virtual JsNode Visit(JsThrowStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsSwitchSection node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Labels.Count; i++)
                {
                    x.Labels[i] = (JsSwitchLabel)x.Labels[i].Accept(this);
                }
                for (var i = 0; i < x.Statements.Count; i++)
                {
                    x.Statements[i] = (JsStatement)x.Statements[i].Accept(this);
                }
                return x;
            });
        }

        public virtual JsNode Visit(JsSwitchStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                for (var i = 0; i < x.Sections.Count; i++)
                {
                    x.Sections[i] = (JsSwitchSection)x.Sections[i].Accept(this);
                }
                return x;
            });
        }

        public virtual JsNode Visit(JsSwitchLabel node)
        {
            return DefaultVisit(node, x =>
            {
                if (x.Value != null)
                    x.Value = (JsExpression)x.Value.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsWhileStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Condition = (JsExpression)x.Condition.Accept(this);
                x.Body = (JsStatement)x.Body.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsBreakStatement node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsEmptyStatement node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsCatchClause node)
        {
            return DefaultVisit(node, x =>
            {
                x.Declaration = (JsVariableDeclarator)x.Declaration.Accept(this);
                x.Body = (JsBlockStatement)x.Body.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsTryStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Body = (JsBlockStatement)x.Body.Accept(this);
                if (x.Catch != null)
                    x.Catch = (JsCatchClause)x.Catch.Accept(this);
                if (x.Finally != null)
                    x.Finally = (JsBlockStatement)x.Finally.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsConditionalExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Condition = (JsExpression)x.Condition.Accept(this);
                x.IfTrue = (JsExpression)x.IfTrue.Accept(this);
                x.IfFalse = (JsExpression)x.IfFalse.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsDeleteExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Target = (JsExpression)x.Target.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsForInStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Declaration = (JsVariableDeclaration)x.Declaration.Accept(this);
                x.Target = (JsExpression)x.Target.Accept(this);
                x.Body = (JsStatement)x.Body.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsTypeOfExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Target = (JsExpression)x.Target.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsContinueStatement node)
        {
            return DefaultVisit(node, x => x);
        }

        public virtual JsNode Visit(JsDeclarationReferenceExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Declaration = (IJsDeclaration)VisitDeclaration(x.Declaration);
                return x;
            });
        }

        public virtual JsNode Visit(JsLabeledStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Statement = (JsStatement)x.Statement.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsDoWhileStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Condition = (JsExpression)x.Condition.Accept(this);
                x.Body = (JsStatement)x.Body.Accept(this);
                return x;
            });
        }

        public virtual JsNode Visit(JsInstanceOfExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                x.Type = (JsExpression)x.Type.Accept(this);
                return x;
            });
        }
    }
}