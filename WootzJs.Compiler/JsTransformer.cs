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
using System.Runtime.WootzJs;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using WootzJs.Compiler.JsAst;
using Microsoft.CodeAnalysis.CSharp;

namespace WootzJs.Compiler
{
    public class JsTransformer : CSharpSyntaxVisitor<JsNode>
    {
        internal SyntaxTree syntaxTree;
        internal SemanticModel model;
        internal Idioms idioms;
        internal List<JsBlockStatement> outputBlockStack = new List<JsBlockStatement>();
        private Dictionary<ISymbol, IJsDeclaration> declarationsBySymbol = new Dictionary<ISymbol, IJsDeclaration>();
        private Stack<IJsDeclaration> initializableObjectsStack = new Stack<IJsDeclaration>();
        private Stack<ISymbol> declarationStack = new Stack<ISymbol>();
        private Stack<LoopEntry> loopLabels = new Stack<LoopEntry>();
        private JsCompilationUnit compilationUnit;
        private Stack<JsExpression> memberBindingTargets = new Stack<JsExpression>();

        public JsTransformer(SyntaxTree syntaxTree, SemanticModel model, JsCompilationUnit compilationUnit)
        {
            this.syntaxTree = syntaxTree;
            this.model = model;
            this.compilationUnit = compilationUnit;
            idioms = new Idioms(this);
        }

        public JsTransformer(Idioms idioms) 
        {
            syntaxTree = idioms.transformer.syntaxTree;
            model = idioms.transformer.model;
            compilationUnit = idioms.transformer.compilationUnit;
            this.idioms = new Idioms(this);
            declarationsBySymbol = new Dictionary<ISymbol, IJsDeclaration>(idioms.transformer.declarationsBySymbol);
            outputBlockStack = idioms.transformer.outputBlockStack.ToList();
            initializableObjectsStack = new Stack<IJsDeclaration>(idioms.transformer.initializableObjectsStack.Reverse());
            declarationStack = new Stack<ISymbol>(idioms.transformer.declarationStack.Reverse());
            loopLabels = new Stack<LoopEntry>(idioms.transformer.loopLabels.Reverse());
        }

        public SemanticModel Model => model;

        public int GetLabelDepth(string label)
        {
            foreach (var entry in loopLabels)
            {
                if (entry.Label == label)
                    return entry.Depth;
            }
            throw new Exception();
        }

        public bool IsDeclaredInScope(Scope scope, string name)
        {
            var declaration = scope[name];
            return declaration != null;
        }

        public void DeclareInCurrentScope(ISymbol symbol, IJsDeclaration declaration)
        {
            declarationsBySymbol[symbol] = declaration;
        }

        private Dictionary<ISymbol, int> currentAnonymousNames = new Dictionary<ISymbol, int>();

        public string GenerateUniqueNameInScope()
        {
            int ordinal;
            if (!currentAnonymousNames.TryGetValue(CurrentDeclaration, out ordinal))
            {
                ordinal = 1;
                currentAnonymousNames[CurrentDeclaration] = ordinal;
            }
            else
            {
                ordinal++;
                currentAnonymousNames[CurrentDeclaration] = ordinal;
            }

            return "$anon$" + ordinal;
        }

        public IJsDeclaration ReferenceDeclarationInScope(ISymbol symbol)
        {
            IJsDeclaration declaration;
            if (declarationsBySymbol.TryGetValue(symbol, out declaration))
            {
                return declaration;
            }
            throw new InvalidOperationException("Symbol not found in scope: " + symbol);
        }

        public void PushOutput(JsBlockStatement node)
        {
            outputBlockStack.Add(node);
        }

        public void PopOutput()
        {
            outputBlockStack.RemoveAt(outputBlockStack.Count - 1);
        }

        public JsBlockStatement GetCurrentBlock() 
        {
            return outputBlockStack.Last();
        }

        public void PushDeclaration(ISymbol symbol)
        {
            declarationStack.Push(symbol);
        }

        public void PopDeclaration()
        {
            declarationStack.Pop();
        }

        public ISymbol CurrentDeclaration => declarationStack.Peek();

        public override JsNode DefaultVisit(SyntaxNode node)
        {
            var result = base.DefaultVisit(node);
            if (result == null)
                throw new Exception("No result returned for " + node.GetType().FullName);
            return result;
        }

        public override JsNode VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            var jsBlock = new JsBlockStatement();
            var classType = model.GetDeclaredSymbol(node);
            var isExported = classType.IsExported();
            if (!isExported)
                return jsBlock;

            PushDeclaration(classType);
            JsBlockStatement typeInitializer;
            JsBlockStatement staticInitializer;
            jsBlock.Aggregate(idioms.CreateTypeFunction(classType, out typeInitializer, out staticInitializer));

            foreach (var member in node.Members)
            {
                var block = (JsBlockStatement)member.Accept(this);
                typeInitializer.Aggregate(block);
            }

            PopDeclaration();
            return jsBlock;
        }

        public override JsNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var jsBlock = new JsBlockStatement();
            if (idioms.TryUnwrapSpecialFunctions(node, compilationUnit))
                return jsBlock;

            var classType = model.GetDeclaredSymbol(node);
            var isExported = classType.IsExported();
            if (!isExported)
                return jsBlock;

            PushDeclaration(classType);

            JsBlockStatement typeInitializer;
            JsBlockStatement staticInitializer;
            jsBlock.Aggregate(idioms.CreateTypeFunction(classType, out typeInitializer, out staticInitializer));

            if (!node.Members.OfType<ConstructorDeclarationSyntax>().Any(x => !x.Modifiers.Any(y => y.Kind() == SyntaxKind.StaticKeyword)) && !classType.IsStatic)
            {
                typeInitializer.Aggregate(idioms.CreateDefaultConstructor(node));
            }

            foreach (var member in node.Members)
            {
                var block = (JsBlockStatement)member.Accept(this);
                typeInitializer.Aggregate(block);
            }

            // Initialize all the static fields
            staticInitializer.Aggregate(idioms.InitializeStaticFields(node));

            // Call all static initializers in sequence
            foreach (var constructor in node.Members.OfType<ConstructorDeclarationSyntax>())
            {
                var constructorSymbol = model.GetDeclaredSymbol(constructor);
                if (constructorSymbol.IsStatic)
                {
                    var body = (JsBlockStatement)constructor.Body.Accept(this);
                    staticInitializer.Aggregate(body);
                }
            }

            PopDeclaration();
            return jsBlock;
        }

        public override JsNode VisitStructDeclaration(StructDeclarationSyntax node)
        {
            var jsBlock = new JsBlockStatement();

            var classType = model.GetDeclaredSymbol(node);
            var isExported = classType.IsExported();
            if (!isExported)
                return jsBlock;

            PushDeclaration(classType);
            JsBlockStatement typeInitializer;
            JsBlockStatement staticInitializer;
            jsBlock.Aggregate(idioms.CreateTypeFunction(classType, out typeInitializer, out staticInitializer));

            if (!node.Members.OfType<ConstructorDeclarationSyntax>().Any() && !classType.IsStatic)
            {
                typeInitializer.Aggregate(idioms.CreateDefaultConstructor(node));
            }

            foreach (var member in node.Members)
            {
                var block = (JsBlockStatement)member.Accept(this);
                typeInitializer.Aggregate(block);
            }

            // Initialize all the static fields
            staticInitializer.Aggregate(idioms.InitializeStaticFields(node));

            // Call all static initializers in sequence
            foreach (var constructor in node.Members.OfType<ConstructorDeclarationSyntax>())
            {
                var constructorSymbol = model.GetDeclaredSymbol(constructor);
                if (constructorSymbol.IsStatic)
                {
                    var body = (JsBlockStatement)constructor.Body.Accept(this);
                    staticInitializer.Aggregate(body);
                }
            }

            PopDeclaration();

            return jsBlock;
        }

        public override JsNode VisitEnumDeclaration(EnumDeclarationSyntax node)
        {
            var jsBlock = new JsBlockStatement();

            var enumType = model.GetDeclaredSymbol(node);
            var isExported = enumType.IsExported();
            if (!isExported)
                return jsBlock;

            PushDeclaration(enumType);

            JsBlockStatement typeInitializer;
            JsBlockStatement staticInitializer;
            jsBlock.Aggregate(idioms.CreateTypeFunction(enumType, out typeInitializer, out staticInitializer));

            // Create special enum constructor
            var constructorNameParameter = Js.Parameter("name");
            var constructorValueParameter = Js.Parameter("value");
            var constructorBlock = new JsBlockStatement();
            constructorBlock.Express(idioms.InvokeMethodAsThis(Context.Instance.EnumType.Constructors.First(x => !x.IsStatic), 
                constructorNameParameter.GetReference(), constructorValueParameter.GetReference()));
            typeInitializer.Add(idioms.StoreInPrototype("$ctor", Js.Reference(SpecialNames.DefineConstructor).Invoke(
                Js.Reference(SpecialNames.TypeInitializerTypeFunction), 
                Js.Function(constructorNameParameter, constructorValueParameter).Body(constructorBlock))));

            // Instantiate all the enum members
            IFieldSymbol lastEnum = null;
            for (var i = 0; i < node.Members.Count; i++)
            {
                var enumValue = node.Members[i];
                var enumSymbol = model.GetDeclaredSymbol(enumValue);
                
                JsExpression value = null;
                if (enumValue.EqualsValue != null)
                    value = (JsExpression)enumValue.EqualsValue.Accept(this);
                if (lastEnum == null && value == null)
                    value = Js.Primitive(0);
                if (value == null)
                    value = idioms.Invoke(idioms.GetEnumValue(lastEnum), Context.Instance.EnumGetValue).Add(Js.Primitive(1));

                lastEnum = enumSymbol;                    

                staticInitializer.Add(idioms.StoreInType(enumValue.Identifier.ToString(), 
                    idioms.GetFromPrototype("$ctor").Member("$new").Invoke(
                        Js.Primitive(enumValue.Identifier.ToString()), value)));
            }

            PopDeclaration();
            return jsBlock;
        }

        public override JsNode VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            var block = new JsBlockStatement();

