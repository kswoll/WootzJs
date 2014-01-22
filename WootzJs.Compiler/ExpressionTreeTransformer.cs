using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class ExpressionTreeTransformer : SyntaxVisitor<JsExpression>
    {
        private Context context;
        private Idioms idioms;
        private SemanticModel model;
        private Dictionary<string, string> parameterVariables;

        public ExpressionTreeTransformer(Context context, SemanticModel model, Idioms idioms)
        {
            this.context = context;
            this.model = model;
            this.idioms = idioms;
            this.parameterVariables = new Dictionary<string, string>();
        }

        public override JsExpression DefaultVisit(SyntaxNode node)
        {
            throw new Exception();
        }

        private MethodSymbol GetExpressionMethod(string methodName, params TypeSymbol[] parameterTypes)
        {
            return context.Expression.GetMethod(methodName, parameterTypes);
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

        private JsExpression VisitLambdaExpression(ExpressionSyntax node, ParameterSyntax[] parameters, SyntaxNode body)
        {
            var expressionType = (NamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            NamedTypeSymbol delegateType;
            if (expressionType.OriginalDefinition == context.ExpressionGeneric)
                delegateType = (NamedTypeSymbol)expressionType.TypeArguments[0];
            else
                delegateType = expressionType;
            var lambdaParameters = parameters.ToArray();
            var delegateMethod = (MethodSymbol)delegateType.GetMembers("Invoke")[0]; 
//            Compiler.CsCompilation.FindType()
            var lambdaMethods = context.Expression.GetMembers("Lambda").OfType<MethodSymbol>().ToArray();
            var lambdaMethods2 = lambdaMethods.Where(x => x.TypeParameters.Count == 1 && x.Parameters.Count == 2 && x.Parameters[0].Type == context.Expression && x.Parameters[1].Type == context.ParameterExpressionArray).ToArray();
            var lambdaMethod = lambdaMethods2.Single();
            var parameterMethod = context.Expression.GetMembers("Parameter").OfType<MethodSymbol>().Single(x => x.Parameters.Count == 2 && x.Parameters[0].Type == context.TypeType && x.Parameters[1].Type == context.String);
            lambdaMethod = lambdaMethod.Construct(delegateType);

            var jsLambda = idioms.InvokeStatic(lambdaMethod);

            // Convert parameters
            var workspace = new JsBlockStatement();
            var jsParameters = Js.Array();
            for (var i = 0; i < delegateMethod.Parameters.Count; i++)
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
            if (parameterVariables.ContainsKey(key))
            {
                return Js.Reference(parameterVariables[key]);
            }
            else
            {
                var constantMethod = context.Expression.GetMethod("Constant", context.ObjectType, context.TypeType);
                var typeInfo = model.GetTypeInfo(node);
                return idioms.InvokeStatic(constantMethod, Js.Reference(key), idioms.TypeOf(typeInfo.ConvertedType));
            }
        }

        public override JsExpression VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            var constantMethod = context.Expression.GetMethod("Constant", context.ObjectType, context.TypeType);
            var typeInfo = model.GetTypeInfo(node);
            return idioms.InvokeStatic(constantMethod, Js.Literal(node.Token.Value), idioms.TypeOf(typeInfo.ConvertedType));
        }

        public override JsExpression VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            switch (node.Kind)
            {
                case SyntaxKind.IsExpression:
                {
                    var operand = node.Left.Accept(this);
                    var type = (NamedTypeSymbol)model.GetSymbolInfo(node.Right).Symbol;
                    var typeIs = GetExpressionMethod("TypeIs", context.Expression, context.TypeType);
                    return idioms.InvokeStatic(typeIs, operand, idioms.TypeOf(type));
                }
                case SyntaxKind.AsExpression:
                {
                    var operand = node.Left.Accept(this);
                    var type = (NamedTypeSymbol)model.GetSymbolInfo(node.Right).Symbol;
                    var typeAs = GetExpressionMethod("TypeAs", context.Expression, context.TypeType);
                    return idioms.InvokeStatic(typeAs, operand, idioms.TypeOf(type));
                }
            }

            ExpressionType op;
            switch (node.Kind)
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
                    throw new Exception("Unknown operation: " + node.Kind);
            }

            var left = node.Left.Accept(this);
            var right = node.Right.Accept(this);
            
            var jsMethodInfo = GetExpressionMethod("MakeBinary", context.ExpressionType, context.Expression, context.Expression);
            var opExpression = idioms.GetEnumValue(context.ExpressionType.GetMembers(op.ToString()).OfType<FieldSymbol>().Single());

            var jsMethod = idioms.InvokeStatic(jsMethodInfo, opExpression, left, right);

            return jsMethod;
        }

        public override JsExpression VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node);
            var target = node.Expression.Accept(this);
            var arguments = node.ArgumentList.Arguments[0].Accept(this);

            if (symbol.Symbol is PropertySymbol)
            {
                var property = (PropertySymbol)symbol.Symbol;
                var propertyInfo = idioms.MemberOf(property);
                var jsMethodInfo = GetExpressionMethod("MakeIndex", context.Expression, context.PropertyInfo, context.EnumerableGeneric.Construct(context.Expression));
                return idioms.InvokeStatic(jsMethodInfo, target, propertyInfo, Js.Array(node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToArray()));
            }
            else
            {
                if (node.ArgumentList.Arguments.Count == 1)
                {
                    var jsMethodInfo = GetExpressionMethod("ArrayIndex", context.Expression, context.Expression);
                    return idioms.InvokeStatic(jsMethodInfo, target, node.ArgumentList.Arguments.Single().Accept(this));
                }
                else
                {
                    var jsMethodInfo = GetExpressionMethod("ArrayIndex", context.Expression, context.ExpressionArray);
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
            var jsMethodInfo = GetExpressionMethod("Condition", context.Expression, context.Expression, context.Expression, context.TypeType);
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
            var jsMethodInfo = GetExpressionMethod("Default", context.TypeType);
            return idioms.InvokeStatic(jsMethodInfo, idioms.TypeOf(type));
        }

        public override JsExpression VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node).Symbol;
            var method = (MethodSymbol)symbol;
            if (method.IsStatic)
            {
                var jsMethodInfo = GetExpressionMethod("Call", context.MethodInfo, context.ExpressionArray);
                var arguments = node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToList();
                return idioms.InvokeStatic(jsMethodInfo, idioms.MemberOf(method), Js.Array(arguments.ToArray()));
            }
            if (method.ContainingType.DelegateInvokeMethod != method)
            {
                var jsMethodInfo = GetExpressionMethod("Call", context.Expression, context.MethodInfo, context.ExpressionArray);
                var methodTarget = ((MemberAccessExpressionSyntax)node.Expression).Expression.Accept(this);
                var arguments = node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToArray();
                var jsMethod = idioms.InvokeStatic(jsMethodInfo, methodTarget, idioms.MemberOf(method), idioms.MakeArray(Js.Array(arguments), context.ExpressionArray));
                return jsMethod;                
            }
            else 
            {
                var jsMethodInfo = GetExpressionMethod("Invoke", context.Expression, context.ExpressionArray);
                var target = node.Expression.Accept(this);
                var arguments = node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToArray();
                return idioms.InvokeStatic(jsMethodInfo, target, idioms.MakeArray(Js.Array(arguments), context.ExpressionArray));
            }
        }

        private JsExpression VisitMemberInit(BinaryExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node.Left).Symbol;
            var member = idioms.MemberOf(symbol);

            //System.Linq.Expressions.Expression.Bind(MemberInfo, Expression)
            var jsMethodInfo = GetExpressionMethod("Bind", context.MemberInfo, context.Expression);
            return idioms.InvokeStatic(jsMethodInfo, member, node.Right.Accept(this));
        }

        public override JsExpression VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            var constructor = (MethodSymbol)model.GetSymbolInfo(node).Symbol;
            var jsConstructor = idioms.MemberOf(constructor);
            var args = node.ArgumentList == null ? new JsExpression[0] : node.ArgumentList.Arguments.Select(x => x.Accept(this)).ToArray();
            var jsMethodInfo = GetExpressionMethod("New", context.ConstructorInfo, context.ExpressionArray);
            var jsMethod = idioms.InvokeStatic(jsMethodInfo, jsConstructor, Js.Array(args));
            
            if (node.Initializer != null && node.Initializer.Expressions.Count > 0)
            {
                if (node.Initializer.Kind == SyntaxKind.ObjectInitializerExpression)
                {
                    var memberInit = GetExpressionMethod("MemberInit", context.NewExpression, context.MemberBindingArray);
                    var jsMemberInit = idioms.InvokeStatic(
                        memberInit, 
                        jsMethod,
                        idioms.Array(context.MemberBindingArray, node.Initializer.Expressions.Select(x => VisitMemberInit((BinaryExpressionSyntax)x)).ToArray()));
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
                    var addMethodInfo = constructor.ContainingType.GetMembers("Add").OfType<MethodSymbol>().First(x => x.Parameters.Count == subitemCount);
                    var addMethod = idioms.MemberOf(addMethodInfo);
                    var elementInitMethodInfo = GetExpressionMethod("ElementInit", context.MethodInfo, context.ExpressionArray);
                    var jsMemberInitMethodInfo = GetExpressionMethod("ListInit", context.NewExpression, context.ElementInitArray);

                    var jsMemberInitMethod = idioms.InvokeStatic(
                        jsMemberInitMethodInfo,
                        jsMethod,
                        idioms.MakeArray(Js.Array(items
                            .Select(x => idioms.InvokeStatic(
                                elementInitMethodInfo, 
                                addMethod,
                                idioms.MakeArray(Js.Array(x.Select(y => y.Accept(this)).ToArray()), context.ExpressionArray)))
                            .ToArray()), context.ElementInitArray));
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
            var type = (ArrayTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            var elementType = type.ElementType;
            var newArrayInit = GetExpressionMethod("NewArrayInit", context.TypeType, context.ExpressionArray);
            var jsMethod = idioms.InvokeStatic(
                newArrayInit,
                idioms.TypeOf(elementType),
                idioms.Array(context.ExpressionArray, node.Initializer.Expressions.Select(x => x.Accept(this)).ToArray()));
            return jsMethod;
        }

        public override JsExpression VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            var type = (ArrayTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            var elementType = type.ElementType;
            if (node.Initializer != null)
            {
                var newArrayInit = GetExpressionMethod("NewArrayInit", context.TypeType, context.ExpressionArray);
                var jsMethod = idioms.InvokeStatic(
                    newArrayInit,
                    idioms.TypeOf(elementType),
                    idioms.Array(context.ExpressionArray, node.Initializer.Expressions.Select(x => x.Accept(this)).ToArray()));
                return jsMethod;
            }
            else
            {
                var jsMethodInfo = GetExpressionMethod("NewArrayBounds", context.TypeType, context.ExpressionArray);
                var jsMethod = idioms.InvokeStatic(
                    jsMethodInfo, 
                    idioms.TypeOf(elementType), 
                    idioms.Array(context.ExpressionArray, node.Type.RankSpecifiers[0].Sizes.Select(x => x.Accept(this)).ToArray()));
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
            switch (node.Kind)
            {
                case SyntaxKind.LogicalNotExpression:
                    op = ExpressionType.Not;
                    break;
                case SyntaxKind.NegateExpression:
                    op = ExpressionType.Negate;
                    break;
                case SyntaxKind.PostDecrementExpression:
                case SyntaxKind.PostIncrementExpression:
                    throw new Exception("Expression trees cannot contain assignment operators.");
                default:
                    throw new Exception("Unknown operation: " + node.Kind);
            }

            var makeUnary = GetExpressionMethod("MakeUnary", context.ExpressionType, context.Expression, context.TypeType);
            var opExpression = idioms.GetEnumValue(context.ExpressionType.GetMembers(op.ToString()).OfType<FieldSymbol>().Single());
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