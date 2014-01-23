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
using System.Linq;
using System.Runtime.WootzJs;
using Roslyn.Compilers.CSharp;
using NamedTypeSymbol = Roslyn.Compilers.CSharp.NamedTypeSymbol;
using SyntaxNode = Roslyn.Compilers.CSharp.SyntaxNode;
using TypeSymbol = Roslyn.Compilers.CSharp.TypeSymbol;
using TypeSyntax = Roslyn.Compilers.CSharp.TypeSyntax;

namespace WootzJs.Compiler.JsAst
{
    public static class Js
    {
        internal static Context context;

        public static JsLocalVariableDeclaration Local(JsVariableDeclaration declaration)
        {
            return new JsLocalVariableDeclaration(declaration);
        }

        public static JsLocalVariableDeclaration Local(params JsVariableDeclarator[] declarators)
        {
            return Local(Declare(declarators));
        }

        public static JsLocalVariableDeclaration Local(string name, JsExpression initializer = null)
        {
            return Local(Declare(Variable(name, initializer)));
        }

        public static JsVariableDeclaration Declare(params JsVariableDeclarator[] declarators)
        {
            var result = new JsVariableDeclaration();
            result.Declarations.AddRange(declarators);
            return result;
        }

        public static JsVariableDeclaration Declare(string name, JsExpression initializer = null)
        {
            return Declare(Variable(name, initializer));
        }

        public static JsVariableDeclarator Variable(string name, JsExpression initializer = null)
        {
            return new JsVariableDeclarator(name, initializer);
        }

        public static JsBinaryExpression Assign(JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.Assign, left, right);
        }

        public static JsBinaryExpression Binary(JsBinaryOperator @operator, JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(@operator, left, right);
        }

        public static JsUnaryExpression Unary(JsUnaryOperator @operator, JsExpression operand)
        {
            return new JsUnaryExpression(@operator, operand);
        }

        public static JsUnaryExpression Increment(this JsExpression expression)
        {
            return Js.Unary(JsUnaryOperator.PostIncrement, expression);
        }

        public static JsVariableReferenceExpression Reference(string name)
        {
            return new JsVariableReferenceExpression(name);
        }

        public static JsVariableReferenceExpression Reference(JsFunctionDeclaration function)
        {
            if (function.Function.Name == null)
                throw new Exception("Cannot reference anonymous function by name");

            return new JsVariableReferenceExpression(function.Function.Name);
        }

        public static string GetFullName(this BaseTypeDeclarationSyntax typeDeclaration)
        {
            string fullTypeName;
            string @namespace;
            GetTypeInfo(typeDeclaration, out fullTypeName, out @namespace);            
            return fullTypeName;
        }

        public static void GetTypeInfo(this BaseTypeDeclarationSyntax typeDeclaration, out string fullTypeName, out string @namespace)
        {
            Func<SyntaxNode, NamespaceDeclarationSyntax> getNamespace = null;
            getNamespace = x => x == null ? null : x is NamespaceDeclarationSyntax ? (NamespaceDeclarationSyntax)x : getNamespace(x.Parent);
            var namespaceDeclaration = getNamespace(typeDeclaration);
            @namespace = namespaceDeclaration != null ? namespaceDeclaration.Name.ToString() : null;
            fullTypeName = typeDeclaration.Identifier.ValueText;
            if (@namespace != null)
            {
                fullTypeName = @namespace + "." + fullTypeName;
            }
        }

        public static JsMemberReferenceExpression Member(this JsExpression target, string name)
        {
            return new JsMemberReferenceExpression(target, name);
        }

        public static JsMemberReferenceExpression Member(string path)
        {
            var parts = path.Split('.');
            if (parts.Length < 2)
                throw new Exception("Cannot construct path with only one part");

            var result = new JsMemberReferenceExpression();
            var current = result;
            for (var i = parts.Length - 1; i >= 0; i--)
            {
                current.Name = parts[i];
                var next = parts[i - 1];
                if (i == 1)
                {
                    current.Target = Reference(next);
                    return result;
                }
                else
                {
                    current.Target = new JsMemberReferenceExpression();
                    current = (JsMemberReferenceExpression)current.Target;
                }
            }
            throw new Exception("Should never get here");
        }

        public static JsObjectExpression Object(params JsObjectItem[] items)
        {
            var jsObjectExpression = new JsObjectExpression();
            jsObjectExpression.Items.AddRange(items);
            return jsObjectExpression;
        }

