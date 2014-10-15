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

namespace WootzJs.Compiler
{
    public class Context
    {
        [ThreadStatic]
        private static Context instance;

        public static Context Instance
        {
            get { return instance; }
        }

        public Solution Solution { get; private set; } 
        public Project Project { get; private set; }
        public Compilation Compilation { get; private set; }
        public SymbolNameMap SymbolNames { get; private set; }

        public INamedTypeSymbol Exception { get; private set; }
        public INamedTypeSymbol SpecialFunctions { get; private set; }
        public IMethodSymbol DefaultOf { get; private set; }
        public IMethodSymbol InternalInit { get; private set; }
        public INamedTypeSymbol Assembly { get; private set; }
        public IMethodSymbol AssemblyConstructor { get; private set; }
        public INamedTypeSymbol JsAttributeType { get; private set; }
        public INamedTypeSymbol PrecedesAttribute { get; private set; }
        public INamedTypeSymbol ObjectType { get; private set; }
        public IMethodSymbol GetType { get; private set; }
        public IMethodSymbol ObjectReferenceEquals { get; private set; }
        public IMethodSymbol ObjectCast { get; private set; }
        public IMethodSymbol ObjectCreateDelegate { get; private set; }
        public INamedTypeSymbol TypeType { get; private set; }
        public IArrayTypeSymbol TypeArray { get; private set; }
        public IMethodSymbol TypeConstructor { get; private set; }
        public IMethodSymbol TypeInit { get; private set; }
        public IMethodSymbol CreateTypeParameter { get; private set; }
        public IMethodSymbol TypeIsInstanceOfType { get; private set; }
        public IMethodSymbol Type_GetTypeFromTypeFunc { get; private set; }
        public IMethodSymbol GetField { get; private set; }
        public IMethodSymbol GetProperty { get; private set; }
        public IMethodSymbol GetMethod { get; private set; }
        public IMethodSymbol GetConstructor { get; private set; }
        public INamedTypeSymbol AsExtensionType { get; private set; }
        public INamedTypeSymbol JsniType { get; private set; }
        public INamedTypeSymbol EnumType { get; private set; }
        public IMethodSymbol EnumGetValue { get; private set; }
        public IMethodSymbol EnumInternalToObject { get; private set; }
        public INamedTypeSymbol Enumerable { get; private set; }
        public INamedTypeSymbol EnumerableGeneric { get; private set; }
        public INamedTypeSymbol Enumerator { get; private set; }
        public IMethodSymbol EnumerableGetEnumerator { get; private set; }
        public IPropertySymbol EnumeratorCurrent { get; private set; }
        public IMethodSymbol EnumeratorMoveNext { get; private set; }
        public INamedTypeSymbol DelegateType { get; private set; }
        public IMethodSymbol DelegateTypeConstructor { get; private set; }
        public IPropertySymbol DelegateTarget { get; private set; }
        public IMethodSymbol DelegateCombine { get; private set; }
        public IMethodSymbol DelegateRemove { get; private set; }
        public INamedTypeSymbol MulticastDelegateType { get; private set; }
        public IMethodSymbol MulticastDelegateConstructor { get; private set; }
        public INamedTypeSymbol NullableType { get; private set; }
        public IPropertySymbol NullableHasValue { get; private set; }
        public IPropertySymbol NullableValue { get; private set; }
        public IMethodSymbol NullableGetValueOrDefault { get; private set; }
        public INamedTypeSymbol FieldInfo { get; private set; }
        public INamedTypeSymbol MethodInfo { get; private set; }
        public INamedTypeSymbol MemberInfo { get; private set; }
        public INamedTypeSymbol ParameterInfo { get; private set; }
        public INamedTypeSymbol ConstructorInfo { get; private set; }
        public INamedTypeSymbol PropertyInfo { get; private set; }
        public INamedTypeSymbol EventInfo { get; private set; }
        public INamedTypeSymbol Attribute { get; private set; }
        public IMethodSymbol FieldInfoConstructor { get; private set; }
        public IMethodSymbol MethodInfoConstructor { get; private set; }
        public IMethodSymbol ParameterInfoConstructor { get; private set; }
        public IMethodSymbol ConstructorInfoConstructor { get; private set; }
        public IMethodSymbol PropertyInfoConstructor { get; private set; }
        public IMethodSymbol EventInfoConstructor { get; private set; }
        public INamedTypeSymbol TypeAttributes { get; private set; }
        public IFieldSymbol TypeAttributesPublic { get; private set; }
        public IFieldSymbol TypeAttributesNotPublic { get; private set; }
        public IFieldSymbol TypeAttributesNestedPublic { get; private set; }
        public IFieldSymbol TypeAttributesNestedPrivate { get; private set; }
        public IFieldSymbol TypeAttributesNestedFamily { get; private set; }
        public IFieldSymbol TypeAttributesNestedAssembly { get; private set; }
        public IFieldSymbol TypeAttributesNestedFamANDAssem { get; private set; }
        public IFieldSymbol TypeAttributesNestedFamORAssem { get; private set; }
        public IFieldSymbol TypeAttributesAbstract { get; private set; }
        public IFieldSymbol TypeAttributesSealed { get; private set; }
        public IFieldSymbol TypeAttributesClass { get; private set; }
        public IFieldSymbol TypeAttributesInterface { get; private set; }
        public INamedTypeSymbol FieldAttributes { get; private set; }
        public IFieldSymbol FieldAttributesPublic { get; private set; }
        public IFieldSymbol FieldAttributesPrivate { get; private set; }
        public IFieldSymbol FieldAttributesFamily { get; private set; }
        public IFieldSymbol FieldAttributesAssembly { get; private set; }
        public IFieldSymbol FieldAttributesFamORAssem { get; private set; }
        public IFieldSymbol FieldAttributesStatic { get; private set; }
        public IFieldSymbol FieldAttributesInitOnly { get; private set; }
        public IFieldSymbol FieldAttributesLiteral { get; private set; }
        public INamedTypeSymbol MethodAttributes { get; private set; }
        public IFieldSymbol MethodAttributesPublic { get; private set; }
        public IFieldSymbol MethodAttributesPrivate { get; private set; }
        public IFieldSymbol MethodAttributesFamily { get; private set; }
        public IFieldSymbol MethodAttributesAssembly { get; private set; }
        public IFieldSymbol MethodAttributesFamORAssem { get; private set; }
        public IFieldSymbol MethodAttributesStatic { get; private set; }
        public INamedTypeSymbol ParameterAttributes { get; private set; }
        public IFieldSymbol ParameterAttributesOut { get; private set; }
        public IFieldSymbol ParameterAttributesHasDefault { get; private set; }
        public IFieldSymbol ParameterAttributesNone { get; private set; }
        public INamedTypeSymbol JsFunction { get; private set; }
        public INamedTypeSymbol IDisposable { get; private set; }
        public IMethodSymbol IDisposableDispose { get; private set; }
        public INamedTypeSymbol Expression { get; private set; }
        public INamedTypeSymbol ExpressionGeneric { get; private set; }
        public IArrayTypeSymbol ExpressionArray { get; private set; }
        public INamedTypeSymbol ExpressionType { get; private set; }
        public INamedTypeSymbol ExpressionLambda { get; private set; }
        public INamedTypeSymbol ParameterExpression { get; private set; }
        public IArrayTypeSymbol ParameterExpressionArray { get; private set; }
        public INamedTypeSymbol NewExpression { get; private set; }
        public INamedTypeSymbol MemberBinding { get; private set; }
        public IArrayTypeSymbol MemberBindingArray { get; private set; }
        public INamedTypeSymbol ElementInit { get; private set; }
        public IArrayTypeSymbol ElementInitArray { get; private set; }
        public INamedTypeSymbol String { get; private set; }
        public IMethodSymbol ObjectToString { get; private set; }
        public INamedTypeSymbol Char { get; private set; }
        public INamedTypeSymbol CharNullable { get; private set; }
        public INamedTypeSymbol Int64 { get; private set; }
        public INamedTypeSymbol Int32 { get; private set; }
        public INamedTypeSymbol Int16 { get; private set; }
        public INamedTypeSymbol UInt64 { get; private set; }
        public INamedTypeSymbol UInt32 { get; private set; }
        public INamedTypeSymbol UInt16 { get; private set; }
        public INamedTypeSymbol Byte { get; private set; }
        public INamedTypeSymbol SByte { get; private set; }
        public INamedTypeSymbol Single { get; private set; }
        public INamedTypeSymbol Double { get; private set; }
        public INamedTypeSymbol Decimal { get; private set; }
        public INamedTypeSymbol Constant { get; private set; }
        public INamedTypeSymbol Action { get; private set; }
        public INamedTypeSymbol ActionT { get; private set; }
        public INamedTypeSymbol Func { get; private set; }
        public INamedTypeSymbol JsObject { get; private set; }
        public INamedTypeSymbol JsString { get; private set; }
        public IMethodSymbol SafeToString { get; private set; }
        public INamedTypeSymbol Array { get; private set; }
        public INamedTypeSymbol INotifyPropertyChanged { get; private set; }
        public INamedTypeSymbol InvalidOperationException { get; private set; }
        public IMethodSymbol InvalidOperationExceptionStringConstructor { get; private set; }
        public INamedTypeSymbol LiftedVariableAttribute { get; private set; }
        public INamedTypeSymbol LiftedVariableAccessor { get; private set; }
        public IMethodSymbol LiftedVariableAccessorConstructor { get; private set; }