/*
            foreach (var variable in node.Declaration.Variables)
            {
                var field = (FieldSymbol)model.GetDeclaredSymbol(variable);
                if (!field.IsExported())
                    continue;

                PushDeclaration(field);
                block.Add(idioms.StoreInPrototype(field.GetMemberName(), idioms.DefaultValue(field.Type)));
                PopDeclaration();
            }
*/

            return block;
        }

        public override JsNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            var block = new JsBlockStatement();

            var property = model.GetDeclaredSymbol(node);
            var isExported = property.IsExported();
            if (!isExported)
                return block;

            var getter = node.AccessorList?.Accessors.SingleOrDefault(x => x.Keyword.IsKind(SyntaxKind.GetKeyword));
            var setter = node.AccessorList?.Accessors.SingleOrDefault(x => x.Keyword.IsKind(SyntaxKind.SetKeyword));
            var propertyName = property.GetMemberName();

            Func<string, JsExpression, JsExpressionStatement> storeIn = (member, value) => !property.IsStatic ? idioms.StoreInPrototype(member, value) : idioms.StoreInType(member, value);

            if (property.ContainingType.TypeKind == TypeKind.Interface)
            {
                if (property.GetMethod != null)
                    block.Add(storeIn(property.GetMethod.GetMemberName(), Js.Function().Body(idioms.CreateInterfaceMethod(property.GetMethod))));
                if (property.SetMethod != null)
                    block.Add(storeIn(property.SetMethod.GetMemberName(), Js.Function(Js.Parameter("value")).Body(idioms.CreateInterfaceMethod(property.SetMethod))));
            }
            else if (node.IsAutoProperty())
            {
                if (idioms.IsMinimizedAutoProperty(property))
                {
                    // Do nothing -- handled by idioms.InitializeInstanceFields and idioms.InitializeStaticFields
                }
                else 
                {
                    var backingField = property.GetBackingFieldName();
                    var valueParameter = Js.Parameter("value");

                    block.Add(storeIn(property.GetMethod.GetMemberName(), Js.Function().Body(
                        Js.This().Member(backingField).Return()
                        ).Compact()));

                    // Null for immutable auto-properties
                    if (property.SetMethod != null)
                    {
                        var setterBlock = Js.Block();
                        setterBlock.Assign(Js.This().Member(backingField), valueParameter.GetReference());
                        IMethodSymbol notifyPropertyChanged;
                        if (property.IsAutoNotifyPropertyChange(out notifyPropertyChanged))
                        {
                            setterBlock.Express(idioms.Invoke(Js.This(), notifyPropertyChanged, Js.Primitive(property.Name)));
                        }
                        setterBlock.Return(valueParameter.GetReference()); // We want the property to actually return the newly assigned value, since expressions like `x = y = 5`, where x and y are properties, requires that `y` return the new value.

                        block.Add(storeIn(property.SetMethod.GetMemberName(), Js.Function(valueParameter).Body(setterBlock).Compact()));
                    }
                }
            }
            else
            {
                if (node.ExpressionBody != null)
                {
                    PushDeclaration(property.GetMethod);
                    var body = new JsBlockStatement();
                    PushOutput(body);
                    body.Aggregate(((JsExpression)node.ExpressionBody.Accept(this)).Return());
                    block.Add(storeIn(property.GetMethod.GetMemberName(), Js.Function().Body(body)));
                    PopOutput();
                    PopDeclaration();
                }
                if (getter != null)
                {
                    PushDeclaration(property.GetMethod);
                    var getterBody = new JsBlockStatement();
                    PushOutput(getterBody);
                    if (getter.Body != null)
                        getterBody.Aggregate((JsStatement)getter.Body.Accept(this));
                    block.Add(storeIn(property.GetMethod.GetMemberName(), Js.Function().Body(getterBody)));
                    PopOutput();
                    PopDeclaration();
                }
                if (setter != null)
                {
                    var setterBody = new JsBlockStatement();
                    var valueParameter = Js.Parameter("value");
                    PushDeclaration(property.SetMethod);
                    PushOutput(setterBody);
                    DeclareInCurrentScope(property.SetMethod.Parameters.Last(), valueParameter);
                    if (setter.Body != null)
                        setterBody.Aggregate((JsStatement)setter.Body.Accept(this));
                    IMethodSymbol notifyPropertyChanged;
                    if (property.IsAutoNotifyPropertyChange(out notifyPropertyChanged))
                    {
                        setterBody.Express(idioms.Invoke(Js.This(), notifyPropertyChanged, Js.Primitive(property.Name)));
                    }
                    setterBody.Add(valueParameter.GetReference().Return());   // We want the property to actually return the newly assigned value, since expressions like `x = y = 5`, where x and y are properties, requires that `y` return the new value.
                    block.Add(storeIn("set_" + propertyName, Js.Function(valueParameter).Body(setterBody)));
                    PopOutput();
                    PopDeclaration();
                }                
            }

            // Also store all interface implementations
            var implementedInterfaceMembers = SymbolFinder.FindImplementedInterfaceMembersAsync(property.GetRootOverride(), Context.Instance.Solution).Result;
            foreach (IPropertySymbol interfaceImplementation in implementedInterfaceMembers)
            {
                if (interfaceImplementation.GetMethod != null)
                    block.Add(idioms.MapInterfaceMethod(idioms.GetPrototype(), interfaceImplementation.GetMethod, idioms.GetFromPrototype(property.GetMethod.GetMemberName())));
                if (interfaceImplementation.SetMethod != null)
                    block.Add(idioms.MapInterfaceMethod(idioms.GetPrototype(), interfaceImplementation.SetMethod, idioms.GetFromPrototype(property.SetMethod.GetMemberName())));
            }

            return block;
        }

        public override JsNode VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
        {
            var constructor = model.GetDeclaredSymbol(node);

            var classType = constructor.ContainingType;
            var block = new JsBlockStatement();
            if (constructor.IsStatic)
                return block;

            PushDeclaration(constructor);
            PushOutput(block);

            var parameters = node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)).ToArray();

            var fullTypeName = classType.GetFullName();
            var constructorBlock = new JsBlockStatement();

            var code = constructor.GetCode();
            if (code != null)
            {
                constructorBlock.Aggregate(Js.Native(code));
            }
            else
            {
                constructorBlock.Aggregate(idioms.InitializeInstanceFields((TypeDeclarationSyntax)node.Parent));

                if (fullTypeName != "System.Object")
                {
                    // No explicit initializer was specified, so infer the call to the base class parameterless constructor.
                    if (node.Initializer == null)
                    {
                        constructorBlock.Express(idioms.InvokeParameterlessBaseClassConstructor(classType.BaseType));
                    }
                    else
                    {
                        constructorBlock.Express((JsExpression)node.Initializer.Accept(this));
                    }
                }

                var body = (JsBlockStatement)node.Body.Accept(this);
                constructorBlock.Aggregate(body);                
            }

            var constructorName = constructor.GetMemberName();
            if (!classType.IsBuiltIn())
            {
                block.Add(idioms.StoreInPrototype(constructorName, Js.Reference(SpecialNames.DefineConstructor).Invoke(
                    Js.Reference(SpecialNames.TypeInitializerTypeFunction), 
                    Js.Function(parameters).Body(constructorBlock))));
            }
            else
            {
                block.Add(idioms.StoreInPrototype(constructorName, Js.Function(parameters).Body(constructorBlock)));
                block.Aggregate(idioms.InitializeConstructor(classType, constructorName, constructor.Parameters.ToArray()));                
            }

            PopOutput();
            PopDeclaration();
            return block;
        }

        public override JsNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var method = model.GetDeclaredSymbol(node);
            var block = new JsBlockStatement();

            var code = method.GetCode();
            var isExported = method.IsExported();
            if (!isExported && code == null)
                return block;

            PushDeclaration(method);
            PushOutput(block);
            var parameters = new List<JsParameter>();
            if (node.TypeParameterList != null)
                parameters.AddRange(node.TypeParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)));
            parameters.AddRange(node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)));

            JsStatement body;
            if (code != null)
                body = Js.Native(code);
            else if (node.ExpressionBody != null)
                body = ((JsExpression)node.ExpressionBody.Accept(this)).Return();
            else if (method.ContainingType.TypeKind == TypeKind.Interface)
                body = idioms.CreateInterfaceMethod(method);
            else if (node.Body == null)
                body = new JsBlockStatement();
            else if (YieldChecker.HasYield(node))
                body = idioms.GenerateYieldMethod(node, method);
            else if (node.IsAsync())
                body = idioms.GenerateAsyncMethod(node, method);
            else
                body = (JsBlockStatement)node.Body.Accept(this);

            var methodFunction = Js.Function(parameters.ToArray()).Body(body);

            var memberName = method.GetMemberName();
            if (method.IsStatic)
            {
                block.Add(idioms.StoreInType(memberName, methodFunction));
            }
            else 
            {
                block.Add(idioms.StoreInPrototype(memberName, methodFunction));

                // Also store all interface implementations
                var implementedInterfaceMembers = SymbolFinder.FindImplementedInterfaceMembersAsync(method.GetRootOverride(), Context.Instance.Solution).Result;
                foreach (IMethodSymbol interfaceImplementation in implementedInterfaceMembers)
                {
                    block.Add(idioms.MapInterfaceMethod(idioms.GetPrototype(), interfaceImplementation, idioms.GetFromPrototype(memberName)));
                }
            }

            PopOutput();
            PopDeclaration();

            return block;
        }

        public override JsNode VisitConversionOperatorDeclaration(ConversionOperatorDeclarationSyntax node)
        {
            var method = model.GetDeclaredSymbol(node);
            var block = new JsBlockStatement();

            var isExported = method.IsExported();
            if (!isExported)
                return block;

            PushDeclaration(method);
            PushOutput(block);
            var parameters = new List<JsParameter>();
            parameters.AddRange(node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)));

            var body = node.Body == null ? new JsBlockStatement() : (JsBlockStatement)node.Body.Accept(this);
            var methodFunction = Js.Function(parameters.ToArray()).Body(body);
            var memberName = method.GetMemberName();
            block.Add(idioms.StoreInType(memberName, methodFunction));

            PopOutput();
            PopDeclaration();

            return block;
        }

        public override JsNode VisitBlock(BlockSyntax node)
        {
            var result = new JsBlockStatement();
            PushOutput(result);
            foreach (var statement in node.Statements)
            {
                result.Add((JsStatement)statement.Accept(this));
            }
            PopOutput();
            return result;
        }

        public override JsNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            var symbol = model.GetSymbolInfo(node).Symbol;