        public static JsObjectItem Item(string name, JsExpression value)
        {
            return new JsObjectItem(name, value);
        }

        public static JsInvocationExpression Invoke(this JsExpression target, params JsExpression[] arguments)
        {
            var result = new JsInvocationExpression(target);
            result.AddArgumentRange(arguments);
            return result;
        }

        public static JsFunctionDeclaration Declare(JsFunction function)
        {
            return new JsFunctionDeclaration(function);
        }

        public static JsFunction NamedFunction(string name, params IJsDeclaration[] parameters)
        {
            var function = new JsFunction(name);
            foreach (var parameter in parameters)
            {
                function.Parameters.Add(parameter);
            }
            return function;
        }

        public static JsFunction Function(params IJsDeclaration[] parameters)
        {
            return NamedFunction(null, parameters);
        }

        public static JsParameter Parameter(string name)
        {
            return new JsParameter(name);
        }

        public static JsPrimitiveExpression Primitive(string s)
        {
            return new JsPrimitiveExpression(s);
        }

        public static JsPrimitiveExpression Primitive(int value)
        {
            return new JsPrimitiveExpression(value);
        }

        public static JsPrimitiveExpression Primitive(bool value)
        {
            return new JsPrimitiveExpression(value);
        }

        public static JsExpressionStatement Express(JsExpression expression)
        {
            return new JsExpressionStatement(expression);
        }

        public static JsFunction Body(this JsFunction function, JsExpression expression)
        {
            function.Body.Add(Js.Express(expression));
            return function;
        }

        public static JsFunction Body(this JsFunction function, JsStatement statement)
        {
            function.Body.Aggregate(statement);
            return function;
        }

        public static JsFunction Body(this JsFunction function, JsBlockStatement statement)
        {
            function.Body = statement;
            return function;
        }

        public static JsReturnStatement Return()
        {
            return new JsReturnStatement();
        }

        public static JsReturnStatement Return(JsExpression expression)
        {
            return new JsReturnStatement(expression);
        }

        public static JsThisExpression This()
        {
            return new JsThisExpression();
        }

        public static JsPrimitiveExpression Null()
        {
            return new JsPrimitiveExpression();
        }

        public static JsExpression Literal(object value)
        {
            if (value == null)
                return new JsPrimitiveExpression();
            if (value is string)
                return new JsPrimitiveExpression((string)value);
            if (value is bool)
                return new JsPrimitiveExpression((bool)value);
            if (value is int)
                return new JsPrimitiveExpression((int)value);
            if (value is uint)
                return new JsPrimitiveExpression((uint)value);
            if (value is float)
                return new JsPrimitiveExpression((float)value);
            if (value is double)
                return new JsPrimitiveExpression((double)value);
            if (value is char)
                return new JsPrimitiveExpression((char)value);
            if (value is TypedConstant)
                return Literal(((TypedConstant)value).Value);
            if (value is TypeSymbol)
                return Js.Reference(((TypeSymbol)value).GetFullName());
            else
                throw new Exception("Unexpected primitive type: " + value);
        }

/*
        public static JsNewExpression NakedNew(JsExpression expression)
        {
            return new JsNewExpression(expression.Invoke());
        }
*/

        public static JsNewExpression New(JsExpression type, params JsExpression[] arguments)
        {
            return new JsNewExpression(type.Invoke(arguments));
        }

        public static JsIfStatement If(JsExpression condition, JsStatement ifTrue, JsStatement ifFalse = null)
        {
            return new JsIfStatement(condition, ifTrue, ifFalse);
        }

        public static JsIfStatement If(JsExpression condition, JsExpression ifTrue, JsExpression ifFalse = null)
        {
            return new JsIfStatement(condition, Express(ifTrue), ifFalse != null ? Express(ifFalse) : null);
        }

        public static JsNativeStatement Native(string code)
        {
            return new JsNativeStatement(code);
        }

        public static JsParentheticalExpression Parenthetical(this JsExpression expression)
        {
            return new JsParentheticalExpression(expression);
        }

        public static JsNewArrayExpression NewArray(JsExpression size)
        {
            return new JsNewArrayExpression(size);
        }

        public static JsForInStatement ForIn(JsVariableDeclaration declaration, JsExpression target)
        {
            return new JsForInStatement(declaration, target);
        }

