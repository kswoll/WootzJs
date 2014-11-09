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
    public class JsVisitor : JsAst.IJsVisitor
    {
        protected virtual void BeforeVisit(JsNode node)
        {
        }

        protected virtual void AfterVisit(JsNode node)
        {
        }

        protected virtual void DefaultVisit<T>(T node, Action<T> action) where T : JsNode
        {
            action(node);
        }

        public virtual void VisitCompilationUnit(JsCompilationUnit node) {}
        public virtual void VisitBlockStatement(JsBlockStatement node) {}
        public virtual void VisitExpressionStatement(JsExpressionStatement node) {}
        public virtual void VisitFunction(JsFunction node) {}
        public virtual void VisitMemberReferenceExpression(JsMemberReferenceExpression node) {}
        public virtual void VisitObjectExpression(JsObjectExpression node) {}
        public virtual void VisitParentheticalExpression(JsParentheticalExpression node) {}
        public virtual void VisitReturnStatement(JsReturnStatement node) {}
        public virtual void VisitVariableDeclarator(JsVariableDeclarator node) {}
        public virtual void VisitVariableDeclaration(JsVariableDeclaration node) {}
        public virtual void VisitVariableReferenceExpression(JsVariableReferenceExpression node) {}
        public virtual void VisitObjectItem(JsObjectItem node) {}
        public virtual void VisitInvocationExpression(JsInvocationExpression node) {}
        public virtual void VisitParameter(JsParameter node) {}
        public virtual void VisitFunctionDeclaration(JsFunctionDeclaration node) {}
        public virtual void VisitPrimitiveExpression(JsPrimitiveExpression node) {}
        public virtual void VisitThisExpression(JsThisExpression node) {}
        public virtual void VisitNewExpression(JsNewExpression node) {}
        public virtual void VisitIfStatement(JsIfStatement node) {}
        public virtual void VisitBinaryExpression(JsBinaryExpression node) {}
        public virtual void VisitUnaryExpression(JsUnaryExpression node) {}
        public virtual void VisitNativeStatement(JsNativeStatement node) {}
        public virtual void VisitNativeExpression(JsNativeExpression node) {}
        public virtual void VisitNewArrayExpression(JsNewArrayExpression node) {}
        public virtual void VisitForStatement(JsForStatement node) {}
        public virtual void VisitIndexExpression(JsIndexExpression node) {}
        public virtual void VisitLocalVariableDeclaration(JsLocalVariableDeclaration node) {}
        public virtual void VisitRegexExpression(JsRegexExpression node) {}
        public virtual void VisitArrayExpression(JsArrayExpression node) {}
        public virtual void VisitThrowStatement(JsThrowStatement node) {}
        public virtual void VisitSwitchSection(JsSwitchSection node) {}
        public virtual void VisitSwitchStatement(JsSwitchStatement node) {}
        public virtual void VisitSwitchLabel(JsSwitchLabel node) {}
        public virtual void VisitWhileStatement(JsWhileStatement node) {}
        public virtual void VisitBreakStatement(JsBreakStatement node) {}
        public virtual void VisitEmptyStatement(JsEmptyStatement node) {}
        public virtual void VisitCatchClause(JsCatchClause node) {}
        public virtual void VisitTryStatement(JsTryStatement node) {}
        public virtual void VisitConditionalExpression(JsConditionalExpression node) {}
        public virtual void VisitDeleteExpression(JsDeleteExpression node) {}
        public virtual void VisitForInStatement(JsForInStatement node) {}
        public virtual void VisitTypeOfExpression(JsTypeOfExpression node) {}
        public virtual void VisitContinueStatement(JsContinueStatement node) {}
        public virtual void VisitDeclarationReferenceExpression(JsDeclarationReferenceExpression node) {}
        public virtual void VisitLabeledStatement(JsLabeledStatement node) {}
        public virtual void VisitDoWhileStatement(JsDoWhileStatement node) {}
        public virtual void VisitInstanceOfExpression(JsInstanceOfExpression node) {}
        public virtual void VisitInExpression(JsInExpression node) {}
        public virtual void VisitSnippetExpression(JsSnippetExpression node) {}

        public void Visit(JsCompilationUnit node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitCompilationUnit);
            AfterVisit(node);
        }

        public void Visit(JsBlockStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitBlockStatement);
            AfterVisit(node);
        }

        public void Visit(JsExpressionStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitExpressionStatement);
            AfterVisit(node);
        }

        public void Visit(JsFunction node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitFunction);
            AfterVisit(node);
        }

        public void Visit(JsMemberReferenceExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitMemberReferenceExpression);
            AfterVisit(node);
        }

        public void Visit(JsObjectExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitObjectExpression);
            AfterVisit(node);
        }

        public void Visit(JsParentheticalExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitParentheticalExpression);
            AfterVisit(node);
        }

        public void Visit(JsReturnStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitReturnStatement);
            AfterVisit(node);
        }

        public void Visit(JsVariableDeclarator node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitVariableDeclarator);
            AfterVisit(node);
        }

        public void Visit(JsVariableDeclaration node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitVariableDeclaration);
            AfterVisit(node);
        }

        public void Visit(JsVariableReferenceExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitVariableReferenceExpression);
            AfterVisit(node);
        }

        public void Visit(JsObjectItem node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitObjectItem);
            AfterVisit(node);
        }

        public void Visit(JsInvocationExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitInvocationExpression);
            AfterVisit(node);
        }

        public void Visit(JsParameter node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitParameter);
            AfterVisit(node);
        }

        public void Visit(JsFunctionDeclaration node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitFunctionDeclaration);
            AfterVisit(node);
        }

        public void Visit(JsPrimitiveExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitPrimitiveExpression);
            AfterVisit(node);
        }

        public void Visit(JsThisExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitThisExpression);
            AfterVisit(node);
        }

        public void Visit(JsNewExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitNewExpression);
            AfterVisit(node);
        }

        public void Visit(JsIfStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitIfStatement);
            AfterVisit(node);
        }

        public void Visit(JsBinaryExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitBinaryExpression);
            AfterVisit(node);
        }

        public void Visit(JsUnaryExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitUnaryExpression);
            AfterVisit(node);
        }

        public void Visit(JsNativeStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitNativeStatement);
            AfterVisit(node);
        }

        public void Visit(JsNativeExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitNativeExpression);
            AfterVisit(node);
        }

        public void Visit(JsNewArrayExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitNewArrayExpression);
            AfterVisit(node);
        }

        public void Visit(JsForStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitForStatement);
            AfterVisit(node);
        }

        public void Visit(JsIndexExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitIndexExpression);
            AfterVisit(node);
        }

        public void Visit(JsLocalVariableDeclaration node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitLocalVariableDeclaration);
            AfterVisit(node);
        }

        public void Visit(JsRegexExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitRegexExpression);
            AfterVisit(node);
        }

        public void Visit(JsArrayExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitArrayExpression);
            AfterVisit(node);
        }

        public void Visit(JsThrowStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitThrowStatement);
            AfterVisit(node);
        }

        public void Visit(JsSwitchSection node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitSwitchSection);
            AfterVisit(node);
        }

        public void Visit(JsSwitchStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitSwitchStatement);
            AfterVisit(node);
        }

        public void Visit(JsSwitchLabel node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitSwitchLabel);
            AfterVisit(node);
        }

        public void Visit(JsWhileStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitWhileStatement);
            AfterVisit(node);
        }

        public void Visit(JsBreakStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitBreakStatement);
            AfterVisit(node);
        }

        public void Visit(JsEmptyStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitEmptyStatement);
            AfterVisit(node);
        }

        public void Visit(JsCatchClause node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitCatchClause);
            AfterVisit(node);
        }

        public void Visit(JsTryStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitTryStatement);
            AfterVisit(node);
        }

        public void Visit(JsConditionalExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitConditionalExpression);
            AfterVisit(node);
        }

        public void Visit(JsDeleteExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitDeleteExpression);
            AfterVisit(node);
        }

        public void Visit(JsForInStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitForInStatement);
            AfterVisit(node);
        }

        public void Visit(JsTypeOfExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitTypeOfExpression);
            AfterVisit(node);
        }

        public void Visit(JsContinueStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitContinueStatement);
            AfterVisit(node);
        }

        public void Visit(JsDeclarationReferenceExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitDeclarationReferenceExpression);
            AfterVisit(node);
        }

        public void Visit(JsLabeledStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitLabeledStatement);
            AfterVisit(node);
        }

        public void Visit(JsDoWhileStatement node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitDoWhileStatement);
            AfterVisit(node);
        }

        public void Visit(JsInstanceOfExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitInstanceOfExpression);
            AfterVisit(node);
        }

        public void Visit(JsInExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitInExpression);
        }

        public void Visit(JsSnippetExpression node)
        {
            BeforeVisit(node);
            DefaultVisit(node, VisitSnippetExpression);
        }
    }
}
