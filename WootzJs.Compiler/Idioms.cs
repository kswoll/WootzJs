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
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class Idioms
    {
        private JsTransformer transformer;

        public Idioms(JsTransformer transformer)
        {
            this.transformer = transformer;
        }

        public JsInvocationExpression MakeGenericType(INamedTypeSymbol unconstructedType)
        {
            return MakeGenericType(unconstructedType, unconstructedType.TypeArguments.Select(x => Type(x)).ToArray());
        }

        public JsInvocationExpression MakeGenericType(INamedTypeSymbol unconstructedType, params JsExpression[] typeArguments)
        {
            var containingType = unconstructedType.ContainingType;
            JsExpression target;
            if (containingType != null) 
            {
                target = Type(containingType).Member(unconstructedType.GetShortTypeName() + SpecialNames.MakeGenericType);
            }
            else
            {
                target = Js.Reference(unconstructedType.GetTypeName() + SpecialNames.MakeGenericType);
            }

            var result = target.Invoke(typeArguments);
            return result;
        }

        public JsExpression CreateObject(JsExpression containingType, IMethodSymbol constructor, params JsExpression[] arguments)
        {
            var constructorReference = containingType.Member("prototype").Member(constructor.GetMemberName());

            if (constructor.IsBuiltIn())
            {
                // If the constructor is built-in, then we don't want it invoked at all, since it's just a shim for the built-in
                // version.  Therefore, just call the types constructor passing in the arguments as usual for a normal JS new.
                return Js.New(containingType, arguments);
            }
            else
            {
                // Object creation gets transformed into:
                // new T(T.prototype.ctor, arg1, arg2, arg3...)
                return constructorReference.Member(SpecialNames.New).Invoke(arguments);
            }
        }

        public JsExpression CreateObject(IMethodSymbol constructor, params JsExpression[] arguments)
        {
            return CreateObject(Type(constructor.ContainingType), constructor, arguments);
        }

        public JsBlockStatement CreateTypeFunction(INamedTypeSymbol classType, out JsBlockStatement typeInitializer, out JsBlockStatement staticInitializer)
        {
            var isBuiltIn = classType.IsBuiltIn();
            var explicitBaseType = classType.GetAttributeValue<ITypeSymbol>(Context.Instance.JsAttributeType, "BaseType");
            var baseType = 
                explicitBaseType != null ? Type(explicitBaseType) :
                Equals(classType, Context.Instance.ObjectType) ? Js.Reference("Object") : 
                classType.BaseType == null ? Type(Context.Instance.ObjectType) : 
                Js.Reference(classType.BaseType.GetTypeName());

            var block = new JsBlockStatement();
            JsExpression outerClassType = Js.Reference(classType.GetTypeName());
            if (!isBuiltIn)
            {
                var displayName = classType.Name;
                if (classType.TypeParameters.Any())
                    displayName += "`" + classType.TypeParameters.Count();
                if (classType.ContainingType == null && !classType.IsAnonymousType)
                {
                    block.Assign(Js.Reference(Context.Instance.SymbolNames[classType.ContainingNamespace, classType.ContainingNamespace.GetFullName()]).Member(classType.GetShortTypeName()), 
                        Js.Reference(SpecialNames.Define).Invoke(Js.Primitive(displayName), baseType));
                }
                else if (classType.ContainingType != null)
                {
                    outerClassType = Js.Reference(SpecialNames.TypeInitializerTypeFunction).Member(classType.GetShortTypeName());
                    block.Assign(outerClassType, Js.Reference(SpecialNames.Define).Invoke(Js.Primitive(displayName), baseType));
                }
                else
                {
                    block.Assign(Js.Reference(classType.GetTypeName()), 
                        Js.Reference(SpecialNames.Define).Invoke(Js.Primitive(displayName), baseType));
                }
            }
            typeInitializer = new JsBlockStatement();
            typeInitializer.Add(StoreInType(SpecialNames.GetAssembly, Js.Reference(classType.ContainingAssembly.GetAssemblyMethodName())));
            typeInitializer.Add(StoreInPrototype(SpecialNames.TypeField, Js.Reference(SpecialNames.TypeInitializerTypeFunction)));
            typeInitializer.Add(StoreInType(SpecialNames.BaseType, baseType));
            typeInitializer.Add(StoreInPrototype(SpecialNames.TypeName, Js.Primitive(classType.GetFullName())));
            typeInitializer.Add(StoreInType(SpecialNames.TypeName, GetFromPrototype(SpecialNames.TypeName)));
            typeInitializer.Add(StoreClassGetType());
            typeInitializer.Add(StoreClassCreateType(classType));

            var containingType = classType.ContainingType;
            var typeInitializerFunction = Js.Function(new[] { Js.Parameter(SpecialNames.TypeInitializerTypeFunction), Js.Parameter(SpecialNames.TypeInitializerPrototype) }.Concat(classType.TypeParameters.Select(x => Js.Parameter(x.Name)).ToArray()).ToArray()).Body(typeInitializer);
            block.Express(Js.Assign(outerClassType.Member(SpecialNames.TypeInitializer), typeInitializerFunction)
                .Parenthetical()
                .Member("call")
                .Invoke(
                    new[] 
                    { 
                        containingType == null ? (JsExpression)Js.Null() : Js.Reference(SpecialNames.TypeInitializerTypeFunction), 
                        outerClassType, 
                        outerClassType.Member("prototype")
                    }
                    .Concat(
                        classType.TypeParameters.Select(x => 
                            Js.Reference("$definetypeparameter").Invoke(
                                Js.Primitive(x.Name), 
                                Type(x.BaseType ?? Context.Instance.ObjectType, true)))
                    )
                    .ToArray()
                ));
            block.Express(Js.Reference(classType.ContainingAssembly.GetAssemblyTypesArray()).Member("push").Invoke(outerClassType));

            staticInitializer = new JsBlockStatement();
            staticInitializer.If(GetFromType(SpecialNames.IsStaticInitialized), Js.Return());
            staticInitializer.Add(StoreInType(SpecialNames.IsStaticInitialized, Js.Primitive(true)));
            if (classType.BaseType != null)
            {
                staticInitializer.Express(Type(classType.BaseType).Member(SpecialNames.StaticInitializer).Invoke());
            }
            var staticInitializerFunction = Js.Function().Body(staticInitializer);
            typeInitializer.Add(StoreInType(SpecialNames.StaticInitializer, staticInitializerFunction));

            if (classType.HasOrIsEnclosedInGenericParameters())
            {
                var makeGenericType = new JsBlockStatement();
                makeGenericType.Return(
                    Js.Reference(SpecialNames.MakeGenericTypeConstructor)
                    .Member("call")
                    .Invoke(containingType == null ? (JsExpression)Js.Null() : Js.Reference(SpecialNames.TypeInitializerTypeFunction), SpecialTypeOnlyForEnclosingTypes(classType), Js.Reference("arguments"))
                    .Invoke()
                );
                typeInitializer.Add(StoreInType("$", Js.Function().Body(makeGenericType)));

                JsExpression target;
                if (containingType != null) 
                {
                    target = Js.This().Member(classType.GetShortTypeName() + SpecialNames.MakeGenericType);
                }
                else
                {
                    target = Js.Reference("window." + classType.GetTypeName() + SpecialNames.MakeGenericType);
                }

                typeInitializer.Assign(target, GetFromType("$"));
            }

            return block;
        }

        public JsExpressionStatement StoreClassCreateType(INamedTypeSymbol type)
        {
            var explicitName = type.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            var fullTypeName = type.GetFullName();
            var baseType = type.BaseType != null ? Type(type.BaseType, true) : Js.Null();
            var body = new JsBlockStatement();
            body.Assign(Js.This().Member(SpecialNames.TypeField), 
                CreateObject(Context.Instance.TypeConstructor, Js.Primitive(type.Name), CreateAttributes(type)));

            JsExpression typeAttributes;
            if (type.ContainingType == null)
            {
                switch (type.DeclaredAccessibility)
                {
                    case Accessibility.Public:
                        typeAttributes = GetEnumValue(Context.Instance.TypeAttributesPublic);
                        break;
                    case Accessibility.Internal:
                        typeAttributes = GetEnumValue(Context.Instance.TypeAttributesNotPublic);
                        break;
                    default:
                        throw new Exception();
                }                
            }
            else
            {
                switch (type.DeclaredAccessibility)
                {
                    case Accessibility.Public:
                        typeAttributes = GetEnumValue(Context.Instance.TypeAttributesNestedPublic);
                        break;
                    case Accessibility.Internal:
                        typeAttributes = GetEnumValue(Context.Instance.TypeAttributesNestedAssembly);
                        break;
                    case Accessibility.Private:
                        typeAttributes = GetEnumValue(Context.Instance.TypeAttributesNestedPrivate);
                        break;
                    case Accessibility.Protected:
                        typeAttributes = GetEnumValue(Context.Instance.TypeAttributesNestedFamily);
                        break;
                    case Accessibility.ProtectedOrInternal:
                        typeAttributes = GetEnumValue(Context.Instance.TypeAttributesNestedFamORAssem);
                        break;
                    default:
                        throw new Exception();
                }
            }
            if (type.TypeKind == TypeKind.Interface)
            {
                typeAttributes = EnumBitwise(SyntaxKind.BitwiseOrExpression, Context.Instance.TypeAttributes, 
                    typeAttributes, GetEnumValue(Context.Instance.TypeAttributesInterface));
            }
            else if (type.TypeKind == TypeKind.Class)
            {
                typeAttributes = EnumBitwise(SyntaxKind.BitwiseOrExpression, Context.Instance.TypeAttributes, 
                    typeAttributes, GetEnumValue(Context.Instance.TypeAttributesClass));                
            }
            if (type.IsAbstract)
            {
                typeAttributes = EnumBitwise(SyntaxKind.BitwiseOrExpression, Context.Instance.TypeAttributes, 
                    typeAttributes, GetEnumValue(Context.Instance.TypeAttributesAbstract));                
            }
            else if (type.IsSealed)
            {
                typeAttributes = EnumBitwise(SyntaxKind.BitwiseOrExpression, Context.Instance.TypeAttributes, 
                    typeAttributes, GetEnumValue(Context.Instance.TypeAttributesSealed));                
            }

            body.Express(Invoke(Js.This().Member(SpecialNames.TypeField), Context.Instance.TypeInit, 
                Js.Primitive(explicitName ?? fullTypeName),          // Param1: fullTypeName
                typeAttributes,
                Type(type, true), 
                baseType,
                CreateInterfaceReferences(type),
                MakeArray(Js.Array(type.TypeParameters.Select(x => Js.Reference(x.Name)).ToArray()), Context.Instance.TypeArray),
                CreateFieldInfos(type),
                CreateMethodInfos(type, false),
                CreateMethodInfos(type, true),
                CreatePropertyInfos(type),
                CreateEventInfos(type),
                Js.Primitive(type.IsValueType),
                Js.Primitive(type.IsAbstract),
                Js.Primitive(type.TypeKind == TypeKind.Interface),
                Js.Primitive(type.IsPrimitive()),
                Js.Primitive(type.IsGenericType),
                Js.Primitive(type.TypeParameters.Any()),
                Js.Primitive(type.TypeKind == TypeKind.Enum)));
            body.Return(Js.This().Member(SpecialNames.TypeField));
            var result = StoreInType(SpecialNames.CreateType, Js.Function().Body(body).Compact());
            return result;
        }

        private JsExpression CreateInterfaceReferences(INamedTypeSymbol type)
        {
            return MakeArray(Js.Array(type.AllInterfaces.Select(x => Js.Reference(x.GetTypeName())).ToArray()), Context.Instance.TypeArray);
        }

        private JsExpression CreatePropertyInfos(INamedTypeSymbol type)
        {
            var result = Js.Array();
            foreach (var property in type.GetMembers().OfType<IPropertySymbol>())
            {
                if (!property.IsExported())
                    continue;

                var propertyInfo = CreateObject(Context.Instance.PropertyInfoConstructor, 
                    Js.Primitive(property.Name),
                    Type(property.Type, false), // True when it's an unconstructed type -- perhaps we need more sophistication if the type is already reified
                    property.GetMethod != null ? CreateMethodInfo(property.GetMethod) : Js.Null(),
                    property.SetMethod != null ? CreateMethodInfo(property.SetMethod) : Js.Null(),
                    CreateParameterInfos(property.Parameters.ToArray()),
                    CreateAttributes(property));
                result.Elements.Add(propertyInfo);
            }
            return MakeArray(result, Context.Instance.Compilation.CreateArrayTypeSymbol(Context.Instance.PropertyInfo));
        }

        private JsExpression CreateEventInfos(INamedTypeSymbol type)
        {
            var result = Js.Array();
            foreach (var property in type.GetMembers().OfType<IEventSymbol>())
            {
                if (!property.IsExported())
                    continue;

                var propertyInfo = CreateObject(Context.Instance.EventInfoConstructor, 
                    Js.Primitive(property.Name),
                    Type(property.Type, true),
                    property.AddMethod != null ? CreateMethodInfo(property.AddMethod) : Js.Null(),
                    property.RemoveMethod != null ? CreateMethodInfo(property.RemoveMethod) : Js.Null(),
                    CreateAttributes(property));
                result.Elements.Add(propertyInfo);
            }
            return MakeArray(result, Context.Instance.Compilation.CreateArrayTypeSymbol(Context.Instance.EventInfo));
        }

        private JsExpression CreateFieldInfos(INamedTypeSymbol type)
        {
            var result = Js.Array();
            foreach (var field in type.GetMembers().OfType<IFieldSymbol>())
            {
                if (!field.IsExported() || !field.Type.IsExported())
                    continue;

                JsExpression fieldAttributes;
                switch (field.DeclaredAccessibility)
                {
                    case Accessibility.Public:
                        fieldAttributes = GetEnumValue(Context.Instance.FieldAttributesPublic);
                        break;
                    case Accessibility.Internal:
                        fieldAttributes = GetEnumValue(Context.Instance.FieldAttributesAssembly);
                        break;
                    case Accessibility.Private:
                        fieldAttributes = GetEnumValue(Context.Instance.FieldAttributesPrivate);
                        break;
                    case Accessibility.Protected:
                        fieldAttributes = GetEnumValue(Context.Instance.FieldAttributesFamily);
                        break;
                    case Accessibility.ProtectedOrInternal:
                        fieldAttributes = GetEnumValue(Context.Instance.FieldAttributesFamORAssem);
                        break;
                    default:
                        throw new Exception();
                }
                if (field.IsStatic)
                {
                    fieldAttributes = EnumBitwise(SyntaxKind.BitwiseOrExpression, Context.Instance.FieldAttributes, 
                        fieldAttributes, GetEnumValue(Context.Instance.FieldAttributesStatic));
                }
                if (field.IsReadOnly)
                {
                    fieldAttributes = EnumBitwise(SyntaxKind.BitwiseOrExpression, Context.Instance.FieldAttributes, 
                        fieldAttributes, GetEnumValue(Context.Instance.FieldAttributesInitOnly));
                }
                if (field.IsConst)
                {
                    fieldAttributes = EnumBitwise(SyntaxKind.BitwiseOrExpression, Context.Instance.FieldAttributes, 
                        fieldAttributes, GetEnumValue(Context.Instance.FieldAttributesLiteral));
                }

                var fieldInfo = CreateObject(Context.Instance.FieldInfoConstructor, 
                    Js.Primitive(field.GetMemberName()),
                    Type(field.Type, true),
                    fieldAttributes,
                    Js.Literal(field.ConstantValue),
                    CreateAttributes(field));
                result.Elements.Add(fieldInfo);
            }
            return MakeArray(result, Context.Instance.Compilation.CreateArrayTypeSymbol(Context.Instance.FieldInfo));
        }

        private JsExpression CreateMethodInfos(INamedTypeSymbol type, bool constructors)
        {
            var result = Js.Array();
            foreach (var method in type.GetMembers().OfType<IMethodSymbol>())
            {
                if (!method.IsExported())
                    continue;
                if (method.MethodKind == MethodKind.Constructor != constructors)
                    continue;

                var info = CreateMethodInfo(method, constructors);
                result.Elements.Add(info);
            }
            return MakeArray(result, Context.Instance.Compilation.CreateArrayTypeSymbol(Context.Instance.MethodInfo));
        }

        private JsExpression CreateMethodInfo(IMethodSymbol method, bool constructor = false)
        {
            JsExpression methodAttributes;
            switch (method.DeclaredAccessibility)
            {
                case Accessibility.Public:
                    methodAttributes = GetEnumValue(Context.Instance.MethodAttributesPublic);
                    break;
                case Accessibility.Internal:
                    methodAttributes = GetEnumValue(Context.Instance.MethodAttributesAssembly);
                    break;
                case Accessibility.Private:
                    methodAttributes = GetEnumValue(Context.Instance.MethodAttributesPrivate);
                    break;
                case Accessibility.Protected:
                    methodAttributes = GetEnumValue(Context.Instance.MethodAttributesFamily);
                    break;
                case Accessibility.ProtectedOrInternal:
                    methodAttributes = GetEnumValue(Context.Instance.MethodAttributesFamORAssem);
                    break;
                default:
                    throw new Exception();
            }
            if (method.IsStatic)
            {
                methodAttributes = EnumBitwise(SyntaxKind.BitwiseOrExpression, Context.Instance.MethodAttributes, 
                    methodAttributes, GetEnumValue(Context.Instance.MethodAttributesStatic));
            }

            var returnType = method.ReturnType;

            JsExpression info = constructor ?
                CreateObject(Context.Instance.ConstructorInfoConstructor,
                    Js.Primitive(method.GetMemberName()),
                    GetMethodFunction(method, true),
                    CreateParameterInfos(method.Parameters.ToArray()),
                    methodAttributes,
                    CreateAttributes(method)) :
                CreateObject(Context.Instance.MethodInfoConstructor,
                    Js.Primitive(method.MetadataName),
                    GetMethodFunction(method, true),
                    CreateParameterInfos(method.Parameters.ToArray()),
                    Type(returnType, false),
                    methodAttributes,
                    CreateAttributes(method));

            if (method.TypeParameters.Any())
            {
                var block = new JsBlockStatement();
                foreach (var typeParameter in method.TypeParameters)
                {
                    block.Local(typeParameter.Name, Js.Reference("$definetypeparameter").Invoke(
                        Js.Primitive(typeParameter.Name), Type(typeParameter.BaseType ?? Context.Instance.ObjectType, true)));
                }
                block.Return(info);
                info = Wrap(block);
            }

            return info;
        }

        private JsExpression CreateParameterInfos(IParameterSymbol[] parameters)
        {
            var result = Js.Array();
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                JsExpression parameterAttributes = null;
                if (parameter.HasExplicitDefaultValue)
                    parameterAttributes = GetEnumValue(Context.Instance.ParameterAttributesHasDefault);
                if (parameter.RefKind == RefKind.Out)
                {
                    var enumValue = GetEnumValue(Context.Instance.ParameterAttributesOut);
                    parameterAttributes = parameterAttributes == null ? enumValue : parameterAttributes.BitwiseOr(enumValue);
                }
                if (parameterAttributes == null)
                {
                    parameterAttributes = Js.Primitive(0);
                }

                var parameterInfo = CreateObject(Context.Instance.ParameterInfoConstructor,
                    Js.Primitive(parameter.Name),
                    Type(parameter.Type),
                    Js.Primitive(i), 
                    parameterAttributes,
                    parameter.HasExplicitDefaultValue ? GetExplicitDefaultValue(parameter) : Js.Null(),
                    CreateAttributes(parameter));
                result.Elements.Add(parameterInfo);
            }
            return MakeArray(result, Context.Instance.Compilation.CreateArrayTypeSymbol(Context.Instance.ParameterInfo));
        }

        private JsExpression CreateAttributes(ISymbol symbol)
        {
            var result = Js.Array();
            foreach (var attribute in symbol.GetAttributes().Where(x => x.AttributeClass.IsExported()))
            {
                if (!attribute.AttributeClass.IsExported())
                    continue;

                var attributeInstance = CreateObject(attribute.AttributeConstructor,
                    attribute.ConstructorArguments.Select(x => Js.Literal(x.Value)).ToArray());
                if (attribute.NamedArguments.Any())
                {
                    // Wrap initialization in an anonymous function
                    var initializerBlock = new JsBlockStatement();
                    var variable = Js.Variable("$obj$", attributeInstance);
                    initializerBlock.Local(variable);

                    // Process named arguments
                    foreach (var argument in attribute.NamedArguments)
                    {
                        initializerBlock.Express(variable.GetReference().Member("set_" + argument.Key).Invoke(Js.Literal(argument.Value)));
                    }

                    // Return obj
                    initializerBlock.Return(Js.Reference("$obj$"));

                    attributeInstance = Wrap(initializerBlock);
                }
                result.Elements.Add(attributeInstance);
            }
            return MakeArray(result, Context.Instance.Compilation.CreateArrayTypeSymbol(Context.Instance.Attribute));
        }

        public JsExpression CreateAssembly(IAssemblySymbol assembly, JsExpression assemblyTypes)
        {
            return CreateObject(
                Context.Instance.AssemblyConstructor,
                Js.Primitive(assembly.Name), 
                assemblyTypes,
                CreateAttributes(assembly));
        }

        public JsInvocationExpression Get(JsExpression target, IPropertySymbol property, params JsExpression[] arguments)
        {
            return target.Member(property.GetMethod.GetMemberName()).Invoke(arguments);
        }

        public JsBlockStatement InitializeStaticFields(TypeDeclarationSyntax classDeclaration)
        {
            var result = new JsBlockStatement();

            // Add field initializers
            foreach (var field in classDeclaration.Members.OfType<FieldDeclarationSyntax>())
            {
                foreach (var variable in field.Declaration.Variables)
                {
                    var fieldSymbol = (IFieldSymbol)ModelExtensions.GetDeclaredSymbol(transformer.model, variable);
                    var initializer = variable.Initializer != null ? 
                        (JsExpression)variable.Initializer.Accept(transformer) :
                        DefaultValue(fieldSymbol.Type);
                    if (fieldSymbol.IsStatic)
                        result.Add(StoreInType(fieldSymbol.GetMemberName(), initializer));
                }
            }
            var model = Context.Instance.Compilation.GetSemanticModel(classDeclaration.SyntaxTree);
            foreach (var node in classDeclaration.Members.OfType<PropertyDeclarationSyntax>())
            {
                var getter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.IsKind(SyntaxKind.GetKeyword));
                var setter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.IsKind(SyntaxKind.SetKeyword));
                if (getter == null && setter == null)
                {
                    var property = (IPropertySymbol)ModelExtensions.GetDeclaredSymbol(model, node);
                    if (property.IsStatic)
                    {
                        var backingField = property.GetBackingFieldName();
                        result.Add(StoreInType(backingField, DefaultValue(property.Type)));
                    }
                }
            }
            
            return result;
        }

        public JsBlockStatement InitializeInstanceFields(TypeDeclarationSyntax classDeclaration)
        {
            var result = new JsBlockStatement();

            // Add field initializers
            foreach (var field in classDeclaration.Members.OfType<FieldDeclarationSyntax>())
            {
                foreach (var variable in field.Declaration.Variables)
                {
                    var fieldSymbol = (IFieldSymbol)ModelExtensions.GetDeclaredSymbol(transformer.model, variable);
                    if (!fieldSymbol.IsExported())
                        continue;

                    var initializer = variable.Initializer != null ? 
                        (JsExpression)variable.Initializer.Accept(transformer) :
                        DefaultValue(fieldSymbol.Type);
                    if (!fieldSymbol.IsStatic)
                        result.Assign(Js.This().Member(fieldSymbol.GetMemberName()), initializer);
                }
            }
            var model = Context.Instance.Compilation.GetSemanticModel(classDeclaration.SyntaxTree);
            foreach (var node in classDeclaration.Members.OfType<PropertyDeclarationSyntax>())
            {
                var getter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.IsKind(SyntaxKind.GetKeyword));
                var setter = node.AccessorList.Accessors.SingleOrDefault(x => x.Keyword.IsKind(SyntaxKind.SetKeyword));
                if (getter != null && setter != null && getter.Body == null && setter.Body == null)
                {
                    var property = (IPropertySymbol)ModelExtensions.GetDeclaredSymbol(model, node);
                    if (!property.IsStatic)
                    {
                        var backingField = property.GetBackingFieldName();
                        result.Assign(Js.This().Member(backingField), DefaultValue(property.Type));
                    }
                }
            }
            
            return result;
        }

        public JsExpressionStatement CreatePrototype(INamedTypeSymbol type, INamedTypeSymbol baseType)
        {
            return CreatePrototype(Type(type), Type(baseType));
        }

        public JsExpressionStatement CreatePrototype(INamedTypeSymbol type, JsExpression baseType)
        {
            return CreatePrototype(Type(type), baseType);
        }

        public JsExpressionStatement CreatePrototype(JsExpression type, JsExpression baseType)
        {
            return Js.Express(Js.Assign(
                type.Member("prototype"), 
                Js.New(baseType)));
        }

        public JsExpression GetFromPrototype(string prototypeMember)
        {
            return Js.Reference(SpecialNames.TypeInitializerPrototype).Member(prototypeMember);
        }

        public JsExpression GetFromType(string typeMember)
        {
            return Js.Reference(SpecialNames.TypeInitializerTypeFunction).Member(typeMember);
        }

        public JsExpressionStatement StoreInPrototype(string prototypeMember, JsExpression value)
        {
            // Effectively, this is:
            // $p.prototypeMember = value;
            return Js.Express(Js.Assign(
                Js.Reference(SpecialNames.TypeInitializerPrototype).Member(prototypeMember),
                value));
        }

        public JsExpressionStatement StoreInType(string typeMember, JsExpression value)
        {
            return Js.Express(Js.Assign(Js.Reference(SpecialNames.TypeInitializerTypeFunction).Member(typeMember), value));
        }

        public JsInvocationExpression InvokeMethodAsThis(IMethodSymbol method, params JsExpression[] arguments)
        {
            return InvokeMethodAs(method, Js.This(), arguments);
        }

        public JsInvocationExpression InvokeMethodAs(IMethodSymbol method, JsExpression @this, params JsExpression[] arguments)
        {
            var containingMember = Type(method.ContainingType);
            if (!method.IsStatic)
                containingMember = containingMember.Member("prototype");
            return containingMember.Member(method.GetMemberName()).Member("call")
                .Invoke(new[] { @this }.Concat(arguments).ToArray());
        }

        public JsInvocationExpression Invoke(JsExpression target, IMethodSymbol method, params JsExpression[] arguments)
        {
            return target.Member(method.GetMemberName()).Invoke(arguments);
        }

        public JsExpression GetMethodFunction(IMethodSymbol method, bool forceUnconstructedScope = false)
        {
            // Handle type arguments in the containing type
            JsExpression typeReference = Type(method.ContainingType, forceUnconstructedScope);
            var target = method.IsStatic ? typeReference : typeReference.Member("prototype");
            return target.Member(method.GetMemberName());            
        }

        public JsInvocationExpression InvokeStatic(IMethodSymbol method, params JsExpression[] args)
        {
            args = method.TypeArguments.Select(x => TypeAndResolve(x)).Concat(args).ToArray();

            JsExpression target;
            if (Equals(method.ContainingType, Context.Instance.SpecialFunctions))
                target = Js.Reference(method.GetMemberName());
            else
                target = Type(method.ContainingType).Member(method.GetMemberName());

            return target.Invoke(args);
        }

