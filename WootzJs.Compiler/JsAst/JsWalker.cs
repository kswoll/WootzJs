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

namespace WootzJs.Compiler.JsAst
{
    public class JsWalker : IJsVisitor
    {
        public virtual void DefaultVisit(JsNode node)
        {
        }

        public virtual void Visit(JsCompilationUnit node)
        {
            DefaultVisit(node);
            node.Body.Accept(this);
        }

        public virtual void Visit(JsBlockStatement node)
        {
            DefaultVisit(node);
            foreach (var statement in node.Statements)
            {
                statement.Accept(this);
            }
        }

        public virtual void Visit(JsExpressionStatement node)
        {
            DefaultVisit(node);
            node.Expression.Accept(this);
        }

        private void VisitDeclaration(IJsDeclaration declaration)
        {
            if (declaration is JsParameter)
                ((JsParameter)declaration).Accept(this);
            else if (declaration is JsVariableDeclarator)
                ((JsVariableDeclarator)declaration).Accept(this);            
        }

        public virtual void Visit(JsFunction node)
        {
            DefaultVisit(node);
            foreach (var parameter in node.Parameters)
            {
                VisitDeclaration(parameter);
            }
            node.Body.Accept(this);
        }

        public virtual void Visit(JsMemberReferenceExpression node)
        {
            DefaultVisit(node);
            node.Target.Accept(this);
        }

        public virtual void Visit(JsObjectExpression node)
        {
            DefaultVisit(node);
            foreach (var item in node.Items)
            {
                item.Accept(this);
            }
        }

        public virtual void Visit(JsParentheticalExpression node)
        {
            DefaultVisit(node);
            node.Expression.Accept(this);
        }

        public virtual void Visit(JsReturnStatement node)
        {
            DefaultVisit(node);
            node.Expression.Accept(this);
        }

        public virtual void Visit(JsVariableDeclarator node)
        {
            DefaultVisit(node);
            if (node.Initializer != null)
                node.Initializer.Accept(this);
        }

        public virtual void Visit(JsVariableDeclaration node)
        {
            DefaultVisit(node);
            foreach (var declaration in node.Declarations)
            {
                declaration.Accept(this);
            }
        }

        public virtual void Visit(JsVariableReferenceExpression node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsObjectItem node)
        {
            DefaultVisit(node);
            node.Value.Accept(this);
        }

        public virtual void Visit(JsInvocationExpression node)
        {
            DefaultVisit(node);
            node.Target.Accept(this);
            foreach (var item in node.Arguments)
            {
                item.Accept(this);
            }
        }

        public virtual void Visit(JsParameter node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsFunctionDeclaration node)
        {
            DefaultVisit(node);
            node.Function.Accept(this);
        }

        public virtual void Visit(JsPrimitiveExpression node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsThisExpression node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsNewExpression node)
        {
            DefaultVisit(node);
            node.Expression.Accept(this);
        }

        public virtual void Visit(JsIfStatement node)
        {
            DefaultVisit(node);
            node.Condition.Accept(this);
            node.IfTrue.Accept(this);
            if (node.IfFalse != null)
                node.IfFalse.Accept(this);
        }

        public virtual void Visit(JsBinaryExpression node)
        {
            DefaultVisit(node);
            node.Left.Accept(this);
            node.Right.Accept(this);
        }

        public virtual void Visit(JsUnaryExpression node)
        {
            DefaultVisit(node);
            node.Operand.Accept(this);
        }

        public virtual void Visit(JsNativeStatement node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsNativeExpression node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsNewArrayExpression node)
        {
            DefaultVisit(node);
            if (node.Size != null)
                node.Size.Accept(this);
        }

        public virtual void Visit(JsForStatement node)
        {
            DefaultVisit(node);
            if (node.Declaration != null) 
                node.Declaration.Accept(this);
            if (node.Condition != null)
                node.Condition.Accept(this);
            foreach (var incrementor in node.Incrementors)
                incrementor.Accept(this);
        }

        public virtual void Visit(JsIndexExpression node)
        {
            DefaultVisit(node);
            node.Target.Accept(this);
            node.Index.Accept(this);
        }

        public virtual void Visit(JsLocalVariableDeclaration node)
        {
            DefaultVisit(node);
            node.Declaration.Accept(this);
        }

        public virtual void Visit(JsRegexExpression node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsArrayExpression node)
        {
            DefaultVisit(node);
            foreach (var item in node.Elements)
            {
                item.Accept(this);
            }
        }

        public virtual void Visit(JsThrowStatement node)
        {
            DefaultVisit(node);
            node.Expression.Accept(this);
        }

        public virtual void Visit(JsSwitchSection node)
        {
            DefaultVisit(node);
            foreach (var label in node.Labels)
            {
                label.Accept(this);
            }
            foreach (var statement in node.Statements)
            {
                statement.Accept(this);
            }
        }

        public virtual void Visit(JsSwitchStatement node)
        {
            DefaultVisit(node);
            node.Expression.Accept(this);
            foreach (var section in node.Sections)
            {
                section.Accept(this);
            }
        }

        public virtual void Visit(JsSwitchLabel node)
        {
            DefaultVisit(node);
            if (node.Value != null)
                node.Value.Accept(this);
        }

        public virtual void Visit(JsWhileStatement node)
        {
            DefaultVisit(node);
            node.Condition.Accept(this);
            node.Body.Accept(this);
        }

        public virtual void Visit(JsBreakStatement node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsEmptyStatement node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsCatchClause node)
        {
            DefaultVisit(node);
            node.Declaration.Accept(this);
            node.Body.Accept(this);
        }

        public virtual void Visit(JsTryStatement node)
        {
            DefaultVisit(node);
            node.Body.Accept(this);
            if (node.Catch != null)
                node.Catch.Accept(this);
            if (node.Finally != null)
                node.Finally.Accept(this);
        }

        public virtual void Visit(JsConditionalExpression node)
        {
            DefaultVisit(node);
            node.Condition.Accept(this);
            node.IfTrue.Accept(this);
            node.IfFalse.Accept(this);
        }

        public virtual void Visit(JsDeleteExpression node)
        {
            DefaultVisit(node);
            node.Target.Accept(this);
        }

        public virtual void Visit(JsForInStatement node)
        {
            DefaultVisit(node);
            node.Declaration.Accept(this);
            node.Target.Accept(this);
            node.Body.Accept(this);
        }

        public virtual void Visit(JsTypeOfExpression node)
        {
            DefaultVisit(node);
            node.Target.Accept(this);
        }

        public virtual void Visit(JsContinueStatement node)
        {
            DefaultVisit(node);
        }

        public virtual void Visit(JsDeclarationReferenceExpression node)
        {
            DefaultVisit(node);
            VisitDeclaration(node.Declaration);
        }

        public virtual void Visit(JsLabeledStatement node)
        {
            DefaultVisit(node);
            node.Statement.Accept(this);
        }

        public virtual void Visit(JsDoWhileStatement node)
        {
            DefaultVisit(node);
            node.Body.Accept(this);
            node.Condition.Accept(this);
        }

        public virtual void Visit(JsInstanceOfExpression node)
        {
            DefaultVisit(node);
            node.Expression.Accept(this);
            node.Type.Accept(this);
        }

        public void Visit(JsInExpression node)
        {
            DefaultVisit(node);
            node.Object.Accept(this);
        }

        public void Visit(JsSnippetExpression node)
        {
            DefaultVisit(node);
            foreach (var part in node.Parts)
            {
                part.Accept(this);
            }
        }
    }
}