        public static JsForInStatement ForIn(JsVariableDeclarator declarator, JsExpression target)
        {
            return ForIn(Declare(declarator), target);
        }

        public static JsForInStatement ForIn(string variableName, JsExpression target)
        {
            return ForIn(Variable(variableName), target);
        }

        public static JsForInStatement Body(this JsForInStatement forInStatement, JsStatement statement)
        {
            forInStatement.Body = statement;
            return forInStatement;
        }

        public static JsForStatement For(JsVariableDeclaration declaration, JsExpression condition, params JsExpression[] incrementors)
        {
            var forStatement = new JsForStatement(declaration, condition);
            forStatement.Incrementors.AddRange(incrementors);
            return forStatement;
        }

        public static JsForStatement For(JsVariableDeclarator declarator, JsExpression condition, params JsExpression[] incrementors)
        {
            return For(Declare(declarator), condition, incrementors);
        }

        public static JsForStatement For(string variableName, JsExpression initializer, JsExpression condition, params JsExpression[] incrementors)
        {
            return For(Variable(variableName, initializer), condition, incrementors);
        }

        public static JsForStatement Body(this JsForStatement forStatement, JsStatement body)
        {
            forStatement.Body = body;
            return forStatement;
        }

        public static JsIndexExpression Index(this JsExpression target, JsExpression index)
        {
            return new JsIndexExpression(target, index);
        }
 
        public static JsRegexExpression Regex(string pattern)
        {
            return new JsRegexExpression(pattern);
        }    

        public static JsArrayExpression Array(params JsExpression[] elements)
        {
            var expression = new JsArrayExpression();
            expression.Elements.AddRange(elements);
            return expression;
        }

        public static JsThrowStatement Throw(JsExpression expression)
        {
            return new JsThrowStatement(expression);
        }

        public static JsSwitchStatement Switch(JsExpression expression, params JsSwitchSection[] sections)
        {
            var switchStatement = new JsSwitchStatement(expression);
            switchStatement.Sections.AddRange(sections);
            return switchStatement;
        }

        public static JsSwitchLabel DefaultLabel()
        {
            return new JsSwitchLabel(true, null);
        }

        public static JsSwitchLabel CaseLabel(JsExpression label)
        {
            return new JsSwitchLabel(false, label);
        }

        public static JsSwitchSection DefaultSection()
        {
            return Section(DefaultLabel());
        }

        public static JsSwitchSection Section(params JsExpression[] caseLabels)
        {
            return Section(caseLabels.Select(x => CaseLabel(x)).ToArray());
        }

        public static JsSwitchSection Section(params JsSwitchLabel[] caseLabels)
        {
            var switchSection = new JsSwitchSection();
            foreach (var caseLabel in caseLabels)
            {
                switchSection.Labels.Add(caseLabel);
            }
            return switchSection;
        }

        public static JsSwitchSection Statement(this JsSwitchSection section, JsStatement statement)
        {
            section.Statements.Add(statement);
            return section;
        }

        public static JsSwitchSection Statements(this JsSwitchSection section, params JsStatement[] statements)
        {
            section.Statements.AddRange(statements);
            return section;
        }

        public static JsWhileStatement While(JsExpression condition, JsStatement statement)
        {
            return new JsWhileStatement(condition, statement);
        }

        public static JsDoWhileStatement DoWhile(JsExpression condition, JsStatement statement)
        {
            return new JsDoWhileStatement(condition, statement);
        }

        public static JsBreakStatement Break(JsExpression label = null)
        {
            return new JsBreakStatement(label);
        }

        public static JsEmptyStatement Empty()
        {
            return new JsEmptyStatement();
        }

        public static JsTryStatement Try() 
        {
            var result = new JsTryStatement();
            return result;
        }

        public static JsCatchClause Catch()
        {
            var catchClause = new JsCatchClause();
            return catchClause;
        }

        public static JsCatchClause Catch(JsVariableDeclarator declaration)
        {
            var catchClause = new JsCatchClause(declaration);
            return catchClause;
        }

        public static JsTryStatement Catch(this JsTryStatement tryStatement, JsCatchClause catchClause)
        {
            tryStatement.Catch = catchClause;
            return tryStatement;
        }

        public static JsTryStatement Catch(this JsTryStatement tryStatement, JsVariableDeclarator declaration)
        {
            tryStatement.Catch = Catch(declaration);
            return tryStatement;
        }