//            if (symbol == null)
//            {
//                var classText = node.FirstAncestorOrSelf<ClassDeclarationSyntax>().Parent.NormalizeWhitespace().ToString();
//                var diagnostics = model.GetDiagnostics().Select(x => x.ToString()).ToArray();
//            }

            var @this = (JsExpression)Js.This();
            if (symbol.IsStatic && symbol.ContainingType != null)
            {
                @this = idioms.Type(symbol.ContainingType);
                if (!(@this is JsInvocationExpression))
                    @this = @this.Invoke();
            }
            var binaryExpressionParent = node.FirstAncestorOrSelf<BinaryExpressionSyntax>();
            var isSetter = binaryExpressionParent != null && binaryExpressionParent.IsKind(SyntaxKind.SimpleAssignmentExpression) && node.AncestorsAndSelf().Contains(binaryExpressionParent.Left);
            var result = idioms.MemberReference(@this, symbol, isSetter);
            return ImplicitCheck(node, result);
        }

        public override JsNode VisitQualifiedName(QualifiedNameSyntax node)
        {
            return node.Right.Accept(this);
//            throw new Exception();
//            return ((JsMemberReferenceExpression)idioms.MemberReference(Js.This(), model.GetSymbolInfo(node).Symbol, false)).Target;
        }

        public override JsNode VisitGenericName(GenericNameSyntax node)
        {
            return idioms.MemberReference(Js.This(), model.GetSymbolInfo(node).Symbol);
        }

        public override JsNode VisitTypeArgumentList(TypeArgumentListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitPredefinedType(PredefinedTypeSyntax node)
        {
            var symbol = model.GetTypeInfo(node);
            return idioms.Type(symbol.ConvertedType);
        }

        public override JsNode VisitArrayType(ArrayTypeSyntax node)
        {
            var symbol = model.GetTypeInfo(node);
            return idioms.Type(symbol.ConvertedType);
        }

        public override JsNode VisitArrayRankSpecifier(ArrayRankSpecifierSyntax node)
        {
            return node.Sizes[0].Accept(this);
        }

        public override JsNode VisitPointerType(PointerTypeSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitNullableType(NullableTypeSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitOmittedTypeArgument(OmittedTypeArgumentSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitParenthesizedExpression(ParenthesizedExpressionSyntax node)
        {
            return ImplicitCheck(node, ((JsExpression)node.Expression.Accept(this)).Parenthetical());
        }

/*
        public override JsNode VisitAwaitExpression(AwaitExpressionSyntax node)
        {
            throw new Exception("Failure of the async generator to catch the await keyword");
        }
*/

        public override JsNode VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            var operand = (JsExpression)node.Operand.Accept(this);
            var operandType = model.GetTypeInfo(node.Operand);
            JsExpression result;
            if (idioms.TryCharUnaryExpression(node.Kind(), operandType, operand, out result))
                return result;
            JsUnaryOperator op;

            var symbol = model.GetSymbolInfo(node).Symbol;
            var methodSymbol = symbol as IMethodSymbol;
            if (methodSymbol != null && methodSymbol.Parameters.Length == 1)
            {
                var method = methodSymbol;
                if (method.IsExported() && method.MethodKind != MethodKind.BuiltinOperator)
                    return ImplicitCheck(node, idioms.InvokeStatic(method, operand));
            }

            switch (node.Kind())
            {
                case SyntaxKind.UnaryMinusExpression:
                    op = JsUnaryOperator.Negate;
                    break;
                case SyntaxKind.LogicalNotExpression:
                    op = JsUnaryOperator.LogicalNot;
                    break;
                case SyntaxKind.PreIncrementExpression:
                    op = JsUnaryOperator.PreIncrement;
                    break;
                case SyntaxKind.PreDecrementExpression:
                    op = JsUnaryOperator.PreDecrement;
                    break;
                case SyntaxKind.BitwiseNotExpression:
                    op = JsUnaryOperator.BitwiseNot;
                    break;
                default:
                    throw new Exception();
            }

            return ImplicitCheck(node, Js.Unary(op, operand));
        }

        public override JsNode VisitPostfixUnaryExpression(PostfixUnaryExpressionSyntax node)
        {
            var operand = (JsExpression)node.Operand.Accept(this);
            var operandType = model.GetTypeInfo(node.Operand);
            JsExpression result;
            if (idioms.TryCharUnaryExpression(node.Kind(), operandType, operand, out result))
                return result;

            JsUnaryOperator op;

            switch (node.Kind())
            {
                case SyntaxKind.PostIncrementExpression:
                    op = JsUnaryOperator.PostIncrement;
                    break;
                case SyntaxKind.PostDecrementExpression:
                    op = JsUnaryOperator.PostDecrement;
                    break;
                default:
                    throw new Exception();
            }

            return ImplicitCheck(node, Js.Unary(op, operand));
        }

        public override JsNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            var symbolInfo = model.GetSymbolInfo(node);
            var symbol = symbolInfo.Symbol;
//            if (symbolInfo.Symbol == null)
//            {
//                var classText = node.FirstAncestorOrSelf<ClassDeclarationSyntax>().NormalizeWhitespace().ToString();
//                var diagnostics = model.GetDiagnostics().Select(x => x.ToString()).ToArray();
//            }

            JsExpression target;
            bool isBaseReference;
            if (node.Expression is BaseExpressionSyntax)
            {
                isBaseReference = true;
                target = Js.This();
            }
            else
            {
                isBaseReference = false;
                var expressionSymbol = model.GetSymbolInfo(node.Expression).Symbol;
                if (symbol != null && symbol.IsStatic && expressionSymbol != null && !Equals(expressionSymbol, symbol.ContainingType) && symbol.ContainingType != null)
                {
                    // For static methods, we want to ensure that we are capturing the correct type.
                    // Typically, C# programmers qualify static members with declaring type, but 
                    // C# allows you to qualify with sub types.  However, in the compiled output
                    // we need to ensure that they are accessing it via the declaring type.
                    target = idioms.Type(symbol.ContainingType).Invoke();
                }
                else
                {
                    target = (JsExpression)node.Expression.Accept(this);
                }
            }

            var binaryExpressionParent = node.FirstAncestorOrSelf<AssignmentExpressionSyntax>();
            var isSetter = binaryExpressionParent != null && node.AncestorsAndSelf().Contains(binaryExpressionParent.Left);
            var result = idioms.MemberReference(target, symbol, isSetter, isBaseReference);
            return ImplicitCheck(node, result);
        }

        public override JsNode VisitBinaryExpression(BinaryExpressionSyntax node)
        {
            var leftSymbol = model.GetSymbolInfo(node.Left).Symbol;
            var rightSymbol = model.GetSymbolInfo(node.Right).Symbol;
            var leftType = model.GetTypeInfo(node.Left);
            var rightType = model.GetTypeInfo(node.Right);
            var left = (JsExpression)node.Left.Accept(this);
            var right = (JsExpression)node.Right.Accept(this);
            var symbol = model.GetSymbolInfo(node).Symbol;

            JsExpression result;
//            if (idioms.TryAccessorAssignment(node.CSharpKind(), leftSymbol, rightSymbol, left, right, out result))
//                return ImplicitCheck(node, result);
            if (idioms.TryIsExpression(node.Kind(), leftSymbol, rightSymbol, left, right, out result))
                return ImplicitCheck(node, result);
            if (idioms.TryAsExpression(node.Kind(), leftSymbol, rightSymbol, left, right, out result))
                return result;
            if (idioms.TryCharBinaryExpression(node.Kind(), leftType, rightType, left, right, out result))
                return result;
            if (idioms.TryIntegerDivision(node.Kind(), leftType, rightType, left, right, out result))
                return result;
            if (idioms.TryEnumBitwise(node.Kind(), leftType.Type, rightType.Type, left, right, out result))
                return result;
            if (idioms.TryEnumEquality(node.Kind(), leftType.Type, rightType.Type, left, right, out result))
                return result;
            if (idioms.TryStringConcatenation(node.Kind(), leftType, rightType, left, right, out result))
                return result;

            var methodSymbol = symbol as IMethodSymbol;
            if (methodSymbol != null && methodSymbol.Parameters.Length == 2)
            {
                var method = methodSymbol;
                if (method.IsExported() && method.MethodKind != MethodKind.BuiltinOperator)
                    return ImplicitCheck(node, idioms.InvokeStatic(method, left, right));
            }
            var op = idioms.ToBinaryOperator(node.Kind());
            if (op == null)
                throw new Exception();

            return ImplicitCheck(node, Js.Binary(op.Value, left, right));
        }

        public override JsNode VisitAssignmentExpression(AssignmentExpressionSyntax node)
        {
            var leftSymbol = model.GetSymbolInfo(node.Left).Symbol;
            var rightSymbol = model.GetSymbolInfo(node.Right).Symbol;
            var leftType = model.GetTypeInfo(node.Left);
            var rightType = model.GetTypeInfo(node.Right);
            var left = (JsExpression)node.Left.Accept(this);
            var right = (JsExpression)node.Right.Accept(this);
            var symbol = model.GetSymbolInfo(node).Symbol;

            JsExpression result;
            if (idioms.TryAccessorAssignment(node.Kind(), leftSymbol, rightSymbol, left, right, out result))
                return ImplicitCheck(node, result);
            if (idioms.TryIntegerDivision(node.Kind(), leftType, rightType, left, right, out result))
                return result;

            var methodSymbol = symbol as IMethodSymbol;
            if (methodSymbol != null && methodSymbol.Parameters.Length == 2)
            {
                var method = methodSymbol;
				if (method.IsExported() && method.MethodKind != MethodKind.BuiltinOperator) {
					var expression = idioms.InvokeStatic(method, left, right);
					var assignment = Js.Assign(left, expression);
					return ImplicitCheck(node, assignment);
				}
            }
            var op = idioms.ToBinaryOperator(node.Kind());
            if (op == null)
                throw new Exception();

            return ImplicitCheck(node, Js.Binary(op.Value, left, right));
        }

        public override JsNode VisitConditionalExpression(ConditionalExpressionSyntax node)
        {
            return ImplicitCheck(node, Js.Conditional(
                (JsExpression)node.Condition.Accept(this),
                (JsExpression)node.WhenTrue.Accept(this),
                (JsExpression)node.WhenFalse.Accept(this)));
        }

        public override JsNode VisitThisExpression(ThisExpressionSyntax node)
        {
            return ImplicitCheck(node, Js.This());
        }

        public override JsNode VisitBaseExpression(BaseExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            return ImplicitCheck(node, Js.Literal(node.Token.Value));
        }

        public override JsNode VisitMakeRefExpression(MakeRefExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitRefTypeExpression(RefTypeExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitRefValueExpression(RefValueExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitCheckedExpression(CheckedExpressionSyntax node)
        {
            node.ReportError("checked expressions are not supported");
            return node.Expression.Accept(this);
        }

        public override JsNode VisitDefaultExpression(DefaultExpressionSyntax node)
        {
            var type = model.GetTypeInfo(node).ConvertedType;
            var result = idioms.DefaultValue(type);
            return ImplicitCheck(node, result);
        }

        public override JsNode VisitTypeOfExpression(TypeOfExpressionSyntax node)
        {
            var type = (ITypeSymbol)model.GetSymbolInfo(node.Type).Symbol;
            var result = idioms.TypeOf(type);
            return ImplicitCheck(node, result);
        }

        public override JsNode VisitSizeOfExpression(SizeOfExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            JsExpression specialResult;
            var symbol = model.GetSymbolInfo(node).Symbol;
            var method = (IMethodSymbol)symbol;

            if (idioms.TryNameofInvocation(node, method, out specialResult))
                return ImplicitCheck(node, specialResult);

            var target = (JsExpression)node.Expression.Accept(this);
            return VisitInvocationExpression(node, target);
        }

        public JsNode VisitInvocationExpression(InvocationExpressionSyntax node, JsExpression target)
        {
            JsExpression specialResult;
            var symbol = model.GetSymbolInfo(node).Symbol;
            var method = (IMethodSymbol)symbol;

            var actualArguments = node.ArgumentList.Arguments.Select(x => (JsExpression)x.Accept(this)).ToArray();

            if (idioms.TryBaseMethodInvocation(node, method, actualArguments, out specialResult))
                return ImplicitCheck(node, specialResult);

/*
            if (model.GetTypeInfo(((Roslyn.Compilers.CSharp.MemberAccessExpressionSyntax)(node.Expression)).Expression).ConvertedType.BaseType is ErrorTypeSymbol)
            {
                var diagnostics = model.GetDiagnostics();
                var diagnostics2 = model.GetDeclarationDiagnostics();
            }
*/
            var targetType = node.Expression is MemberAccessExpressionSyntax ? model.GetTypeInfo(((MemberAccessExpressionSyntax)node.Expression).Expression).ConvertedType : null;
            var methodTarget = target is JsMemberReferenceExpression ? ((JsMemberReferenceExpression)target).Target : target;    // methodTarget has meaning only for method (as opposed to delegate) invocations
            var originalMethodTarget = node.Expression is MemberAccessExpressionSyntax ? ((MemberAccessExpressionSyntax)node.Expression).Expression : node.Expression;

            if (idioms.TryUnwrapAsExpression(method, target, actualArguments, out specialResult))
                return ImplicitCheck(node, specialResult);
            if (idioms.TryUnwrapJsFunctionInvoke(method, node, methodTarget, actualArguments, out specialResult))
                return ImplicitCheck(node, specialResult);
            if (idioms.TryUnwrapJsniExpression(method, originalMethodTarget, node.ArgumentList.Arguments.Select(x => x.Expression).ToArray(), methodTarget, actualArguments, out specialResult))
                return ImplicitCheck(node, specialResult);
            if (idioms.TryNullableGetValueOrDefault(method, target, out specialResult))
                return ImplicitCheck(node, specialResult);
            if (idioms.TryReferenceEquals(method, actualArguments, out specialResult))
                return ImplicitCheck(node, specialResult);
            if (idioms.TryEnumToString(method, target, methodTarget, targetType, actualArguments, out specialResult))
                return ImplicitCheck(node, specialResult);
            if (idioms.TryGetType(method, target, methodTarget, targetType, actualArguments, node, out specialResult))
                return ImplicitCheck(node, specialResult);
            if (idioms.TryInline(method, methodTarget, actualArguments, out specialResult))
                return ImplicitCheck(node, specialResult);

            var arguments = idioms.TranslateArguments(
                node,
                method, 
                (x, i) => model.GetTypeInfo(node.ArgumentList.Arguments[i].Expression).ConvertedType is IArrayTypeSymbol, 
                (x, i) => node.ArgumentList.Arguments[i].NameColon == null ? null : node.ArgumentList.Arguments[i].NameColon.Name.ToString(),
                actualArguments.ToArray()
            ).ToList();
            var isExtension = method.IsExtension();

            var prependers = new List<JsStatement>();
            var appenders = new List<JsStatement>();
            idioms.InstrumentRefAndOutParameters(method, arguments, prependers, appenders);

            var typeArguments = method.TypeParameters.Any() ? method.TypeArguments.Select(x => idioms.TypeAndResolve(x)).ToArray() : new JsExpression[0];
            var invokedAsExtensionMethod = method.ReducedFrom != null;

            // Extension methods come in as target.ExtensionMethod(arg1, arg2...) but we want them as ExtensionMethod(target, arg1, arg2...), and that's
            // what ReducedFrom is
            JsInvocationExpression invocation = null;
            if (isExtension)
            {
                if (!method.IsStatic)
                {
                    invocation = idioms.InvokeMethodAs(method, methodTarget, typeArguments.Concat(arguments).ToArray());
                }
                else
                {
                    invocation = idioms.InvokeStatic(method, arguments.ToArray());
                }
            }
            if (invocation == null && method.IsExtensionMethod)
            {
                var staticArgs = arguments.ToArray();
                if (invokedAsExtensionMethod)
                    staticArgs = new[] { methodTarget }.Concat(staticArgs).ToArray();
                invocation = idioms.InvokeStatic(method, staticArgs);
            }
            if (invocation == null && method.IsStatic)
            {
                invocation = idioms.InvokeStatic(method, arguments.ToArray());
            }
            if (invocation == null)
            {
                invocation = target.Invoke(typeArguments.Concat(arguments).ToArray());
            }

            if (idioms.TryApplyRefAndOutParametersAfterInvocation(method, invocation, out specialResult, prependers, appenders))
                return ImplicitCheck(node, specialResult);

            return ImplicitCheck(node, invocation);
        }

        public override JsNode VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node);
            var target = (JsExpression)node.Expression.Accept(this);
            var arguments = node.ArgumentList.Arguments.Select(x => (JsExpression)x.Accept(this)).ToArray();

            if (symbol.Symbol is IPropertySymbol)
            {
                var property = (IPropertySymbol)symbol.Symbol;
                var isExported = property.IsExported();
                var nameOverride = property.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
                JsExpression inline;
                if (idioms.TryInline(property.GetMethod, target, arguments, out inline))
                {
                    return inline;
                }
                else if (isExported)
                {
                    return idioms.Get(target, property, arguments);
                }
                else if (nameOverride != null)
                {
                    return target.Member(nameOverride).Invoke(arguments);
                }
            }

            return ImplicitCheck(node, target.Index(arguments.First()));
        }

        public override JsNode VisitArgumentList(ArgumentListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitBracketedArgumentList(BracketedArgumentListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitArgument(ArgumentSyntax node)
        {
            return node.Expression.Accept(this);
        }

        public override JsNode VisitNameColon(NameColonSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitCastExpression(CastExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node).Symbol;
            if (symbol != null)
            {
                var method = (IMethodSymbol)symbol;
                return ImplicitCheck(node, idioms.InvokeStatic(method, (JsExpression)node.Expression.Accept(this)));
            }

            var target = (JsExpression)node.Expression.Accept(this);
            if (node.Expression is LiteralExpressionSyntax && node.Expression.Kind() == SyntaxKind.NullLiteralExpression)
            {
                return ImplicitCheck(node, target);
            }

            var typeInfo = model.GetTypeInfo(node.Expression);
            var originalType = typeInfo.Type;
            var convertedType = typeInfo.ConvertedType;
            var destinationType = model.GetTypeInfo(node.Type).Type;

            Func<ITypeSymbol, bool> isInteger = null;
            isInteger = x => Equals(x, Context.Instance.Byte) || Equals(x, Context.Instance.SByte) ||
                             Equals(x, Context.Instance.Int16) || Equals(x, Context.Instance.UInt16) ||
                             Equals(x, Context.Instance.Int32) || Equals(x, Context.Instance.UInt32) ||
                             Equals(x, Context.Instance.Int64) || Equals(x, Context.Instance.UInt64) ||
                (Equals(x.OriginalDefinition, Context.Instance.NullableType) && isInteger(((INamedTypeSymbol)x).TypeArguments[0]));
            Func<ITypeSymbol, bool> isDecimal = null;
            isDecimal = x => Equals(x, Context.Instance.Single) ||
                             Equals(x, Context.Instance.Double) || Equals(x, Context.Instance.Decimal) ||
                (Equals(x.OriginalDefinition, Context.Instance.NullableType) && isDecimal(((INamedTypeSymbol)x).TypeArguments[0]));

            if (originalType != null && originalType.TypeKind == TypeKind.Enum)
            {
                return idioms.Invoke(target, Context.Instance.EnumGetValue);
            }
            if (destinationType.TypeKind == TypeKind.Enum && isInteger(convertedType))
            {
                return idioms.InvokeStatic(Context.Instance.EnumInternalToObject, idioms.Type(destinationType).Invoke(), target);
            }
            if (Equals(convertedType, Context.Instance.Int32) && (Equals(convertedType, Context.Instance.Char) || Equals(convertedType, Context.Instance.CharNullable)))
            {
                return target.Member("charCodeAt").Invoke();
            }
            if (Equals(destinationType, Context.Instance.Byte) && !Equals(originalType, Context.Instance.Byte) && isInteger(originalType))
            {
                return (target.BitwiseAnd(Js.Literal(0xFF)));
            }
            if (isDecimal(convertedType) && isInteger(destinationType))
            {
                return Js.Reference(SpecialNames.Truncate).Invoke(target);
            }
            if (isDecimal(convertedType) && isDecimal(destinationType))
            {
                return target;
            }
            if (isInteger(convertedType) && isInteger(destinationType))
            {
                return target;
            }
            if (!convertedType.IsExported())
            {
                return target;
            }

            var cast = idioms.InvokeStatic(Context.Instance.ObjectCast.Construct(destinationType), target);
            return ImplicitCheck(node, cast);
        }

        private JsNode VisitLambdaExpression(CSharpSyntaxNode node, INamedTypeSymbol delegateType, ParameterSyntax[] parameterNodes, CSharpSyntaxNode bodyNode, bool isAsync)
        {
            // If the lambda expression is being *assigned* to an `Expression<T>` variable, then we want to decompose it so
            // it results in an expression tree being generated.
            if (delegateType.IsGenericType && Equals(delegateType.OriginalDefinition, Context.Instance.ExpressionGeneric))
            {
                delegateType = (INamedTypeSymbol)delegateType.TypeArguments[0];
            }

            var block = new JsBlockStatement();
            var parameters = parameterNodes.Select(x => (JsParameter)x.Accept(this)).ToArray();

            PushOutput(block);

            if (isAsync)
            {
                Action<BaseStateGenerator, JsTransformer> nodeAcceptor = (stateGenerator, transformer) =>
                {
                    if (bodyNode is StatementSyntax)
                        bodyNode.Accept(stateGenerator);
                    else if (delegateType.DelegateInvokeMethod.ReturnsVoid)
                    {
                        stateGenerator.CurrentState.Add(((JsExpression)bodyNode.Accept(transformer)).Express());
                    }
                    else
                    {
                        ((AsyncStateGenerator)stateGenerator).SetResult((ExpressionSyntax)bodyNode);
                    }
                };

                block.Aggregate(idioms.GenerateAsyncMethod(node, delegateType.DelegateInvokeMethod, nodeAcceptor));
            }
            else
            {
                var body = bodyNode.Accept(this);
                if (body is JsStatement)
                {
                    block.Aggregate((JsStatement)body);
                }
                else if (delegateType.DelegateInvokeMethod.ReturnsVoid)
                {
                    block.Add(((JsExpression)body).Express());
                }
                else
                {
                    block.Add(((JsExpression)body).Return());
                }                
            }

            PopOutput();

            var arguments = new List<JsExpression>
            {
                Js.This(),
                Js.Function(parameters).Body(block)
            };
            if (!model.Compilation.Assembly.AreDelegatesMinimized())
            {
                arguments.Add(idioms.Type(delegateType));
            }
            var createDelegate = idioms.InvokeStatic(Context.Instance.ObjectCreateDelegate, arguments.ToArray());
            return createDelegate;
        }

        public override JsNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            var delegateType = (INamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            return ImplicitCheck(node, VisitLambdaExpression(node, delegateType, new[] { node.Parameter }, node.Body, node.AsyncKeyword.Kind() == SyntaxKind.AsyncKeyword));
        }

        public override JsNode VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            var delegateType = (INamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            return ImplicitCheck(node, VisitLambdaExpression(node, delegateType, node.ParameterList.Parameters.ToArray(), node.Body, node.AsyncKeyword.Kind() == SyntaxKind.AsyncKeyword));
        }

        public override JsNode VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            var delegateType = (INamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            return ImplicitCheck(node, VisitLambdaExpression(node, delegateType, node.ParameterList?.Parameters.ToArray() ?? new ParameterSyntax[0], node.Block, false));
        }

        public override JsNode VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node)
        {
            return node.Expression.Accept(this);
        }

        public override JsNode VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node);
            var method = (IMethodSymbol)symbol.Symbol;
            var obj = idioms.CreateObject(method);

            // Wrap initialization in an anonymous function
            var initializerBlock = new JsBlockStatement();
            var variable = Js.Variable("$obj$", obj);
            initializerBlock.Local(variable);

            // Process initializers
            foreach (var initializer in node.Initializers)
            {
                var property = model.GetDeclaredSymbol(initializer);
                var jsInitializer = (JsExpression)initializer.Accept(this);
                initializerBlock.Assign(variable.GetReference().Member(property.GetBackingFieldName()), jsInitializer);
            }

            // Return obj
            initializerBlock.Return(Js.Reference("$obj$"));

            return ImplicitCheck(node, idioms.Wrap(initializerBlock));
        }

        public override JsNode VisitInitializerExpression(InitializerExpressionSyntax node)
        {
            var block = new JsBlockStatement();
            
            foreach (var statement in node.Expressions)
            {
                switch (node.Kind())
                {
                    case SyntaxKind.ObjectInitializerExpression:
                    {
                        var newTarget = initializableObjectsStack.Peek().GetReference();
                        var expression = (JsExpression)statement.Accept(this);
                        if (expression is JsInvocationExpression)
                        {
                            var assignment = (JsInvocationExpression)expression;
                            var target = (JsMemberReferenceExpression)assignment.Target;
                            target.Target = initializableObjectsStack.Peek().GetReference();
                        }
                        else
                        {
                            var assignment = (JsBinaryExpression)expression;
                            var target = (JsMemberReferenceExpression)assignment.Left;
                            target.Target = newTarget;
                        }
                        block.Express(expression);
                        break;
                    }
                    case SyntaxKind.CollectionInitializerExpression:
                    {
                        var newTarget = initializableObjectsStack.Peek().GetReference();
                        var arguments = new List<JsExpression>();
                        var objectCreateExpression = (ObjectCreationExpressionSyntax)node.Parent;
                        var constructor = model.GetSymbolInfo(objectCreateExpression).Symbol;
                        IMethodSymbol addMethod;
                        if (statement is InitializerExpressionSyntax)
                        {
                            var initializer = (InitializerExpressionSyntax)statement;
                            addMethod = constructor.ContainingType.GetMembers("Add").OfType<IMethodSymbol>().First(x => x.Parameters.Count() == 2);
                            arguments.AddRange(initializer.Expressions.Select(x => (JsExpression)x.Accept(this)));
                        }
                        else
                        {
                            var expression = (JsExpression)statement.Accept(this);
                            addMethod = constructor.ContainingType.GetMembers("Add").OfType<IMethodSymbol>().First(x => x.Parameters.Count() == 1);
                            arguments.Add(expression);
                        }
                        block.Express(idioms.Invoke(newTarget, addMethod, arguments.ToArray()));
                        break;
                    }
                    case SyntaxKind.ArrayInitializerExpression:
                    {
                        var arraySymbol = (IArrayTypeSymbol)model.GetTypeInfo(node).ConvertedType;
                        var result = idioms.MakeArray(
                            Js.Array(node.Expressions.Select(x => (JsExpression)x.Accept(this)).ToArray()),
                            arraySymbol);
                        return ImplicitCheck(node, result);            
                    }
                    default:
                        throw new Exception();
                }
            }

            return block;
        }

        public override JsNode VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            var type = (ITypeSymbol)model.GetSymbolInfo(node.Type).Symbol;
            if (type is ITypeParameterSymbol)
            {
                var typeParameter = (ITypeParameterSymbol)type;
                return Js.Reference(typeParameter.Name).Member("prototype").Member("$ctor").Member("$new").Invoke();
            }

            var method = (IMethodSymbol)model.GetSymbolInfo(node).Symbol;
//            if (method == null)
//            {
//                var classText = node.FirstAncestorOrSelf<ClassDeclarationSyntax>().NormalizeWhitespace().ToString();
//                var diagnostics = model.GetDiagnostics().Select(x => x.ToString()).ToArray();                
//            }
            if (Equals(type, Context.Instance.MulticastDelegateType))
            {
                return ImplicitCheck(node, idioms.CreateMulticastDelegate((JsExpression)node.ArgumentList.Arguments[0].Accept(this), 
                    (JsExpression)node.ArgumentList.Arguments[1].Accept(this)));
            }
            if (Context.Instance.DelegateType.IsAssignableFrom(type))
            {
                return ImplicitCheck(node, node.ArgumentList.Arguments[0].Accept(this));
            }

            var isExported = type.IsExported();
            var isBuiltIn = type.GetAttributeValue(Context.Instance.JsAttributeType, "BuiltIn", false);
            var actualArguments = (node.ArgumentList?.Arguments.Select(x => (JsExpression)x.Accept(this)) ?? new List<JsExpression>()).ToArray();
            var args = idioms.TranslateArguments(
                node,
                method, 
                (x, i) => model.GetTypeInfo(node.ArgumentList.Arguments[i].Expression).ConvertedType is IArrayTypeSymbol, 
                (x, i) => node.ArgumentList.Arguments[i].NameColon == null ? null : node.ArgumentList.Arguments[i].NameColon.Name.ToString(),
                actualArguments.ToArray()
            ).ToList();

            JsExpression specialResult;
            if (idioms.TryInline(method, null, actualArguments.ToArray(), out specialResult))
                return specialResult;

            var inline = method.GetInline();
            if ((isExported || inline != null) && !isBuiltIn)
            {
                if (inline != null)
                {
                    return Js.NativeExpression(inline);
                }

                var obj = idioms.CreateObject(method, args.ToArray());

                if (node.Initializer != null)
                {
                    // Wrap initialization in an anonymous function
                    var initializerBlock = new JsBlockStatement();
                    var variable = Js.Variable("$obj$", obj);
                    initializerBlock.Local(variable);

                    // Process initializers
                    initializableObjectsStack.Push(variable);
                    var initializers = (JsBlockStatement)node.Initializer.Accept(this);
                    initializerBlock.Aggregate(initializers);
                    initializableObjectsStack.Pop();

                    // Return obj
                    initializerBlock.Return(Js.Reference("$obj$"));

                    return ImplicitCheck(node, idioms.Wrap(initializerBlock));
                }

                var result = (JsExpression)ImplicitCheck(node, obj);
                if (Context.Instance.Exception.IsAssignableFrom(type))
                    result = idioms.Invoke(result, Context.Instance.InternalInit, Js.New(Js.Reference("Error")));
                return result;
            }
            else
            {
                if (type.GetAttributeValue(Context.Instance.JsAttributeType, "InvokeConstructorAsClass", false))
                    return ImplicitCheck(node, idioms.Type(type).Invoke(args.ToArray()));
                else if (!isExported)
                    return ImplicitCheck(node, Js.New(Js.Reference(type.GetName()), args.ToArray()));
                else
                    return ImplicitCheck(node, Js.New(idioms.Type(type), args.ToArray()));
            }
        }

        public override JsNode VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            var arrayType = node.Type;
            var arraySymbol = (IArrayTypeSymbol)model.GetTypeInfo(node).Type;
            if (node.Initializer == null)
            {
                if (arrayType.RankSpecifiers.Count > 1 || arrayType.RankSpecifiers[0].Sizes.Count > 1)
                    throw new Exception("Multi-dimensional arrays are not supported.  (Use jagged arrays)");

                return ImplicitCheck(node, idioms.MakeArray(
                    Js.NewArray((JsExpression)arrayType.RankSpecifiers[0].Accept(this)),
                    arraySymbol));
            }

            return VisitArrayCreationExpression(node, node.Initializer);
        }

        public override JsNode VisitImplicitArrayCreationExpression(ImplicitArrayCreationExpressionSyntax node)
        {
            return VisitArrayCreationExpression(node, node.Initializer);
        }

        private JsNode VisitArrayCreationExpression(ExpressionSyntax node, InitializerExpressionSyntax initializer)
        {
            var arraySymbol = (IArrayTypeSymbol)model.GetTypeInfo(node).Type;
            var result = idioms.MakeArray(
                Js.Array(initializer.Expressions.Select(x => (JsExpression)x.Accept(this)).ToArray()),
                arraySymbol);
            return ImplicitCheck(node, result);            
        }

        public override JsNode VisitStackAllocArrayCreationExpression(StackAllocArrayCreationExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitQueryExpression(QueryExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitQueryBody(QueryBodySyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitFromClause(FromClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitLetClause(LetClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitJoinClause(JoinClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitJoinIntoClause(JoinIntoClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitWhereClause(WhereClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitOrderByClause(OrderByClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitOrdering(OrderingSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitSelectClause(SelectClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitGroupClause(GroupClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitQueryContinuation(QueryContinuationSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitOmittedArraySizeExpression(OmittedArraySizeExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitGlobalStatement(GlobalStatementSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            return Js.Local((JsVariableDeclaration)node.Declaration.Accept(this));
        }

        public override JsNode VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            return Js.Declare(node.Variables.Select(x => (JsVariableDeclarator)x.Accept(this)).ToArray());
        }

        public override JsNode VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            var symbol = (ILocalSymbol)model.GetDeclaredSymbol(node);
//            if (symbol == null)
//            {
//                symbol = VariableUsageFinder.FirstValidSymbolOccuranceOfVariable(model, node, node.Identifier.ToString());
//                var classText = node.FirstAncestorOrSelf<ClassDeclarationSyntax>().Parent.NormalizeWhitespace().ToString();
//                var diagnostics = model.GetDiagnostics().Select(x => x.ToString()).ToArray();
//            }
            var variable = Js.Variable(JsNames.EscapeIfReservedWord(node.Identifier.ToString()), (JsExpression)node.Initializer?.Accept(this));
            DeclareInCurrentScope(symbol, variable);
            return variable;
        }

        public override JsNode VisitEqualsValueClause(EqualsValueClauseSyntax node)
        {
            return node.Value.Accept(this);
        }

        public override JsNode VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            JsStatement result;
            if (idioms.TryUnwrapJsniStatement(node, out result))
                return result;

            return ((JsExpression)node.Expression.Accept(this)).Express();
        }

        public override JsNode VisitEmptyStatement(EmptyStatementSyntax node)
        {
            return Js.Empty();
        }

        public override JsNode VisitLabeledStatement(LabeledStatementSyntax node)
        {
            return Js.Label(node.Identifier.ToString(), (JsStatement)node.Statement.Accept(this));
        }

        public override JsNode VisitGotoStatement(GotoStatementSyntax node)
        {
            return Js.Continue(node.Expression.Accept(this).ToString().Trim());
        }

        public override JsNode VisitBreakStatement(BreakStatementSyntax node)
        {
            return Js.Break();
        }

        public override JsNode VisitContinueStatement(ContinueStatementSyntax node)
        {
            return Js.Continue();
        }

        public override JsNode VisitReturnStatement(ReturnStatementSyntax node)
        {
            if (node.Expression == null)
                return Js.Return();
            else
                return ((JsExpression)node.Expression.Accept(this)).Return();
        }

        public override JsNode VisitThrowStatement(ThrowStatementSyntax node)
        {
            // In Javascript land, a naked throw; in C# is actually equivalent to throw $ex;
            JsExpression expression;
            if (node.Expression == null)
            {
                var catchClause = node.FirstAncestorOrSelf<CatchClauseSyntax>();
                var catchDeclaration = catchClause.Declaration;
                expression = Js.Reference(catchDeclaration.Identifier.ToString());
            }
            else
            {
                expression = (JsExpression)node.Expression.Accept(this);
            }

            return Js.Throw(expression);
        }

        public override JsNode VisitYieldStatement(YieldStatementSyntax node)
        {
            throw new Exception("Yield statement is not supported.");
        }

        public override JsNode VisitWhileStatement(WhileStatementSyntax node)
        {
            var nextStatement = node.GetNextStatement();
            var loopLabel = 
                node.Parent is LabeledStatementSyntax ? (LabeledStatementSyntax)node.Parent :
                nextStatement as LabeledStatementSyntax;
            var loopEntry = new LoopEntry();
            if (loopLabel != null)
            {
                loopEntry.Label = loopLabel.Identifier.ToString();
            }
            loopLabels.Push(loopEntry);
            loopEntry.Depth = loopLabels.Count;
            var condition = (JsExpression)node.Condition.Accept(this);

            var block = new JsBlockStatement();
            PushOutput(block);

            block.Aggregate((JsStatement)node.Statement.Accept(this));

            PopOutput();

            var result = new LoopTransformer(this, node, loopEntry.Depth, node.Statement).TransformLoop(Js.While(condition, block));

            loopLabels.Pop();
            return result;
        }

        public override JsNode VisitDoStatement(DoStatementSyntax node)
        {
            var nextStatement = node.GetNextStatement();
            var loopLabel = 
                node.Parent is LabeledStatementSyntax ? (LabeledStatementSyntax)node.Parent :
                nextStatement as LabeledStatementSyntax;
            var loopEntry = new LoopEntry();
            if (loopLabel != null)
            {
                loopEntry.Label = loopLabel.Identifier.ToString();
            }
            loopLabels.Push(loopEntry);
            loopEntry.Depth = loopLabels.Count;
            var condition = (JsExpression)node.Condition.Accept(this);

            var block = new JsBlockStatement();
            PushOutput(block);

            block.Aggregate((JsStatement)node.Statement.Accept(this));

            PopOutput();
            var result = new LoopTransformer(this, node, loopEntry.Depth, node.Statement).TransformLoop(Js.DoWhile(condition, block));
            loopLabels.Pop();
            return result;
        }

        public override JsNode VisitForStatement(ForStatementSyntax node)
        {
            var nextStatement = node.GetNextStatement();
            var loopLabel = 
                node.Parent is LabeledStatementSyntax ? (LabeledStatementSyntax)node.Parent :
                nextStatement as LabeledStatementSyntax;
            var loopEntry = new LoopEntry();
            if (loopLabel != null)
            {
                loopEntry.Label = loopLabel.Identifier.ToString();
            }
            loopLabels.Push(loopEntry);
            loopEntry.Depth = loopLabels.Count;

            var declaration = (JsVariableDeclaration)node.Declaration?.Accept(this);

            var initializers = node.Initializers.Select(x => (JsExpression)x.Accept(this)).ToArray();

            var condition = (JsExpression)node.Condition.Accept(this);
            var incrementors = node.Incrementors.Select(x => (JsExpression)x.Accept(this)).ToArray();

            var block = new JsBlockStatement();
            PushOutput(block);

            block.Aggregate((JsStatement)node.Statement.Accept(this));

            PopOutput();

            var forStatement = new JsForStatement();
            forStatement.Declaration = declaration;
            forStatement.Initializers.AddRange(initializers);
            forStatement.Condition = condition;
            forStatement.Incrementors.AddRange(incrementors);
            forStatement.Body = block;

            var result = new LoopTransformer(this, node, loopEntry.Depth, node.Statement).TransformLoop(forStatement);
            loopLabels.Pop();
            return result;
        }

        public override JsNode VisitForEachStatement(ForEachStatementSyntax node)
        {
            var nextStatement = node.GetNextStatement();
            var loopLabel = 
                node.Parent is LabeledStatementSyntax ? (LabeledStatementSyntax)node.Parent :
                nextStatement as LabeledStatementSyntax;
            var loopEntry = new LoopEntry();
            if (loopLabel != null)
            {
                loopEntry.Label = loopLabel.Identifier.ToString();
            }
            loopLabels.Push(loopEntry);
            loopEntry.Depth = loopLabels.Count;

            var declaration = model.GetDeclaredSymbol(node);
            var block = new JsBlockStatement();
            var enumerable = (JsExpression)node.Expression.Accept(this);

            // Special handling for native js objects to use for/in
            if (!model.GetTypeInfo(node.Expression).Type.IsExported())
            {
                var forInBlock = new JsBlockStatement();
                PushOutput(forInBlock);

                var item = Js.Variable(JsNames.EscapeIfReservedWord(node.Identifier.ToString()));
                DeclareInCurrentScope(declaration, item);

                forInBlock.Aggregate((JsStatement)node.Statement.Accept(this));

                var forInLoop = Js.ForIn(item, (JsExpression)node.Expression.Accept(this)).Body(forInBlock);
                block.Add(forInLoop);
            }
            else
            {
                var iterator = Js.Variable(GenerateUniqueNameInScope() + "iterator", enumerable);
                var enumerator = Js.Variable(GenerateUniqueNameInScope() + "enumerator", idioms.Invoke(iterator.GetReference(), Context.Instance.EnumerableGetEnumerator));
                block.Local(iterator);
                block.Local(enumerator);
                
                var whileBlock = new JsBlockStatement();
                PushOutput(whileBlock);
                var item = Js.Variable(JsNames.EscapeIfReservedWord(node.Identifier.ToString()), idioms.Get(enumerator.GetReference(), Context.Instance.EnumeratorCurrent));
                DeclareInCurrentScope(declaration, item);

                whileBlock.Local(item);
                whileBlock.Aggregate((JsStatement)node.Statement.Accept(this));

                var whileLoop = new LoopTransformer(this, node, loopEntry.Depth, node.Statement).TransformLoop(Js.While(idioms.Invoke(enumerator.GetReference(), Context.Instance.EnumeratorMoveNext), whileBlock));
                block.Add(whileLoop);
            }

            PopOutput();

            loopLabels.Pop();
            return block;
        }

        public override JsNode VisitUsingStatement(UsingStatementSyntax node)
        {
            var tryStatement = Js.Try();
            var result = new JsBlockStatement { Inline = true };

            var disposables = new List<IJsDeclaration>();

            if (node.Declaration != null)
            {
                foreach (var variable in node.Declaration.Variables)
                {
                    var symbol = model.GetDeclaredSymbol(variable);
                    var disposable = Js.Variable(JsNames.EscapeIfReservedWord(variable.Identifier.ToString()));
                    disposable.Initializer = (JsExpression)variable.Initializer.Value.Accept(this);
                    DeclareInCurrentScope(symbol, disposable);
                    result.Local(disposable);
                    disposables.Add(disposable);
                }
            }
            else
            {
                var disposable = Js.Variable(GenerateUniqueNameInScope(), (JsExpression)node.Expression.Accept(this));
                result.Local(disposable);
                disposables.Add(disposable);
            }

            tryStatement.Body.Aggregate((JsStatement)node.Statement.Accept(this));
            foreach (var disposable in disposables)
            {
                tryStatement.Finally = new JsBlockStatement();
                tryStatement.Finally.Express(idioms.Invoke(disposable.GetReference(), Context.Instance.IDisposableDispose));
            }

            result.Add(tryStatement);

            return result;
        }

        public override JsNode VisitFixedStatement(FixedStatementSyntax node)
        {
            throw new Exception("Fixed statements are not supported.");
        }

        public override JsNode VisitCheckedStatement(CheckedStatementSyntax node)
        {
            throw new Exception("Checked statements are not supported.");
        }

        public override JsNode VisitUnsafeStatement(UnsafeStatementSyntax node)
        {
            throw new Exception("Unsafe operations are not supported.");
        }

        public override JsNode VisitLockStatement(LockStatementSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitIfStatement(IfStatementSyntax node)
        {
            return Js.If(
                (JsExpression)node.Condition.Accept(this),
                (JsStatement)node.Statement.Accept(this),
                (JsStatement)node.Else?.Accept(this));
        }

        public override JsNode VisitElseClause(ElseClauseSyntax node)
        {
            return node.Statement.Accept(this);
        }

        public override JsNode VisitSwitchStatement(SwitchStatementSyntax node)
        {
            return Js.Switch((JsExpression)node.Expression.Accept(this), node.Sections.Select(x => (JsSwitchSection)x.Accept(this)).ToArray());
        }

        public override JsNode VisitSwitchSection(SwitchSectionSyntax node)
        {
            return Js.Section(node.Labels.Select(x => (JsSwitchLabel)x.Accept(this)).ToArray())
                .Statements(node.Statements.Select(x => (JsStatement)x.Accept(this)).ToArray());
        }

        public override JsNode VisitCaseSwitchLabel(CaseSwitchLabelSyntax node)
        {
            return Js.CaseLabel((JsExpression)node.Value.Accept(this));
        }

        public override JsNode VisitDefaultSwitchLabel(DefaultSwitchLabelSyntax node)
        {
            return Js.DefaultLabel();
        }

        public override JsNode VisitTryStatement(TryStatementSyntax node)
        {
            var result = Js.Try();

            PushOutput(result.Body);
            result.Body.Aggregate((JsStatement)node.Block.Accept(this));
            PopOutput();

            if (node.Catches.Any())
            {
                result.Catch = Js.Catch();
                PushOutput(result.Catch.Body);

                if (node.Catches.Count > 0)
                {
                    result.Catch.Declaration = Js.Variable(GenerateUniqueNameInScope());
                    JsIfStatement currentIfStatement = null;
                    foreach (var catchClause in node.Catches)
                    {
                        // Catch if block
                        var operand = catchClause.Declaration == null ? null : (ITypeSymbol)model.GetSymbolInfo(catchClause.Declaration.Type).Symbol;
                        var getTypeFromType = operand == null ? null : idioms.Type(operand).Member(SpecialNames.GetTypeFromType).Invoke();
                        var catchBlock = Js.Block();
                        var symbol = catchClause.Declaration == null ? null : model.GetDeclaredSymbol(catchClause.Declaration);
                        if (symbol != null)
                            DeclareInCurrentScope(symbol, result.Catch.Declaration);
                        catchBlock.Aggregate((JsStatement)catchClause.Block.Accept(this));
                        if (catchClause.Declaration != null)
                        {
                            var ifStatement = Js.If(
                                idioms.Invoke(getTypeFromType, Context.Instance.TypeIsInstanceOfType, result.Catch.Declaration.GetReference()),
                                catchBlock);

                            if (currentIfStatement == null)
                            {
                                currentIfStatement = ifStatement;
                                result.Catch.Body.Add(ifStatement);
                            }
                            else
                            {
                                currentIfStatement.IfFalse = ifStatement;
                                currentIfStatement = ifStatement;
                            }
                        }
                        else
                        {
                            if (currentIfStatement == null)
                            {
                                result.Catch.Body.Add(catchBlock);
                            }
                            else
                            {
                                currentIfStatement.IfFalse = catchBlock;
                            }
                        }
                    }
                    if (currentIfStatement != null)
                    {
                        currentIfStatement.IfFalse = Js.Throw(result.Catch.Declaration.GetReference());
                    }
                }
/*
                else if (node.Catches.Count == 1)
                {
                    var catchClause = node.Catches[0];
                    if (catchClause.Declaration != null)
                    {
                        var declaration = catchClause.Declaration.Accept(this);
                        result.Catch.Declaration = (JsVariableDeclarator)declaration;
                    }
                    else
                    {
                        result.Catch.Declaration = Js.Variable("$exception");
                    }

                    result.Catch.Body.Aggregate((JsStatement)catchClause.Block.Accept(this));
                }
*/

                PopOutput();
            }

            if (node.Finally != null)
            {
                result.Finally = new JsBlockStatement();
                PushOutput(result.Finally);

                result.Finally.Aggregate((JsStatement)node.Finally.Block.Accept(this));

                PopOutput();
            }

            return result;
        }

        public override JsNode VisitCatchClause(CatchClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitCatchDeclaration(CatchDeclarationSyntax node)
        {
            var identifier = node.Identifier.ToString();
            if (node.Identifier.Kind() == SyntaxKind.None)
            {
                identifier = GenerateUniqueNameInScope();
            }
            var symbol = model.GetDeclaredSymbol(node);
            var variable = Js.Variable(JsNames.EscapeIfReservedWord(identifier));
            DeclareInCurrentScope(symbol, variable);
            return variable;
        }

        public override JsNode VisitFinallyClause(FinallyClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitExternAliasDirective(ExternAliasDirectiveSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitUsingDirective(UsingDirectiveSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitAttributeList(AttributeListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitAttributeTargetSpecifier(AttributeTargetSpecifierSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitAttribute(AttributeSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitAttributeArgumentList(AttributeArgumentListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitAttributeArgument(AttributeArgumentSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitNameEquals(NameEqualsSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitTypeParameterList(TypeParameterListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitTypeParameter(TypeParameterSyntax node)
        {
            var symbol = model.GetDeclaredSymbol(node);
            return Js.Parameter(symbol.Name);
        }

        public override JsNode VisitDelegateDeclaration(DelegateDeclarationSyntax node)
        {
            var jsBlock = new JsBlockStatement();

            var classType = model.GetDeclaredSymbol(node);
            var isExported = classType.IsExported();
            if (!isExported)
                return jsBlock;

            var symbol = model.GetDeclaredSymbol(node);
            PushDeclaration(symbol);

            JsBlockStatement typeInitializer;
            JsBlockStatement staticInitializer;
            jsBlock.Aggregate(idioms.CreateTypeFunction(classType, out typeInitializer, out staticInitializer));

            var method = classType.DelegateInvokeMethod;

            PushDeclaration(method);
            var parameters = new List<JsParameter>();
            parameters.AddRange(method.Parameters.Select(x =>
            {
                var parameter = Js.Parameter(x.Name);
                DeclareInCurrentScope(x, parameter);
                return parameter;
            }));

            var body = new JsBlockStatement();
            body.Return(Js.This().Invoke(parameters.Select(x => x.GetReference()).ToArray()));
            var methodFunction = Js.Function(parameters.ToArray()).Body(body);

            var memberName = method.GetMemberName();
            typeInitializer.Add(idioms.StoreInPrototype(memberName, methodFunction));

            PopDeclaration();

            PopDeclaration();
            return jsBlock;
        }

        public override JsNode VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitBaseList(BaseListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitTypeParameterConstraintClause(TypeParameterConstraintClauseSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitConstructorConstraint(ConstructorConstraintSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitClassOrStructConstraint(ClassOrStructConstraintSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitTypeConstraint(TypeConstraintSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
        {
            var block = new JsBlockStatement();

            foreach (var variable in node.Declaration.Variables)
            {
                var field = (IEventSymbol)model.GetDeclaredSymbol(variable);
                var propertyName = field.GetMemberName();

                var isExported = field.IsExported();
                if (!isExported)
                    continue;

                var backingField = field.GetBackingFieldName();
                var addParameter = Js.Parameter("value");
                var removeParameter = Js.Parameter("value");
                block.Add(idioms.StoreInPrototype(backingField, Js.Null()));

                // Effectively:
                // $k__BackingField = Delegate.Combine($k__BackingField, value);
                var addBlock = new JsBlockStatement();
                PushOutput(addBlock);
                addBlock.Assign(Js.This().Member(backingField), 
                    idioms.InvokeStatic(Context.Instance.DelegateCombine,  Js.This().Member(backingField), addParameter.GetReference()));
                block.Add(idioms.StoreInPrototype("add_" + propertyName, Js.Function(addParameter).Body(addBlock)));
                PopOutput();

                // Effectively:
                // $k__BackingField = Delegate.Remove($k__BackingField, value);
                var removeBlock = new JsBlockStatement();
                PushOutput(removeBlock);
                removeBlock.Assign(Js.This().Member(backingField), 
                    idioms.InvokeStatic(Context.Instance.DelegateRemove, Js.This().Member(backingField), removeParameter.GetReference()));
                block.Add(idioms.StoreInPrototype("remove_" + propertyName, 
                    Js.Function(removeParameter).Body(removeBlock)));
                PopOutput();
            }

            return block;
        }

        public override JsNode VisitExplicitInterfaceSpecifier(ExplicitInterfaceSpecifierSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitOperatorDeclaration(OperatorDeclarationSyntax node)
        {
            var method = model.GetDeclaredSymbol(node);
            var block = new JsBlockStatement();

            var isExported = method.IsExported();
            if (!isExported)
                return block;

            PushDeclaration(method);
            PushOutput(block);
            var parameters = new List<JsParameter>();
            parameters.AddRange(node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)));

            var body = node.Body == null ? new JsBlockStatement() : (JsBlockStatement)node.Body.Accept(this);
            var methodFunction = Js.Function(parameters.ToArray()).Body(body);
            var memberName = method.GetMemberName();
            block.Add(idioms.StoreInType(memberName, methodFunction));

            PopOutput();
            PopDeclaration();

            return block;
        }

        public override JsNode VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            var symbol = model.GetSymbolInfo(node);
            var method = (IMethodSymbol)symbol.Symbol;

            var arguments = idioms.TranslateArguments(
                node,
                method, 
                (x, i) => model.GetTypeInfo(node.ArgumentList.Arguments[i].Expression).ConvertedType is IArrayTypeSymbol, 
                (x, i) => node.ArgumentList.Arguments[i].NameColon == null ? null : node.ArgumentList.Arguments[i].NameColon.Name.ToString(),
                node.ArgumentList.Arguments.Select(x => (JsExpression)x.Accept(this)).ToArray()
            ).ToArray();

            return idioms.InvokeMethodAsThis(method, arguments);
        }

        public override JsNode VisitDestructorDeclaration(DestructorDeclarationSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitEventDeclaration(EventDeclarationSyntax node)
        {
            var block = new JsBlockStatement();

            var property = model.GetDeclaredSymbol(node);
            var adder = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind() == SyntaxKind.AddKeyword);
            var remover = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind() == SyntaxKind.RemoveKeyword);
            var propertyName = property.GetMemberName();

            var adderBody = new JsBlockStatement();
            var addValueParameter = Js.Parameter("value");
            PushDeclaration(property.AddMethod);
            PushOutput(adderBody);
            DeclareInCurrentScope(property.AddMethod.Parameters.Last(), addValueParameter);
            adderBody.Aggregate((JsStatement)adder.Body.Accept(this));
            block.Add(idioms.StoreInPrototype("add_" + propertyName, Js.Function(addValueParameter).Body(adderBody)));
            PopOutput();
            PopDeclaration();

            var removerBody = new JsBlockStatement();
            var removeValueParameter = Js.Parameter("value");
            PushDeclaration(property.RemoveMethod);
            PushOutput(removerBody);
            DeclareInCurrentScope(property.RemoveMethod.Parameters.Last(), removeValueParameter);
            removerBody.Aggregate((JsStatement)remover.Body.Accept(this));
            block.Add(idioms.StoreInPrototype("remove_" + propertyName, Js.Function(removeValueParameter).Body(removerBody)));
            PopOutput();
            PopDeclaration();

            return block;
        }

        public override JsNode VisitIndexerDeclaration(IndexerDeclarationSyntax node)
        {
            var block = new JsBlockStatement();
            PushOutput(block);

            var property = model.GetDeclaredSymbol(node);
            var isExported = property.IsExported();
            if (!isExported)
                return block;

            var getter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind() == SyntaxKind.GetKeyword);
            var setter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind() == SyntaxKind.SetKeyword);

            if (getter != null)
            {
                var getterSymbol = model.GetDeclaredSymbol(getter);
                PushDeclaration(property.GetMethod);
                var addBody = new JsBlockStatement();
                var parameters = node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)).ToArray();
                for (var i = 0; i < getterSymbol.Parameters.Length; i++)
                {
                    var parameter = getterSymbol.Parameters[i];
                    DeclareInCurrentScope(parameter, parameters[i]);
                }
                PushOutput(addBody);
                if (getter.Body != null)
                    addBody.Aggregate((JsBlockStatement)getter.Body.Accept(this));
                block.Add(idioms.StoreInPrototype(getterSymbol.GetMemberName(), Js.Function(parameters.ToArray()).Body(addBody)));
                PopOutput();
                PopDeclaration();
            }
            if (setter != null)
            {
                var setterSymbol = model.GetDeclaredSymbol(setter);
                PushDeclaration(property.SetMethod);
                var valueParameter = Js.Parameter("value");
                DeclareInCurrentScope(property.SetMethod.Parameters.Last(), valueParameter);
                var parameters = node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)).ToArray();
                for (var i = 0; i < setterSymbol.Parameters.Length - 1; i++)
                {
                    var parameter = setterSymbol.Parameters[i];
                    DeclareInCurrentScope(parameter, parameters[i]);
                }
                var removeBody = new JsBlockStatement();
                PushOutput(removeBody);
                if (setter.Body != null)
                    removeBody.Aggregate((JsBlockStatement)setter.Body.Accept(this));
                block.Add(idioms.StoreInPrototype(setterSymbol.GetMemberName(), Js.Function(parameters.Concat(new[] { valueParameter }).ToArray()).Body(removeBody)));
                PopOutput();
                PopDeclaration();
            }                

            // Also store all interface implementations
            var implementedInterfaceMembers = SymbolFinder.FindImplementedInterfaceMembersAsync(property.GetRootOverride(), Context.Instance.Solution).Result;
            foreach (IPropertySymbol interfaceImplementation in implementedInterfaceMembers)
            {
                if (interfaceImplementation.GetMethod != null)
                    block.Add(idioms.MapInterfaceMethod(idioms.GetPrototype(), interfaceImplementation.GetMethod, idioms.GetFromPrototype(property.GetMethod.GetMemberName())));
                if (interfaceImplementation.SetMethod != null)
                    block.Add(idioms.MapInterfaceMethod(idioms.GetPrototype(), interfaceImplementation.SetMethod, idioms.GetFromPrototype(property.SetMethod.GetMemberName())));
            }

            PopOutput();
            return block;
        }

        public override JsNode VisitAccessorList(AccessorListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitAccessorDeclaration(AccessorDeclarationSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitParameterList(ParameterListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitBracketedParameterList(BracketedParameterListSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitParameter(ParameterSyntax node)
        {
            var symbol = model.GetDeclaredSymbol(node);
            var parameter = Js.Parameter(JsNames.EscapeIfReservedWord(symbol.Name));
            if (symbol.RefKind == RefKind.None)
                DeclareInCurrentScope(symbol, parameter);
            else 
                DeclareInCurrentScope(symbol, new Idioms.ReferenceParameterDeclaration(parameter));
            return parameter;
        }

        public override JsNode VisitMemberBindingExpression(MemberBindingExpressionSyntax node)
        {
            var member = model.GetSymbolInfo(node).Symbol;
            var target = memberBindingTargets.Pop();
            return idioms.MemberReference(target, member);
        }

        // Null-propagating operator
        public override JsNode VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            var expression = (JsExpression)node.Expression.Accept(this);

            var type = model.GetTypeInfo(node).ConvertedType;
            if (Equals(type.OriginalDefinition, Context.Instance.NullableType))
            {
                type = type.GetGenericArgument(Context.Instance.NullableType, 0);
            }

            var jsParameter = Js.Parameter("$target");
            memberBindingTargets.Push(jsParameter.GetReference());
            var whenNotNull = (JsExpression)node.WhenNotNull.Accept(this);

            return idioms.InvokeStatic
            (
                Context.Instance.NullPropagation, 
                Js.This(), 
                expression, 
                idioms.DefaultValue(type), 
                Js.Function(jsParameter).Body(whenNotNull.Return())
            );
        }

        public override JsNode VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            var stringParts = new List<JsExpression>();
            foreach (var part in node.Contents)
            {
                if (part is InterpolatedStringTextSyntax)
                {
                    var s = (InterpolatedStringTextSyntax)part;
                    stringParts.Add(Js.Literal(s.TextToken.ValueText));
                }
                else
                {
                    var interpolation = (InterpolationSyntax)part;
                    stringParts.Add(idioms.InvokeStatic(Context.Instance.SafeToString, (JsExpression)interpolation.Expression.Accept(this)));
                }
            }

            // If the interpolated string is just $"" then there will be no string parts. So just return the empty string.
            if (!stringParts.Any())
                return Js.Literal("");

            var current = stringParts.First();
            foreach (var rest in stringParts.Skip(1))
            {
                current = current.Add(rest);
            }

            return ImplicitCheck(node, current);
        }

        public override JsNode VisitArrowExpressionClause(ArrowExpressionClauseSyntax node)
        {
            return node.Expression.Accept(this);
        }

        public override JsNode VisitIncompleteMember(IncompleteMemberSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitSkippedTokensTrivia(SkippedTokensTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitDocumentationCommentTrivia(DocumentationCommentTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlElement(XmlElementSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlElementStartTag(XmlElementStartTagSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlElementEndTag(XmlElementEndTagSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlEmptyElement(XmlEmptyElementSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlName(XmlNameSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlPrefix(XmlPrefixSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlText(XmlTextSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlCDataSection(XmlCDataSectionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlProcessingInstruction(XmlProcessingInstructionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitXmlComment(XmlCommentSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitIfDirectiveTrivia(IfDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitElifDirectiveTrivia(ElifDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitElseDirectiveTrivia(ElseDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitEndIfDirectiveTrivia(EndIfDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitRegionDirectiveTrivia(RegionDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitEndRegionDirectiveTrivia(EndRegionDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitErrorDirectiveTrivia(ErrorDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitWarningDirectiveTrivia(WarningDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitBadDirectiveTrivia(BadDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitDefineDirectiveTrivia(DefineDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitUndefDirectiveTrivia(UndefDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitLineDirectiveTrivia(LineDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitPragmaWarningDirectiveTrivia(PragmaWarningDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitPragmaChecksumDirectiveTrivia(PragmaChecksumDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitReferenceDirectiveTrivia(ReferenceDirectiveTriviaSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitCompilationUnit(CompilationUnitSyntax node)
        {
            throw new Exception();
        }

        private JsNode ImplicitCheck(ExpressionSyntax node, JsNode result)
        {
            var typeInfo = model.GetTypeInfo(node);
            if (typeInfo.ConvertedType == null)
                return result;

            var conversion = model.ClassifyConversion(node, typeInfo.ConvertedType);
            var namedTypeSymbol = typeInfo.ConvertedType as INamedTypeSymbol;
            if (!Equals(typeInfo.Type, typeInfo.ConvertedType) && namedTypeSymbol != null && !Equals(namedTypeSymbol.OriginalDefinition, namedTypeSymbol) && Equals(namedTypeSymbol.OriginalDefinition, Context.Instance.ExpressionLambda))
            {
                var expressionTreeTransformer = new ExpressionTreeTransformer(model, idioms);
                return node.Accept(expressionTreeTransformer);
            }
            if (!Equals(typeInfo.Type, typeInfo.ConvertedType) && conversion.IsMethodGroup && namedTypeSymbol.DelegateInvokeMethod != null)
            {
                var symbol = model.GetSymbolInfo(node).Symbol;
                var thisReference = node is MemberAccessExpressionSyntax ? (JsExpression)((MemberAccessExpressionSyntax)node).Expression.Accept(this) : symbol.IsStatic ? (JsExpression)Js.Reference(SpecialNames.TypeInitializerTypeFunction) : Js.This();
                var delegateType = idioms.Type(typeInfo.ConvertedType);
                var arguments = new List<JsExpression>()
                {
                    thisReference, 
                    (JsExpression)result, 
                    model.Compilation.Assembly.AreDelegatesMinimized() ? Js.Null() : delegateType, 
                    Js.Primitive(symbol.GetMemberName() + "$delegate")
                };
                result = idioms.InvokeStatic(Context.Instance.ObjectCreateDelegate, arguments.ToArray());
            }
            if (conversion.IsUserDefined && conversion.MethodSymbol.IsExported())
            {
                result = idioms.InvokeStatic(conversion.MethodSymbol, (JsExpression)result);
            }
//            if (typeInfo.ConvertedType == context.String && typeInfo.Type != null && typeInfo.Type != context.String && typeInfo.Type != context.JsString && !typeInfo.Type.IsValueType)
//            {
//                result = idioms.Invoke((JsExpression)result, context.ObjectToString);
//            }
            return result;
        }

        public class LoopEntry
        {
            public string Label { get; set; }
            public int Depth { get; set; }
        }
    }
}
