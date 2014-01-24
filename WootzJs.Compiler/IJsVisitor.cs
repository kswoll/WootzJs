using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public interface IJsVisitor<out T>
    {
        T Visit(JsCompilationUnit node);
        T Visit(JsBlockStatement node);
        T Visit(JsExpressionStatement node);
        T Visit(JsFunction node);
        T Visit(JsMemberReferenceExpression node);
        T Visit(JsObjectExpression node);
        T Visit(JsParentheticalExpression node);
        T Visit(JsReturnStatement node);
        T Visit(JsVariableDeclarator node);
        T Visit(JsVariableDeclaration node);
        T Visit(JsVariableReferenceExpression node);
        T Visit(JsObjectItem node);
        T Visit(JsInvocationExpression node);
        T Visit(JsParameter node);
        T Visit(JsFunctionDeclaration node);
        T Visit(JsPrimitiveExpression node);
        T Visit(JsThisExpression node);
        T Visit(JsNewExpression node);
        T Visit(JsIfStatement node);
        T Visit(JsBinaryExpression node);
        T Visit(JsUnaryExpression node);
        T Visit(JsNativeStatement node);
        T Visit(JsNewArrayExpression node);
        T Visit(JsForStatement node);
        T Visit(JsIndexExpression node);
        T Visit(JsLocalVariableDeclaration node);
        T Visit(JsRegexExpression node);
        T Visit(JsArrayExpression node);
        T Visit(JsThrowStatement node);
        T Visit(JsSwitchSection node);
        T Visit(JsSwitchStatement node);
        T Visit(JsSwitchLabel node);
        T Visit(JsWhileStatement node);
        T Visit(JsBreakStatement node);
        T Visit(JsEmptyStatement node);
        T Visit(JsCatchClause node);
        T Visit(JsTryStatement node);
        T Visit(JsConditionalExpression node);
        T Visit(JsDeleteExpression node);
        T Visit(JsForInStatement node);
        T Visit(JsTypeOfExpression node);
        T Visit(JsContinueStatement node);
        T Visit(JsDeclarationReferenceExpression node);
        T Visit(JsLabeledStatement node);
        T Visit(JsDoWhileStatement node);
        T Visit(JsInstanceOfExpression node);         
    }
}