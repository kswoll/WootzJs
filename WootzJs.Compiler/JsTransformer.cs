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
using System.IO;
using System.Linq;
using System.Runtime.WootzJs;
using Roslyn.Compilers;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class JsTransformer : SyntaxVisitor<JsNode>
    {
        internal SyntaxTree syntaxTree;
        internal SemanticModel model;
        internal List<Scope> scopes = new List<Scope>();
        internal Idioms idioms;
        internal List<JsBlockStatement> outputBlockStack = new List<JsBlockStatement>();
        private Stack<IJsDeclaration> initializableObjectsStack = new Stack<IJsDeclaration>();
        private Stack<Symbol> declarationStack = new Stack<Symbol>();
        private Stack<LoopEntry> loopLabels = new Stack<LoopEntry>();

        public JsTransformer(SyntaxTree syntaxTree, SemanticModel model)
        {
            this.syntaxTree = syntaxTree;
            this.model = model;
            idioms = new Idioms(this);
        }

        public int GetLabelDepth(string label)
        {
            foreach (var entry in loopLabels)
            {
                if (entry.Label == label)
                    return entry.Depth;
            }
            throw new Exception();
        }

        public Scope PushScope(Symbol symbol)
        {
            return PushScope(scopes.Any() ? scopes.Last() : null, symbol);
        }

        public Scope PushScope(Scope parent, Symbol symbol)
        {
            var scope = new Scope(symbol);
            scopes.Add(scope);
            if (parent != null)
            {
                scope.AddDeclarations(parent.Declarations.ToArray());
            }

            return scope;
        }

        public bool IsDeclaredInScope(Scope scope, string name)
        {
            var declaration = scope[name];
            return declaration != null;
        }

        public void DeclareInCurrentScope(params IJsDeclaration[] declarations)
        {
            scopes.Last().AddDeclarations(declarations);
        }

        private Dictionary<Symbol, int> currentAnonymousNames = new Dictionary<Symbol, int>();

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

        public void PopScope()
        {
            scopes.RemoveAt(scopes.Count - 1);
        }

        public class ReferenceTracker : IDisposable
        {
            public List<IJsDeclaration> ReferencedDeclarations { get; set; }

            private JsTransformer transformer;
            private Scope scope;

            internal ReferenceTracker(JsTransformer transformer)
            {
                this.transformer = transformer; 
                this.scope = transformer.scopes.Last();
                ReferencedDeclarations = new List<IJsDeclaration>();
            }

            public void Add(IJsDeclaration declaration, string name)
            {
                if (!ReferencedDeclarations.Any(x => x.Name == declaration.Name) && transformer.IsDeclaredInScope(scope, name))
                    ReferencedDeclarations.Add(declaration);
            }

            public void Dispose()
            {
                transformer.StopTrackingReferences(this);
            }
        }

        private List<ReferenceTracker> referenceTracking = new List<ReferenceTracker>();

        private ReferenceTracker TrackReferences()
        {
            var result = new ReferenceTracker(this);
            referenceTracking.Add(result);
            return result;
        }

        private void StopTrackingReferences(ReferenceTracker tracker)
        {
            referenceTracking.Remove(tracker);
        }

        public IJsDeclaration ReferenceDeclarationInScope(string name)
        {
            var scope = scopes.Last();
            var declaration = scope[name];
            if (declaration != null)
            {
                foreach (var tracker in referenceTracking)
                {
                    tracker.Add(declaration, name);
                }
                return declaration;
            }
            throw new InvalidOperationException("Symbol not found in scope: " + name);
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

        public void PushDeclaration(Symbol symbol)
        {
            declarationStack.Push(symbol);
        }

        public void PopDeclaration()
        {
            declarationStack.Pop();
        }

        public Symbol CurrentDeclaration
        {
            get { return declarationStack.Peek(); }
        }

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
            if (idioms.TryUnwrapSpecialFunctions(node, jsBlock))
                return jsBlock;

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
                typeInitializer.Aggregate(CreateDefaultConstructor(node));
            }

            foreach (var member in node.Members)
            {
                var block = (JsBlockStatement)member.Accept(this);
                typeInitializer.Aggregate(block);
            }

            // Initialize all the static fields
            staticInitializer.Aggregate(idioms.InitializeStaticFields(node));
//            foreach (var field in node.Members.OfType<FieldDeclarationSyntax>())
//            {
//                foreach (var variable in field.Declaration.Variables)
//                {
//                    var fieldSymbol = (FieldSymbol)model.GetDeclaredSymbol(variable);
//                    if (fieldSymbol.IsStatic && variable.Initializer != null)
//                    {
//                        staticInitializer.Assign(idioms.Type(fieldSymbol.ContainingType).Member(fieldSymbol.GetMemberName()), (JsExpression)variable.Initializer.Accept(this));
//                    }
//                }
//            }

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
                typeInitializer.Aggregate(CreateDefaultConstructor(node));
            }

            foreach (var member in node.Members)
            {
                var block = (JsBlockStatement)member.Accept(this);
                typeInitializer.Aggregate(block);
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
            PushScope(null);
            var constructorNameParameter = Js.Parameter("name");
            var constructorValueParameter = Js.Parameter("value");
            var constructorBlock = new JsBlockStatement();
            constructorBlock.Express(idioms.InvokeMethodAsThis((MethodSymbol)Context.Instance.EnumType.GetConstructors().Where(x => !x.IsStatic).First(), 
                constructorNameParameter.GetReference(), constructorValueParameter.GetReference()));
            typeInitializer.Add(idioms.StoreInPrototype("$ctor", Js.Function(constructorNameParameter, constructorValueParameter).Body(constructorBlock)));
            typeInitializer.Aggregate(idioms.InitializeConstructor(enumType, "$ctor", new[] { "name", "value" }));
            PopScope();

            // Instantiate all the enum members
            FieldSymbol lastEnum = null;
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
                    value = idioms.GetEnumValue(lastEnum).Add(Js.Primitive(1));

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

            var getter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind == SyntaxKind.GetKeyword);
            var setter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind == SyntaxKind.SetKeyword);
            var propertyName = property.GetMemberName();

            Func<string, JsExpression, JsExpressionStatement> storeIn = (member, value) => !property.IsStatic ? idioms.StoreInPrototype(member, value) : idioms.StoreInType(member, value);

            if (getter != null && setter != null && getter.Body == null && setter.Body == null)
            {
                var backingField = property.GetBackingFieldName();
                var valueParameter = Js.Parameter("value");

                block.Add(storeIn(property.GetMethod.GetMemberName(), Js.Function().Body(Js.Return(Js.This().Member(backingField))).Compact()));
                block.Add(storeIn(property.SetMethod.GetMemberName(), Js.Function(valueParameter).Body(
                    Js.Assign(Js.This().Member(backingField), valueParameter.GetReference())).Compact()));
            }
            else
            {
                if (getter != null)
                {
                    PushDeclaration(property.GetMethod);
                    PushScope(property.GetMethod);
                    var getterBody = new JsBlockStatement();
                    PushOutput(getterBody);
                    if (getter.Body != null)
                        getterBody.Aggregate((JsStatement)getter.Body.Accept(this));
                    block.Add(storeIn(property.GetMethod.GetMemberName(), Js.Function().Body(getterBody)));
                    PopOutput();
                    PopScope();
                    PopDeclaration();
                }
                if (setter != null)
                {
                    var setterBody = new JsBlockStatement();
                    var valueParameter = Js.Parameter("value");
                    PushDeclaration(property.SetMethod);
                    PushScope(property.SetMethod);
                    PushOutput(setterBody);
                    DeclareInCurrentScope(valueParameter);
                    if (setter.Body != null)
                        setterBody.Aggregate((JsStatement)setter.Body.Accept(this));
                    block.Add(storeIn("set_" + propertyName, Js.Function(valueParameter).Body(setterBody)));
                    PopOutput();
                    PopScope();
                    PopDeclaration();
                }                
            }

            // Also store all interface implementations
            foreach (PropertySymbol interfaceImplementation in property.GetRootOverride().FindImplementedInterfaceMembers(Context.Instance.Solution))
            {
                if (interfaceImplementation.GetMethod != null)
                    block.Add(idioms.StoreInPrototype(interfaceImplementation.GetMethod.GetMemberName(), idioms.GetFromPrototype(property.GetMethod.GetMemberName())));
                if (interfaceImplementation.SetMethod != null)
                    block.Add(idioms.StoreInPrototype(interfaceImplementation.SetMethod.GetMemberName(), idioms.GetFromPrototype(property.SetMethod.GetMemberName())));
            }

            return block;
        }

        private JsBlockStatement CreateDefaultConstructor(BaseTypeDeclarationSyntax type)
        {
            var classType = model.GetDeclaredSymbol(type);
            PushScope(null);

            var fullTypeName = type.GetFullName();
            var constructorBlock = new JsBlockStatement();

            if (fullTypeName != "System.Object")
            {
                constructorBlock.Express(idioms.InvokeParameterlessBaseClassConstructor(classType.BaseType));
            }

            if (type is ClassDeclarationSyntax)
            {
                constructorBlock.Aggregate(idioms.InitializeInstanceFields((ClassDeclarationSyntax)type));
            }

            var assignConstructorToPrototype = idioms.StoreInPrototype(classType.GetDefaultConstructorName(), Js.Function().Body(constructorBlock));
            var block = new JsBlockStatement();
            block.Add(assignConstructorToPrototype);
            block.Aggregate(idioms.InitializeConstructor(classType, classType.GetDefaultConstructorName(), new ParameterSymbol[0]));
            PopScope();

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
            PushScope(constructor);
            PushOutput(block);

            var parameters = node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)).ToArray();

            var fullTypeName = classType.GetFullName();
            var constructorBlock = new JsBlockStatement();

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

            var constructorName = JsNames.GetMemberName(constructor);
            block.Add(idioms.StoreInPrototype(constructorName, Js.Function(parameters).Body(constructorBlock)));
            block.Aggregate(idioms.InitializeConstructor(classType, constructorName, constructor.Parameters.ToArray()));

            PopOutput();
            PopScope();
            PopDeclaration();
            return block;
        }

        public override JsNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var method = model.GetDeclaredSymbol(node);
            var block = new JsBlockStatement();

            var isExported = method.IsExported();
            if (!isExported)
                return block;

            PushDeclaration(method);
            PushScope(method);
            PushOutput(block);
            var parameters = new List<JsParameter>();
            if (node.TypeParameterList != null)
                parameters.AddRange(node.TypeParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)));
            parameters.AddRange(node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)));

            JsStatement body;
            if (node.Body == null)
                body = new JsBlockStatement();
            else if (YieldChecker.HasYield(node))
            {
                // Get generated enumerator
                var generatorType = (NamedTypeSymbol)method.ContainingType.GetMembers().Single(x => x.Name == "YieldEnumerator$" + method.GetMemberName());
                var constructor = generatorType.InstanceConstructors.Single();
                var generatorTypeExpression = idioms.Type(generatorType);
                if (method.TypeParameters.Any())
                {
                    generatorTypeExpression = idioms.MakeGenericType(generatorType, method.TypeArguments.Select(x => idioms.Type(x)).ToArray());
                }

                var arguments = new List<JsExpression>();
                if (!method.IsStatic)
                    arguments.Add(Js.This());
                arguments.AddRange(method.Parameters.Select(x => Js.Reference(x.Name)));
                body = Js.Return(idioms.CreateObject(generatorTypeExpression, constructor, arguments.ToArray()));
            }
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
                foreach (MethodSymbol interfaceImplementation in method.GetRootOverride().FindImplementedInterfaceMembers(Context.Instance.Solution))
                {
                    block.Add(idioms.StoreInPrototype(interfaceImplementation.GetMemberName(), idioms.GetFromPrototype(memberName)));
                }
            }

            PopScope();
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
            PushScope(method);
            PushOutput(block);
            var parameters = new List<JsParameter>();
            parameters.AddRange(node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)));

            var body = node.Body == null ? new JsBlockStatement() : (JsBlockStatement)node.Body.Accept(this);
            var methodFunction = Js.Function(parameters.ToArray()).Body(body);
            var memberName = method.GetMemberName();
            block.Add(idioms.StoreInType(memberName, methodFunction));

            PopScope();
            PopOutput();
            PopDeclaration();

            return block;
        }

        public override JsNode VisitBlock(BlockSyntax node)
        {
            PushScope(null);
            var result = new JsBlockStatement();
            PushOutput(result);
            foreach (var statement in node.Statements)
            {
                result.Add((JsStatement)statement.Accept(this));
            }
            PopOutput();
            PopScope();
            return result;
        }

        public override JsNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            var symbol = model.GetSymbolInfo(node).Symbol;
            if (symbol == null)
            {
                var diagnostics = model.GetDiagnostics();
            }
            var @this = (JsExpression)Js.This();
            if (symbol.IsStatic && symbol.ContainingType != null)
            {
                @this = idioms.Type(symbol.ContainingType);
                if (!(@this is JsInvocationExpression))
                    @this = @this.Invoke();
            }
            var result = idioms.MemberReference(@this, symbol, node.Parent is BinaryExpressionSyntax && node.Parent.Kind == SyntaxKind.AssignExpression && ((BinaryExpressionSyntax)node.Parent).Left == node);
            return ImplicitCheck(node, result);
        }

        public override JsNode VisitQualifiedName(QualifiedNameSyntax node)
        {
            throw new Exception();
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

        public override JsNode VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
        {
            var operand = (JsExpression)node.Operand.Accept(this);
            var operandType = model.GetTypeInfo(node.Operand);
            JsExpression result;
            if (idioms.TryCharUnaryExpression(node.Kind, operandType, operand, out result))
                return result;
            JsUnaryOperator op;

            switch (node.Kind)
            {
                case SyntaxKind.NegateExpression:
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
            if (idioms.TryCharUnaryExpression(node.Kind, operandType, operand, out result))
                return result;

            JsUnaryOperator op;

            switch (node.Kind)
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
            var symbol = model.GetSymbolInfo(node).Symbol;
/*
            if (symbolInfo.Symbol == null)
            {
                var classText = node.FirstAncestorOrSelf<ClassDeclarationSyntax>().NormalizeWhitespace().ToString();
                var diagnostics = model.GetDiagnostics().Select(x => x.ToString()).ToArray();
            }
*/

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
                if (symbol.IsStatic && expressionSymbol != null && expressionSymbol != symbol.ContainingType && symbol.ContainingType != null)
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

            var result = idioms.MemberReference(target, symbol, false, isBaseReference);
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
            if (idioms.TryAccessorAssignment(node.Kind, leftSymbol, rightSymbol, left, right, out result))
                return ImplicitCheck(node, result);
            if (idioms.TryIsExpression(node.Kind, leftSymbol, rightSymbol, left, right, out result))
                return ImplicitCheck(node, result);
            if (idioms.TryAsExpression(node.Kind, leftSymbol, rightSymbol, left, right, out result))
                return result;
            if (idioms.TryCharBinaryExpression(node.Kind, leftType, rightType, left, right, out result))
                return result;
            if (idioms.TryStringConcatenation(node.Kind, leftType, rightType, left, right, out result))
                return result;
            if (idioms.TryEnumBitwise(node.Kind, leftType.Type, rightType.Type, left, right, out result))
                return result;

            if (symbol != null)
            {
                var method = (MethodSymbol)symbol;
                if (method.IsExported())
                    return ImplicitCheck(node, idioms.InvokeStatic(method, left, right));
            }
            var op = idioms.ToBinaryOperator(node.Kind);
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
            var type = (TypeSymbol)model.GetSymbolInfo(node.Type).Symbol;
            var result = idioms.TypeOf(type);
            return ImplicitCheck(node, result);
        }

        public override JsNode VisitSizeOfExpression(SizeOfExpressionSyntax node)
        {
            throw new Exception();
        }

        public override JsNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node).Symbol;
            var method = (MethodSymbol)symbol;
            var actualArguments = node.ArgumentList.Arguments.Select(x => (JsExpression)x.Accept(this)).ToArray();

            JsExpression specialResult;
            if (idioms.TryBaseMethodInvocation(node, method, actualArguments, out specialResult))
                return ImplicitCheck(node, specialResult);

/*
            if (model.GetTypeInfo(((Roslyn.Compilers.CSharp.MemberAccessExpressionSyntax)(node.Expression)).Expression).ConvertedType.BaseType is ErrorTypeSymbol)
            {
                var diagnostics = model.GetDiagnostics();
                var diagnostics2 = model.GetDeclarationDiagnostics();
            }
*/
            var target = (JsExpression)node.Expression.Accept(this);
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

            var arguments = idioms.TranslateArguments(
                method, 
                (x, i) => model.GetTypeInfo(node.ArgumentList.Arguments[i].Expression).ConvertedType is ArrayTypeSymbol, 
                (x, i) => node.ArgumentList.Arguments[i].NameColon == null ? null : node.ArgumentList.Arguments[i].NameColon.Name.ToString(),
                actualArguments.ToArray()
            ).ToList();
            var isExtension = method.IsExtension();

            var prependers = new List<JsStatement>();
            var appenders = new List<JsStatement>();
            idioms.InstrumentRefAndOutParameters(method, arguments, prependers, appenders);

            var typeArguments = method.TypeParameters.Any() ? method.TypeArguments.Select(x => idioms.Type(x)).ToArray() : new JsExpression[0];
            var invokedAsExtensionMethod = false;

            // Extension methods come in as target.ExtensionMethod(arg1, arg2...) but we want them as ExtensionMethod(target, arg1, arg2...), and that's
            // what ReducedFrom is
            if (method.ReducedFrom != null)
            {
                method = method.ReducedFrom;
                invokedAsExtensionMethod = true;
            }
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
                invocation = Js.Invoke(target, typeArguments.Concat(arguments).ToArray());
            }

            if (idioms.TryApplyRefAndOutParametersAfterInvocation(method, invocation, out specialResult, prependers, appenders))
                return ImplicitCheck(node, specialResult);

            return invocation;
        }

        public override JsNode VisitElementAccessExpression(ElementAccessExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node);
            var target = (JsExpression)node.Expression.Accept(this);
            var arguments = (JsExpression)node.ArgumentList.Arguments[0].Accept(this);

            if (symbol.Symbol is PropertySymbol)
            {
                var property = (PropertySymbol)symbol.Symbol;
                var isExported = property.IsExported();
                var nameOverride = property.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
                if (isExported)
                {
                    return idioms.Get(target, property, arguments);
                }
                else if (nameOverride != null)
                {
                    return target.Member(nameOverride).Invoke(arguments);
                }
            }

            return ImplicitCheck(node, Js.Index(target, arguments));
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
                var method = (MethodSymbol)symbol;
                return ImplicitCheck(node, idioms.InvokeStatic(method, (JsExpression)node.Expression.Accept(this)));
            }

            var target = (JsExpression)node.Expression.Accept(this);
            if (node.Expression is LiteralExpressionSyntax && node.Expression.Kind == SyntaxKind.NullLiteralExpression)
            {
                return ImplicitCheck(node, target);
            }

            var typeInfo = model.GetTypeInfo(node.Expression);
            var originalType = typeInfo.Type;
            var convertedType = typeInfo.ConvertedType;
            var destinationType = model.GetTypeInfo(node.Type).Type;

            Func<TypeSymbol, bool> isInteger = x => x == Context.Instance.Byte || x == Context.Instance.SByte ||
                x == Context.Instance.Int16 || x == Context.Instance.UInt16 ||
                x == Context.Instance.Int32 || x == Context.Instance.UInt32 ||
                x == Context.Instance.Int64 || x == Context.Instance.UInt64;
            Func<TypeSymbol, bool> isDecimal = x => x == Context.Instance.Single || 
                x == Context.Instance.Double || x == Context.Instance.Decimal;

            if (originalType.TypeKind == TypeKind.Enum)
            {
                return idioms.Invoke(target, Context.Instance.EnumGetValue);
            }
            if (destinationType.TypeKind == TypeKind.Enum && isInteger(convertedType))
            {
                return idioms.InvokeStatic(Context.Instance.EnumInternalToObject, idioms.Type(destinationType).Invoke(), target);
            }
            if (convertedType == Context.Instance.Int32 && convertedType == Context.Instance.Char)
            {
                return target.Member("charCodeAt").Invoke();
            }
            if (isDecimal(convertedType) && isInteger(destinationType))
            {
                return Js.Reference(SpecialNames.Truncate).Invoke(target);
            }

            var cast = idioms.InvokeStatic(Context.Instance.ObjectCast.Construct(convertedType), target);
            return ImplicitCheck(node, cast);
        }

        private JsNode VisitLambdaExpression(NamedTypeSymbol delegateType, ParameterSyntax[] parameterNodes, SyntaxNode bodyNode)
        {
            if (delegateType.IsGenericType && delegateType.OriginalDefinition == Context.Instance.ExpressionGeneric)
            {
                delegateType = (NamedTypeSymbol)delegateType.TypeArguments[0];
            }

            PushScope(null);

            var block = new JsBlockStatement();
            JsParameter[] parameters = parameterNodes.Select(x => (JsParameter)x.Accept(this)).ToArray();

            PushOutput(block);

            var body = bodyNode.Accept(this);
            if (body is JsStatement)
            {
                block.Aggregate((JsStatement)body);
            }
            else if (delegateType.DelegateInvokeMethod.ReturnsVoid)
            {
                block.Add(Js.Express((JsExpression)body));
            }
            else
            {
                block.Add(Js.Return((JsExpression)body));
            }

            PopOutput();
            PopScope();

            var createDelegate = idioms.InvokeStatic(Context.Instance.ObjectCreateDelegate, Js.This(), idioms.Type(delegateType), Js.Function(parameters).Body(block));
            return createDelegate;
        }

        public override JsNode VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            var delegateType = (NamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            return ImplicitCheck(node, VisitLambdaExpression(delegateType, new[] { node.Parameter }, node.Body));
        }

        public override JsNode VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            var delegateType = (NamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            return ImplicitCheck(node, VisitLambdaExpression(delegateType, node.ParameterList.Parameters.ToArray(), node.Body));
        }

        public override JsNode VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node)
        {
            var delegateType = (NamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
            return ImplicitCheck(node, VisitLambdaExpression(delegateType, node.ParameterList == null ? new ParameterSyntax[0] : node.ParameterList.Parameters.ToArray(), node.Block));
        }

        public override JsNode VisitAnonymousObjectMemberDeclarator(AnonymousObjectMemberDeclaratorSyntax node)
        {
            return node.Expression.Accept(this);
        }

        public override JsNode VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node);
            var method = (MethodSymbol)symbol.Symbol;
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
                var newTarget = initializableObjectsStack.Peek().GetReference();
                switch (node.Kind)
                {
                    case SyntaxKind.ObjectInitializerExpression:
                    {
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
                        var arguments = new List<JsExpression>();
                        var objectCreateExpression = (ObjectCreationExpressionSyntax)node.Parent;
                        var constructor = model.GetSymbolInfo(objectCreateExpression).Symbol;
                        MethodSymbol addMethod;
                        if (statement is InitializerExpressionSyntax)
                        {
                            var initializer = (InitializerExpressionSyntax)statement;
                            addMethod = constructor.ContainingType.GetMembers("Add").OfType<MethodSymbol>().First(x => x.Parameters.Count == 2);
                            arguments.AddRange(initializer.Expressions.Select(x => (JsExpression)x.Accept(this)));
                        }
                        else
                        {
                            var expression = (JsExpression)statement.Accept(this);
                            addMethod = constructor.ContainingType.GetMembers("Add").OfType<MethodSymbol>().First(x => x.Parameters.Count == 1);
                            arguments.Add(expression);
                        }
                        block.Express(idioms.Invoke(newTarget, addMethod, arguments.ToArray()));
                        break;
                    }
/*
                    case SyntaxKind.ArrayInitializerExpression:
                    {
                        
                    }
*/
                    default:
                        throw new Exception();
                }
            }

            return block;
        }

        public override JsNode VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            var symbol = model.GetSymbolInfo(node.Type);
            if (symbol.Symbol is TypeParameterSymbol)
            {
                var typeParameter = (TypeParameterSymbol)symbol.Symbol;
                return Js.Reference(typeParameter.Name).Member("prototype").Member("$ctor").Member("$new").Invoke();
            }

            var method = (MethodSymbol)symbol.Symbol;
            var type = method.ContainingType;

            if (type == Context.Instance.MulticastDelegateType)
            {
                return ImplicitCheck(node, idioms.CreateMulticastDelegate((JsExpression)node.ArgumentList.Arguments[0].Accept(this), 
                    (JsExpression)node.ArgumentList.Arguments[1].Accept(this)));
            }

            var isExported = type.IsExported();
            var isBuiltIn = type.GetAttributeValue(Context.Instance.JsAttributeType, "BuiltIn", false);
            var actualArguments = node.ArgumentList == null ? new List<JsExpression>() : node.ArgumentList.Arguments.Select(x => (JsExpression)x.Accept(this));
            var args = idioms.TranslateArguments(
                method, 
                (x, i) => model.GetTypeInfo(node.ArgumentList.Arguments[i].Expression).ConvertedType is ArrayTypeSymbol, 
                (x, i) => node.ArgumentList.Arguments[i].NameColon == null ? null : node.ArgumentList.Arguments[i].NameColon.Name.ToString(),
                actualArguments.ToArray()
            ).ToList();
            if (isExported && !isBuiltIn)
            {
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

                return ImplicitCheck(node, obj);
            }
            else
            {
                if (type.GetAttributeValue(Context.Instance.JsAttributeType, "InvokeConstructorAsClass", false))
                    return ImplicitCheck(node, Js.Invoke(idioms.Type(type), args.ToArray()));
                else if (!isExported)
                    return ImplicitCheck(node, Js.New(Js.Reference(type.GetName()), args.ToArray()));
                else
                    return ImplicitCheck(node, Js.New(idioms.Type(type), args.ToArray()));
            }
        }

        public override JsNode VisitArrayCreationExpression(ArrayCreationExpressionSyntax node)
        {
            var arrayType = node.Type;
            var arraySymbol = (ArrayTypeSymbol)model.GetTypeInfo(node).Type;
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
            var arraySymbol = (ArrayTypeSymbol)model.GetTypeInfo(node).Type;
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
            var variable = Js.Variable(node.Identifier.ToString(), node.Initializer != null ? (JsExpression)node.Initializer.Accept(this) : null);
            DeclareInCurrentScope(variable);
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

            return Js.Express((JsExpression)node.Expression.Accept(this));
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
                return Js.Return((JsExpression)node.Expression.Accept(this));
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
                expression = idioms.Invoke(expression, Context.Instance.InternalInit, Js.New(Js.Reference("Error")));
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
                nextStatement is LabeledStatementSyntax ? (LabeledStatementSyntax)nextStatement :
                null;
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
                nextStatement is LabeledStatementSyntax ? (LabeledStatementSyntax)nextStatement :
                null;
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
                nextStatement is LabeledStatementSyntax ? (LabeledStatementSyntax)nextStatement :
                null;
            var loopEntry = new LoopEntry();
            if (loopLabel != null)
            {
                loopEntry.Label = loopLabel.Identifier.ToString();
            }
            loopLabels.Push(loopEntry);
            loopEntry.Depth = loopLabels.Count;

            PushScope(null);
            var declaration = node.Declaration == null ? null : (JsVariableDeclaration)node.Declaration.Accept(this);

            var initializers = node.Initializers.Select(x => (JsExpression)x.Accept(this)).ToArray();

            var condition = (JsExpression)node.Condition.Accept(this);
            var incrementors = node.Incrementors.Select(x => (JsExpression)x.Accept(this)).ToArray();

            var block = new JsBlockStatement();
            PushOutput(block);

            block.Aggregate((JsStatement)node.Statement.Accept(this));

            PopScope();
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
                nextStatement is LabeledStatementSyntax ? (LabeledStatementSyntax)nextStatement :
                null;
            var loopEntry = new LoopEntry();
            if (loopLabel != null)
            {
                loopEntry.Label = loopLabel.Identifier.ToString();
            }
            loopLabels.Push(loopEntry);
            loopEntry.Depth = loopLabels.Count;

            PushScope(null);
            var block = new JsBlockStatement();
            var enumerable = (JsExpression)node.Expression.Accept(this);

            // Special handling for native js objects to use for/in
            if (!model.GetTypeInfo(node.Expression).Type.IsExported())
            {
                var forInBlock = new JsBlockStatement();
                PushOutput(forInBlock);

                var item = Js.Variable(node.Identifier.ToString());
                DeclareInCurrentScope(item);

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
                var item = Js.Variable(node.Identifier.ToString(), idioms.Get(enumerator.GetReference(), Context.Instance.EnumeratorCurrent));
                DeclareInCurrentScope(item);

                whileBlock.Local(item);
                whileBlock.Aggregate((JsStatement)node.Statement.Accept(this));

                var whileLoop = new LoopTransformer(this, node, loopEntry.Depth, node.Statement).TransformLoop(Js.While(idioms.Invoke(enumerator.GetReference(), Context.Instance.EnumeratorMoveNext), whileBlock));
                block.Add(whileLoop);
            }

            PopOutput();
            PopScope();

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
                    var disposable = Js.Variable(variable.Identifier.ToString());
                    disposable.Initializer = (JsExpression)variable.Initializer.Value.Accept(this);
                    DeclareInCurrentScope(disposable);
                    result.Local(disposable);
                    disposables.Add(disposable);
                }
            }
            else
            {
                var disposable = Js.Variable(GenerateUniqueNameInScope(), (JsExpression)node.Expression.Accept(this));
                DeclareInCurrentScope(disposable);
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
                node.Else != null ? (JsStatement)node.Else.Accept(this) : null);
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

        public override JsNode VisitSwitchLabel(SwitchLabelSyntax node)
        {
            if (node.Kind == SyntaxKind.DefaultSwitchLabel)
                return Js.DefaultLabel();
            else
                return Js.CaseLabel((JsExpression)node.Value.Accept(this));
        }

        public override JsNode VisitTryStatement(TryStatementSyntax node)
        {
            var result = Js.Try();

            PushOutput(result.Body);
            result.Body.Aggregate((JsStatement)node.Block.Accept(this));
            PopOutput();

            if (node.Catches != null && node.Catches.Any())
            {
                PushScope(null);

                result.Catch = Js.Catch();
                PushOutput(result.Catch.Body);

                if (node.Catches.Count > 1)
                {
                    throw new Exception();
                }
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

                PopOutput();
                PopScope();
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
            if (node.Identifier.Kind == SyntaxKind.None)
            {
                identifier = GenerateUniqueNameInScope();
            }
            var variable = Js.Variable(identifier);
            DeclareInCurrentScope(variable);
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
            PushScope(method);
            var parameters = new List<JsParameter>();
            parameters.AddRange(method.Parameters.Select(x =>
            {
                var parameter = Js.Parameter(x.Name);
                DeclareInCurrentScope(parameter);
                return parameter;
            }));

            var body = new JsBlockStatement();
            body.Return(Js.Invoke(Js.This(), parameters.Select(x => x.GetReference()).ToArray()));
            var methodFunction = Js.Function(parameters.ToArray()).Body(body);

            var memberName = method.GetMemberName();
            typeInitializer.Add(idioms.StoreInPrototype(memberName, methodFunction));

            PopScope();
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

            var type = (ClassDeclarationSyntax)node.Parent;
            var classType = model.GetDeclaredSymbol(type);

            foreach (var variable in node.Declaration.Variables)
            {
                var field = (EventSymbol)model.GetDeclaredSymbol(variable);
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
            PushScope(method);
            PushOutput(block);
            var parameters = new List<JsParameter>();
            parameters.AddRange(node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)));

            var body = node.Body == null ? new JsBlockStatement() : (JsBlockStatement)node.Body.Accept(this);
            var methodFunction = Js.Function(parameters.ToArray()).Body(body);
            var memberName = method.GetMemberName();
            block.Add(idioms.StoreInType(memberName, methodFunction));

            PopScope();
            PopOutput();
            PopDeclaration();

            return block;
        }

        public override JsNode VisitConstructorInitializer(ConstructorInitializerSyntax node)
        {
            var symbol = model.GetSymbolInfo(node);
            var method = (MethodSymbol)symbol.Symbol;

            var arguments = idioms.TranslateArguments(
                method, 
                (x, i) => model.GetTypeInfo(node.ArgumentList.Arguments[i].Expression).ConvertedType is ArrayTypeSymbol, 
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
            var adder = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind == SyntaxKind.AddKeyword);
            var remover = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind == SyntaxKind.RemoveKeyword);
            var propertyName = property.GetMemberName();

            var adderBody = new JsBlockStatement();
            var addValueParameter = Js.Parameter("value");
            PushDeclaration(property.AddMethod);
            PushScope(property.AddMethod);
            PushOutput(adderBody);
            DeclareInCurrentScope(addValueParameter);
            adderBody.Aggregate((JsStatement)adder.Body.Accept(this));
            block.Add(idioms.StoreInPrototype("add_" + propertyName, Js.Function(addValueParameter).Body(adderBody)));
            PopOutput();
            PopScope();
            PopDeclaration();

            var removerBody = new JsBlockStatement();
            var removeValueParameter = Js.Parameter("value");
            PushDeclaration(property.RemoveMethod);
            PushScope(property.RemoveMethod);
            PushOutput(removerBody);
            DeclareInCurrentScope(removeValueParameter);
            removerBody.Aggregate((JsStatement)remover.Body.Accept(this));
            block.Add(idioms.StoreInPrototype("remove_" + propertyName, Js.Function(removeValueParameter).Body(removerBody)));
            PopOutput();
            PopScope();
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

            var getter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind == SyntaxKind.GetKeyword);
            var setter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.Kind == SyntaxKind.SetKeyword);

            if (getter != null)
            {
                var getterSymbol = model.GetDeclaredSymbol(getter);
                PushDeclaration(property.GetMethod);
                PushScope(property.GetMethod);
                var addBody = new JsBlockStatement();
                var parameters = node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)).ToArray();
                PushOutput(addBody);
                if (getter.Body != null)
                    addBody.Aggregate((JsBlockStatement)getter.Body.Accept(this));
                block.Add(idioms.StoreInPrototype(getterSymbol.GetMemberName(), Js.Function(parameters.ToArray()).Body(addBody)));
                PopOutput();
                PopScope();
                PopDeclaration();
            }
            if (setter != null)
            {
                var setterSymbol = model.GetDeclaredSymbol(setter);
                PushDeclaration(property.SetMethod);
                PushScope(property.SetMethod);
                var valueParameter = Js.Parameter("value");
                DeclareInCurrentScope(valueParameter);
                var parameters = node.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(this)).ToArray();
                var removeBody = new JsBlockStatement();
                PushOutput(removeBody);
                if (setter.Body != null)
                    removeBody.Aggregate((JsBlockStatement)setter.Body.Accept(this));
                block.Add(idioms.StoreInPrototype(setterSymbol.GetMemberName(), Js.Function(parameters.Concat(new[] { valueParameter }).ToArray()).Body(removeBody)));
                PopOutput();
                PopScope();
                PopDeclaration();
            }                

            // Also store all interface implementations
            foreach (PropertySymbol interfaceImplementation in property.GetRootOverride().FindImplementedInterfaceMembers(Context.Instance.Solution))
            {
                if (interfaceImplementation.GetMethod != null)
                    block.Add(idioms.StoreInPrototype(interfaceImplementation.GetMethod.GetMemberName(), idioms.GetFromPrototype(property.GetMethod.GetMemberName())));
                if (interfaceImplementation.SetMethod != null)
                    block.Add(idioms.StoreInPrototype(interfaceImplementation.SetMethod.GetMemberName(), idioms.GetFromPrototype(property.SetMethod.GetMemberName())));
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
            var parameter = Js.Parameter(symbol.Name);
            if (symbol.RefKind == RefKind.None)
                DeclareInCurrentScope(parameter);
            else 
                DeclareInCurrentScope(new Idioms.ReferenceParameterDeclaration(parameter));
            return parameter;
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

        public override JsNode VisitXmlAttribute(XmlAttributeSyntax node)
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
            var namedTypeSymbol = typeInfo.ConvertedType as NamedTypeSymbol;
            if (typeInfo.Type != typeInfo.ConvertedType && namedTypeSymbol != null && namedTypeSymbol.OriginalDefinition != namedTypeSymbol && namedTypeSymbol.OriginalDefinition == Context.Instance.ExpressionLambda)
            {
                var expressionTreeTransformer = new ExpressionTreeTransformer(model, idioms);
                return node.Accept(expressionTreeTransformer);
            }
            if (typeInfo.Type != typeInfo.ConvertedType && typeInfo.ImplicitConversion.IsMethodGroup && namedTypeSymbol.DelegateInvokeMethod != null)
            {
                var thisReference = node is MemberAccessExpressionSyntax ? (JsExpression)((MemberAccessExpressionSyntax)node).Expression.Accept(this) : Js.This();
                var symbol = model.GetSymbolInfo(node).Symbol;
                result = idioms.InvokeStatic(Context.Instance.ObjectCreateDelegate, thisReference, idioms.Type(typeInfo.ConvertedType), (JsExpression)result, Js.Primitive(symbol.GetMemberName() + "$delegate"));
            }
            if (typeInfo.ImplicitConversion.IsUserDefined && typeInfo.ImplicitConversion.Method.IsExported())
            {
                result = idioms.InvokeStatic(typeInfo.ImplicitConversion.Method, (JsExpression)result);
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
