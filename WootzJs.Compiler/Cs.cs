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
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public static class Cs
    {
        public static GotoStatementSyntax Goto(int label)
        {
            return SyntaxFactory.GotoStatement(
                SyntaxKind.GotoCaseStatement, 
                SyntaxFactory.LiteralExpression(
                    SyntaxKind.NumericLiteralExpression, 
                    SyntaxFactory.Literal(label)));
        }

        public static IdentifierNameSyntax IdentifierName(string name)
        {
            return SyntaxFactory.IdentifierName(name);
        }

        public static LiteralExpressionSyntax True()
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression);
        }

        public static LiteralExpressionSyntax False()
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression);
        }

        public static PredefinedTypeSyntax Bool()
        {
            return SyntaxFactory.PredefinedType(Token(SyntaxKind.BoolKeyword));
        }

        public static PredefinedTypeSyntax Void()
        {
            return SyntaxFactory.PredefinedType(Token(SyntaxKind.VoidKeyword));
        }

        public static PredefinedTypeSyntax Int()
        {
            return SyntaxFactory.PredefinedType(Token(SyntaxKind.IntKeyword));
        }

        public static SyntaxToken Ref()
        {
            return Token(SyntaxKind.RefKeyword);
        }

        public static SyntaxToken Out()
        {
            return Token(SyntaxKind.OutKeyword);
        }

        public static SyntaxToken Token(SyntaxKind kind)
        {
            return SyntaxFactory.Token(kind);
        }

        public static LiteralExpressionSyntax Integer(int value)
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value));
        }

        public static BinaryExpressionSyntax Assign(this ExpressionSyntax left, ExpressionSyntax right)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.SimpleAssignmentExpression, left, right);
        }

        public static ThisExpressionSyntax This()
        {
            return SyntaxFactory.ThisExpression();
        }

        public static TypeSyntax Var()
        {
            return SyntaxFactory.ParseTypeName("var");
//            return SyntaxFactory.PredefinedType(Token(SyntaxKind.TypeVarKeyword));
        }

        public static MemberAccessExpressionSyntax Member(this ExpressionSyntax target, string member)
        {
            return target.Member(SyntaxFactory.IdentifierName(member));
        }

        public static MemberAccessExpressionSyntax Member(this ExpressionSyntax target, SyntaxToken member)
        {
            return target.Member(SyntaxFactory.IdentifierName(member));
        }

        public static MemberAccessExpressionSyntax Member(this ExpressionSyntax target, SimpleNameSyntax member)
        {
            return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, target, member);
        }

        public static ExpressionStatementSyntax Express(this ExpressionSyntax expression)
        {
            return SyntaxFactory.ExpressionStatement(expression);
        }

        public static ReturnStatementSyntax Return()
        {
            return SyntaxFactory.ReturnStatement();
        }

        public static ReturnStatementSyntax Return(ExpressionSyntax expression)
        {
            return SyntaxFactory.ReturnStatement(expression);
        }

        public static WhileStatementSyntax While(ExpressionSyntax condition, StatementSyntax statement)
        {
            return SyntaxFactory.WhileStatement(condition, statement);
        }

        public static SwitchStatementSyntax Switch(ExpressionSyntax target, params SwitchSectionSyntax[] sections)
        {
            return SyntaxFactory.SwitchStatement(target, SyntaxFactory.List(sections));
        }

        public static SwitchSectionSyntax Section(ExpressionSyntax label, params StatementSyntax[] statements)
        {
            return Section(SyntaxFactory.SwitchLabel(SyntaxKind.CaseSwitchLabel, label), statements);
        }

        public static SyntaxToken Public()
        {
            return SyntaxFactory.Token(SyntaxKind.PublicKeyword);
        }

        public static SyntaxToken Override()
        {
            return SyntaxFactory.Token(SyntaxKind.OverrideKeyword);
        }

        public static ClassDeclarationSyntax WithBaseList(this ClassDeclarationSyntax declaration, params TypeSyntax[] baseTypes)
        {
            return declaration.WithBaseList(SyntaxFactory.BaseList(SyntaxFactory.SeparatedList(baseTypes, baseTypes.Skip(1).Select(_ => SyntaxFactory.Token(SyntaxKind.CommaToken)))));
        }

        public static ClassDeclarationSyntax WithMembers(this ClassDeclarationSyntax declaration, params MemberDeclarationSyntax[] members)
        {
            return declaration.WithMembers(SyntaxFactory.List(members));
        }

        public static ConstructorDeclarationSyntax WithParameterList(this ConstructorDeclarationSyntax constructor, params ParameterSyntax[] parameters)
        {
            return constructor.WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(parameters, parameters.Skip(1).Select(_ => SyntaxFactory.Token(SyntaxKind.CommaToken)))));
        }

        public static MethodDeclarationSyntax WithParameterList(this MethodDeclarationSyntax method, params ParameterSyntax[] parameters)
        {
            return method.WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(parameters, parameters.Skip(1).Select(_ => SyntaxFactory.Token(SyntaxKind.CommaToken)))));
        }

        public static VariableDeclaratorSyntax Declarator(string name, ExpressionSyntax initializer = null)
        {
            var result = SyntaxFactory.VariableDeclarator(name);
            if (initializer != null)
                result = result.WithInitializer(SyntaxFactory.EqualsValueClause(initializer));
            return result;
        }

        public static VariableDeclarationSyntax Variable(TypeSyntax type, string name, ExpressionSyntax initializer = null)
        {
            return SyntaxFactory.VariableDeclaration(type, SyntaxFactory.SeparatedList(new[] { Declarator(name, initializer) }));
        }

        public static LocalDeclarationStatementSyntax Local(TypeSyntax type, string name, ExpressionSyntax initializer = null)
        {
            return Local(Variable(type, name, initializer));
        }

        public static LocalDeclarationStatementSyntax Local(VariableDeclarationSyntax variable)
        {
            return SyntaxFactory.LocalDeclarationStatement(variable);
        }

        public static FieldDeclarationSyntax Field(TypeSyntax type, string name)
        {
            return SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(type, SyntaxFactory.SeparatedList(new[] { SyntaxFactory.VariableDeclarator(name) })));
        }

        public static FieldDeclarationSyntax Field(TypeSyntax type, SyntaxToken name)
        {
            return SyntaxFactory.FieldDeclaration(SyntaxFactory.VariableDeclaration(type, SyntaxFactory.SeparatedList(new[] { SyntaxFactory.VariableDeclarator(name) })));
        }

        public static BlockSyntax WithStatements(this BlockSyntax block, IEnumerable<StatementSyntax> statements)
        {
            return block.WithStatements(SyntaxFactory.List(statements));
        }

        public static BreakStatementSyntax Break()
        {
            return SyntaxFactory.BreakStatement();
        }

        public static ClassDeclarationSyntax WithTypeParameters(this ClassDeclarationSyntax classDeclaration, params TypeParameterSyntax[] typeParameters)
        {
            return classDeclaration
                .WithTypeParameterList(SyntaxFactory.TypeParameterList(SyntaxFactory.SeparatedList(typeParameters, typeParameters.Skip(1).Select(_ => SyntaxFactory.Token(SyntaxKind.CommaToken)))));
        }

        public static IfStatementSyntax If(ExpressionSyntax condition, StatementSyntax statement)
        {
            return SyntaxFactory.IfStatement(condition, statement);
        }

        public static IfStatementSyntax If(ExpressionSyntax condition, StatementSyntax statement, StatementSyntax @else)
        {
            return SyntaxFactory.IfStatement(condition, statement, SyntaxFactory.ElseClause(@else));
        }

        public static BlockSyntax Block(params StatementSyntax[] statements)
        {
            return SyntaxFactory.Block(statements);
        }

        public static SwitchStatementSyntax Switch(ExpressionSyntax expression)
        {
            return SyntaxFactory.SwitchStatement(expression);
        }

        public static SwitchSectionSyntax Section(SwitchLabelSyntax label, params StatementSyntax[] statements)
        {
            return SyntaxFactory.SwitchSection(SyntaxFactory.List(new[] { label }), SyntaxFactory.List(statements));
        }

        public static SwitchSectionSyntax Section(SyntaxList<SwitchLabelSyntax> labels, params StatementSyntax[] statements)
        {
            return SyntaxFactory.SwitchSection(labels, SyntaxFactory.List(statements));
        }

        public static TryStatementSyntax Try()
        {
            return SyntaxFactory.TryStatement();
        }

        public static FinallyClauseSyntax Finally(params StatementSyntax[] statements)
        {
            return SyntaxFactory.FinallyClause(Block(statements));
        }

        public static TryStatementSyntax WithFinally(this TryStatementSyntax tryStatement, params StatementSyntax[] statements)
        {
            return tryStatement.WithFinally(Finally(statements));
        }

        public static TryStatementSyntax WithCatch(this TryStatementSyntax tryStatement, TypeSyntax exceptionType, string exceptionIdentifier, params StatementSyntax[] statements)
        {
            return tryStatement
                .WithCatches(SyntaxFactory.List(new[] { SyntaxFactory.CatchClause().WithDeclaration(SyntaxFactory.CatchDeclaration(exceptionType, SyntaxFactory.Identifier(exceptionIdentifier))) }));
        }

        public static BinaryExpressionSyntax NotEqualTo(this ExpressionSyntax left, ExpressionSyntax right)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression, left, right);
        }

        public static BinaryExpressionSyntax EqualTo(this ExpressionSyntax left, ExpressionSyntax right)
        {
            return SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, left, right);
        }

        public static LiteralExpressionSyntax Null()
        {
            return SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression);
        }

        public static ThrowStatementSyntax Rethrow()
        {
            return SyntaxFactory.ThrowStatement();
        }

        public static ThrowStatementSyntax Throw(ExpressionSyntax expression)
        {
            return SyntaxFactory.ThrowStatement(expression);
        }

        public static AnonymousObjectCreationExpressionSyntax Anonymous(params Tuple<string, ExpressionSyntax>[] initializers)
        {
            return SyntaxFactory.AnonymousObjectCreationExpression(SyntaxFactory.SeparatedList(
                initializers.Select(x =>
                    SyntaxFactory.AnonymousObjectMemberDeclarator(SyntaxFactory.NameEquals(x.Item1), x.Item2)
                ), 
                initializers.Skip(1).Select(_ => SyntaxFactory.Token(SyntaxKind.CommaToken))));
        }

        public static BlockSyntax Local(this BlockSyntax block, string name, ExpressionSyntax initializer, out VariableDeclaratorSyntax variable)
        {
            var declaration = Local(name, initializer, out variable);
            block = block.AddStatements(declaration);
            return block;
        }

        public static LocalDeclarationStatementSyntax Local(string name, ExpressionSyntax initializer, out VariableDeclaratorSyntax variable)
        {
            variable = SyntaxFactory.VariableDeclarator(name).WithInitializer(SyntaxFactory.EqualsValueClause(initializer));           
            var declaration = SyntaxFactory.LocalDeclarationStatement(SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName("var"),
                SyntaxFactory.SeparatedList(new[] { variable })));
            return declaration; 
        }

        public static LocalDeclarationStatementSyntax Local(string name, ExpressionSyntax initializer)
        {
            VariableDeclaratorSyntax variable;
            return Local(name, initializer, out variable);
        }

        public static BlockSyntax If(this BlockSyntax block, ExpressionSyntax condition, StatementSyntax ifTrue, StatementSyntax ifFalse = null)
        {
            var result = SyntaxFactory.IfStatement(condition, ifTrue);
            if (ifFalse != null)
                result = result.WithElse(SyntaxFactory.ElseClause(ifFalse));
            return block.AddStatements(result);
        }

        public static ExpressionSyntax Reference(this VariableDeclaratorSyntax variable)
        {
            return SyntaxFactory.IdentifierName(variable.Identifier);
        }

        public static InvocationExpressionSyntax Invoke(this ExpressionSyntax target, params ExpressionSyntax[] arguments)
        {
            return target.Invoke(arguments.Select(x => SyntaxFactory.Argument(x)).ToArray()); 
        }

        public static InvocationExpressionSyntax Invoke(this ExpressionSyntax target)
        {
            return target.Invoke(new ArgumentSyntax[0]);
        }

        public static InvocationExpressionSyntax Invoke(this ExpressionSyntax target, params ArgumentSyntax[] arguments)
        {
            return SyntaxFactory.InvocationExpression(target, SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(
                arguments, 
                arguments.Skip(1).Select(_ => SyntaxFactory.Token(SyntaxKind.CommaToken)))));
        }

        public static ObjectCreationExpressionSyntax New(this TypeSyntax type, params ExpressionSyntax[] arguments)
        {
            return SyntaxFactory.ObjectCreationExpression(type)
                .WithArgumentList(SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(arguments.Select(x => SyntaxFactory.Argument(x)), arguments.Skip(1).Select(_ => SyntaxFactory.Token(SyntaxKind.CommaToken)))));
        }
    }
}