/*
        public JsExpression[] TranslateArguments(MethodSymbol method, params JsExpression[] args)
        {
            return TranslateArguments(method, (x, i) => x is JsArrayExpression);
        }
*/

        public JsExpression[] TranslateArguments(SyntaxNode context, IMethodSymbol method, Func<JsExpression, int, bool> isArgumentArray, Func<JsExpression, int, string> getArgumentName, params JsExpression[] args)
        {
            var isExported = method.IsExported();

            // The number of arguments may differ from the number of parameters, due to default parameters and the params keyword.
            // This queue holds all the remaining arguments, and the matching of parameters to arguments happens in sequence, 
            // consuming from the queue.
            var remainingArguments = new Queue<JsExpression>(args);

            var argumentsByName = args
                .Select((x, i) => new { Name = getArgumentName(x, i), Argument = x })
                .Where(x => x.Name != null)
                .ToDictionary(x => x.Name, x => x.Argument);
            if (argumentsByName.Any())
            {
                var newArguments = new List<JsExpression>();
                foreach (var parameter in method.Parameters)
                {
                    if (!parameter.HasExplicitDefaultValue)
                    {
                        newArguments.Add(remainingArguments.Dequeue());
                    }
                    else
                    {
                        if (!argumentsByName.ContainsKey(parameter.Name))
                        {
                            if (parameter.GetAttributes().Any(x => Equals(x.AttributeClass, Context.Instance.CallerMemberNameAttribute)))
                            {
                                var value = context.GetContainingMemberName();
                                newArguments.Add(value != null ? Js.Literal(value) : GetExplicitDefaultValue(parameter));
                            }
                            else
                            {
                               newArguments.Add(GetExplicitDefaultValue(parameter));
                            }
                        }
                        else
                        {
                            var argument = argumentsByName[parameter.Name];
                            newArguments.Add(argument);
                        }
                    }
                }
                remainingArguments = new Queue<JsExpression>(newArguments);
            }

            var arguments = new List<JsExpression>();
            foreach (var parameter in method.Parameters)
            {
                // params parameters require special handling
                if (parameter.IsParams)
                {
                    // If there's only one argument for the params parameter, it could be either an array containing
                    // the the params arguments, or just a single argument.
                    if (remainingArguments.Count == 1)
                    {
                        var argument = remainingArguments.Peek();
                        var argIndex = args.Length - remainingArguments.Count;

                        if (isArgumentArray(argument, argIndex))
                        {
                            // If it's an array and exported, we just pass it as is, since the argument must ultimately be an array.
                            if (isExported)
                            {
                                arguments.Add(argument);
                            }
                            // If it's NOT exported, then we simply pass them as ordinary arguments, since that's how this "params"
                            // concept works over there (it's not abstracted into an array).
                            else
                            {
                                foreach (var element in ((JsArrayExpression)argument).Elements)
                                {
                                    arguments.Add(element);
                                }
                            }
                            remainingArguments.Dequeue();
                            continue;
                        }
                    }
                    // If exported, then add all the rest of the arguments as an array
                    if (isExported)
                    {
                        arguments.Add(MakeArray(Js.Array(remainingArguments.ToArray()), (IArrayTypeSymbol)parameter.Type));
                    }
                    // Otherwise, add all the rest of the arguments as ordinary arguments per the comment earlier about non exported types.
                    else
                    {
                        while (remainingArguments.Any())
                            arguments.Add(remainingArguments.Dequeue());
                    }
                }
                else if (!remainingArguments.Any())
                {
                    // If not exported, then it's a C# to Javascript transfer, and in Javascript land, default arguments are 
                    // always undefined. Thus we don't want to add default arguments for non-exported methods.
                    if (isExported)
                    {
                        if (parameter.GetAttributes().Any(x => Equals(x.AttributeClass, Context.Instance.CallerMemberNameAttribute)))
                        {
                            var value = context.GetContainingMemberName();
                            arguments.Add(value != null ? Js.Literal(value) : GetExplicitDefaultValue(parameter));
                        }
                        else
                        {
                            arguments.Add(GetExplicitDefaultValue(parameter));
                        }
                    }
                }
                else
                {
                    arguments.Add(remainingArguments.Dequeue());
                }
            }
            return arguments.ToArray();
        }

        public JsExpression GetExplicitDefaultValue(IParameterSymbol parameter)
        {
            if (!parameter.HasExplicitDefaultValue)
                throw new Exception("No explicit default value.  You should check that before invoking this method.");
            if (parameter.Type.TypeKind == TypeKind.Enum)
            {
                return GetEnumByValue(parameter.Type, Js.Literal(parameter.ExplicitDefaultValue));
            }
            else
            {
                return Js.Literal(parameter.ExplicitDefaultValue);
            }
        }

        public JsExpression GetEnumByValue(ITypeSymbol enumType, JsExpression value)
        {
            return InvokeStatic(Context.Instance.EnumInternalToObject, Type(enumType).Invoke(), value);
        }

        public JsExpression GetPropertyValue(JsExpression target, IPropertySymbol property, bool isBaseReference = false)
        {
            bool isExported = property.IsExported();
            var propertyName = property.GetMemberName();
            if (!isExported)
            {
                return Js.Member(target, propertyName);
            }
            else
            {
                bool isExtension = property.IsExtension();
                if (isExtension || isBaseReference)
                    return InvokeMethodAs(property.GetMethod, target);
                else if (property.GetMethod != null)
                    return Js.Invoke(Js.Member(target, property.GetMethod.GetMemberName()));
                else 
                    return Js.Invoke(Js.Member(target, "get_" + property.GetMemberName()));
            }
        }

        public JsExpression MemberReference(JsExpression @this, ISymbol symbol, bool isSetter = false, bool isBaseReference = false)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.Field:
                {
                    var field = (IFieldSymbol)symbol;
                    var result = (JsExpression)@this.Member(field.GetMemberName());

                    if (field.Type is IArrayTypeSymbol && !field.IsExported())
                    {
                        result = MakeArray(result, (IArrayTypeSymbol)field.Type);
                    }

                    return result;
                }
                case SymbolKind.Event:
                {
                    var field = (IEventSymbol)symbol;
                    return @this.Member(field.GetBackingFieldName());
                }
                case SymbolKind.Property:
                {
                    var property = (IPropertySymbol)symbol;
                    if (property.ContainingType.IsGenericType && Equals(property.ContainingType.ConstructedFrom, Context.Instance.NullableType))
                    {
                        property = (IPropertySymbol)property.OriginalDefinition;
                        if (Equals(property, Context.Instance.NullableHasValue))
                        {
                            return @this.NotEqualTo(Js.Null()).Parenthetical();
                        }
                        else if (Equals(property, Context.Instance.NullableValue))
                        {
                            return Js.Reference(SpecialNames.NullableGetValue).Invoke(@this);
                        }
                    }

                    return GetPropertyValue(@this, property, isBaseReference);
                }
                case SymbolKind.Parameter:
                    return transformer.ReferenceDeclarationInScope(symbol.Name).GetReference();
                case SymbolKind.NamedType:
                    var namedTypeSymbol = (INamedTypeSymbol)symbol;
                    var type = Type(namedTypeSymbol);
                    if (!(type is JsInvocationExpression) && namedTypeSymbol.IsExported())
                        type = type.Invoke();
                    return type;
                case SymbolKind.Local:
                    var localName = symbol.Name;
                    if (transformer.nameOverrides.ContainsKey(localName))
                        localName = transformer.nameOverrides[localName];
                    var declaration = transformer.ReferenceDeclarationInScope(localName);
                    return !isSetter ? declaration.GetReference() : declaration.SetReference();
                case SymbolKind.Method:
                {
                    var method = (IMethodSymbol)symbol;
                    var containingSymbol = symbol.ContainingType;
                    var name = method.GetMemberName();
                    var target = method.IsStatic ? Type(containingSymbol) : @this;
                    if (Equals(method.ContainingType, containingSymbol))
                    {
                        return target.Member(name);
                    }
                    else if (containingSymbol.IsSubclassOf(method.ContainingType))
                    {
                        return target.Member(name);
                    }
                    else 
                    {
                        throw new Exception();
                    }
                }
                case SymbolKind.Namespace:
                    return Js.Reference(symbol.Name);
                case SymbolKind.Label:
                    return Js.Reference(symbol.Name);
                case SymbolKind.TypeParameter:
                    return Js.Reference(symbol.Name);
                default:
                    throw new InvalidOperationException("Unexpected node: " + symbol);
            }
        }

        public JsExpressionStatement StoreClassGetType()
        {
            return StoreInType(SpecialNames.GetTypeFromType, Js.Function().Body(Js.Return(Type(Context.Instance.TypeType).Member("_GetTypeFromTypeFunc").Invoke(Js.This()))));
        }

        /// <summary>
        /// Very useful idiom to allow a sequence of statements to be executed while still returning a valid expression inline in the
        /// AST.  It essentially creates a lambda whose body is the specified block, wraps it in parentheses, and then immediately invokes
        /// it.
        /// </summary>
        /// <param name="block">The block of statements to invoke.</param>
        /// <returns>The invocation expression that performs the above.</returns>
        public JsInvocationExpression Wrap(JsBlockStatement block, params IJsDeclaration[] arguments)
        {
            var function = Js.Function(arguments.Select(x => Js.Parameter(x.Name)).ToArray()).Body(block);
            return Js.Parenthetical(function).Member("call").Invoke(new[] { (JsExpression)Js.This() }.Concat(arguments.Select(x => Js.Reference(UnwrappedName(x)))).ToArray());
        }

        private string UnwrappedName(IJsDeclaration declaration)
        {
            if (declaration is WrappedParent)
                return ((WrappedParent)declaration).Parent.Name;
            else
                return declaration.Name;
        }

        public class WrappedParent : IJsDeclaration
        {
            public string Name { get; set; }

            private IJsDeclaration parent;

            public IJsDeclaration Parent
            {
                get { return parent; }
            }

            public WrappedParent(IJsDeclaration parent)
            {
                this.parent = parent;
                Name = parent.Name;
            }

            public JsExpression GetReference()
            {
                return Js.Reference(Name);
            }

            public JsExpression SetReference()
            {
                return Js.Assign(Js.Reference(Name), parent.SetReference());
            }
        }

        public JsInvocationExpression CreateMulticastDelegate(JsExpression target, JsExpression invocationList)
        {
            var delegateBody = new JsBlockStatement();
            var list = Js.Variable("$invocationList", invocationList);
            var i = Js.Variable("$i", Js.Primitive(0));
            delegateBody.Add(
                Js.For(
                    i, 
                    i.GetReference().LessThan(list.GetReference().Member("length")), 
                    i.GetReference().Increment()
                )
                .Body(Js.Express(list.GetReference().Index(i.GetReference()).Invoke(Js.Reference("arguments")))));

            var delegateExpression = Js.Function();
            delegateExpression.Body(delegateBody);
            var delegateVariable = Js.Variable("$delegate$", delegateExpression);

            var delegateType = invocationList.Index(Js.Primitive(0)).Member(SpecialNames.TypeField);

            var wrapper = new JsBlockStatement();
            wrapper.Local(list);
            wrapper.Local(delegateVariable);
            wrapper.Assign(delegateVariable.GetReference().Member("prototype"), Js.New(Type(Context.Instance.MulticastDelegateType)));
            wrapper.Invoke(Type(Context.Instance.ObjectType).Member(SpecialNames.TypeInitializer), delegateVariable.GetReference(), delegateVariable.GetReference());
            wrapper.Invoke(Type(Context.Instance.DelegateType).Member(SpecialNames.TypeInitializer), delegateVariable.GetReference(), delegateVariable.GetReference());
            wrapper.Invoke(Type(Context.Instance.MulticastDelegateType).Member(SpecialNames.TypeInitializer), delegateVariable.GetReference(), delegateVariable.GetReference());
            wrapper.Invoke(delegateType.Member(SpecialNames.TypeInitializer), delegateVariable.GetReference(), delegateVariable.GetReference());
            wrapper.Express(InvokeMethodAs(
                Context.Instance.MulticastDelegateConstructor, 
                delegateVariable.GetReference(), 
                target, 
                list.GetReference()));
            wrapper.Assign(delegateVariable.GetReference().Member(SpecialNames.TypeField), delegateType);
            wrapper.Return(delegateVariable.GetReference());

            return Wrap(wrapper);
        }

        public bool TryAccessorAssignment(SyntaxKind type, ISymbol leftSymbol, ISymbol rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            // Special handling for property and event assignments, since those have to be translated to a set/add/remove_PropertyName invocation.
            if (type == SyntaxKind.SimpleAssignmentExpression || type == SyntaxKind.AddAssignmentExpression || type == SyntaxKind.SubtractAssignmentExpression)
            {
                if (leftSymbol is IPropertySymbol || leftSymbol is IEventSymbol)
                {
                    var isExported = leftSymbol.IsExported();
                    var nameOverride = leftSymbol.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
                    var target = left.GetLogicalTarget();
                    var arguments = new List<JsExpression>();
                    var property = leftSymbol as IPropertySymbol;
                    var isCall = false;
                    if (left is JsInvocationExpression)
                    {
                        var invocationExpression = (JsInvocationExpression)left;
                        if (invocationExpression.Target is JsMemberReferenceExpression)
                        {
                            var innerMemberReference = (JsMemberReferenceExpression)invocationExpression.Target;
                            if (innerMemberReference.Name == "call" && target is JsMemberReferenceExpression && ((JsMemberReferenceExpression)target).Name.StartsWith("get_"))
                            {
                                isCall = true;
                                target = target.GetLogicalTarget();
                            }
                        }
                        
                        arguments.AddRange(invocationExpression.Arguments);
                    }
                    arguments.Add(right);
                    if (isExported)
                    {
                        IMethodSymbol methodSymbol;
                        if (leftSymbol is IPropertySymbol)
                            methodSymbol = ((IPropertySymbol)leftSymbol).SetMethod;
                        else
                        {
                            var @event = (IEventSymbol)leftSymbol;
                            switch (type)
                            {
                                case SyntaxKind.AddAssignmentExpression:
                                    methodSymbol = @event.AddMethod;
                                    break;
                                default:
                                    methodSymbol = @event.RemoveMethod;
                                    break;
                            }
                        }
                        target = target.Member(methodSymbol.Name);
                        if (isCall)
                            target = target.Member("call");
                        result = target.Invoke(arguments.ToArray());
                        return true;
                    }
                    else if (nameOverride != null && property != null && property.SetMethod.Parameters.Count() > 1)
                    {
                        result = target.Member(nameOverride).Invoke(arguments.ToArray());
                        return true;
                    }
                }
            }
            result = null;
            return false;
        }

        public bool TryIsExpression(SyntaxKind type, ISymbol leftSymbol, ISymbol rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            if (type == SyntaxKind.IsExpression)
            {
                var operand = (ITypeSymbol)rightSymbol;
                result = Invoke(Type(operand).Member(SpecialNames.GetTypeFromType).Invoke(), Context.Instance.TypeIsInstanceOfType, left);
                return true;
            }
            result = null;
            return false;
        }

        public bool TryCharUnaryExpression(SyntaxKind type, TypeInfo operandType, JsExpression operand, out JsExpression result)
        {
            if (Equals(operandType.Type, Context.Instance.Char))
            {
                switch (type)
                {
                    case SyntaxKind.PostDecrementExpression:
                    case SyntaxKind.PostIncrementExpression:
                    {
                        var old = Js.Variable("$old", operand);

                        var op = type == SyntaxKind.PostDecrementExpression ? JsBinaryOperator.Subtract : JsBinaryOperator.Add;
                        result = Js.Binary(
                            op, 
                            old.GetReference().Member("charCodeAt").Invoke(Js.Primitive(0)),
                            Js.Primitive(1)
                        );
                        result = Js.Assign(operand, Js.Reference("String").Member("fromCharCode").Invoke(result));

                        var block = new JsBlockStatement();
                        block.Local(old);
                        block.Express(result);
                        block.Return(old.GetReference());
                        result = Wrap(block);

                        return true;
                    }
                    case SyntaxKind.PreDecrementExpression:
                    case SyntaxKind.PreIncrementExpression:
                    {
                        var op = type == SyntaxKind.PreDecrementExpression ? JsBinaryOperator.Subtract : JsBinaryOperator.Add;
                        result = Js.Binary(
                            op, 
                            operand.Member("charCodeAt").Invoke(Js.Primitive(0)),
                            Js.Primitive(1)
                        );
                        result = Js.Assign(operand, Js.Reference("String").Member("fromCharCode").Invoke(result));
                        return true;
                    }
                }
            }
            result = null;
            return false;
        }

        public bool TryCharBinaryExpression(SyntaxKind type, TypeInfo leftSymbol, TypeInfo rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            if (Equals(leftSymbol.Type, Context.Instance.Char) || Equals(rightSymbol.Type, Context.Instance.Char))
            {
                switch (type)
                {
                    case SyntaxKind.SubtractExpression:
                    case SyntaxKind.AddExpression:
                    case SyntaxKind.MultiplyExpression:
                    case SyntaxKind.DivideExpression:
                    case SyntaxKind.ModuloExpression:
                    case SyntaxKind.BitwiseAndExpression:
                    case SyntaxKind.BitwiseOrExpression:
                    case SyntaxKind.LessThanExpression:
                    case SyntaxKind.LessThanOrEqualExpression:
                    case SyntaxKind.GreaterThanExpression:
                    case SyntaxKind.GreaterThanOrEqualExpression:
                    case SyntaxKind.LeftShiftExpression:
                    case SyntaxKind.RightShiftExpression:
                    case SyntaxKind.ExclusiveOrExpression:
                    case SyntaxKind.AddAssignmentExpression:
                    case SyntaxKind.SubtractAssignmentExpression:
                    case SyntaxKind.MultiplyAssignmentExpression:
                    case SyntaxKind.DivideAssignmentExpression:
                    case SyntaxKind.ModuloAssignmentExpression:
                        result = Js.Binary(
                            ToBinaryOperator(type).Value,
                            !Equals(leftSymbol.Type, Context.Instance.Char) || Equals(rightSymbol.Type, Context.Instance.String) ? left : left.Member("charCodeAt").Invoke(Js.Primitive(0)),
                            !Equals(rightSymbol.Type, Context.Instance.Char) || Equals(leftSymbol.Type, Context.Instance.String) ? right : right.Member("charCodeAt").Invoke(Js.Primitive(0))
                        );
                        switch (type)
                        {
                            case SyntaxKind.AddAssignmentExpression:
                            case SyntaxKind.SubtractAssignmentExpression:
                            case SyntaxKind.MultiplyAssignmentExpression:
                            case SyntaxKind.DivideAssignmentExpression:
                            case SyntaxKind.ModuloAssignmentExpression:
                                result = Js.Assign(left, Js.Reference("String").Member("fromCharCode").Invoke(result));
                                break;
                        }
                        return true;
                }                
            }
            result = null;
            return false;
        }

        private bool IsIntegerType(ITypeSymbol type)
        {
            return type == Context.Instance.Int16 || type == Context.Instance.Int32 || type == Context.Instance.Int64;
        }

        public bool TryStringConcatenation(SyntaxKind type, TypeInfo leftSymbol, TypeInfo rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            if ((type == SyntaxKind.DivideExpression || type == SyntaxKind.DivideAssignmentExpression) && 
                IsIntegerType(leftSymbol.ConvertedType) && 
                IsIntegerType(rightSymbol.ConvertedType))
            {
                result = Js.Reference(SpecialNames.Truncate).Invoke(Js.Binary(JsBinaryOperator.Divide, left, right));
                if (type == SyntaxKind.DivideAssignmentExpression)
                {
                    result = left.Assign(result);
                }
                return true;
            }
            result = null;
            return false;
        }

        public bool TryIntegerDivision(SyntaxKind type, TypeInfo leftSymbol, TypeInfo rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            if (type == SyntaxKind.AddExpression && 
                (Equals(leftSymbol.ConvertedType, Context.Instance.String) || Equals(rightSymbol.ConvertedType, Context.Instance.String)) &&
                (!Equals(leftSymbol.ConvertedType, Context.Instance.String) || !Equals(rightSymbol.ConvertedType, Context.Instance.String)))
            {
                if (!Equals(leftSymbol.ConvertedType, Context.Instance.String))
                    left = InvokeStatic(Context.Instance.SafeToString, left);
                if (!Equals(rightSymbol.ConvertedType, Context.Instance.String))
                    right = InvokeStatic(Context.Instance.SafeToString, right);

                result = Js.Binary(JsBinaryOperator.Add, left, right);
                return true;
            }
            result = null;
            return false;
        }

        public JsExpression EnumBitwise(SyntaxKind type, ITypeSymbol enumType, JsExpression left, JsExpression right)
        {
            JsExpression result;
            if (TryEnumBitwise(type, enumType, enumType, left, right, out result))
                return result;
            else
                throw new Exception();
        }

        public bool TryEnumBitwise(SyntaxKind type, ITypeSymbol leftSymbol, ITypeSymbol rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            if ((type == SyntaxKind.BitwiseOrExpression || type == SyntaxKind.BitwiseAndExpression) && 
                (leftSymbol.TypeKind == TypeKind.Enum && rightSymbol.TypeKind == TypeKind.Enum))
            {
                left = Invoke(left, Context.Instance.EnumGetValue);
                right = Invoke(right, Context.Instance.EnumGetValue);

                result = InvokeStatic(Context.Instance.EnumInternalToObject, Type(leftSymbol), Js.Binary(ToBinaryOperator(type).Value, left, right));
                return true;
            }
            result = null;
            return false;
        }

        public bool TryEnumEquality(SyntaxKind type, ITypeSymbol leftSymbol, ITypeSymbol rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            var leftIsEnum = (leftSymbol != null && leftSymbol.TypeKind == TypeKind.Enum);
            var rightIsEnum = (rightSymbol != null && rightSymbol.TypeKind == TypeKind.Enum);
            var isEqualityExpression = (type == SyntaxKind.EqualsExpression || type == SyntaxKind.NotEqualsExpression);

            if (isEqualityExpression && (leftIsEnum || rightIsEnum))
            {
                if (leftSymbol.TypeKind == TypeKind.Enum)
                    left = Invoke(left, Context.Instance.EnumGetValue);
                if (rightSymbol.TypeKind == TypeKind.Enum)
                    right = Invoke(right, Context.Instance.EnumGetValue);

                result = Js.Binary(ToBinaryOperator(type).Value, left, right);
                return true;
            }
            result = null;
            return false;
        }

        public JsBinaryOperator? ToBinaryOperator(SyntaxKind kind)
        {
            JsBinaryOperator op;
            switch (kind)
            {
                case SyntaxKind.SimpleAssignmentExpression:
                    op = JsBinaryOperator.Assign;
                    break;
                case SyntaxKind.EqualsExpression:
                    op = JsBinaryOperator.Equals;
                    break;
                case SyntaxKind.NotEqualsExpression:
                    op = JsBinaryOperator.NotEquals;
                    break;
                case SyntaxKind.SubtractExpression:
                    op = JsBinaryOperator.Subtract;
                    break;
                case SyntaxKind.AddExpression:
                    op = JsBinaryOperator.Add;
                    break;
                case SyntaxKind.MultiplyExpression:
                    op = JsBinaryOperator.Multiply;
                    break;
                case SyntaxKind.DivideExpression:
                    op = JsBinaryOperator.Divide;
                    break;
                case SyntaxKind.ModuloExpression:
                    op = JsBinaryOperator.Modulus;
                    break;
                case SyntaxKind.BitwiseAndExpression:
                    op = JsBinaryOperator.BitwiseAnd;
                    break;
                case SyntaxKind.BitwiseOrExpression:
                    op = JsBinaryOperator.BitwiseOr;
                    break;
                case SyntaxKind.LogicalAndExpression:
                    op = JsBinaryOperator.LogicalAnd;
                    break;
                case SyntaxKind.LogicalOrExpression:
                    op = JsBinaryOperator.LogicalOr;
                    break;
                case SyntaxKind.LessThanExpression:
                    op = JsBinaryOperator.LessThan;
                    break;
                case SyntaxKind.LessThanOrEqualExpression:
                    op = JsBinaryOperator.LessThanOrEqual;
                    break;
                case SyntaxKind.GreaterThanExpression:
                    op = JsBinaryOperator.GreaterThan;
                    break;
                case SyntaxKind.GreaterThanOrEqualExpression:
                    op = JsBinaryOperator.GreaterThanOrEqual;
                    break;
                case SyntaxKind.LeftShiftExpression:
                    op = JsBinaryOperator.ShiftLeft;
                    break;
                case SyntaxKind.RightShiftExpression:
                    op = JsBinaryOperator.ShiftRight;
                    break;
                case SyntaxKind.AddAssignmentExpression:
                    op = JsBinaryOperator.AddAssign;
                    break;
                case SyntaxKind.SubtractAssignmentExpression:
                    op = JsBinaryOperator.SubtractAssign;
                    break;
                case SyntaxKind.MultiplyAssignmentExpression:
                    op = JsBinaryOperator.MultiplyAssign;
                    break;
                case SyntaxKind.DivideAssignmentExpression:
                    op = JsBinaryOperator.DivideAssign;
                    break;
                case SyntaxKind.ModuloAssignmentExpression:
                    op = JsBinaryOperator.ModulusAssign;
                    break;
                case SyntaxKind.CoalesceExpression:
                    op = JsBinaryOperator.LogicalOr;
                    break;
                case SyntaxKind.ExclusiveOrExpression:
                    op = JsBinaryOperator.ExclusiveOr;
                    break;
                default:
                    return null;
            }            
            return op;
        }

        public bool TryAsExpression(SyntaxKind type, ISymbol leftSymbol, ISymbol rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            if (type == SyntaxKind.AsExpression)
            {
                var operand = (ITypeSymbol)rightSymbol;
                var asBody = new JsBlockStatement();
                var asVariable = Js.Variable("$as$", left);
                asBody.Local(asVariable);
                var condition = Type(Context.Instance.TypeType)
                    .Member("prototype")
                    .Member(Context.Instance.TypeIsInstanceOfType.GetMemberName())
                    .Member("call")
                    .Invoke(Type(operand).Member(SpecialNames.GetTypeFromType).Invoke(), asVariable.GetReference());
                asBody.If(Js.Not(condition), Js.Assign(asVariable.GetReference(), Js.Null()));
                asBody.Return(asVariable.GetReference());
                result = Wrap(asBody);
                return true;
            }
            result = null;
            return false;
        }

        public bool TryBaseMethodInvocation(InvocationExpressionSyntax node, IMethodSymbol method, JsExpression[] arguments, out JsExpression result)
        {
            if (node.Expression is MemberAccessExpressionSyntax)
            {
                var methodTargetSyntax = ((MemberAccessExpressionSyntax)node.Expression).Expression;
                if (methodTargetSyntax is BaseExpressionSyntax)
                {
                    // Special handling for base method calls.  Similar to base constructor invocations.
                    result = InvokeMethodAsThis(method, arguments.ToArray());
                    return true;
                }
            }            
            result = null;
            return false;
        }

        // Special compiler handler of AsExtension -- we just inline the call since it's just sugar for substituting types.
        public bool TryUnwrapAsExpression(IMethodSymbol method, JsExpression target, JsExpression[] arguments, out JsExpression result)
        {
            var methodClass = method.ContainingType;
            if (Equals(methodClass, Context.Instance.AsExtensionType))
            {
                if (arguments.Length == 1)
                {
                    result = arguments[0];
                    return true;
                }
                else
                {
                    var memberAccessExpression = (JsMemberReferenceExpression)target;
                    result = memberAccessExpression.Target;
                    return true;
                }
            }            
            result = null;
            return false;
        }

        public bool TryNullableGetValueOrDefault(IMethodSymbol method, JsExpression target, out JsExpression result)
        {
            // Special compiler handler for Nullable.GetValueOrDefault
            if (method.ContainingType.IsGenericType && Equals(method.ContainingType.ConstructedFrom, Context.Instance.NullableType)) 
            {
                var constructedMethod = method.OriginalDefinition;
                if (Equals(constructedMethod, Context.Instance.NullableGetValueOrDefault))
                {
                    result = ((JsMemberReferenceExpression)target).Target;
                    return true;
                }
            }
            result = null;
            return false;
        }

        public bool TryReferenceEquals(IMethodSymbol method, JsExpression[] arguments, out JsExpression result)
        {
            // Special compiler handler for ReferenceEquals (since there is no native operator overloading, == comparisons
            // are always reference comparisons.
            if (method == Context.Instance.ObjectReferenceEquals)
            {
                result = arguments[0].EqualTo(arguments[1]);
                return true;
            }            
            result = null;
            return false;
        }

        public bool TryEnumToString(IMethodSymbol method, JsExpression target, JsExpression methodTarget, ITypeSymbol targetType, JsExpression[] arguments, out JsExpression result)
        {
/*
            if (method.Name == "ToString" && targetType != null && targetType.TypeKind == TypeKind.Enum)
            {
                result = Type(Context.Instance.EnumType).Member("InternalToObject").Invoke(Type(targetType), methodTarget).Member("ToString").Invoke();
                return true;
            }            
*/
            result = null;
            return false;
        }

        public bool TryGetType(IMethodSymbol method, JsExpression target, JsExpression methodTarget, ITypeSymbol targetType, JsExpression[] arguments, InvocationExpressionSyntax node, out JsExpression result)
        {
            if (method == Context.Instance.GetType)
            {
                result = Js.Reference(SpecialNames.SafeGetType).Invoke(methodTarget);
                return true;                    
            }
            result = null;
            return false;
        }

        private string GetConstantString(ExpressionSyntax expression)
        {
            string s;
            if (expression is LiteralExpressionSyntax)
            {
                s = (string)((LiteralExpressionSyntax)expression).Token.Value;
            }
            else
            {
                var memberArgSymbol = ModelExtensions.GetSymbolInfo(transformer.model, expression).Symbol;
                s = (string)((IFieldSymbol)memberArgSymbol).ConstantValue;
            }
            return s;
        }

        public bool TryUnwrapJsFunctionInvoke(IMethodSymbol method, InvocationExpressionSyntax invocation, JsExpression methodTarget, JsExpression[] arguments, out JsExpression result)
        {
            if (Equals(method.ContainingType, Context.Instance.JsFunction) && method.Name == "invoke")
            {
                result = methodTarget.Invoke(arguments);
                return true;
            }
            result = null;
            return false;
        }

        public bool TryUnwrapSpecialFunctions(ClassDeclarationSyntax classDeclaration, JsBlockStatement block)
        {
            var model = Context.Instance.Compilation.GetSemanticModel(classDeclaration.SyntaxTree);
            var type = ModelExtensions.GetDeclaredSymbol(model, classDeclaration);
            if (Equals(type, Context.Instance.SpecialFunctions))
            {
                foreach (var method in classDeclaration.Members.OfType<MethodDeclarationSyntax>())
                {
                    var methodSymbol = ModelExtensions.GetDeclaredSymbol(model, method);
                    transformer.PushDeclaration(methodSymbol);
                    transformer.PushScope(methodSymbol);
                    transformer.PushOutput(block);
                    var name = methodSymbol.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name") ?? methodSymbol.Name;
                    var parameters = new List<JsParameter>();
                    if (method.TypeParameterList != null)
                        parameters.AddRange(method.TypeParameterList.Parameters.Select(x => (JsParameter)x.Accept(transformer)));
                    parameters.AddRange(method.ParameterList.Parameters.Select(x => (JsParameter)x.Accept(transformer)));
                    var body = (JsBlockStatement)method.Body.Accept(transformer);
                    var function = Js.NamedFunction(name, parameters.ToArray()).Body(body);
                    block.Add(Js.Declare(function));
                    transformer.PopScope();
                    transformer.PopOutput();
                    transformer.PopDeclaration();
                }
                return true;
            }
            return false;
        }

        public bool TryUnwrapJsniExpression(IMethodSymbol method, ExpressionSyntax originalTarget, ExpressionSyntax[] originalArguments, JsExpression target, JsExpression[] arguments, out JsExpression result)
        {
            // Special compiler handler of Jsni -- these are special methods that translate into otherwise inexpressible javascript
            if (Equals(method.ContainingType, Context.Instance.JsniType))
            {
                if (method.ReducedFrom != null && method.ReducedFrom != method)
                {
                    method = method.ReducedFrom;
                    arguments = new[] { target }.Concat(arguments).ToArray();
                    originalArguments = new[] { originalTarget }.Concat(originalArguments).ToArray();
                    target = null;
                }
                switch (method.Name)
                {
                    case "apply":
                    {
                        if (method.TypeArguments.Any())
                        {
                            // First argument is an Action -- we want to deconstruct it to extract the target and method name.
                            var body = originalArguments[0].GetBody();
                            var lambdaInvocation = (InvocationExpressionSyntax)body;
                            var lambdaMethod = (IMethodSymbol)ModelExtensions.GetSymbolInfo(transformer.model, lambdaInvocation).Symbol;
                            result = Type(lambdaMethod.ContainingType).Member("prototype").Member(lambdaMethod.GetMemberName()).Member("apply").Invoke(arguments[1], arguments[2]);
                            return true;
                        }
                        else
                        {
                            result = arguments[0].Member("apply").Invoke(arguments[1], arguments[2]);
                            return true;
                        }
                    }
                    case "call":
                    {
                        if (method.TypeArguments.Any())
                        {
                            // First argument is an Action -- we want to deconstruct it to extract the target and method name.
                            var body = originalArguments[0].GetBody();
                            var lambdaInvocation = (InvocationExpressionSyntax)body;
                            var lambdaMethod = (IMethodSymbol)ModelExtensions.GetSymbolInfo(transformer.model, lambdaInvocation).Symbol;
                            result = Type(lambdaMethod.ContainingType).Member("prototype").Member(lambdaMethod.GetMemberName()).Member("call").Invoke(arguments.Skip(1).ToArray());
                            return true;
                        }
                        else
                        {
                            // First argument is an Action -- we want to deconstruct it to extract the target and method name.
                            result = arguments[0].Member("call").Invoke(arguments.Skip(1).ToArray());
                            return true;
                        }
                    }
                    case "type":
                        result = method.TypeArguments.Any() ? 
                            Type(method.TypeArguments.Single()) : 
                            ((JsMemberReferenceExpression)((JsInvocationExpression)arguments[0]).Target).Target;
                        return true;
                    case "new":
                    case "@new":
                        result = Js.New(arguments[0], arguments.Skip(1).ToArray());
                        return true;
                    case "array":
                        result = Js.Array(arguments);
                        return true;
                    case "invoke":
                        result = arguments[0].Invoke(arguments.Skip(1).ToArray());
                        return true;
                    case "memberset":
                    {
                        var memberName = GetConstantString(originalArguments[1]);
                        result = Js.Assign(arguments[0].Member(memberName), arguments[2]);
                        return true;
                    }
                    case "member":
                    {
                        var memberName = GetConstantString(originalArguments[1]);
                        result = arguments[0].Member(memberName);
                        return true;
                    }
                    case "function":
                    case "procedure":
                        var nameArguments = originalArguments.Skip(1).ToArray();
                        var nameOverrides = nameArguments.Select(x => GetConstantString(x)).ToArray();

                        var lambda = originalArguments[0];
                        var lambdaParameters = lambda.GetParameters();
                        transformer.PushScope(null);

                        var jsParameters = lambdaParameters.Select(x => Js.Parameter(x.Identifier.ToString())).Cast<IJsDeclaration>().ToArray();
                        for (var i = 0; i < nameOverrides.Length; i++)
                        {
                            jsParameters[i] = new WrappedParent(jsParameters[i]) { Name = nameOverrides[i] };
                        }
                        foreach (var parameter in jsParameters)
                        {
                            transformer.DeclareInCurrentScope(parameter);
                        }

                        var jsBody = new JsBlockStatement();
                        transformer.PushOutput(jsBody);
                        var lambdaBody = lambda.GetBody();

                        var lambdaNode = lambdaBody.Accept(transformer);

                        JsStatement lambdaStatement;
                        if (lambdaNode is JsExpression)
                        {
                            switch (method.Name)
                            {
                                case "function":
                                    lambdaStatement = Js.Return((JsExpression)lambdaNode);
                                    break;
                                default:
                                    lambdaStatement = Js.Express((JsExpression)lambdaNode);
                                    break;
                            }
                        }
                        else
                        {
                            lambdaStatement = (JsStatement)lambdaNode;
                        }

                        result = Js.Function(jsParameters).Body(lambdaStatement);

                        transformer.PopOutput();
                        transformer.PopScope();

                        return true;
                    case "arguments":
                        result = Js.Reference("arguments");
                        return true;
                    case "this":
                    case "@this":
                        result = Js.This();
                        return true;
                    case "delete":
                        var deleteTarget = arguments[0];
                        result = deleteTarget.Delete();
                        return true;
                    case "_typeof":
                        var typeofTarget = arguments[0];
                        result = Js.TypeOf(typeofTarget);
                        return true;
                    case "reference":
                        result = Js.Reference(GetConstantString(originalArguments[0]));
                        return true;
                    case "parseInt":
                        result = Js.Reference("parseInt").Invoke(arguments);
                        return true;
                    case "parseFloat":
                        result = Js.Reference("parseFloat").Invoke(arguments);
                        return true;
                    case "encodeURIComponent":
                        result = Js.Reference("encodeURIComponent").Invoke(arguments);
                        return true;
                    case "decodeURIComponent":
                        result = Js.Reference("decodeURIComponent").Invoke(arguments);
                        return true;
                    case "getComputedStyle":
                        result = Js.Reference("getComputedStyle").Invoke(arguments);
                        return true;
                    case "isNaN":
                        result = Js.Reference("isNaN").Invoke(arguments);
                        return true;
                    case "instanceof":
                        result = Js.Parenthetical(Js.InstanceOf(arguments[0], arguments[1]));
                        return true;
                    case "object":
                        // Deconstruct the object passed in into a JS object
                        var obj = (AnonymousObjectCreationExpressionSyntax)originalArguments[0];
                        result = Js.Object(
                            obj.Initializers.Select(x => Js.Item(
                                x.NameEquals.Name.ToString(),
                                (JsExpression)x.Expression.Accept(transformer)
                            )).ToArray()
                        );
                        if (arguments.Length > 1 && originalArguments[1].IsTrue())
                        {
                            result = result.Compact();
                        }
                        return true;
                    case "regex":
                        result = new JsRegexExpression(GetConstantString(originalArguments[0]));
                        if (originalArguments.Length > 1)
                            ((JsRegexExpression)result).Suffix = GetConstantString(originalArguments[1]);
                        return true;
                    case "in":
                        result = Js.In(arguments[0], arguments[1]);
                        return true;
                    case "setTimeout":
                        result = Js.Reference("setTimeout").Invoke(arguments[0], arguments[1]);
                        return true;
                    case "setInterval":
                        result = Js.Reference("setInterval").Invoke(arguments[0], arguments[1]);
                        return true;
                    case "clearTimeout":
                        result = Js.Reference("clearTimeout").Invoke(arguments[0]);
                        return true;
                    case "clearInterval":
                        result = Js.Reference("clearInterval").Invoke(arguments[0]);
                        return true;
                }
            }            
            result = null;
            return false;
        }

        public bool TryUnwrapJsniStatement(ExpressionStatementSyntax statement, out JsStatement result)
        {
            var expression = statement.Expression;
            if (expression is InvocationExpressionSyntax)
            {
                var jsniInvocation = (InvocationExpressionSyntax)expression;
                var symbolInfo = Context.Instance.Compilation.GetSemanticModel(expression.SyntaxTree).GetSymbolInfo(jsniInvocation);
                var method = (IMethodSymbol)symbolInfo.Symbol;
                var arguments = jsniInvocation.ArgumentList.Arguments.Select(x => (JsExpression)x.Accept(transformer)).ToArray();

                if (symbolInfo.Symbol == null)
                {
                    var classText = statement.FirstAncestorOrSelf<ClassDeclarationSyntax>().NormalizeWhitespace().ToString();
                    var diagnostics = transformer.model.GetDiagnostics().Select(x => x.ToString()).ToArray();
                }

                if (method.ReducedFrom != null && !method.ReducedFrom.Equals(method))
                {
                    method = method.ReducedFrom;
                    var target = (JsExpression)jsniInvocation.Expression.Accept(transformer);
                    var methodTarget = target is JsMemberReferenceExpression ? ((JsMemberReferenceExpression)target).Target : target;
                    arguments = new[] { methodTarget }.Concat(arguments).ToArray();
                }

                if (method != null && Equals(method.ContainingType, Context.Instance.JsniType))
                {
                    switch (method.Name)
                    {
                        case "forin":
                            var target = arguments[0];
                            var invocation = (JsInvocationExpression)arguments[1];
                            var function = (JsFunction)invocation.Arguments[2];
                            result = Js.ForIn(function.Parameters[0].Name, target).Body(function.Body);
                            return true;
                    }
                }
            }
            result = null;
            return false;
        }

        public void InstrumentRefAndOutParameters(IMethodSymbol method, List<JsExpression> arguments, List<JsStatement> prependers, List<JsStatement> appenders)
        {
            // It's a ref or out parameter, we need somewhere to store the value and instrument the arguments
            if (method.Parameters.Any(x => x.RefKind != RefKind.None))
            {
                for (var i = 0; i < method.Parameters.Count(); i++)
                {
                    var parameter = method.Parameters[i];
                    if (parameter.RefKind != RefKind.None)
                    {
                        var argument = arguments[i];    
                        var variableName = transformer.GenerateUniqueNameInScope();
                        var variable = Js.Variable(variableName, Js.Object(Js.Item("value", parameter.RefKind == RefKind.Out ? Js.Null() : argument)));
                        transformer.DeclareInCurrentScope(new ReferenceParameterDeclaration(variable));
                        arguments[i] = Js.Reference(variableName);
                        prependers.Add(Js.Local(variable));
                        appenders.Add(Js.Express(Js.Assign(argument, Js.Reference(variableName).Member("value"))));
                    }
                }
            }
        }

        public bool TryApplyRefAndOutParametersAfterInvocation(IMethodSymbol method, JsInvocationExpression invocation, out JsExpression result, List<JsStatement> prependers, List<JsStatement> appenders)
        {
            // Finishing special handling of ref/out parameters -- doing the actual function wrapping here now that we
            // have the invocation.
            if (method.Parameters.Any(x => x.RefKind != RefKind.None))
            {
                // It's a ref or out parameter, we need somewhere to store the value.
                var invocationStage = new JsBlockStatement();
                foreach (var statement in prependers)
                    invocationStage.Add(statement);
                invocationStage.Local("$result$", invocation);
                foreach (var statement in appenders)
                    invocationStage.Add(statement);
                invocationStage.Return(Js.Reference("$result$"));

                result = Wrap(invocationStage);
                return true;
            }            
            result = null;
            return false;
        }

        public JsExpression SpecialTypeOnlyForEnclosingTypes(ITypeSymbol type)
        {
            if (type.ContainingType != null)
            {
                return Js.Reference(SpecialNames.TypeInitializerTypeFunction);
            }
            else
            {
                return Js.Reference(type.GetTypeName());
            }
        }

        public JsExpression MakeArrayType(ITypeSymbol elementType)
        {
            return Js.Reference(SpecialNames.MakeArrayType).Invoke(Type(elementType));
        }

        public JsExpression TypeOf(ITypeSymbol type)
        {
            var typeExpression = Type(type);
//            if (type.IsExported() && !type.IsBuiltIn() && !(type is TypeParameterSymbol))
//                typeExpression = typeExpression.Invoke();
            return typeExpression.Member(SpecialNames.GetTypeFromType).Invoke();
        }

        public JsExpression TypeAndResolve(ITypeSymbol type)
        {
            if (!type.IsExported() || type.IsBuiltIn() || type.TypeKind == TypeKind.ArrayType || type.TypeKind == TypeKind.TypeParameter)
                return Type(type);
            else 
                return Type(type).Invoke();
        }

        public JsExpression Type(ITypeSymbol type, bool forceUnconstructedScope = false)
        {
            if (type is IArrayTypeSymbol)
            {
                var arrayType = (IArrayTypeSymbol)type;
                var elementType = arrayType.ElementType;
/*
                if (elementType is TypeParameterSymbol && forceUnconstructedScope)
                {
                    var tp = (TypeParameterSymbol)elementType;
                    elementType = Context.Instance.ObjectType;
                }
*/
                return MakeArrayType(elementType);
            }

            var explicitName = type.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name");
            if (explicitName != null)
                return Js.Reference(explicitName);

            var typeParameter = type as ITypeParameterSymbol;
            if (typeParameter != null && typeParameter.DeclaringType != null)
            {
                return Js.Reference(type.Name);
//                return Js.This().Member(SpecialNames.TypeArgs).Index(Js.Primitive(type.Name));
            }
            var namedTypeSymbol = type as INamedTypeSymbol;
            if (namedTypeSymbol != null)
            {
                if ((namedTypeSymbol.HasOrIsEnclosedInGenericParameters()) && !forceUnconstructedScope && !namedTypeSymbol.IsUnboundGenericType)
                {
                    return MakeGenericType(namedTypeSymbol);
                }
                else if (type.ContainingType != null && type.ContainingType.GetAttributeValue<string>(Context.Instance.JsAttributeType, "Name") != null)
                {
                    var result = Type(type.ContainingType).Member(type.Name.MaskSpecialCharacters());
                    return result;
                }
                else 
                {
                    var name = type.GetFullName().Replace('`', '$');
                    JsExpression result = Js.Reference(name);
                    return result;
                }
            }
            var typeName = JsNames.GetTypeName(type);
            return new JsVariableReferenceExpression(typeName);
        }

        public class ReferenceParameterDeclaration : IJsDeclaration
        {
            public IJsDeclaration declaration;

            public ReferenceParameterDeclaration(IJsDeclaration declaration)
            {
                this.declaration = declaration;
            }

            public string Name
            {
                get { return declaration.Name; }
            }

            public JsExpression GetReference()
            {
                return Js.Member(declaration.GetReference(), "value");
            }

            public JsExpression SetReference()
            {
                return Js.Member(declaration.SetReference(), "value");
            }
        }

        public JsBlockStatement InitializeConstructor(INamedTypeSymbol type, string constructorName, string[] parameterNames)
        {
            return InitializeConstructor(type, constructorName, parameterNames.Select(x => Tuple.Create(x, (IParameterSymbol)null)).ToArray());
        }

        public JsBlockStatement InitializeConstructor(INamedTypeSymbol type, string constructorName, IParameterSymbol[] parameters)
        {
            return InitializeConstructor(type, constructorName, parameters.Select(x => Tuple.Create(x.Name, x)).ToArray());
        }

        private JsBlockStatement InitializeConstructor(INamedTypeSymbol type, string constructorName, Tuple<string, IParameterSymbol>[] parameters)
        {
            var parameterNames = parameters.Select(x => x.Item1);
            JsExpression[] arguments;
            if (!type.IsBuiltIn())
            {
                arguments = new[] { (JsExpression)Js.This() }.Concat(parameterNames.Select(x => Js.Reference(x))).ToArray();
            }
            else
            {
                arguments = parameters.Where(x => x.Item2 != null && x.Item2.IsBuiltIn()).Select(x => Js.Reference(x.Item1)).ToArray();
            }

            var block = new JsBlockStatement();
            block.Assign(GetFromPrototype(constructorName).Member(SpecialNames.TypeField), Js.Reference(SpecialNames.TypeInitializerTypeFunction));
            block.Assign(GetFromPrototype(constructorName).Member("$new"), 
                Js.Function(parameterNames.Select(x => Js.Parameter(x)).ToArray())
                    .Body(Js.Return(Js.New(GetFromPrototype(constructorName).Member(SpecialNames.TypeField), arguments))));
            return block;
        }

        public JsExpression GetEnumValue(params IFieldSymbol[] enumFields)
        {
            JsExpression current = null;
            foreach (var enumField in enumFields)
            {
                var next = Type(enumField.ContainingType).Invoke().Member(enumField.GetMemberName());
                if (current == null)
                    current = next;
                else
                    current = Js.BitwiseOr(current, next);
            }

            return current;
        }

        public JsExpression MemberOf(ISymbol symbol)
        {
            if (symbol is IFieldSymbol)
            {
                var field = (IFieldSymbol)symbol;
                return Invoke(TypeOf(field.ContainingType), Context.Instance.GetField, Js.Primitive(field.Name));
            }
            else if (symbol is IPropertySymbol)
            {
                var property = (IPropertySymbol)symbol;
                return Invoke(TypeOf(property.ContainingType), Context.Instance.GetProperty, Js.Primitive(property.Name));
            }
            else if (symbol is IMethodSymbol)
            {
                var method = (IMethodSymbol)symbol;
                if (method.MethodKind == MethodKind.Constructor)
                {
                    return Invoke(TypeOf(method.ContainingType), Context.Instance.GetConstructor, Js.Array(method.Parameters.Select(x => TypeOf(x.Type)).ToArray()));
                }
                else
                {
                    return Invoke(TypeOf(method.ContainingType), Context.Instance.GetMethod, Js.Primitive(method.Name), Js.Array(method.Parameters.Select(x => TypeOf(x.Type)).ToArray()));
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public JsInvocationExpression Array(IArrayTypeSymbol arrayType, params JsExpression[] elements)
        {
            return MakeArray(Js.Array(elements), arrayType);
        }

        public JsInvocationExpression MakeArray(JsExpression array, IArrayTypeSymbol arrayType)
        {
            return Js.Reference(SpecialNames.InitializeArray).Invoke(
                array,
                Type(arrayType.ElementType));
        }

        public JsExpression DefaultValue(ITypeSymbol type)
        {
            JsExpression value;
            switch (type.SpecialType)
            {
                case SpecialType.System_Double:
                case SpecialType.System_Int32:
                case SpecialType.System_Single:
                case SpecialType.System_SByte:
                case SpecialType.System_UInt16:
                case SpecialType.System_UInt32:
                case SpecialType.System_UInt64:
                case SpecialType.System_Byte:
                case SpecialType.System_Decimal:
                case SpecialType.System_Int16:
                case SpecialType.System_Int64:
                    value = Js.Primitive(0);
                    break;
                case SpecialType.System_Boolean:
                    value = Js.Primitive(false);
                    break;
                case SpecialType.System_Char:
                    value = Js.Primitive("\0");
                    break;
                default:
                    if (Equals(type.BaseType, Context.Instance.EnumType))
                        value = GetEnumByValue(type, Js.Literal(0));
                    else if (type is ITypeParameterSymbol)
                        value = InvokeStatic(Context.Instance.DefaultOf, Js.Reference(type.Name));
                    else
                        value = Js.Null();
                    break;
            }

            return value;
        }

        public JsExpression InvokeParameterlessBaseClassConstructor(INamedTypeSymbol baseType)
        {
            var baseConstructor = baseType.InstanceConstructors.SingleOrDefault(x => x.Parameters.Count() == 0);
            var arguments = new List<JsExpression>();
            if (baseConstructor == null)
            {
                baseConstructor = baseType.InstanceConstructors.Single(x => x.Parameters[0].HasExplicitDefaultValue);
                arguments.AddRange(baseConstructor.Parameters
                    .Where(x => x.HasExplicitDefaultValue)
                    .Select(x => GetExplicitDefaultValue(x)));
            }
            return InvokeMethodAsThis(baseConstructor, arguments.ToArray());
        }
    }
}
