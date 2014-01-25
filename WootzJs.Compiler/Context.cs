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

using System.Linq;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;

namespace WootzJs.Compiler
{
    public class Context
    {
        public ISolution Solution { get; private set; } 
        public IProject Project { get; private set; }
        public Compilation Compilation { get; private set; }
        public SymbolNameMap SymbolNames { get; private set; }

        public NamedTypeSymbol Exception { get; private set; }
        public NamedTypeSymbol SpecialFunctions { get; private set; }
        public MethodSymbol InternalInit { get; private set; }
        public NamedTypeSymbol Assembly { get; private set; }
        public MethodSymbol AssemblyConstructor { get; private set; }
        public NamedTypeSymbol JsAttributeType { get; private set; }
        public NamedTypeSymbol PrecedesAttribute { get; private set; }
        public NamedTypeSymbol ObjectType { get; private set; }
        public MethodSymbol ObjectReferenceEquals { get; private set; }
        public MethodSymbol ObjectCast { get; private set; }
        public MethodSymbol ObjectCreateDelegate { get; private set; }
        public NamedTypeSymbol TypeType { get; private set; }
        public ArrayTypeSymbol TypeArray { get; private set; }
        public MethodSymbol TypeConstructor { get; private set; }
        public MethodSymbol TypeInit { get; private set; }
        public MethodSymbol TypeIsInstanceOfType { get; private set; }
        public MethodSymbol Type_GetTypeFromTypeFunc { get; private set; }
        public MethodSymbol GetField { get; private set; }
        public MethodSymbol GetProperty { get; private set; }
        public MethodSymbol GetMethod { get; private set; }
        public MethodSymbol GetConstructor { get; private set; }
        public NamedTypeSymbol AsExtensionType { get; private set; }
        public NamedTypeSymbol JsRegexLiteralType { get; private set; }
        public NamedTypeSymbol JsniType { get; private set; }
        public NamedTypeSymbol EnumType { get; private set; }
        public NamedTypeSymbol Enumerable { get; private set; }
        public NamedTypeSymbol EnumerableGeneric { get; private set; }
        public NamedTypeSymbol Enumerator { get; private set; }
        public MethodSymbol EnumerableGetEnumerator { get; private set; }
        public PropertySymbol EnumeratorCurrent { get; private set; }
        public MethodSymbol EnumeratorMoveNext { get; private set; }
        public NamedTypeSymbol DelegateType { get; private set; }
        public MethodSymbol DelegateTypeConstructor { get; private set; }
        public PropertySymbol DelegateTarget { get; private set; }
        public MethodSymbol DelegateCombine { get; private set; }
        public MethodSymbol DelegateRemove { get; private set; }
        public NamedTypeSymbol MulticastDelegateType { get; private set; }
        public MethodSymbol MulticastDelegateConstructor { get; private set; }
        public NamedTypeSymbol NullableType { get; private set; }
        public PropertySymbol NullableHasValue { get; private set; }
        public PropertySymbol NullableValue { get; private set; }
        public MethodSymbol NullableGetValueOrDefault { get; private set; }
        public NamedTypeSymbol FieldInfo { get; private set; }
        public NamedTypeSymbol MethodInfo { get; private set; }
        public NamedTypeSymbol MemberInfo { get; private set; }
        public NamedTypeSymbol ParameterInfo { get; private set; }
        public NamedTypeSymbol ConstructorInfo { get; private set; }
        public NamedTypeSymbol PropertyInfo { get; private set; }
        public NamedTypeSymbol EventInfo { get; private set; }
        public MethodSymbol FieldInfoConstructor { get; private set; }
        public MethodSymbol MethodInfoConstructor { get; private set; }
        public MethodSymbol ParameterInfoConstructor { get; private set; }
        public MethodSymbol ConstructorInfoConstructor { get; private set; }
        public MethodSymbol PropertyInfoConstructor { get; private set; }
        public MethodSymbol EventInfoConstructor { get; private set; }
        public NamedTypeSymbol FieldAttributes { get; private set; }
        public FieldSymbol FieldAttributesPublic { get; private set; }
        public FieldSymbol FieldAttributesPrivate { get; private set; }
        public FieldSymbol FieldAttributesFamily { get; private set; }
        public FieldSymbol FieldAttributesAssembly { get; private set; }
        public FieldSymbol FieldAttributesFamORAssem { get; private set; }
        public FieldSymbol FieldAttributesStatic { get; private set; }
        public FieldSymbol FieldAttributesInitOnly { get; private set; }
        public FieldSymbol FieldAttributesLiteral { get; private set; }
        public NamedTypeSymbol MethodAttributes { get; private set; }
        public FieldSymbol MethodAttributesPublic { get; private set; }
        public FieldSymbol MethodAttributesPrivate { get; private set; }
        public FieldSymbol MethodAttributesFamily { get; private set; }
        public FieldSymbol MethodAttributesAssembly { get; private set; }
        public FieldSymbol MethodAttributesFamORAssem { get; private set; }
        public FieldSymbol MethodAttributesStatic { get; private set; }
        public NamedTypeSymbol ParameterAttributes { get; private set; }
        public FieldSymbol ParameterAttributesOut { get; private set; }
        public FieldSymbol ParameterAttributesHasDefault { get; private set; }
        public FieldSymbol ParameterAttributesNone { get; private set; }
        public NamedTypeSymbol JsFunction { get; private set; }
        public NamedTypeSymbol IDisposable { get; private set; }
        public MethodSymbol IDisposableDispose { get; private set; }
        public NamedTypeSymbol Expression { get; private set; }
        public NamedTypeSymbol ExpressionGeneric { get; private set; }
        public ArrayTypeSymbol ExpressionArray { get; private set; }
        public NamedTypeSymbol ExpressionType { get; private set; }
        public NamedTypeSymbol ExpressionLambda { get; private set; }
        public NamedTypeSymbol ParameterExpression { get; private set; }
        public ArrayTypeSymbol ParameterExpressionArray { get; private set; }
        public NamedTypeSymbol NewExpression { get; private set; }
        public NamedTypeSymbol MemberBinding { get; private set; }
        public ArrayTypeSymbol MemberBindingArray { get; private set; }
        public NamedTypeSymbol ElementInit { get; private set; }
        public ArrayTypeSymbol ElementInitArray { get; private set; }
        public ArrayTypeSymbol ArrayIndex { get; private set; }
        public NamedTypeSymbol String { get; private set; }
        public NamedTypeSymbol Char { get; private set; }
        public NamedTypeSymbol Int32 { get; private set; }
        public NamedTypeSymbol Constant { get; private set; }
        public NamedTypeSymbol Action { get; private set; }
        public NamedTypeSymbol Func { get; private set; }
        public NamedTypeSymbol JsObject { get; private set; }