        public static JsTryStatement Finally(this JsTryStatement tryStatement)
        {
            tryStatement.Finally = new JsBlockStatement();
            return tryStatement;
        }

        public static JsConditionalExpression Conditional(JsExpression condition, JsExpression ifTrue, JsExpression ifFalse)
        {
            return new JsConditionalExpression(condition, ifTrue, ifFalse);
        }

        public static void Express(this JsBlockStatement blockStatement, JsExpression expression)
        {
            blockStatement.Add(Express(expression));
        }

        public static void Local(this JsBlockStatement blockStatement, params JsVariableDeclarator[] declarators)
        {
            blockStatement.Add(Local(declarators));
        }

        public static void Local(this JsBlockStatement blockStatement, string name, JsExpression initializer)
        {
            blockStatement.Add(Local(name, initializer));
        }

        public static void Local(this JsBlockStatement blockStatement, JsVariableDeclaration declaration)
        {
            blockStatement.Add(Local(declaration));
        }

        public static void Return(this JsBlockStatement blockStatement, JsExpression expression)
        {
            blockStatement.Add(Js.Return(expression));
        }

        public static void Assign(this JsBlockStatement blockStatement, JsExpression left, JsExpression right)
        {
            blockStatement.Express(Assign(left, right));
        }

        public static void If(this JsBlockStatement blockStatement, JsExpression condition, JsExpression ifTrue, JsExpression ifFalse = null)
        {
            blockStatement.Add(If(condition, ifTrue, ifFalse));
        }

        public static void If(this JsBlockStatement blockStatement, JsExpression condition, JsStatement ifTrue, JsStatement ifFalse = null)
        {
            blockStatement.Add(If(condition, ifTrue, ifFalse));
        }

        public static void Invoke(this JsBlockStatement blockStatement, JsExpression target, params JsExpression[] arguments)
        {
            blockStatement.Express(Invoke(target, arguments));
        }

        public static JsDeleteExpression Delete(this JsExpression target)
        {
            return new JsDeleteExpression(target);
        }

        public static JsTypeOfExpression TypeOf(JsExpression type)
        {
            return new JsTypeOfExpression(type);
        }

        public static JsUnaryExpression Not(JsExpression expression)
        {
            return new JsUnaryExpression(JsUnaryOperator.LogicalNot, expression);
        }

        public static JsContinueStatement Continue(JsExpression label = null)
        {
            return new JsContinueStatement(label);
        }

        public static JsExpression GetLogicalTarget(this JsExpression expression)
        {
            if (expression is JsInvocationExpression)
            {
                var invocation = (JsInvocationExpression)expression;
                var target = invocation.Target;
                if (target is JsMemberReferenceExpression)
                    target = target.GetLogicalTarget();
                return target;
            }
            else if (expression is JsMemberReferenceExpression)
            {
                var memberReference = (JsMemberReferenceExpression)expression;
                return memberReference.Target;
            }
            else
            {
                return null;
            }
        }

        public static JsBinaryExpression BitwiseOr(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.BitwiseOr, left, right);
        }

        public static JsBinaryExpression LogicalAnd(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.LogicalAnd, left, right);
        }

        public static JsBinaryExpression LessThan(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.LessThan, left, right);
        }

        public static JsBinaryExpression GreaterThan(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.GreaterThan, left, right);
        }

        public static JsBinaryExpression LogicalOr(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.LogicalOr, left, right);
        }

        public static JsBinaryExpression NotEqualTo(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.NotEquals, left, right);
        }

        public static JsBinaryExpression EqualTo(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.Equals, left, right);
        }

        public static JsBinaryExpression Add(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.Add, left, right);
        }

        public static JsBinaryExpression Subtract(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.Subtract, left, right);
        }

        public static JsBinaryExpression Multiply(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.Multiply, left, right);
        }

        public static JsBinaryExpression Divide(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.Divide, left, right);
        }

        public static JsBinaryExpression Modulus(this JsExpression left, JsExpression right)
        {
            return new JsBinaryExpression(JsBinaryOperator.Modulus, left, right);
        }

        public static JsLabeledStatement Label(string label, JsStatement statement)
        {
            return new JsLabeledStatement(label, statement);
        }

        public static JsInstanceOfExpression InstanceOf(JsExpression expression, JsExpression type)
        {
            return new JsInstanceOfExpression(expression, type);
        }
    }
}