        public INamedTypeSymbol IAsyncStateMachine { get; private set; }
        public IMethodSymbol IAsyncStateMachineMoveNext { get; private set; }
        public IMethodSymbol IAsyncStateMachineSetStateMachine { get; private set; }
        public INamedTypeSymbol IEnumerator { get; private set; }
        public INamedTypeSymbol IEnumeratorT { get; private set; }
        public INamedTypeSymbol IEnumerable { get; private set; }
        public INamedTypeSymbol IEnumerableT { get; private set; }
        public IPropertySymbol IEnumeratorCurrent { get; private set; }
        public IMethodSymbol IEnumeratorMoveNext { get; private set; }
        public IMethodSymbol IEnumeratorReset { get; private set; }
        public IMethodSymbol IEnumerableGetEnumerator { get; private set; }
        public IPropertySymbol IEnumeratorTCurrent { get; private set; }
        public IMethodSymbol IEnumerableTGetEnumerator { get; private set; }
        public INamedTypeSymbol YieldIterator { get; set; }
        public IMethodSymbol YieldIteratorClone { get; set; }
        public IMethodSymbol YieldIteratorMoveNext { get; set; }

        public IMethodSymbol Nop { get; private set; }
        public INamedTypeSymbol Task { get; private set; }
        public INamedTypeSymbol TaskT { get; private set; }
        public INamedTypeSymbol TaskAwaiter { get; private set; }
        public INamedTypeSymbol TaskAwaiterT { get; private set; }
        public INamedTypeSymbol AsyncVoidMethodBuilder { get; private set; }
        public IMethodSymbol AsyncVoidMethodBuilderCreate { get; private set; }
        public IMethodSymbol AsyncVoidMethodBuilderStart { get; private set; }
        public INamedTypeSymbol AsyncTaskMethodBuilder { get; private set; }
        public IMethodSymbol AsyncTaskMethodBuilderCreate { get; private set; }
        public IMethodSymbol AsyncTaskMethodBuilderStart { get; private set; }
        public INamedTypeSymbol AsyncTaskTMethodBuilder { get; private set; }
        public IMethodSymbol AsyncTaskTMethodBuilderCreate { get; private set; }
        public IMethodSymbol AsyncTaskTMethodBuilderStart { get; private set; }
        public INamedTypeSymbol CallerMemberNameAttribute { get; private set; }
        public INamedTypeSymbol CultureInfo { get; private set; }
//        public NamedTypeSymbol IAutoNotifyPropertyChanged { get; private set; }
//        public MethodSymbol NotifyPropertyChanged { get; private set; }

