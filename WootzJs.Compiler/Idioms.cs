using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.WootzJs;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;
using TypeInfo = Roslyn.Compilers.CSharp.TypeInfo;

namespace WootzJs.Compiler
{
    public class Idioms
    {
        private Context context;
        private JsTransformer transformer;

        public Idioms(Context context, JsTransformer transformer)
        {
            this.context = context;
            this.transformer = transformer;
        }

        public JsInvocationExpression MakeGenericType(NamedTypeSymbol unconstructedType)
        {
            return MakeGenericType(unconstructedType, unconstructedType.TypeArguments.Select(x => Type(x)).ToArray());
        }

        public JsInvocationExpression MakeGenericType(NamedTypeSymbol unconstructedType, params JsExpression[] typeArguments)
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

        public JsExpression CreateObject(JsExpression containingType, MethodSymbol constructor, params JsExpression[] arguments)
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
                return constructorReference.Member("$new").Invoke(arguments);
            }
        }

        public JsExpression CreateObject(MethodSymbol constructor, params JsExpression[] arguments)
        {
            return CreateObject(Type(constructor.ContainingType), constructor, arguments);
        }

        public JsBlockStatement CreateTypeFunction(NamedTypeSymbol classType, out JsBlockStatement typeInitializer, out JsBlockStatement staticInitializer)
        {
            var isBuiltIn = classType.IsBuiltIn();
            var baseType = classType == context.ObjectType ? 
                Js.Reference("Object") : 
                classType.BaseType == null ? Type(context.ObjectType) : Js.Reference(classType.BaseType.GetTypeName());
            var typeName = classType.GetTypeName();

            var block = new JsBlockStatement();
            var classFunction = Js.Function();
            JsExpression outerClassType = Js.Reference(classType.GetTypeName());
            if (!isBuiltIn)
            {
                if (classType.ContainingType == null && !classType.IsAnonymousType)
                {
                    block.Assign(Js.Reference(context.SymbolNames[classType.ContainingNamespace, classType.ContainingNamespace.GetFullName()]).Member(classType.GetShortTypeName()), 
                        Js.Reference("$define").Invoke(Js.Primitive(classType.ToDisplayString())));
                    block.Add(CreatePrototype(Js.Reference(classType.GetTypeName()), baseType));
                }
                else if (classType.ContainingType != null)
                {
                    classFunction.Name = classType.GetShortTypeName();
                    var classFunctionDeclaration = Js.Declare(classFunction);
                    block.Add(classFunctionDeclaration);                    
                    outerClassType = Js.Reference(SpecialNames.TypeInitializerTypeFunction).Member(classType.GetShortTypeName());
                    block.Assign(outerClassType, Js.Reference(classFunctionDeclaration));
                    block.Add(CreatePrototype(outerClassType, baseType));
                }
                else
                {
                    classFunction.Name = typeName.Replace('.', '$');
                    block.Assign(Js.Reference("window." + classType.GetTypeName()), classFunction);
                    block.Add(CreatePrototype(Js.Reference(classType.GetTypeName()), baseType));
                }

                // Create constructor function, which is a superconstructor that takes in the actual
                // constructor as the first argument, and the rest of the arguments are passed directly 
                // to that constructor.  These subconstructors are not Javascript constructors -- they 
                // are not called via new, they exist for initialization only.
                var constructorParameter = Js.Parameter("$constructor");

                classFunction.Parameters.Add(constructorParameter);
                var isNewInstance = Js.Not(Js.Parenthetical(Js.InstanceOf(Js.This(), Js.Reference(classType.GetTypeName()))));

                var initCheck = new JsBlockStatement();
                initCheck.Assign(outerClassType.Member(SpecialNames.IsStaticInitialized), Js.Primitive(true));
                initCheck.Invoke(outerClassType.Member(SpecialNames.StaticInitializer));
                var condition = Js.Not(outerClassType.Member(SpecialNames.IsStaticInitialized)).LogicalAnd(
                    constructorParameter.GetReference().NotEqualTo(Js.Null()).LogicalOr(isNewInstance).Parenthetical());
                classFunction.Body.If(condition, initCheck);

                // Effectively, this is:
                // $constructor$.apply(this, Array.prototype.slice.call(arguments, 1));
                classFunction.Body.If(
                    constructorParameter.GetReference().NotEqualTo(Js.Null()),
                    Js.Express(constructorParameter.GetReference().Member("apply").Invoke(Js.This(), 
                        Js.Member("Array.prototype.slice.call").Invoke(Js.Reference("arguments"), Js.Literal(1)))));
                
                classFunction.Body.If(
                    isNewInstance,
                    Js.Return(outerClassType));
            }
            typeInitializer = new JsBlockStatement();
            typeInitializer.Add(StoreInType(SpecialNames.GetAssembly, Js.Reference(classType.ContainingAssembly.GetAssemblyMethodName())));
            typeInitializer.Add(StoreInPrototype(SpecialNames.TypeField, Js.Reference(classType.GetTypeName())));
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
                .Invoke(containingType == null ? (JsExpression)Js.Null() : Js.Reference(SpecialNames.TypeInitializerTypeFunction), outerClassType, outerClassType.Member("prototype")));
            block.Express(Js.Reference(classType.ContainingAssembly.GetAssemblyTypesArray()).Member("push").Invoke(outerClassType));

            staticInitializer = new JsBlockStatement();
            var staticInitializerFunction = Js.Function().Body(staticInitializer);
            typeInitializer.Add(StoreInType(SpecialNames.StaticInitializer, staticInitializerFunction));

            if (classType.HasOrIsEnclosedInGenericParameters())
            {
                var makeGenericType = new JsBlockStatement();
                makeGenericType.Return(
                    Js.Reference(context.ObjectType.GetTypeName())
                    .Member(SpecialNames.MakeGenericTypeConstructor)
                    .Member("call")
                    .Invoke(containingType == null ? (JsExpression)Js.Null() : Js.This(), SpecialTypeOnlyForEnclosingTypes(classType), Js.Reference("arguments")));

                JsExpression target;
                if (containingType != null) 
                {
                    target = Js.This().Member(classType.GetShortTypeName() + SpecialNames.MakeGenericType);
                }
                else
                {
                    target = Js.Reference("window." + classType.GetTypeName() + SpecialNames.MakeGenericType);
                }

                typeInitializer.Assign(target, Js.Function().Body(makeGenericType));
            }

            return block;
        }

        public JsExpressionStatement StoreClassCreateType(NamedTypeSymbol type)
        {
            var explicitName = type.GetAttributeValue<string>(context.JsAttributeType, "Name");
            var fullTypeName = type.GetFullName();
            var baseType = type.BaseType != null ? Type(type.BaseType) : Js.Null();
            var body = new JsBlockStatement();
            body.Assign(Js.This().Member(SpecialNames.TypeField), 
                CreateObject(context.TypeConstructor, Js.Primitive(type.Name), CreateAttributes(type)));
            body.Express(Invoke(Js.This().Member(SpecialNames.TypeField), context.TypeInit, 
                Js.Primitive(explicitName ?? fullTypeName),          // Param1: fullTypeName
                Type(type, true), 
                baseType,
                CreateInterfaceReferences(type),
                CreateFieldInfos(type),
                CreateMethodInfos(type, false),
                CreateMethodInfos(type, true),
                CreatePropertyInfos(type),
                CreateEventInfos(type),
                Js.Primitive(type.IsValueType)));
            body.Return(Js.This().Member(SpecialNames.TypeField));
            var result = StoreInType(SpecialNames.CreateType, Js.Function().Body(body));
            result.IsCompacted = true;
            return result;
        }

        private JsArrayExpression CreateInterfaceReferences(NamedTypeSymbol type)
        {
            return Js.Array(type.AllInterfaces.Select(x => Js.Reference(x.GetTypeName())).ToArray());
        }

        private JsArrayExpression CreatePropertyInfos(NamedTypeSymbol type)
        {
            var result = Js.Array();
            foreach (var property in type.GetMembers().OfType<PropertySymbol>())
            {
                if (!property.IsExported())
                    continue;

                var propertyInfo = CreateObject(context.PropertyInfoConstructor, 
                    Js.Primitive(property.Name),
                    Type(property.Type, true),
                    property.GetMethod != null ? CreateMethodInfo(property.GetMethod) : Js.Null(),
                    property.SetMethod != null ? CreateMethodInfo(property.SetMethod) : Js.Null(),
                    CreateParameterInfos(property.Parameters.ToArray()),
                    CreateAttributes(property));
                result.Elements.Add(propertyInfo);
            }
            return result;
        }

        private JsArrayExpression CreateEventInfos(NamedTypeSymbol type)
        {
            var result = Js.Array();
            foreach (var property in type.GetMembers().OfType<EventSymbol>())
            {
                if (!property.IsExported())
                    continue;

                var propertyInfo = CreateObject(context.EventInfoConstructor, 
                    Js.Primitive(property.Name),
                    Type(property.Type, true),
                    property.AddMethod != null ? CreateMethodInfo(property.AddMethod) : Js.Null(),
                    property.RemoveMethod != null ? CreateMethodInfo(property.RemoveMethod) : Js.Null(),
                    CreateAttributes(property));
                result.Elements.Add(propertyInfo);
            }
            return result;
        }

        private JsArrayExpression CreateFieldInfos(NamedTypeSymbol type)
        {
            var result = Js.Array();
            foreach (var field in type.GetMembers().OfType<FieldSymbol>())
            {
                if (!field.IsExported() || !field.Type.IsExported())
                    continue;

                JsExpression fieldAttributes;
                switch (field.DeclaredAccessibility)
                {
                    case Accessibility.Public:
                        fieldAttributes = GetEnumValue(context.FieldAttributesPublic);
                        break;
                    case Accessibility.Internal:
                        fieldAttributes = GetEnumValue(context.FieldAttributesAssembly);
                        break;
                    case Accessibility.Private:
                        fieldAttributes = GetEnumValue(context.FieldAttributesPrivate);
                        break;
                    case Accessibility.Protected:
                        fieldAttributes = GetEnumValue(context.FieldAttributesFamily);
                        break;
                    case Accessibility.ProtectedInternal:
                        fieldAttributes = GetEnumValue(context.FieldAttributesFamORAssem);
                        break;
                    default:
                        throw new Exception();
                }
                if (field.IsStatic)
                {
                    fieldAttributes = fieldAttributes.BitwiseOr(GetEnumValue(context.FieldAttributesStatic));
                }
                if (field.IsReadOnly)
                {
                    fieldAttributes = fieldAttributes.BitwiseOr(GetEnumValue(context.FieldAttributesInitOnly));
                }
                if (field.IsConst)
                {
                    fieldAttributes = fieldAttributes.BitwiseOr(GetEnumValue(context.FieldAttributesLiteral));
                }

                var fieldInfo = CreateObject(context.FieldInfoConstructor, 
                    Js.Primitive(field.GetMemberName()),
                    Type(field.Type, true),
                    fieldAttributes,
                    Js.Literal(field.ConstantValue),
                    CreateAttributes(field));
                result.Elements.Add(fieldInfo);
            }
            return result;
        }

        private JsArrayExpression CreateMethodInfos(NamedTypeSymbol type, bool constructors)
        {
            var result = Js.Array();
            foreach (var method in type.GetMembers().OfType<MethodSymbol>())
            {
                if (!method.IsExported())
                    continue;
                if (method.MethodKind == MethodKind.Constructor != constructors)
                    continue;

                var info = CreateMethodInfo(method, constructors);
                result.Elements.Add(info);
            }
            return result;
        }

        private JsExpression CreateMethodInfo(MethodSymbol method, bool constructor = false)
        {
            JsExpression methodAttributes;
            switch (method.DeclaredAccessibility)
            {
                case Accessibility.Public:
                    methodAttributes = GetEnumValue(context.MethodAttributesPublic);
                    break;
                case Accessibility.Internal:
                    methodAttributes = GetEnumValue(context.MethodAttributesAssembly);
                    break;
                case Accessibility.Private:
                    methodAttributes = GetEnumValue(context.MethodAttributesPrivate);
                    break;
                case Accessibility.Protected:
                    methodAttributes = GetEnumValue(context.MethodAttributesFamily);
                    break;
                case Accessibility.ProtectedInternal:
                    methodAttributes = GetEnumValue(context.MethodAttributesFamORAssem);
                    break;
                default:
                    throw new Exception();
            }
            if (method.IsStatic)
            {
                methodAttributes = methodAttributes.BitwiseOr(GetEnumValue(context.MethodAttributesStatic));
            }

            var returnType = method.ReturnType;
            if (returnType.TypeKind == TypeKind.TypeParameter && method.TypeParameters.Contains((TypeParameterSymbol)returnType))
            {
                returnType = context.ObjectType; // Todo:  FIX THIS SUPER HACK.  Type parameter info is lost in reflection because of this.
            }

            var info = constructor ?
                CreateObject(context.ConstructorInfoConstructor,
                    Js.Primitive(method.GetMemberName()),
                    GetMethodFunction(method, true),
                    CreateParameterInfos(method.Parameters.ToArray()),
                    methodAttributes,
                    CreateAttributes(method)) :
                CreateObject(context.MethodInfoConstructor,
                    Js.Primitive(method.GetMemberName()),
                    GetMethodFunction(method, true),
                    CreateParameterInfos(method.Parameters.ToArray()),
                    Type(returnType, true),
                    methodAttributes,
                    CreateAttributes(method));
            return info;
        }

        private JsArrayExpression CreateParameterInfos(ParameterSymbol[] parameters)
        {
            var result = Js.Array();
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                JsExpression parameterAttributes = null;
                if (parameter.HasDefaultValue)
                    parameterAttributes = GetEnumValue(context.ParameterAttributesHasDefault);
                if (parameter.RefKind == RefKind.Out)
                {
                    var enumValue = GetEnumValue(context.ParameterAttributesOut);
                    parameterAttributes = parameterAttributes == null ? enumValue : parameterAttributes.BitwiseOr(enumValue);
                }
                if (parameterAttributes == null)
                {
                    parameterAttributes = Js.Primitive(0);
                }

                var parameterInfo = CreateObject(context.ParameterInfoConstructor,
                    Js.Primitive(parameter.Name),
                    Type(parameter.Type, true),
                    Js.Primitive(i), 
                    parameterAttributes,
                    parameter.HasDefaultValue ? Js.Literal(parameter.DefaultValue) : Js.Null(),
                    CreateAttributes(parameter));
                result.Elements.Add(parameterInfo);
            }
            return result;
        }

        private JsArrayExpression CreateAttributes(Symbol symbol)
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
            return result;
        }

        public JsInvocationExpression Get(JsExpression target, PropertySymbol property, params JsExpression[] arguments)
        {
            return target.Member("get_" + property.GetMemberName()).Invoke(arguments);
        }

        public JsBlockStatement InitializeInstanceFields(TypeDeclarationSyntax classDeclaration)
        {
            var result = new JsBlockStatement();

            // Add field initializers
            foreach (var field in classDeclaration.Members.OfType<FieldDeclarationSyntax>().Where(x => x.Declaration.Variables.Any(y => y.Initializer != null)))
            {
                foreach (var variable in field.Declaration.Variables)
                {
                    var fieldSymbol = (FieldSymbol)transformer.model.GetDeclaredSymbol(variable);
                    if (!fieldSymbol.IsStatic)
                        result.Assign(Js.This().Member(fieldSymbol.GetMemberName()), (JsExpression)variable.Initializer.Accept(transformer));
                }
            }
            
            return result;
        }

        public JsExpressionStatement CreatePrototype(NamedTypeSymbol type, NamedTypeSymbol baseType)
        {
            return CreatePrototype(Type(type), Type(baseType));
        }

        public JsExpressionStatement CreatePrototype(NamedTypeSymbol type, JsExpression baseType)
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

        public JsInvocationExpression InvokeMethodAsThis(MethodSymbol method, params JsExpression[] arguments)
        {
            return InvokeMethodAs(method, Js.This(), arguments);
        }

        public JsInvocationExpression InvokeMethodAs(MethodSymbol method, JsExpression @this, params JsExpression[] arguments)
        {
            var containingMember = Type(method.ContainingType);
            if (!method.IsStatic)
                containingMember = containingMember.Member("prototype");
            return containingMember.Member(method.GetMemberName()).Member("call")
                .Invoke(new[] { @this }.Concat(arguments).ToArray());
        }

        public JsInvocationExpression Invoke(JsExpression target, MethodSymbol method, params JsExpression[] arguments)
        {
            return target.Member(method.GetMemberName()).Invoke(arguments);
        }

        public JsExpression GetMethodFunction(MethodSymbol method, bool forceUnconstructedScope = false)
        {
            // Handle type arguments in the containing type
            JsExpression typeReference = Type(method.ContainingType, forceUnconstructedScope);
            return typeReference.Member("prototype").Member(method.GetMemberName());            
        }

        public JsInvocationExpression InvokeStatic(MethodSymbol method, params JsExpression[] args)
        {
            args = method.TypeArguments.Select(x => Type(x)).Concat(args).ToArray();

            JsExpression target;
            if (method.ContainingType == context.SpecialFunctions)
                target = Js.Reference(method.GetMemberName());
            else
                target = Type(method.ContainingType).Member(method.GetMemberName());

            return target.Invoke(args);
        }

        public JsExpression[] TranslateArguments(MethodSymbol method, params JsExpression[] args)
        {
            return TranslateArguments(method, (x, i) => x is JsArrayExpression);
        }

        public JsExpression[] TranslateArguments(MethodSymbol method, Func<JsExpression, int, bool> isArgumentArray, params JsExpression[] args)
        {
            var arguments = new List<JsExpression>();

            var isExported = method.IsExported();

            // The number of arguments may differ from the number of parameters, due to default parameters and the params keyword.
            // This queue holds all the remaining arguments, and the matching of parameters to arguments happens in sequence, 
            // consuming from the queue.
            var remainingArguments = new Queue<JsExpression>(args);

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
                        arguments.Add(Js.Array(remainingArguments.ToArray()));
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
                        arguments.Add(Js.Literal(parameter.DefaultValue));
                }
                else
                {
                    arguments.Add(remainingArguments.Dequeue());
                }
            }
            return arguments.ToArray();
        }

        public JsExpression GetPropertyValue(JsExpression target, PropertySymbol property)
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
                if (isExtension)
                    return InvokeMethodAs(property.GetMethod, target);
                else 
                    return Js.Invoke(Js.Member(target, "get_" + propertyName));
            }
        }

        public JsExpression MemberReference(JsExpression @this, Symbol symbol, bool isSetter = false)
        {
            switch (symbol.Kind)
            {
                case SymbolKind.Field:
                {
                    var field = (FieldSymbol)symbol;
                    var result = (JsExpression)@this.Member(field.GetMemberName());
/*
                    if (field.Type.TypeKind == TypeKind.Enum)
                        result = GetEnumValue(result);
*/
                    return result;
                }
                case SymbolKind.Event:
                {
                    var field = (EventSymbol)symbol;
                    return @this.Member(field.GetBackingFieldName());
                }
                case SymbolKind.Property:
                {
                    var property = (PropertySymbol)symbol;
                    if (property.ContainingType.IsGenericType && property.ContainingType.ConstructedFrom == context.NullableType)
                    {
                        property = (PropertySymbol)property.OriginalDefinition;
                        if (property == context.NullableHasValue)
                        {
                            return @this.NotEqualTo(Js.Null()).Parenthetical();
                        }
                        else if (property == context.NullableValue)
                        {
                            return @this;
                        }
                    }

                    return GetPropertyValue(@this, property);
                }
                case SymbolKind.Parameter:
                    return transformer.ReferenceDeclarationInScope(symbol.Name).GetReference();
                case SymbolKind.NamedType:
                    return Type((NamedTypeSymbol)symbol).Invoke();
                case SymbolKind.Local:
                    var declaration = transformer.ReferenceDeclarationInScope(symbol.Name);
                    return !isSetter ? declaration.GetReference() : declaration.SetReference();
                case SymbolKind.Method:
                {
                    var method = (MethodSymbol)symbol;
                    var containingSymbol = symbol.ContainingType;
                    var name = method.GetMemberName();
                    var target = method.IsStatic ? Type(containingSymbol) : @this;
                    if (method.ContainingType == containingSymbol)
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
            return StoreInType(SpecialNames.GetTypeFromType, Js.Function().Body(Js.Return(Type(context.TypeType).Member("_GetTypeFromTypeFunc").Invoke(Js.This()))));
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
//            var leftVariable = Js.Variable("$multicast$left", left);
//            var rightVariable = Js.Variable("$multicast$right", right);

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
            wrapper.Assign(delegateVariable.GetReference().Member("prototype"), Js.New(Type(context.MulticastDelegateType)));
            wrapper.Invoke(Type(context.ObjectType).Member(SpecialNames.TypeInitializer), delegateVariable.GetReference(), delegateVariable.GetReference());
            wrapper.Invoke(Type(context.DelegateType).Member(SpecialNames.TypeInitializer), delegateVariable.GetReference(), delegateVariable.GetReference());
            wrapper.Invoke(Type(context.MulticastDelegateType).Member(SpecialNames.TypeInitializer), delegateVariable.GetReference(), delegateVariable.GetReference());
            wrapper.Invoke(delegateType.Member(SpecialNames.TypeInitializer), delegateVariable.GetReference(), delegateVariable.GetReference());
            wrapper.Express(InvokeMethodAs(
                context.MulticastDelegateConstructor, 
                delegateVariable.GetReference(), 
                target, 
                list.GetReference()));
            wrapper.Return(delegateVariable.GetReference());

            return Wrap(wrapper);
        }

        public bool TryAccessorAssignment(SyntaxKind type, Symbol leftSymbol, Symbol rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            // Special handling for property and event assignments, since those have to be translated to a set/add/remove_PropertyName invocation.
            if (type == SyntaxKind.AssignExpression || type == SyntaxKind.AddAssignExpression || type == SyntaxKind.SubtractAssignExpression)
            {
                if (leftSymbol is PropertySymbol || leftSymbol is EventSymbol)
                {
                    var isExported = leftSymbol.IsExported();
                    if (isExported)
                    {
                        var arguments = new List<JsExpression>();
                        var target = left.GetLogicalTarget();

                        if (left is JsInvocationExpression)
                            arguments.AddRange(((JsInvocationExpression)left).Arguments);
                        arguments.Add(right);

                        MethodSymbol methodSymbol;
                        if (leftSymbol is PropertySymbol)
                            methodSymbol = ((PropertySymbol)leftSymbol).SetMethod;
                        else
                        {
                            var @event = (EventSymbol)leftSymbol;
                            switch (type)
                            {
                                case SyntaxKind.AddAssignExpression:
                                    methodSymbol = @event.AddMethod;
                                    break;
                                default:
                                    methodSymbol = @event.RemoveMethod;
                                    break;
                            }
                        }
                        result = target.Member(methodSymbol.Name).Invoke(arguments.ToArray());
                        return true;
                    }
                }
            }
            result = null;
            return false;
        }

        public bool TryIsExpression(SyntaxKind type, Symbol leftSymbol, Symbol rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            if (type == SyntaxKind.IsExpression)
            {
                var operand = (TypeSymbol)rightSymbol;
                result = Invoke(Type(operand).Member(SpecialNames.GetTypeFromType).Invoke(), context.TypeIsInstanceOfType, left);
                return true;
            }
            result = null;
            return false;
        }

        public bool TryCharUnaryExpression(SyntaxKind type, TypeInfo operandType, JsExpression operand, out JsExpression result)
        {
            if (operandType.Type == context.Char)
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
            if (leftSymbol.Type == context.Char || rightSymbol.Type == context.Char)
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
                    case SyntaxKind.AddAssignExpression:
                    case SyntaxKind.SubtractAssignExpression:
                    case SyntaxKind.MultiplyAssignExpression:
                    case SyntaxKind.DivideAssignExpression:
                    case SyntaxKind.ModuloAssignExpression:
                        result = Js.Binary(
                            ToBinaryOperator(type).Value, 
                            leftSymbol.Type != context.Char ? left : left.Member("charCodeAt").Invoke(Js.Primitive(0)),
                            rightSymbol.Type != context.Char ? right : right.Member("charCodeAt").Invoke(Js.Primitive(0))
                        );
                        switch (type)
                        {
                            case SyntaxKind.AddAssignExpression:
                            case SyntaxKind.SubtractAssignExpression:
                            case SyntaxKind.MultiplyAssignExpression:
                            case SyntaxKind.DivideAssignExpression:
                            case SyntaxKind.ModuloAssignExpression:
                                result = Js.Assign(left, Js.Reference("String").Member("fromCharCode").Invoke(result));
                                break;
                        }
                        return true;
                }                
            }
            result = null;
            return false;
        }

        public JsBinaryOperator? ToBinaryOperator(SyntaxKind kind)
        {
            JsBinaryOperator op;
            switch (kind)
            {
                case SyntaxKind.AssignExpression:
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
                case SyntaxKind.AddAssignExpression:
                    op = JsBinaryOperator.AddAssign;
                    break;
                case SyntaxKind.SubtractAssignExpression:
                    op = JsBinaryOperator.SubtractAssign;
                    break;
                case SyntaxKind.MultiplyAssignExpression:
                    op = JsBinaryOperator.MultiplyAssign;
                    break;
                case SyntaxKind.DivideAssignExpression:
                    op = JsBinaryOperator.DivideAssign;
                    break;
                case SyntaxKind.ModuloAssignExpression:
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

        public bool TryAsExpression(SyntaxKind type, Symbol leftSymbol, Symbol rightSymbol, JsExpression left, JsExpression right, out JsExpression result)
        {
            if (type == SyntaxKind.AsExpression)
            {
                var operand = (TypeSymbol)rightSymbol;
                var asBody = new JsBlockStatement();
                var asVariable = Js.Variable("$as$", left);
                asBody.Local(asVariable);
                var condition = Type(context.TypeType)
                    .Member("prototype")
                    .Member(context.TypeIsInstanceOfType.GetMemberName())
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

        public bool TryBaseMethodInvocation(InvocationExpressionSyntax node, MethodSymbol method, JsExpression[] arguments, out JsExpression result)
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
        public bool TryUnwrapAsExpression(MethodSymbol method, JsExpression target, JsExpression[] arguments, out JsExpression result)
        {
            var methodClass = method.ContainingType;
            if (methodClass == context.AsExtensionType)
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

        public bool TryNullableGetValueOrDefault(MethodSymbol method, JsExpression target, out JsExpression result)
        {
            // Special compiler handler for Nullable.GetValueOrDefault
            if (method.ContainingType.IsGenericType && method.ContainingType.ConstructedFrom == context.NullableType) 
            {
                var constructedMethod = method.OriginalDefinition;
                if (constructedMethod == context.NullableGetValueOrDefault)
                {
                    result = ((JsMemberReferenceExpression)target).Target;
                    return true;
                }
            }
            result = null;
            return false;
        }

        public bool TryReferenceEquals(MethodSymbol method, JsExpression[] arguments, out JsExpression result)
        {
            // Special compiler handler for ReferenceEquals (since there is no native operator overloading, == comparisons
            // are always reference comparisons.
            if (method == context.ObjectReferenceEquals)
            {
                result = arguments[0].EqualTo(arguments[1]);
                return true;
            }            
            result = null;
            return false;
        }

        public bool TryEnumToString(MethodSymbol method, JsExpression target, JsExpression methodTarget, TypeSymbol targetType, JsExpression[] arguments, out JsExpression result)
        {
            // Special compiler handler for ReferenceEquals (since there is no native operator overloading, == comparisons
            // are always reference comparisons.
            if (method.Name == "ToString" && targetType != null && targetType.TypeKind == TypeKind.Enum)
            {
                result = Type(context.EnumType).Member("InternalToObject").Invoke(Type(targetType), methodTarget).Member("ToString").Invoke();
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
                var memberArgSymbol = transformer.model.GetSymbolInfo(expression).Symbol;
                s = (string)((FieldSymbol)memberArgSymbol).ConstantValue;
            }
            return s;
        }

        public bool TryUnwrapJsFunctionInvoke(MethodSymbol method, InvocationExpressionSyntax invocation, JsExpression methodTarget, JsExpression[] arguments, out JsExpression result)
        {
            if (method.ContainingType == context.JsFunction && method.Name == "invoke")
            {
                result = methodTarget.Invoke(arguments);
                return true;
            }
            result = null;
            return false;
        }

        public bool TryUnwrapSpecialFunctions(ClassDeclarationSyntax classDeclaration, JsBlockStatement block)
        {
            var model = context.Compilation.GetSemanticModel(classDeclaration.SyntaxTree);
            var type = model.GetDeclaredSymbol(classDeclaration);
            if (type == context.SpecialFunctions)
            {
                foreach (var method in classDeclaration.Members.OfType<MethodDeclarationSyntax>())
                {
                    var methodSymbol = model.GetDeclaredSymbol(method);
                    transformer.PushDeclaration(methodSymbol);
                    transformer.PushScope(methodSymbol);
                    transformer.PushOutput(block);
                    var name = methodSymbol.GetAttributeValue<string>(context.JsAttributeType, "Name") ?? methodSymbol.Name;
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

        public bool TryUnwrapJsniExpression(MethodSymbol method, InvocationExpressionSyntax invocation, JsExpression[] arguments, out JsExpression result)
        {
            // Special compiler handler of Jsni -- these are special methods that translate into otherwise inexpressible javascript
            if (method.ContainingType == context.JsniType)
            {
                switch (method.Name)
                {
                    case "apply":
                    {
                        if (method.TypeArguments.Any())
                        {
                            // First argument is an Action -- we want to deconstruct it to extract the target and method name.
                            var body = invocation.ArgumentList.Arguments[0].Expression.GetBody();
                            var lambdaInvocation = (InvocationExpressionSyntax)body;
                            var lambdaMethod = (MethodSymbol)transformer.model.GetSymbolInfo(lambdaInvocation).Symbol;
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
                            var body = invocation.ArgumentList.Arguments[0].Expression.GetBody();
                            var lambdaInvocation = (InvocationExpressionSyntax)body;
                            var lambdaMethod = (MethodSymbol)transformer.model.GetSymbolInfo(lambdaInvocation).Symbol;
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
                        result = Js.New(arguments[0]);
                        return true;
                    case "array":
                        result = Js.Array(arguments);
                        return true;
                    case "invoke":
                        result = arguments[0].Invoke(arguments.Skip(1).ToArray());
                        return true;
                    case "memberset":
                    {
                        var memberName = GetConstantString(invocation.ArgumentList.Arguments[1].Expression);
                        result = Js.Assign(arguments[0].Member(memberName), arguments[2]);
                        return true;
                    }
                    case "member":
                    {
                        var memberName = GetConstantString(invocation.ArgumentList.Arguments[1].Expression);
                        result = arguments[0].Member(memberName);
                        return true;
                    }
                    case "function":
                    case "procedure":
                        var nameArguments = invocation.ArgumentList.Arguments.Skip(1).ToArray();
                        var nameOverrides = nameArguments.Select(x => GetConstantString(x.Expression)).ToArray();

                        var lambda = invocation.ArgumentList.Arguments[0].Expression;
                        var lambdaParameters = lambda.GetParameters();
                        transformer.PushScope(null);

                        var jsParameters = lambdaParameters.Select(x => Js.Parameter(x.Identifier.ToString())).Cast<IJsDeclaration>().ToArray();
                        for (var i = 0; i < nameOverrides.Length; i++)
                        {
                            jsParameters[i] = new WrappedParent(jsParameters[i]) { Name = nameOverrides[i]};
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
                        result = Js.Reference(GetConstantString(invocation.ArgumentList.Arguments[0].Expression));
                        return true;
                    case "parseInt":
                        result = Js.Reference("parseInt").Invoke(arguments);
                        return true;
                    case "isNaN":
                        result = Js.Reference("isNaN").Invoke(arguments);
                        return true;
                    case "instanceof":
                        result = Js.Parenthetical(Js.InstanceOf(arguments[0], arguments[1]));
                        return true;
                }
            }            
            result = null;
            return false;
        }

        public void InstrumentRefAndOutParameters(MethodSymbol method, List<JsExpression> arguments, List<JsStatement> prependers, List<JsStatement> appenders)
        {
            // It's a ref or out parameter, we need somewhere to store the value and instrument the arguments
            if (method.Parameters.Any(x => x.RefKind != RefKind.None))
            {
                for (var i = 0; i < method.Parameters.Count; i++)
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

        public bool TryApplyRefAndOutParametersAfterInvocation(MethodSymbol method, JsInvocationExpression invocation, out JsExpression result, List<JsStatement> prependers, List<JsStatement> appenders)
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

        public JsExpression SpecialTypeOnlyForEnclosingTypes(TypeSymbol type)
        {
            if (type.ContainingType != null)
            {
                return Js.This().Member(type.GetShortTypeName());
            }
            else
            {
                return Js.Reference(type.GetTypeName());
            }
        }

        public JsExpression MakeArrayType(TypeSymbol elementType)
        {
            return Type(context.ObjectType).Member("$$MakeArrayType").Invoke(Type(elementType));
        }

        public JsExpression TypeOf(TypeSymbol type)
        {
            return Type(type).Member(SpecialNames.GetTypeFromType).Invoke();
        }

        public JsExpression Type(TypeSymbol type, bool forceUnconstructedScope = false)
        {
            if (type is ArrayTypeSymbol)
            {
                var arrayType = (ArrayTypeSymbol)type;
                var elementType = arrayType.ElementType;
/*
                if (elementType is TypeParameterSymbol && forceUnconstructedScope)
                {
                    var tp = (TypeParameterSymbol)elementType;
                    elementType = context.ObjectType;
                }
*/
                return MakeArrayType(elementType);
            }

            var explicitName = type.GetAttributeValue<string>(context.JsAttributeType, "Name");
            if (explicitName != null)
                return Js.Reference(explicitName);

            var typeParameter = type as TypeParameterSymbol;
            if (typeParameter != null && typeParameter.DeclaringType != null)
            {
                return Js.Reference(type.Name);
//                return Js.This().Member(SpecialNames.TypeArgs).Index(Js.Primitive(type.Name));
            }
            var namedTypeSymbol = type as NamedTypeSymbol;
            if (namedTypeSymbol != null)
            {
                if ((namedTypeSymbol.HasOrIsEnclosedInGenericParameters()) && !forceUnconstructedScope && !namedTypeSymbol.IsUnboundGenericType)
                {
                    return Js.Parenthetical(MakeGenericType(namedTypeSymbol));
                }
                else 
                {
                    var result = type.GetFullName().Replace('`', '$');
                    return Js.Reference(result);
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

        public JsBlockStatement InitializeConstructor(NamedTypeSymbol type, string constructorName, string[] parameterNames)
        {
            return InitializeConstructor(type, constructorName, parameterNames.Select(x => Tuple.Create(x, (ParameterSymbol)null)).ToArray());
        }

        public JsBlockStatement InitializeConstructor(NamedTypeSymbol type, string constructorName, ParameterSymbol[] parameters)
        {
            return InitializeConstructor(type, constructorName, parameters.Select(x => Tuple.Create(x.Name, x)).ToArray());
        }

        private JsBlockStatement InitializeConstructor(NamedTypeSymbol type, string constructorName, Tuple<string, ParameterSymbol>[] parameters)
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

        public JsExpression GetEnumValue(params FieldSymbol[] enumFields)
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

        public JsExpression MemberOf(Symbol symbol)
        {
            if (symbol is FieldSymbol)
            {
                var field = (FieldSymbol)symbol;
                return Invoke(TypeOf(field.ContainingType), context.GetField, Js.Primitive(field.Name));
            }
            else if (symbol is PropertySymbol)
            {
                var property = (PropertySymbol)symbol;
                return Invoke(TypeOf(property.ContainingType), context.GetProperty, Js.Primitive(property.Name));
            }
            else if (symbol is MethodSymbol)
            {
                var method = (MethodSymbol)symbol;
                if (method.MethodKind == MethodKind.Constructor)
                {
                    return Invoke(TypeOf(method.ContainingType), context.GetConstructor, Js.Array(method.Parameters.Select(x => TypeOf(x.Type)).ToArray()));
                }
                else
                {
                    return Invoke(TypeOf(method.ContainingType), context.GetMethod, Js.Primitive(method.Name), Js.Array(method.Parameters.Select(x => TypeOf(x.Type)).ToArray()));
                }
            }
            else
            {
                throw new Exception();
            }
        }

        public JsInvocationExpression Array(ArrayTypeSymbol arrayType, params JsExpression[] elements)
        {
            return MakeArray(Js.Array(elements), arrayType);
        }

        public JsInvocationExpression MakeArray(JsArrayExpression array, ArrayTypeSymbol arrayType)
        {
            return Type(context.ObjectType).Member("$$InitializeArray").Invoke(
                array,
                Type(arrayType.ElementType));
        }
    }
}
