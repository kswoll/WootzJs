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
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public static class Cs
    {
        public static LiteralExpressionSyntax True()
        {
            return Syntax.LiteralExpression(SyntaxKind.TrueLiteralExpression);
        }

        public static LiteralExpressionSyntax False()
        {
            return Syntax.LiteralExpression(SyntaxKind.FalseLiteralExpression);
        }

        public static PredefinedTypeSyntax Bool()
        {
            return Syntax.PredefinedType(Syntax.Token(SyntaxKind.BoolKeyword));
        }

        public static PredefinedTypeSyntax Int()
        {
            return Syntax.PredefinedType(Syntax.Token(SyntaxKind.IntKeyword));
        }

        public static LiteralExpressionSyntax Integer(int value)
        {
            return Syntax.LiteralExpression(SyntaxKind.NumericLiteralExpression, Syntax.Literal(value));
        }

        public static BinaryExpressionSyntax Assign(ExpressionSyntax left, ExpressionSyntax right)
        {
            return Syntax.BinaryExpression(SyntaxKind.AssignExpression, left, right);
        }

        public static ThisExpressionSyntax This()
        {
            return Syntax.ThisExpression();
        }

        public static MemberAccessExpressionSyntax Member(this ExpressionSyntax target, string member)
        {
            return target.Member(Syntax.IdentifierName(member));
        }

        public static MemberAccessExpressionSyntax Member(this ExpressionSyntax target, SyntaxToken member)
        {
            return target.Member(Syntax.IdentifierName(member));
        }

        public static MemberAccessExpressionSyntax Member(this ExpressionSyntax target, SimpleNameSyntax member)
        {
            return Syntax.MemberAccessExpression(SyntaxKind.MemberAccessExpression, target, member);
        }

        public static ExpressionStatementSyntax Express(ExpressionSyntax expression)
        {
            return Syntax.ExpressionStatement(expression);
        }

        public static ReturnStatementSyntax Return(ExpressionSyntax expression)
        {
            return Syntax.ReturnStatement(expression);
        }

        public static WhileStatementSyntax While(ExpressionSyntax condition, StatementSyntax statement)
        {
            return Syntax.WhileStatement(condition, statement);
        }

        public static SwitchStatementSyntax Switch(ExpressionSyntax target, params SwitchSectionSyntax[] sections)
        {
            return Syntax.SwitchStatement(target, Syntax.List(sections));
        }

        public static SwitchSectionSyntax Section(ExpressionSyntax label, params StatementSyntax[] statements)
        {
            return Section(Syntax.SwitchLabel(SyntaxKind.CaseSwitchLabel, label), statements);
        }

        public static SyntaxToken Public()
        {
            return Syntax.Token(SyntaxKind.PublicKeyword);
        }

        public static SyntaxToken Override()
        {
            return Syntax.Token(SyntaxKind.OverrideKeyword);
        }

        public static ClassDeclarationSyntax WithBaseList(this ClassDeclarationSyntax declaration, params TypeSyntax[] baseTypes)
        {
            return declaration.WithBaseList(Syntax.BaseList(Syntax.SeparatedList(baseTypes, baseTypes.Skip(1).Select(_ => Syntax.Token(SyntaxKind.CommaToken)))));
        }

        public static ClassDeclarationSyntax WithMembers(this ClassDeclarationSyntax declaration, params MemberDeclarationSyntax[] members)
        {
            return declaration.WithMembers(Syntax.List(members));
        }

        public static ConstructorDeclarationSyntax WithParameterList(this ConstructorDeclarationSyntax constructor, params ParameterSyntax[] parameters)
        {
            return constructor.WithParameterList(Syntax.ParameterList(Syntax.SeparatedList(parameters, parameters.Skip(1).Select(_ => Syntax.Token(SyntaxKind.CommaToken)))));
        }

        public static FieldDeclarationSyntax Field(TypeSyntax type, string name)
        {
            return Syntax.FieldDeclaration(Syntax.VariableDeclaration(type, Syntax.SeparatedList(Syntax.VariableDeclarator(name))));
        }

        public static FieldDeclarationSyntax Field(TypeSyntax type, SyntaxToken name)
        {
            return Syntax.FieldDeclaration(Syntax.VariableDeclaration(type, Syntax.SeparatedList(Syntax.VariableDeclarator(name))));
        }

        public static BlockSyntax WithStatements(this BlockSyntax block, IEnumerable<StatementSyntax> statements)
        {
            return block.WithStatements(Syntax.List(statements));
        }

        public static BreakStatementSyntax Break()
        {
            return Syntax.BreakStatement();
        }

        public static ClassDeclarationSyntax WithTypeParameters(this ClassDeclarationSyntax classDeclaration, params TypeParameterSyntax[] typeParameters)
        {
            return classDeclaration
                .WithTypeParameterList(Syntax.TypeParameterList(Syntax.SeparatedList(typeParameters, typeParameters.Skip(1).Select(_ => Syntax.Token(SyntaxKind.CommaToken)))));
        }

        public static IfStatementSyntax If(ExpressionSyntax condition, StatementSyntax statement)
        {
            return Syntax.IfStatement(condition, statement);
        }

        public static IfStatementSyntax If(ExpressionSyntax condition, StatementSyntax statement, StatementSyntax @else)
        {
            return Syntax.IfStatement(condition, statement, Syntax.ElseClause(@else));
        }

        public static BlockSyntax Block(params StatementSyntax[] statements)
        {
            return Syntax.Block(statements);
        }

        public static SwitchStatementSyntax Switch(ExpressionSyntax expression)
        {
            return Syntax.SwitchStatement(expression);
        }

        public static SwitchSectionSyntax Section(SwitchLabelSyntax label, params StatementSyntax[] statements)
        {
            return Syntax.SwitchSection(Syntax.List(label), Syntax.List(statements));
        }

        public static SwitchSectionSyntax Section(SyntaxList<SwitchLabelSyntax> labels, params StatementSyntax[] statements)
        {
            return Syntax.SwitchSection(labels, Syntax.List(statements));
        }

        public static TryStatementSyntax Try()
        {
            return Syntax.TryStatement();
        }

        public static FinallyClauseSyntax Finally(params StatementSyntax[] statements)
        {
            return Syntax.FinallyClause(Block(statements));
        }

        public static TryStatementSyntax WithFinally(this TryStatementSyntax tryStatement, params StatementSyntax[] statements)
        {
            return tryStatement.WithFinally(Finally(statements));
        }

        public static BinaryExpressionSyntax NotEqualTo(this ExpressionSyntax left, ExpressionSyntax right)
        {
            return Syntax.BinaryExpression(SyntaxKind.NotEqualsExpression, left, right);
        }

        public static LiteralExpressionSyntax Null()
        {
            return Syntax.LiteralExpression(SyntaxKind.NullLiteralExpression);
        }

        public static ThrowStatementSyntax Rethrow()
        {
            return Syntax.ThrowStatement();
        }

        public static ThrowStatementSyntax Throw(ExpressionSyntax expression)
        {
            return Syntax.ThrowStatement(expression);
        }
    }
}