        public static void Update(Solution solution, Project project, Compilation compilation)
        {
            instance = new Context();
            instance.UpdateContext(solution, project, compilation);
        }

        private void UpdateContext(Solution solution, Project project, Compilation compilation)
        {
            Solution = solution;
            Project = project;
            Compilation = compilation;
            SymbolNames = new SymbolNameMap(new Dictionary<ISymbol, string>());//SymbolNameCompiler.CompileSymbolNames(project, compilation);

//            var diagnostics = compilation.GetDiagnostics();
//            var mscorlib = compilation.GetReferencedAssemblySymbol(project.MetadataReferences.First());
//            var typeNames = mscorlib.TypeNames.OrderBy(x => x).ToArray();

            ObjectToString = compilation.ObjectType.GetMembers("ToString").OfType<IMethodSymbol>().Single();
            String = compilation.FindType("System.String");
            SpecialFunctions = compilation.FindType("System.Runtime.WootzJs.SpecialFunctions");
            DefaultOf = SpecialFunctions.GetMethod("DefaultOf");
            Char = compilation.FindType("System.Char");
            Byte = compilation.FindType("System.Byte");
            Int16 = compilation.FindType("System.Int16");
            Int32 = compilation.FindType("System.Int32");
            Int64 = compilation.FindType("System.Int64");
            SByte = compilation.FindType("System.SByte");
            UInt16 = compilation.FindType("System.UInt16");
            UInt32 = compilation.FindType("System.UInt32");
            UInt64 = compilation.FindType("System.UInt64");
            Single = compilation.FindType("System.Single");
            Double = compilation.FindType("System.Double");
            Decimal = compilation.FindType("System.Decimal");
            Exception = compilation.FindType("System.Exception");
            InternalInit = Exception.GetMethodByName("InternalInit");
            Assembly = compilation.FindType("System.Reflection.Assembly");
            AssemblyConstructor = Assembly.InstanceConstructors.Single();
            JsAttributeType = compilation.FindType("System.Runtime.WootzJs.JsAttribute");
            PrecedesAttribute = compilation.FindType("System.Runtime.WootzJs.DependsOnAttribute");
            ObjectType = compilation.FindType("System.Object");
            GetType = ObjectType.GetMethod("GetType");
            ObjectReferenceEquals = (IMethodSymbol)ObjectType.GetMembers("ReferenceEquals").Single();
            ObjectCast = (IMethodSymbol)SpecialFunctions.GetMembers("ObjectCast").Single();
            ObjectCreateDelegate = (IMethodSymbol)SpecialFunctions.GetMembers("CreateDelegate").Single();
            TypeType = compilation.FindType("System.Type");
            TypeArray = compilation.CreateArrayTypeSymbol(TypeType);
            TypeConstructor = TypeType.InstanceConstructors.Single();
            TypeInit = (IMethodSymbol)TypeType.GetMembers("Init").Single();
            CreateTypeParameter = (IMethodSymbol)TypeType.GetMembers("CreateTypeParameter").Single();
            TypeIsInstanceOfType = (IMethodSymbol)TypeType.GetMembers("IsInstanceOfType").Single();
            Type_GetTypeFromTypeFunc = (IMethodSymbol)TypeType.GetMembers("_GetTypeFromTypeFunc").Single();
            GetField = TypeType.GetMethod("GetField", String);
            GetProperty = TypeType.GetMethod("GetProperty", String);
            GetMethod = TypeType.GetMethod("GetMethod", String, TypeArray);
            GetConstructor = TypeType.GetMethod("GetConstructor", TypeArray);
            AsExtensionType = compilation.FindType("System.Runtime.WootzJs.AsExtension");
            JsniType = compilation.FindType("System.Runtime.WootzJs.Jsni");
            EnumType = compilation.FindType("System.Enum");
            EnumGetValue = EnumType.GetMethod("GetValue");
            EnumInternalToObject = EnumType.GetMethod("InternalToObject");
            Enumerable = compilation.FindType("System.Collections.IEnumerable");
            EnumerableGeneric = compilation.FindType("System.Collections.Generic.IEnumerable`1");
            Enumerator = compilation.FindType("System.Collections.IEnumerator");
            EnumerableGetEnumerator = (IMethodSymbol)Enumerable.GetMembers("GetEnumerator").Single();
            EnumeratorCurrent = (IPropertySymbol)Enumerator.GetMembers("Current").Single();
            EnumeratorMoveNext = (IMethodSymbol)Enumerator.GetMembers("MoveNext").Single();
            DelegateType = compilation.FindType("System.Delegate");
            DelegateTypeConstructor = DelegateType.InstanceConstructors.Single();
            DelegateTarget = (IPropertySymbol)DelegateType.GetMembers("Target").Single();
            DelegateCombine = DelegateType.GetMembers("Combine").OfType<IMethodSymbol>().Single(x => x.Parameters.Count() == 2 && x.Parameters.All(y => Equals(y.Type, DelegateType)));
            DelegateRemove = DelegateType.GetMembers("Remove").OfType<IMethodSymbol>().Single(x => x.Parameters.Count() == 2 && x.Parameters.All(y => Equals(y.Type, DelegateType)));
            MulticastDelegateType = compilation.FindType("System.MulticastDelegate");
            MulticastDelegateConstructor = MulticastDelegateType.InstanceConstructors.Single(x => x.Parameters.Last().Type.TypeKind == TypeKind.ArrayType);
            NullableType = compilation.FindType("System.Nullable`1");
            CharNullable = NullableType.Construct(Char);
            NullableHasValue = (IPropertySymbol)NullableType.GetMembers("HasValue").Single();
            NullableValue = (IPropertySymbol)NullableType.GetMembers("Value").Single();
            NullableGetValueOrDefault = (IMethodSymbol)NullableType.GetMembers("GetValueOrDefault").Single();
            FieldInfo = compilation.FindType("System.Reflection.FieldInfo");
            MethodInfo = compilation.FindType("System.Reflection.MethodInfo");
            MemberInfo = compilation.FindType("System.Reflection.MemberInfo");
            PropertyInfo = compilation.FindType("System.Reflection.PropertyInfo");
            EventInfo = compilation.FindType("System.Reflection.EventInfo");
            ConstructorInfo = compilation.FindType("System.Reflection.ConstructorInfo");
            Attribute = compilation.FindType("System.Attribute");
            FieldInfoConstructor = FieldInfo.InstanceConstructors.Single();
            MethodInfoConstructor = MethodInfo.InstanceConstructors.Single();
            ParameterInfo = compilation.FindType("System.Reflection.ParameterInfo");
            ParameterInfoConstructor = ParameterInfo.InstanceConstructors.Single();
            PropertyInfoConstructor = PropertyInfo.InstanceConstructors.Single();
            EventInfoConstructor = EventInfo.InstanceConstructors.Single();
            ConstructorInfoConstructor = ConstructorInfo.InstanceConstructors.Single();
            TypeAttributes = compilation.FindType("System.Reflection.TypeAttributes");
            TypeAttributesPublic = (IFieldSymbol)TypeAttributes.GetMembers("Public").Single();
            TypeAttributesNotPublic = (IFieldSymbol)TypeAttributes.GetMembers("NotPublic").Single();
            TypeAttributesNestedPublic = (IFieldSymbol)TypeAttributes.GetMembers("NestedPublic").Single();
            TypeAttributesNestedPrivate = (IFieldSymbol)TypeAttributes.GetMembers("NestedPrivate").Single();
            TypeAttributesNestedFamily = (IFieldSymbol)TypeAttributes.GetMembers("NestedFamily").Single();
            TypeAttributesNestedAssembly = (IFieldSymbol)TypeAttributes.GetMembers("NestedAssembly").Single();
            TypeAttributesNestedFamANDAssem = (IFieldSymbol)TypeAttributes.GetMembers("NestedFamANDAssem").Single();
            TypeAttributesNestedFamORAssem = (IFieldSymbol)TypeAttributes.GetMembers("NestedFamORAssem").Single();
            TypeAttributesAbstract = (IFieldSymbol)TypeAttributes.GetMembers("Abstract").Single();
            TypeAttributesSealed = (IFieldSymbol)TypeAttributes.GetMembers("Sealed").Single();
            TypeAttributesClass = (IFieldSymbol)TypeAttributes.GetMembers("Class").Single();
            TypeAttributesInterface = (IFieldSymbol)TypeAttributes.GetMembers("Interface").Single();
            FieldAttributes = compilation.FindType("System.Reflection.FieldAttributes");
            FieldAttributesPublic = (IFieldSymbol)FieldAttributes.GetMembers("Public").Single();
            FieldAttributesPrivate = (IFieldSymbol)FieldAttributes.GetMembers("Private").Single();
            FieldAttributesFamily = (IFieldSymbol)FieldAttributes.GetMembers("Family").Single();
            FieldAttributesAssembly = (IFieldSymbol)FieldAttributes.GetMembers("Assembly").Single();
            FieldAttributesFamORAssem = (IFieldSymbol)FieldAttributes.GetMembers("FamORAssem").Single();
            FieldAttributesStatic = (IFieldSymbol)FieldAttributes.GetMembers("Static").Single();
            FieldAttributesInitOnly = (IFieldSymbol)FieldAttributes.GetMembers("InitOnly").Single();
            FieldAttributesLiteral = (IFieldSymbol)FieldAttributes.GetMembers("Literal").Single();
            MethodAttributes = compilation.FindType("System.Reflection.MethodAttributes");
            MethodAttributesPublic = (IFieldSymbol)MethodAttributes.GetMembers("Public").Single();
            MethodAttributesPrivate = (IFieldSymbol)MethodAttributes.GetMembers("Private").Single();
            MethodAttributesFamily = (IFieldSymbol)MethodAttributes.GetMembers("Family").Single();
            MethodAttributesAssembly = (IFieldSymbol)MethodAttributes.GetMembers("Assembly").Single();
            MethodAttributesFamORAssem = (IFieldSymbol)MethodAttributes.GetMembers("FamORAssem").Single();
            MethodAttributesStatic = (IFieldSymbol)MethodAttributes.GetMembers("Static").Single();
            ParameterAttributes = compilation.FindType("System.Reflection.ParameterAttributes");
            ParameterAttributesOut = (IFieldSymbol)ParameterAttributes.GetMembers("Out").Single();
            ParameterAttributesHasDefault = (IFieldSymbol)ParameterAttributes.GetMembers("HasDefault").Single();
            ParameterAttributesNone = (IFieldSymbol)ParameterAttributes.GetMembers("None").Single();
            JsFunction = compilation.FindType("System.Runtime.WootzJs.JsFunction");
            IDisposable = compilation.FindType("System.IDisposable");
            IDisposableDispose = (IMethodSymbol)IDisposable.GetMembers("Dispose").Single();
            Expression = compilation.FindType("System.Linq.Expressions.Expression");
            ExpressionGeneric = compilation.FindType("System.Linq.Expressions.Expression`1");
            ExpressionArray = compilation.CreateArrayTypeSymbol(Expression);
            ExpressionType = compilation.FindType("System.Linq.Expressions.ExpressionType");
            ExpressionLambda = compilation.FindType("System.Linq.Expressions.Expression`1");
            ParameterExpression = compilation.FindType("System.Linq.Expressions.ParameterExpression");
            ParameterExpressionArray = compilation.CreateArrayTypeSymbol(ParameterExpression);
            NewExpression = compilation.FindType("System.Linq.Expressions.NewExpression");
            MemberBinding = compilation.FindType("System.Linq.Expressions.MemberBinding");
            MemberBindingArray = compilation.CreateArrayTypeSymbol(MemberBinding);
            ElementInit = compilation.FindType("System.Linq.Expressions.ElementInit");
            ElementInitArray = compilation.CreateArrayTypeSymbol(ElementInit);
            Constant = compilation.FindType("System.Linq.Expressions.ConstantExpression");
            Action = compilation.FindType("System.Action");
            ActionT = compilation.FindType("System.Action`1");
            Func = compilation.FindType("System.Func`1");
            JsObject = compilation.FindType("System.Runtime.WootzJs.JsObject");
            JsString = compilation.FindType("System.Runtime.WootzJs.JsString");
            SafeToString = SpecialFunctions.GetMembers("SafeToString").OfType<IMethodSymbol>().Single();
            Array = compilation.FindType("System.Array");
            INotifyPropertyChanged = compilation.FindType("System.ComponentModel.INotifyPropertyChanged");
            Task = compilation.FindType("System.Threading.Tasks.Task");
            TaskT = compilation.FindType("System.Threading.Tasks.Task`1");
            TaskAwaiter = compilation.FindType("System.Runtime.CompilerServices.TaskAwaiter");
            TaskAwaiterT = compilation.FindType("System.Runtime.CompilerServices.TaskAwaiter`1");
            Nop = compilation.FindType("System.Runtime.CompilerServices.Op").GetMethod("Nothing");
            AsyncVoidMethodBuilder = compilation.FindType("System.Runtime.CompilerServices.AsyncVoidMethodBuilder");
            AsyncVoidMethodBuilderCreate = AsyncVoidMethodBuilder.GetMethod("Create");
            AsyncVoidMethodBuilderStart = AsyncVoidMethodBuilder.GetMethod("Start");
            AsyncTaskMethodBuilder = compilation.FindType("System.Runtime.CompilerServices.AsyncTaskMethodBuilder");
            AsyncTaskMethodBuilderCreate = AsyncTaskMethodBuilder.GetMethod("Create");
            AsyncTaskMethodBuilderStart = AsyncTaskMethodBuilder.GetMethod("Start");
            AsyncTaskTMethodBuilder = compilation.FindType("System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1");
            AsyncTaskTMethodBuilderCreate = AsyncTaskTMethodBuilder.GetMethod("Create");
            AsyncTaskTMethodBuilderStart = AsyncTaskTMethodBuilder.GetMethod("Start");
            CallerMemberNameAttribute = compilation.FindType("System.Runtime.CompilerServices.CallerMemberNameAttribute");
            CultureInfo = compilation.FindType("System.Globalization.CultureInfo");
            InvalidOperationException = compilation.FindType("System.InvalidOperationException");
            InvalidOperationExceptionStringConstructor = InvalidOperationException.Constructors.Single(x => x.Parameters.Count() == 1 && x.Parameters.First().Type == String);
            LiftedVariableAttribute = compilation.FindType("System.Runtime.WootzJs.LiftedVariableAttribute");
            LiftedVariableAccessor = compilation.FindType("System.Runtime.WootzJs.LiftedVariableAccessor");
            LiftedVariableAccessorConstructor = LiftedVariableAccessor.Constructors.Single();

            IAsyncStateMachine = compilation.FindType("System.Runtime.CompilerServices.IAsyncStateMachine");
            IAsyncStateMachineMoveNext = IAsyncStateMachine.GetMethodByName("MoveNext");
            IAsyncStateMachineSetStateMachine = IAsyncStateMachine.GetMethodByName("SetStateMachine");
            IEnumerator = compilation.FindType("System.Collections.IEnumerator");
            IEnumerable = compilation.FindType("System.Collections.IEnumerable");
            IEnumeratorT = compilation.FindType("System.Collections.Generic.IEnumerator`1");
            IEnumerableT = compilation.FindType("System.Collections.Generic.IEnumerable`1");
            IEnumeratorCurrent = (IPropertySymbol)IEnumerator.GetMembers("Current").Single();
            IEnumeratorMoveNext = (IMethodSymbol)IEnumerator.GetMembers("MoveNext").Single();
            IEnumeratorReset = (IMethodSymbol)IEnumerator.GetMembers("Reset").Single();
            IEnumerableGetEnumerator = (IMethodSymbol)IEnumerable.GetMembers("GetEnumerator").Single();
            IEnumeratorTCurrent = (IPropertySymbol)IEnumeratorT.GetMembers("Current").Single();
            IEnumerableTGetEnumerator = (IMethodSymbol)IEnumerableT.GetMembers("GetEnumerator").Single();
            YieldIterator = compilation.FindType("System.YieldIterator`1");
            YieldIteratorClone = YieldIterator.GetMethodByName("Clone");
            YieldIteratorMoveNext = YieldIterator.GetMethodByName("MoveNext");

//            IAutoNotifyPropertyChanged = compilation.FindType("System.Runtime.WootzJs.IAutoNotifyPropertyChanged");
//            NotifyPropertyChanged = IAutoNotifyPropertyChanged.GetMethod("NotifyPropertyChanged");
        }
    }
}