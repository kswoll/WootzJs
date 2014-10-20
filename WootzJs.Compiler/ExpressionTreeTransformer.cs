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
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class ExpressionTreeTransformer : CSharpSyntaxVisitor<JsExpression>
    {
        private Idioms idioms;
        private SemanticModel model;
        private Dictionary<string, string> parameterVariables;

        public ExpressionTreeTransformer(SemanticModel model, Idioms idioms)
        {
            this.model = model;
            this.idioms = idioms;
            this.parameterVariables = new Dictionary<string, string>();
        }

        public override JsExpression DefaultVisit(SyntaxNode node)
        {
            throw new Exception();
        }

        private IMethodSymbol GetExpressionMethod(string methodName, params ITypeSymbol[] parameterTypes)
        {
            return Context.Instance.Expression.GetMethod(methodName, parameterTypes);
        }

/*
        private MemberExpression GetExpressionMethod(string methodName, Type[] parameterTypes)
        {
            var method = project.FindMethod(typeof(System.Linq.Expressions.Expression).GetMethod(methodName, parameterTypes));
            return SkJs.EntityMethodToJsFunctionRef(method);
        }
*/

        public override JsExpression VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
 	         return VisitLambdaExpression(node, new[] { node.Parameter }, node.Body);
        }

        public override JsExpression VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
 	         return VisitLambdaExpression(node, node.ParameterList.Parameters.ToArray(), node.Body);
        }

        private JsExpression VisitLambdaExpression(ExpressionSyntax node, ParameterSyntax[] parameters, CSharpSyntaxNode body)
        {
            var expressionType = (INamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            INamedTypeSymbol delegateType;
            if (Equals(expressionType.OriginalDefinition, Context.Instance.ExpressionGeneric))
                delegateType = (INamedTypeSymbol)expressionType.TypeArguments[0];
            else
                delegateType = expressionType;
            var lambdaParameters = parameters.ToArray();
            var delegateMethod = (IMethodSymbol)delegateType.GetMembers("Invoke")[0]; 
//            Compiler.CsCompilation.FindType()
            var lambdaMethods = Context.Instance.Expression.GetMembers("Lambda").OfType<IMethodSymbol>().ToArray();
            var lambdaMethods2 = lambdaMethods.Where(x => x.TypeParameters.Count() == 1 && x.Parameters.Count() == 2 && Equals(x.Parameters[0].Type, Context.Instance.Expression) && Equals(x.Parameters[1].Type, Context.Instance.ParameterExpressionArray)).ToArray();
            var lambdaMethod = lambdaMethods2.Single();
            var parameterMethod = Context.Instance.Expression.GetMembers("Parameter").OfType<IMethodSymbol>().Single(x => x.Parameters.Count() == 2 && Equals(x.Parameters[0].Type, Context.Instance.TypeType) && Equals(x.Parameters[1].Type, Context.Instance.String));
            lambdaMethod = lambdaMethod.Construct(delegateType);

            var jsLambda = idioms.InvokeStatic(lambdaMethod);

            // Convert parameters
            var workspace = new JsBlockStatement();
            var jsParameters = Js.Array();
            for (var i = 0; i < delegateMethod.Parameters.Count(); i++)
            {
                var delegateParameter = delegateMethod.Parameters[i];
                var lambdaParameter = lambdaParameters[i];
                var jsParameter = idioms.InvokeStatic(parameterMethod, idioms.TypeOf(delegateParameter.Type), Js.Primitive(lambdaParameter.Identifier.ToString()));
                var parameterVariableName = "$lambdaparam$" + lambdaParameter.Identifier;
                parameterVariables[lambdaParameter.Identifier.ToString()] = parameterVariableName;

                // Declare a variable to hold the parameter object in the parenthetical's scope
                workspace.Local(parameterVariableName, jsParameter);

                // Add a reference to this variable (a ParameterExpression) as one of the 
                // parameters to the lambda.
                jsParameters.Elements.Add(Js.Reference(parameterVariableName));
            }

            var jsBody = body.Accept(this);

            jsLambda.AddArgument(jsBody);
            jsLambda.AddArgument(jsParameters);
            workspace.Return(jsLambda);

            return idioms.Wrap(workspace);
        }

        public override JsExpression VisitIdentifierName(IdentifierNameSyntax node)
        {
            var key = node.Identifier.ToString();
            var symbol = model.GetSymbolInfo(node).Symbol;
            if (parameterVariables.ContainsKey(key))
            {
                return Js.Reference(parameterVariables[key]);
            }
            else
            {
                var constantMethod = Context.Instance.Expression.GetMethod("Constant", Context.Instance.ObjectType, Context.Instance.TypeType);
                var typeInfo = model.GetTypeInfo(node);
                JsExpression keyReference;
                if (symbol is ILocalSymbol)
                    keyReference = Js.Reference(key);
                else 
                    keyReference = idioms.MemberReference(Js.This(), symbol);
                return idioms.InvokeStatic(constantMethod, keyReference, idioms.TypeOf(typeInfo.ConvertedType));
            }
        }

        public override JsExpression VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            var constantMethod = Context.Instance.Expression.GetMethod("Constant", Context.Instance.ObjectType, Context.Instance.TypeType);
            var typeInfo = model.GetTypeInfo(node);
            return idioms.InvokeStatic(constantMethod, Js.Literal(node.Token.Value), idioms.TypeOf(typeInfo.ConvertedType));
        }

        public override JsExpression VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            switch (node.CSharpKind())
            {
                case SyntaxKind.IsExpression:
                {
                    var operand = node.Left.Accept(this);
                    var type = (INamedTypeSymbol)model.GetSymbolInfo(node.Right).Symbol;
                    var typeIs = GetExpressionMethod("TypeIs", Context.Instance.Expression, Context.Instance.TypeType);
                    return idioms.InvokeStatic(typeIs, operand, idioms.TypeOf(type));
                }
                case SyntaxKind.AsExpression:
                {
                    var operand = node.Left.Accept(this);
                    var type = (INamedTypeSymbol)model.GetSymbolInfo(node.Right).Symbol;
                    var typeAs = GetExpressionMethod("TypeAs", Context.Instance.Expression, Context.Instance.TypeType);
                    return idioms.InvokeStatic(typeAs, operand, idioms.TypeOf(type));
                }
            }

            ExpressionType op;
            switch (node.CSharpKind())
            {
                case SyntaxKind.AddExpression:
                    op = ExpressionType.Add;
                    break;
                case SyntaxKind.MultiplyExpression:
                    op = ExpressionType.Multiply;
                    break;
                case SyntaxKind.BitwiseAndExpression:
                    op = ExpressionType.And;
                    break;
                case SyntaxKind.BitwiseOrExpression:
                    op = ExpressionType.Or;
                    break;
                case SyntaxKind.DivideExpression:
                    op = ExpressionType.Divide;
                    break;
                case SyntaxKind.GreaterThanExpression:
                    op = ExpressionType.GreaterThan;
                    break;
                case SyntaxKind.EqualsExpression:
                    op = ExpressionType.Equal;
                    break;
                case SyntaxKind.ExclusiveOrExpression:
                    op = ExpressionType.OrElse;
                    break;
                case SyntaxKind.GreaterThanOrEqualExpression:
                    op = ExpressionType.GreaterThanOrEqual;
                    break;
                case SyntaxKind.LessThanExpression:
                    op = ExpressionType.LessThan;
                    break;
                case SyntaxKind.LessThanOrEqualExpression:
                    op = ExpressionType.LessThanOrEqual;
                    break;
                case SyntaxKind.ModuloExpression:
                    op = ExpressionType.Modulo;
                    break;
                case SyntaxKind.LeftShiftExpression:
                    op = ExpressionType.LeftShift;
                    break;
                case SyntaxKind.RightShiftExpression:
                    op = ExpressionType.RightShift;
                    break;
                case SyntaxKind.SubtractExpression:
                    op = ExpressionType.Subtract;
                    break;
                case SyntaxKind.CoalesceExpression:
                    op = ExpressionType.Coalesce;
                    break;
                case SyntaxKind.LogicalAndExpression:
                    op = ExpressionType.AndAlso;
                    break;
                case SyntaxKind.LogicalOrExpression:
                    op = ExpressionType.OrElse;
                    break;
                default:
                    throw new Exception("Unknown operation: " + node.CSharpKind());
            }

            var left = node.Left.Accept(this);
            var right = node.Right.Accept(this);
            
            var jsMethodInfo = GetExpressionMethod("MakeBinary", Context.Instance.ExpressionType, Context.Instance.Expression, Context.Instance.Expression);
            var opExpression = idioms.GetEnumValue(Context.Instance.ExpressionType.GetMembers(op.ToString()).OfType<IFieldSymbol>().Single());

            var jsMethod = idioms.InvokeStatic(jsMethodInfo, opExpression, left, right);

            return jsMethod;
        }

        public override JsExpression VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node);
            var target = node.Expression.Accept(this);
            var arguments = node.ArgumentList.Arguments[0].Accept(this);

            if (symbol.Symbol is IPropertySymbol)
            {
                var property = (IPropertySymbol)symbol.Symbol;
                var propertyInfo = idioms.MemberOf(property);
                var jsMethodInfo = GetExpressionMethod("MakeIndex", Context.Instance.Expression, Context.Instance.PropertyInfo, Context.Instance.EnumerableGeneric.Construct(Context.Instance.Expression));
                return idioms.InvokeStatic(jsMethodInfo, target, propertyInfo, Js.Array(node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToArray()));
            }
            else
            {
                if (node.ArgumentList.Arguments.Count == 1)
                {
                    var jsMethodInfo = GetExpressionMethod("ArrayIndex", Context.Instance.Expression, Context.Instance.Expression);
                    return idioms.InvokeStatic(jsMethodInfo, target, node.ArgumentList.Arguments.Single().Accept(this));
                }
                else
                {
                    var jsMethodInfo = GetExpressionMethod("ArrayIndex", Context.Instance.Expression, Context.Instance.ExpressionArray);
                    return idioms.InvokeStatic(jsMethodInfo, target, node.ArgumentList.Arguments.Single().Accept(this));
                }
            }
        }

        public override JsExpression VisitArgument(ArgumentSyntax node)
        {
            return node.Expression.Accept(this);
        }

        public override JsExpression VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            var jsMethodInfo = GetExpressionMethod("Condition", Context.Instance.Expression, Context.Instance.Expression, Context.Instance.Expression, Context.Instance.TypeType);
            var type = model.GetTypeInfo(node).ConvertedType;
            return idioms.InvokeStatic(jsMethodInfo, 
                node.Condition.Accept(this),
                node.WhenTrue.Accept(this),
                node.WhenFalse.Accept(this),
                idioms.TypeOf(type));
        }

        public override JsExpression VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            var type = model.GetTypeInfo(node).ConvertedType;
            var jsMethodInfo = GetExpressionMethod("Default", Context.Instance.TypeType);
            return idioms.InvokeStatic(jsMethodInfo, idioms.TypeOf(type));
        }

        public override JsExpression VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node).Symbol;
            var method = (IMethodSymbol)symbol;
            if (method.IsStatic)
            {
                var jsMethodInfo = GetExpressionMethod("Call", Context.Instance.MethodInfo, Context.Instance.ExpressionArray);
                var arguments = node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToList();
                return idioms.InvokeStatic(jsMethodInfo, idioms.MemberOf(method), Js.Array(arguments.ToArray()));
            }
            if (method.ContainingType.DelegateInvokeMethod != method)
            {
                var jsMethodInfo = GetExpressionMethod("Call", Context.Instance.Expression, Context.Instance.MethodInfo, Context.Instance.ExpressionArray);
                var methodTarget = ((MemberAccessExpressionSyntax)node.Expression).Expression.Accept(this);
                var arguments = node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToArray();
                var jsMethod = idioms.InvokeStatic(jsMethodInfo, methodTarget, idioms.MemberOf(method), idioms.MakeArray(Js.Array(arguments), Context.Instance.ExpressionArray));
                return jsMethod;                
            }
            else 
            {
                var jsMethodInfo = GetExpressionMethod("Invoke", Context.Instance.Expression, Context.Instance.ExpressionArray);
                var target = node.Expression.Accept(this);
                var arguments = node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToArray();
                return idioms.InvokeStatic(jsMethodInfo, target, idioms.MakeArray(Js.Array(arguments), Context.Instance.ExpressionArray));
            }
        }

        private JsExpression VisitMemberInit(BinaryExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node.Left).Symbol;
            var member = idioms.MemberOf(symbol);

            //System.Linq.Expressions.Expression.Bind(MemberInfo, Expression)
            var jsMethodInfo = GetExpressionMethod("Bind", Context.Instance.MemberInfo, Context.Instance.Expression);
            return idioms.InvokeStatic(jsMethodInfo, member, node.Right.Accept(this));
        }

        public override JsExpression VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            var constructor = (IMethodSymbol)model.GetSymbolInfo(node).Symbol;
            var jsConstructor = idioms.MemberOf(constructor);
            var args = node.ArgumentList == null ? new JsExpression[0] : node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToArray();
            var jsMethodInfo = GetExpressionMethod("New", Context.Instance.ConstructorInfo, Context.Instance.ExpressionArray);
            var jsMethod = idioms.InvokeStatic(jsMethodInfo, jsConstructor, Js.Array(args));
            
            if (node.Initializer != null && node.Initializer.Expressions.Count > 0)
            {
                if (node.Initializer.CSharpKind() == SyntaxKind.ObjectInitializerExpression)
                {
                    var memberInit = GetExpressionMethod("MemberInit", Context.Instance.NewExpression, Context.Instance.MemberBindingArray);
                    var jsMemberInit = idioms.InvokeStatic(
                        memberInit, 
                        jsMethod,
                        idioms.Array(Context.Instance.MemberBindingArray, node.Initializer.Expressions.Select(x => VisitMemberInit((BinaryExpressionSyntax)x)).ToArray()));
                    return jsMemberInit;
                }
                else 
                {
                    var firstItem = node.Initializer.Expressions.First();
                    var items = new List<List<ExpressionSyntax>>();
                    var subitemCount = 1;
                    if (firstItem is InitializerExpressionSyntax)
                    {
                        var initializer = (InitializerExpressionSyntax)firstItem;
                        items.AddRange(node.Initializer.Expressions.Select(x => ((InitializerExpressionSyntax)x).Expressions.ToList()));
                        subitemCount = initializer.Expressions.Count;
                    }
                    else
                    {
                        items.AddRange(node.Initializer.Expressions.Select(x => new List<ExpressionSyntax> { x }));
                    }
                    var addMethodInfo = constructor.ContainingType.GetMembers("Add").OfType<IMethodSymbol>().First(x => x.Parameters.Count() == subitemCount);
                    var addMethod = idioms.MemberOf(addMethodInfo);
                    var elementInitMethodInfo = GetExpressionMethod("ElementInit", Context.Instance.MethodInfo, Context.Instance.ExpressionArray);
                    var jsMemberInitMethodInfo = GetExpressionMethod("ListInit", Context.Instance.NewExpression, Context.Instance.ElementInitArray);

                    var jsMemberInitMethod = idioms.InvokeStatic(
                        jsMemberInitMethodInfo,
                        jsMethod,
                        idioms.MakeArray(Js.Array(items
                            .Select(x => idioms.InvokeStatic(
                                elementInitMethodInfo, 
                                addMethod,
                                idioms.MakeArray(Js.Array(x.Select(y => y.Accept(this)).ToArray()), Context.Instance.ExpressionArray)))
                            .ToArray()), Context.Instance.ElementInitArray));
                    return jsMemberInitMethod;                    
                }
            }
            else
            {
               return jsMethod;            
            }
        }

        public override JsExpression VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            var jsMethodInfo = GetExpressionMethod("MakeMemberAccess");
            var symbol = model.GetSymbolInfo(node).Symbol;
            var jsMethod = idioms.InvokeStatic(jsMethodInfo, 
                node.Expression.Accept(this),
                idioms.MemberOf(symbol));
            return jsMethod;                                
        }

        public override JsExpression VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            var type = (IArrayTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            var elementType = type.ElementType;
            var newArrayInit = GetExpressionMethod("NewArrayInit", Context.Instance.TypeType, Context.Instance.ExpressionArray);
            var jsMethod = idioms.InvokeStatic(
                newArrayInit,
                idioms.TypeOf(elementType),
                idioms.Array(Context.Instance.ExpressionArray, node.Initializer.Expressions.Select(x => x.Accept(this)).ToArray()));
            return jsMethod;
        }

        public override JsExpression VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            var type = (IArrayTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            var elementType = type.ElementType;
            if (node.Initializer != null)
            {
                var newArrayInit = GetExpressionMethod("NewArrayInit", Context.Instance.TypeType, Context.Instance.ExpressionArray);
                var jsMethod = idioms.InvokeStatic(
                    newArrayInit,
                    idioms.TypeOf(elementType),
                    idioms.Array(Context.Instance.ExpressionArray, node.Initializer.Expressions.Select(x => x.Accept(this)).ToArray()));
                return jsMethod;
            }
            else
            {
                var jsMethodInfo = GetExpressionMethod("NewArrayBounds", Context.Instance.TypeType, Context.Instance.ExpressionArray);
                var jsMethod = idioms.InvokeStatic(
                    jsMethodInfo, 
                    idioms.TypeOf(elementType), 
                    idioms.Array(Context.Instance.ExpressionArray, node.Type.RankSpecifiers[0].Sizes.Select(x => x.Accept(this)).ToArray()));
                return jsMethod;
            }
        }

        public override JsExpression VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
 	         return VisitUnaryExpression(node, node.Operand);
        }

        public override JsExpression VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
 	         return VisitUnaryExpression(node, node.Operand);
        }

        public JsExpression VisitUnaryExpression(ExpressionSyntax node, ExpressionSyntax expression)
        {
            ExpressionType op;
            switch (node.CSharpKind())
            {
                case SyntaxKind.LogicalNotExpression:
                    op = ExpressionType.Not;
                    break;
                case SyntaxKind.UnaryMinusExpression:
                    op = ExpressionType.Negate;
                    break;
                case SyntaxKind.PostDecrementExpression:
                case SyntaxKind.PostIncrementExpression:
                    throw new Exception("Expression trees cannot contain assignment operators.");
                default:
                    throw new Exception("Unknown operation: " + node.CSharpKind());
            }

            var makeUnary = GetExpressionMethod("MakeUnary", Context.Instance.ExpressionType, Context.Instance.Expression, Context.Instance.TypeType);
            var opExpression = idioms.GetEnumValue(Context.Instance.ExpressionType.GetMembers(op.ToString()).OfType<IFieldSymbol>().Single());
            var operand = expression.Accept(this);
            var type = model.GetTypeInfo(node).ConvertedType;
            return idioms.InvokeStatic(
                makeUnary,
                opExpression,
                operand,
                idioms.TypeOf(type));
        }
    }
}
