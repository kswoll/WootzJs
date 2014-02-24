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
    public interface IJsVisitor
    {
        void Visit(JsCompilationUnit node);
        void Visit(JsBlockStatement node);
        void Visit(JsExpressionStatement node);
        void Visit(JsFunction node);
        void Visit(JsMemberReferenceExpression node);
        void Visit(JsObjectExpression node);
        void Visit(JsParentheticalExpression node);
        void Visit(JsReturnStatement node);
        void Visit(JsVariableDeclarator node);
        void Visit(JsVariableDeclaration node);
        void Visit(JsVariableReferenceExpression node);
        void Visit(JsObjectItem node);
        void Visit(JsInvocationExpression node);
        void Visit(JsParameter node);
        void Visit(JsFunctionDeclaration node);
        void Visit(JsPrimitiveExpression node);
        void Visit(JsThisExpression node);
        void Visit(JsNewExpression node);
        void Visit(JsIfStatement node);
        void Visit(JsBinaryExpression node);
        void Visit(JsUnaryExpression node);
        void Visit(JsNativeStatement node);
        void Visit(JsNewArrayExpression node);
        void Visit(JsForStatement node);
        void Visit(JsIndexExpression node);
        void Visit(JsLocalVariableDeclaration node);
        void Visit(JsRegexExpression node);
        void Visit(JsArrayExpression node);
        void Visit(JsThrowStatement node);
        void Visit(JsSwitchSection node);
        void Visit(JsSwitchStatement node);
        void Visit(JsSwitchLabel node);
        void Visit(JsWhileStatement node);
        void Visit(JsBreakStatement node);
        void Visit(JsEmptyStatement node);
        void Visit(JsCatchClause node);
        void Visit(JsTryStatement node);
        void Visit(JsConditionalExpression node);
        void Visit(JsDeleteExpression node);
        void Visit(JsForInStatement node);
        void Visit(JsTypeOfExpression node);
        void Visit(JsContinueStatement node);
        void Visit(JsDeclarationReferenceExpression node);
        void Visit(JsLabeledStatement node);
        void Visit(JsDoWhileStatement node);
        void Visit(JsInstanceOfExpression node);
        void Visit(JsInExpression node);
    }
}
