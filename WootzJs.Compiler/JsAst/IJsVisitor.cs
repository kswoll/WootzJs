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
    }
}