        public Context(ISolution solution, IProject project, Compilation compilation)
        {
            Update(solution, project, compilation);
        }

        public void Update(ISolution solution, IProject project, Compilation compilation)
        {
            Solution = solution;
            Project = project;
            Compilation = compilation;
            SymbolNames = SymbolNameCompiler.CompileSymbolNames(compilation);

            String = compilation.GetTypeByMetadataName("System.String");
            SpecialFunctions = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.SpecialFunctions");
            Char = compilation.GetTypeByMetadataName("System.Char");
            Int32 = compilation.GetTypeByMetadataName("System.Int32");
            Exception = compilation.GetTypeByMetadataName("System.Exception");
            InternalInit = Exception.GetMethodByName("InternalInit");
            Assembly = compilation.GetTypeByMetadataName("System.Reflection.Assembly");
            AssemblyConstructor = Assembly.InstanceConstructors.Single();
            JsAttributeType = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.JsAttribute");
            PrecedesAttribute = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.DependsOnAttribute");
            ObjectType = compilation.GetTypeByMetadataName("System.Object");
            ObjectReferenceEquals = (MethodSymbol)ObjectType.GetMembers("ReferenceEquals").Single();
            ObjectCast = (MethodSymbol)SpecialFunctions.GetMembers("ObjectCast").Single();
            ObjectCreateDelegate = (MethodSymbol)SpecialFunctions.GetMembers("CreateDelegate").Single();
            TypeType = compilation.GetTypeByMetadataName("System.Type");
            TypeArray = compilation.CreateArrayTypeSymbol(TypeType);
            TypeConstructor = TypeType.InstanceConstructors.Single();
            TypeInit = (MethodSymbol)TypeType.GetMembers("Init").Single();
            TypeIsInstanceOfType = (MethodSymbol)TypeType.GetMembers("IsInstanceOfType").Single();
            Type_GetTypeFromTypeFunc = (MethodSymbol)TypeType.GetMembers("_GetTypeFromTypeFunc").Single();
            GetField = TypeType.GetMethod("GetField", String);
            GetProperty = TypeType.GetMethod("GetProperty", String);
            GetMethod = TypeType.GetMethod("GetMethod", String, TypeArray);
            GetConstructor = TypeType.GetMethod("GetConstructor", TypeArray);
            AsExtensionType = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.AsExtension");
            JsRegexLiteralType = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.JsRegexLiteral");
            JsniType = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.Jsni");
            EnumType = compilation.GetTypeByMetadataName("System.Enum");
            Enumerable = compilation.GetTypeByMetadataName("System.Collections.IEnumerable");
            EnumerableGeneric = compilation.GetTypeByMetadataName("System.Collections.Generic.IEnumerable`1");
            Enumerator = compilation.GetTypeByMetadataName("System.Collections.IEnumerator");
            EnumerableGetEnumerator = (MethodSymbol)Enumerable.GetMembers("GetEnumerator").Single();
            EnumeratorCurrent = (PropertySymbol)Enumerator.GetMembers("Current").Single();
            EnumeratorMoveNext = (MethodSymbol)Enumerator.GetMembers("MoveNext").Single();
            DelegateType = compilation.GetTypeByMetadataName("System.Delegate");
            DelegateTypeConstructor = DelegateType.InstanceConstructors.Single();
            DelegateTarget = (PropertySymbol)DelegateType.GetMembers("Target").Single();
            DelegateCombine = DelegateType.GetMembers("Combine").OfType<MethodSymbol>().Single(x => x.Parameters.Count == 2 && x.Parameters.All(y => y.Type == DelegateType));
            DelegateRemove = DelegateType.GetMembers("Remove").OfType<MethodSymbol>().Single(x => x.Parameters.Count == 2 && x.Parameters.All(y => y.Type == DelegateType));
            MulticastDelegateType = compilation.GetTypeByMetadataName("System.MulticastDelegate");
            MulticastDelegateConstructor = MulticastDelegateType.InstanceConstructors.Single();
            NullableType = compilation.GetTypeByMetadataName("System.Nullable`1");
            NullableHasValue = (PropertySymbol)NullableType.GetMembers("HasValue").Single();
            NullableValue = (PropertySymbol)NullableType.GetMembers("Value").Single();
            NullableGetValueOrDefault = (MethodSymbol)NullableType.GetMembers("GetValueOrDefault").Single();
            FieldInfo = compilation.GetTypeByMetadataName("System.Reflection.FieldInfo");
            MethodInfo = compilation.GetTypeByMetadataName("System.Reflection.MethodInfo");
            MemberInfo = compilation.GetTypeByMetadataName("System.Reflection.MemberInfo");
            PropertyInfo = compilation.GetTypeByMetadataName("System.Reflection.PropertyInfo");
            EventInfo = compilation.GetTypeByMetadataName("System.Reflection.EventInfo");
            ConstructorInfo = compilation.GetTypeByMetadataName("System.Reflection.ConstructorInfo");
            FieldInfoConstructor = FieldInfo.InstanceConstructors.Single();
            MethodInfoConstructor = MethodInfo.InstanceConstructors.Single();
            ParameterInfo = compilation.GetTypeByMetadataName("System.Reflection.ParameterInfo");
            ParameterInfoConstructor = ParameterInfo.InstanceConstructors.Single();
            PropertyInfoConstructor = PropertyInfo.InstanceConstructors.Single();
            EventInfoConstructor = EventInfo.InstanceConstructors.Single();
            ConstructorInfoConstructor = ConstructorInfo.InstanceConstructors.Single();
            FieldAttributes = compilation.GetTypeByMetadataName("System.Reflection.FieldAttributes");
            FieldAttributesPublic = (FieldSymbol)FieldAttributes.GetMembers("Public").Single();
            FieldAttributesPrivate = (FieldSymbol)FieldAttributes.GetMembers("Private").Single();
            FieldAttributesFamily = (FieldSymbol)FieldAttributes.GetMembers("Family").Single();
            FieldAttributesAssembly = (FieldSymbol)FieldAttributes.GetMembers("Assembly").Single();
            FieldAttributesFamORAssem = (FieldSymbol)FieldAttributes.GetMembers("FamORAssem").Single();
            FieldAttributesStatic = (FieldSymbol)FieldAttributes.GetMembers("Static").Single();
            FieldAttributesInitOnly = (FieldSymbol)FieldAttributes.GetMembers("InitOnly").Single();
            FieldAttributesLiteral = (FieldSymbol)FieldAttributes.GetMembers("Literal").Single();
            MethodAttributes = compilation.GetTypeByMetadataName("System.Reflection.MethodAttributes");
            MethodAttributesPublic = (FieldSymbol)MethodAttributes.GetMembers("Public").Single();
            MethodAttributesPrivate = (FieldSymbol)MethodAttributes.GetMembers("Private").Single();
            MethodAttributesFamily = (FieldSymbol)MethodAttributes.GetMembers("Family").Single();
            MethodAttributesAssembly = (FieldSymbol)MethodAttributes.GetMembers("Assembly").Single();
            MethodAttributesFamORAssem = (FieldSymbol)MethodAttributes.GetMembers("FamORAssem").Single();
            MethodAttributesStatic = (FieldSymbol)MethodAttributes.GetMembers("Static").Single();
            ParameterAttributes = compilation.GetTypeByMetadataName("System.Reflection.ParameterAttributes");
            ParameterAttributesOut = (FieldSymbol)ParameterAttributes.GetMembers("Out").Single();
            ParameterAttributesHasDefault = (FieldSymbol)ParameterAttributes.GetMembers("HasDefault").Single();
            ParameterAttributesNone = (FieldSymbol)ParameterAttributes.GetMembers("None").Single();
            JsFunction = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.JsFunction");
            IDisposable = compilation.GetTypeByMetadataName("System.IDisposable");
            IDisposableDispose = (MethodSymbol)IDisposable.GetMembers("Dispose").Single();
            Expression = compilation.GetTypeByMetadataName("System.Linq.Expressions.Expression");
            ExpressionGeneric = compilation.GetTypeByMetadataName("System.Linq.Expressions.Expression`1");
            ExpressionArray = compilation.CreateArrayTypeSymbol(Expression);
            ExpressionType = compilation.GetTypeByMetadataName("System.Linq.Expressions.ExpressionType");
            ExpressionLambda = compilation.GetTypeByMetadataName("System.Linq.Expressions.Expression`1");
            ParameterExpression = compilation.GetTypeByMetadataName("System.Linq.Expressions.ParameterExpression");
            ParameterExpressionArray = compilation.CreateArrayTypeSymbol(ParameterExpression);
            NewExpression = compilation.GetTypeByMetadataName("System.Linq.Expressions.NewExpression");
            MemberBinding = compilation.GetTypeByMetadataName("System.Linq.Expressions.MemberBinding");
            MemberBindingArray = compilation.CreateArrayTypeSymbol(MemberBinding);
            ElementInit = compilation.GetTypeByMetadataName("System.Linq.Expressions.ElementInit");
            ElementInitArray = compilation.CreateArrayTypeSymbol(ElementInit);
            Constant = compilation.GetTypeByMetadataName("System.Linq.Expressions.ConstantExpression");
            Action = compilation.GetTypeByMetadataName("System.Action");
            Func = compilation.GetTypeByMetadataName("System.Func`1");
            JsObject = compilation.GetTypeByMetadataName("System.Runtime.WootzJs.JsObject");
        }
    }
}
