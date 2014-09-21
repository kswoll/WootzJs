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
using System.Reflection;
using System.Runtime.WootzJs;

namespace System.Linq.Expressions
{
    public abstract class Expression
    {
        public ExpressionType NodeType { get; private set; }

        public abstract Expression Accept(ExpressionVisitor visitor);
        public abstract Type Type { get; }

        protected Expression(ExpressionType nodeType)
        {
            NodeType = nodeType;
        }

        public static Expression<TDelegate> Lambda<TDelegate>(Expression body, params ParameterExpression[] parameters)
        {
            return Lambda<TDelegate>(body, null, false, parameters);
        }

        public static Expression<TDelegate> Lambda<TDelegate>(Expression body, string name, bool tailCall, params ParameterExpression[] parameters)
        {
            return new Expression<TDelegate>(body, name, tailCall, parameters);
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.LambdaExpression"/> by first constructing a delegate type. It can be used when the delegate type is not known at compile time.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents a lambda expression which has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Lambda"/> and the <see cref="P:System.Linq.Expressions.LambdaExpression.Body"/> and <see cref="P:System.Linq.Expressions.LambdaExpression.Parameters"/> properties set to the specified values.
        /// </returns>
        /// <param name="delegateType">A <see cref="T:System.Type"/> that represents a delegate signature for the lambda.</param><param name="body">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.LambdaExpression.Body"/> property equal to.</param><param name="parameters">An array of <see cref="T:System.Linq.Expressions.ParameterExpression"/> objects to use to populate the <see cref="P:System.Linq.Expressions.LambdaExpression.Parameters"/> collection.</param><exception cref="T:System.ArgumentNullException"><paramref name="delegateType"/> or <paramref name="body"/> is null.-or-One or more elements in <paramref name="parameters"/> are null.</exception><exception cref="T:System.ArgumentException"><paramref name="delegateType"/> does not represent a delegate type.-or-<paramref name="body"/>.Type represents a type that is not assignable to the return type of the delegate type represented by <paramref name="delegateType"/>.-or-<paramref name="parameters"/> does not contain the same number of elements as the list of parameters for the delegate type represented by <paramref name="delegateType"/>.-or-The <see cref="P:System.Linq.Expressions.Expression.Type"/> property of an element of <paramref name="parameters"/> is not assignable from the type of the corresponding parameter type of the delegate type represented by <paramref name="delegateType"/>.</exception>
        public static LambdaExpression Lambda(Type delegateType, Expression body, params ParameterExpression[] parameters)
        {
            return Lambda(delegateType, body, null, false, parameters);
        }

        /// <summary>
        /// Creates a LambdaExpression by first constructing a delegate type.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.LambdaExpression"/> that has the <see cref="P:System.Linq.Expressions.LambdaExpression.NodeType"/> property equal to Lambda and the <see cref="P:System.Linq.Expressions.LambdaExpression.Body"/> and <see cref="P:System.Linq.Expressions.LambdaExpression.Parameters"/> properties set to the specified values.
        /// </returns>
        /// <param name="delegateType">A <see cref="P:System.Linq.Expressions.Expression.Type"/> representing the delegate signature for the lambda.</param><param name="body">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.LambdaExpression.Body"/> property equal to. </param><param name="name">The name for the lambda. Used for emitting debug information.</param><param name="tailCall">A <see cref="T:System.Boolean"/> that indicates if tail call optimization will be applied when compiling the created expression. </param><param name="parameters">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> that contains <see cref="T:System.Linq.Expressions.ParameterExpression"/> objects to use to populate the <see cref="P:System.Linq.Expressions.LambdaExpression.Parameters"/> collection. </param>
        public static LambdaExpression Lambda(Type delegateType, Expression body, string name, bool tailCall, IEnumerable<ParameterExpression> parameters)
        {
            return null;
        }

        /// <summary>
        /// Creates an <see cref="T:System.Linq.Expressions.IndexExpression"/> representing the access to an indexed property.
        /// </summary>
        /// 
        /// <returns>
        /// The created <see cref="T:System.Linq.Expressions.IndexExpression"/>.
        /// </returns>
        /// <param name="instance">The object to which the property belongs. If the property is static/shared, it must be null.</param><param name="propertyName">The name of the indexer.</param><param name="args">An array of <see cref="T:System.Linq.Expressions.Expression"/> objects that are used to index the property.</param>
        public static IndexExpression Property(Expression instance, string propertyName, params Expression[] args)
        {
            //PropertyInfo instanceProperty = Expression.FindInstanceProperty(instance.Type, propertyName, arguments);
            return Expression.Property(instance, (PropertyInfo)null, args);
        }

        /// <summary>
        /// Creates an <see cref="T:System.Linq.Expressions.IndexExpression"/> representing the access to an indexed property.
        /// </summary>
        /// 
        /// <returns>
        /// The created <see cref="T:System.Linq.Expressions.IndexExpression"/>.
        /// </returns>
        /// <param name="instance">The object to which the property belongs. If the property is static/shared, it must be null.</param><param name="indexer">The <see cref="T:System.Reflection.PropertyInfo"/> that represents the property to index.</param><param name="args">An array of <see cref="T:System.Linq.Expressions.Expression"/> objects that are used to index the property.</param>
        public static IndexExpression Property(Expression instance, PropertyInfo indexer, params Expression[] args)
        {
            return Property(instance, indexer, (IEnumerable<Expression>)args);
        }

        /// <summary>
        /// Creates an <see cref="T:System.Linq.Expressions.IndexExpression"/> representing the access to an indexed property.
        /// </summary>
        /// 
        /// <returns>
        /// The created <see cref="T:System.Linq.Expressions.IndexExpression"/>.
        /// </returns>
        /// <param name="instance">The object to which the property belongs. If the property is static/shared, it must be null.</param><param name="indexer">The <see cref="T:System.Reflection.PropertyInfo"/> that represents the property to index.</param><param name="args">An <see cref="T:System.Collections.Generic.IEnumerable`1"/> of <see cref="T:System.Linq.Expressions.Expression"/> objects that are used to index the property.</param>
        public static IndexExpression Property(Expression instance, PropertyInfo indexer, IEnumerable<Expression> args)
        {
            return new IndexExpression(instance, indexer, null, args.ToList());
        }

        public static MemberExpression Property(Expression expression, string propertyName)
        {
            var property = expression.GetType().GetProperty(propertyName);
            return Property(expression, property);
        }

        public static MemberExpression Property(Expression expression, Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName);
            return Property(expression, property);
        }

        public static MemberExpression Property(Expression expression, PropertyInfo property)
        {
            return MemberExpression.Make(expression, property);
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.MemberExpression"/> that represents accessing a property by using a property accessor method.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.MemberExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess"/>, the <see cref="P:System.Linq.Expressions.MemberExpression.Expression"/> property set to <paramref name="expression"/> and the <see cref="P:System.Linq.Expressions.MemberExpression.Member"/> property set to the <see cref="T:System.Reflection.PropertyInfo"/> that represents the property accessed in <paramref name="propertyAccessor"/>.
        /// </returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.MemberExpression.Expression"/> property equal to. This can be null for static properties.</param><param name="propertyAccessor">The <see cref="T:System.Reflection.MethodInfo"/> that represents a property accessor method.</param><exception cref="T:System.ArgumentNullException"><paramref name="propertyAccessor"/> is null.-or-The method that <paramref name="propertyAccessor"/> represents is not static (Shared in Visual Basic) and <paramref name="expression"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="expression"/>.Type is not assignable to the declaring type of the method represented by <paramref name="propertyAccessor"/>.-or-The method that <paramref name="propertyAccessor"/> represents is not a property accessor method.</exception>
        public static MemberExpression Property(Expression expression, MethodInfo propertyAccessor)
        {
            return Expression.Property(expression, Expression.GetProperty(propertyAccessor));
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.MemberExpression"/> that represents accessing a property or field.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.MemberExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess"/>, the <see cref="P:System.Linq.Expressions.MemberExpression.Expression"/> property set to <paramref name="expression"/>, and the <see cref="P:System.Linq.Expressions.MemberExpression.Member"/> property set to the <see cref="T:System.Reflection.PropertyInfo"/> or <see cref="T:System.Reflection.FieldInfo"/> that represents the property or field denoted by <paramref name="propertyOrFieldName"/>.
        /// </returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression"/> whose <see cref="P:System.Linq.Expressions.Expression.Type"/> contains a property or field named <paramref name="propertyOrFieldName"/>. This can be null for static members.</param><param name="propertyOrFieldName">The name of a property or field to be accessed.</param><exception cref="T:System.ArgumentNullException"><paramref name="expression"/> or <paramref name="propertyOrFieldName"/> is null.</exception><exception cref="T:System.ArgumentException">No property or field named <paramref name="propertyOrFieldName"/> is defined in <paramref name="expression"/>.Type or its base types.</exception>
        public static MemberExpression PropertyOrField(Expression expression, string propertyOrFieldName)
        {
            PropertyInfo property1 = expression.Type.GetProperty(propertyOrFieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (property1 != (PropertyInfo)null)
                return Expression.Property(expression, property1);
            FieldInfo field1 = expression.Type.GetField(propertyOrFieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (field1 != (FieldInfo)null)
                return Expression.Field(expression, field1);
            PropertyInfo property2 = expression.Type.GetProperty(propertyOrFieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
            if (property2 != (PropertyInfo)null)
                return Expression.Property(expression, property2);
            FieldInfo field2 = expression.Type.GetField(propertyOrFieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
            if (field2 != (FieldInfo)null)
                return Expression.Field(expression, field2);
            else
                throw new Exception("Not found: " + propertyOrFieldName);
        }

        public static ParameterExpression Parameter(Type type)
        {
            return Parameter(type, null);
        }

        public static ParameterExpression Variable(Type type)
        {
            return Variable(type, null);
        }

        public static ParameterExpression Variable(Type type, string name)
        {
            return new ParameterExpression(type, name);
        }

        public static ParameterExpression Parameter(Type type, string name)
        {
            return new ParameterExpression(type, name);
        }

        public static MemberExpression MakeMemberAccess(Expression target, MemberInfo member)
        {
            if (member is FieldInfo)
                return new FieldExpression(target, (FieldInfo)member);
            else if (member is PropertyInfo)
                return new PropertyExpression(target, (PropertyInfo)member);
            else
                throw new InvalidOperationException("Only field and property members are supported");
        }

        public static MethodCallExpression Call(Expression target, MethodInfo method, params Expression[] args)
        {
            return new MethodCallExpression(target, method, args);
        }

        public static MethodCallExpression Call(MethodInfo method, params Expression[] args)
        {
            return new MethodCallExpression(null, method, args);
        }

        public static ConstantExpression Constant(object value)
        {
            return new ConstantExpression(value);
        }

        public static ConstantExpression Constant(object value, Type type)
        {
            return new ConstantExpression(value, type);
        }

        public static BinaryExpression MakeBinary(ExpressionType nodeType, Expression left,
            Expression right, bool liftToNull, MethodInfo method)
        {
            return new BinaryExpression(left, right, nodeType, liftToNull, method);
        }

        public static BinaryExpression MakeBinary(ExpressionType binaryType, Expression left,
            Expression right)
        {
            return new BinaryExpression(left, right, binaryType, false, null);
        }

        public static UnaryExpression MakeUnary(ExpressionType unaryType, Expression operand, Type type)
        {
            return new UnaryExpression(unaryType, operand, null, type);
        }

        public static UnaryExpression MakeUnary(ExpressionType unaryType, Expression operand, Type type, MethodInfo method)
        {
            return new UnaryExpression(unaryType, operand, method, type);
        }

        public static NewExpression New(Type type)
        {
            var constructor = type.GetConstructors().Single(x => x.GetParameters().Length == 0);
            return new NewExpression(constructor.As<ConstructorInfo>(), new Expression[0]);
        }

        public static NewExpression New(ConstructorInfo constructor)
        {
            return new NewExpression(constructor.As<ConstructorInfo>(), new Expression[0]);
        }

        public static NewExpression New(ConstructorInfo constructor, params Expression[] args)
        {
            return new NewExpression(constructor.As<ConstructorInfo>(), args);
        }

        public static NewExpression New(ConstructorInfo constructor, IEnumerable<Expression> args)
        {
            return new NewExpression(constructor.As<ConstructorInfo>(), args);
        }

        public static MemberAssignment Bind(MemberInfo member, Expression expression)
        {
            return new MemberAssignment(member, expression);
        }

        public static MemberAssignment Bind(MethodInfo propertyAccessor, Expression expression)
        {
            var memberInfo = GetProperty(propertyAccessor);
            return new MemberAssignment(memberInfo, expression);
        }

        public static MemberInitExpression MemberInit(NewExpression newExpression, params MemberBinding[] bindings)
        {
            return MemberInit(newExpression, (IEnumerable<MemberBinding>)bindings);
        }

        public static MemberInitExpression MemberInit(NewExpression newExpression, IEnumerable<MemberBinding> bindings)
        {
            return new MemberInitExpression(newExpression, bindings.ToList());
        }

        private static PropertyInfo GetProperty(MethodInfo mi)
        {
            var propertyName = mi.Name;
            if (propertyName.StartsWith("set_"))
                propertyName = propertyName.Substring(4);
            return mi.DeclaringType.GetProperty(propertyName);
        }

        public static ListInitExpression ListInit(NewExpression newExpression, params Expression[] initializers)
        {
            return ListInit(newExpression, (IEnumerable<Expression>)initializers);
        }

        public static ListInitExpression ListInit(NewExpression newExpression, IEnumerable<Expression> initializers)
        {
            MethodInfo method = newExpression.Type.GetMethod("Add");
            return ListInit(newExpression, method, initializers);
        }

        public static ListInitExpression ListInit(NewExpression newExpression, MethodInfo addMethod, params Expression[] initializers)
        {
            if (addMethod == null)
                return ListInit(newExpression, (IEnumerable<Expression>)initializers);
            return ListInit(newExpression, addMethod, (IEnumerable<Expression>)initializers);
        }

        public static ListInitExpression ListInit(NewExpression newExpression, MethodInfo addMethod, IEnumerable<Expression> initializers)
        {
            if (addMethod == null)
                return ListInit(newExpression, initializers);
            var list = initializers.Select(x => ElementInit(addMethod, new List<Expression> { x })).ToArray();
            return ListInit(newExpression, list);
        }

        public static ListInitExpression ListInit(NewExpression newExpression, params ElementInit[] initializers)
        {
            return ListInit(newExpression, (IEnumerable<ElementInit>)initializers);
        }

        public static ListInitExpression ListInit(NewExpression newExpression, IEnumerable<ElementInit> initializers)
        {
            return new ListInitExpression(newExpression, initializers.ToList());
        }

        public static ElementInit ElementInit(MethodInfo addMethod, params Expression[] args)
        {
            return ElementInit(addMethod, (IEnumerable<Expression>)args);
        }

        public static ElementInit ElementInit(MethodInfo addMethod, IEnumerable<Expression> args)
        {
            return new ElementInit(addMethod, args.ToList());
        }

        public static NewArrayExpression NewArrayInit(Type type, params Expression[] initializers)
        {
            return Expression.NewArrayInit(type, (IEnumerable<Expression>)initializers);
        }

        public static NewArrayExpression NewArrayInit(Type type, IEnumerable<Expression> initializers)
        {
            var expressions = initializers.ToArray();
            int i = 0;
            Expression[] list = null;
/*
            for (int count = expressions.Length; i < count; ++i)
            {
                Expression expression = expressions[i];
                if (!TypeUtils.AreReferenceAssignable(type, expression.Type))
                {
                    if (list == null)
                    {
                        list = new Expression[expressions.Length];
                        for (int j = 0; j < i; ++j)
                            list[j] = expressions[j];
                    }
                }
                if (list != null)
                    list[i] = expression;
            }
*/
            if (list != null)
                expressions = list;
            return new NewArrayExpression(ExpressionType.NewArrayInit, type.MakeArrayType(), expressions.ToList());
        }

        public static NewArrayExpression NewArrayBounds(Type type, params Expression[] bounds)
        {
            return NewArrayBounds(type, (IEnumerable<Expression>)bounds);
        }

        public static NewArrayExpression NewArrayBounds(Type type, IEnumerable<Expression> bounds)
        {
            var expressions = bounds.ToArray();
            int count = expressions.Length;
            return new NewArrayExpression(
                ExpressionType.NewArrayBounds,
                count != 1 ? type.MakeArrayType(count) : type.MakeArrayType(),
                expressions.ToList());
        }

        public static UnaryExpression TypeAs(Expression expression, Type type)
        {
            return new UnaryExpression(ExpressionType.TypeAs, expression, null, type);
        }

        public static TypeBinaryExpression TypeIs(Expression expression, Type type)
        {
            return new TypeBinaryExpression(expression, type, ExpressionType.TypeIs);
        }

        public static DefaultExpression Default(Type type)
        {
            return new DefaultExpression(type);
        }

        public static IndexExpression MakeIndex(Expression target, PropertyInfo indexer, IEnumerable<Expression> args)
        {
            return new IndexExpression(target, indexer, indexer != null ? indexer.PropertyType : null, args.ToList());
        }

        public static MethodCallExpression ArrayIndex(Expression array, params Expression[] indexes)
        {
            return ArrayIndex(array, (IEnumerable<Expression>)indexes);
        }

        public static MethodCallExpression ArrayIndex(Expression array, IEnumerable<Expression> indexes)
        {
            MethodInfo method = typeof (Array).As<Type>().GetMethod("Get");
            return Call(array, method, indexes.ToArray());
        }

        public static BinaryExpression ArrayIndex(Expression array, Expression index)
        {
            return new BinaryExpression(array, index, ExpressionType.ArrayIndex);
        }

        public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse)
        {
            return new ConditionalExpression(test, ifTrue, ifFalse, ifTrue.Type);
        }

        public static ConditionalExpression Condition(Expression test, Expression ifTrue, Expression ifFalse, Type type)
        {
            return new ConditionalExpression(test, ifTrue, ifFalse, type);
        }

        public static InvocationExpression Invoke(Expression expression, params Expression[] args)
        {
            return Invoke(expression, (IEnumerable<Expression>)args);
        }

        public static InvocationExpression Invoke(Expression expression, IEnumerable<Expression> args)
        {
//            var invokeMethod = expression.Type.GetMethod("Invoke"); // Currently broken because SharpKit doesn't support reified generics in reflection
            return new InvocationExpression(expression, args.ToList(), typeof (object).As<Type>()); // invokeMethod.ReturnType
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.MemberExpression"/> that represents accessing a field.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.MemberExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess"/> and the <see cref="P:System.Linq.Expressions.MemberExpression.Expression"/> and <see cref="P:System.Linq.Expressions.MemberExpression.Member"/> properties set to the specified values.
        /// </returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.MemberExpression.Expression"/> property equal to. For static (Shared in Visual Basic), <paramref name="expression"/> must be null.</param><param name="field">The <see cref="T:System.Reflection.FieldInfo"/> to set the <see cref="P:System.Linq.Expressions.MemberExpression.Member"/> property equal to.</param><exception cref="T:System.ArgumentNullException"><paramref name="field"/> is null.-or-The field represented by <paramref name="field"/> is not static (Shared in Visual Basic) and <paramref name="expression"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="expression"/>.Type is not assignable to the declaring type of the field represented by <paramref name="field"/>.</exception>
        public static MemberExpression Field(Expression expression, FieldInfo field)
        {
            return MemberExpression.Make(expression, field);
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.MemberExpression"/> that represents accessing a field given the name of the field.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.MemberExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess"/>, the <see cref="P:System.Linq.Expressions.MemberExpression.Expression"/> property set to <paramref name="expression"/>, and the <see cref="P:System.Linq.Expressions.MemberExpression.Member"/> property set to the <see cref="T:System.Reflection.FieldInfo"/> that represents the field denoted by <paramref name="fieldName"/>.
        /// </returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression"/> whose <see cref="P:System.Linq.Expressions.Expression.Type"/> contains a field named <paramref name="fieldName"/>. This can be null for static fields.</param><param name="fieldName">The name of a field to be accessed.</param><exception cref="T:System.ArgumentNullException"><paramref name="expression"/> or <paramref name="fieldName"/> is null.</exception><exception cref="T:System.ArgumentException">No field named <paramref name="fieldName"/> is defined in <paramref name="expression"/>.Type or its base types.</exception>
        public static MemberExpression Field(Expression expression, string fieldName)
        {
            FieldInfo field = expression.Type.GetField(fieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (field == null)
                field = expression.Type.GetField(fieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
            if (field == null)
                throw new InvalidOperationException(fieldName + ": " + expression.Type);
            else
                return Field(expression, field);
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.MemberExpression"/> that represents accessing a field.
        /// </summary>
        /// 
        /// <returns>
        /// The created <see cref="T:System.Linq.Expressions.MemberExpression"/>.
        /// </returns>
        /// <param name="expression">The containing object of the field. This can be null for static fields.</param><param name="type">The <see cref="P:System.Linq.Expressions.Expression.Type"/> that contains the field.</param><param name="fieldName">The field to be accessed.</param>
        public static MemberExpression Field(Expression expression, Type type, string fieldName)
        {
            FieldInfo field = type.GetField(fieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            if (field == null)
                field = type.GetField(fieldName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
            if (field == null)
                throw new Exception(fieldName + ": " + type);
            else
                return Field(expression, field);
        }


        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.UnaryExpression"/> that represents a type conversion operation.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.UnaryExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Convert"/> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand"/> and <see cref="P:System.Linq.Expressions.Expression.Type"/> properties set to the specified values.
        /// </returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand"/> property equal to.</param><param name="type">A <see cref="T:System.Type"/> to set the <see cref="P:System.Linq.Expressions.Expression.Type"/> property equal to.</param><exception cref="T:System.ArgumentNullException"><paramref name="expression"/> or <paramref name="type"/> is null.</exception><exception cref="T:System.InvalidOperationException">No conversion operator is defined between <paramref name="expression"/>.Type and <paramref name="type"/>.</exception>
        public static UnaryExpression Convert(Expression expression, Type type)
        {
            return Expression.Convert(expression, type, (MethodInfo)null);
        }
/*

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.BinaryExpression"/> that represents an equality comparison.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.BinaryExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Equal"/> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left"/> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right"/> properties set to the specified values.
        /// </returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left"/> property equal to.</param><param name="right">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right"/> property equal to.</param><exception cref="T:System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception><exception cref="T:System.InvalidOperationException">The equality operator is not defined for <paramref name="left"/>.Type and <paramref name="right"/>.Type.</exception>
        public static BinaryExpression Equal(Expression left, Expression right)
        {
            return Equal(left, right, false, null);
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.BinaryExpression"/> that represents an equality comparison. The implementing method can be specified.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.BinaryExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Equal"/> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left"/>, <see cref="P:System.Linq.Expressions.BinaryExpression.Right"/>, <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull"/>, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method"/> properties set to the specified values.
        /// </returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left"/> property equal to.</param><param name="right">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right"/> property equal to.</param><param name="liftToNull">true to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull"/> to true; false to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull"/> to false.</param><param name="method">A <see cref="T:System.Reflection.MethodInfo"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method"/> property equal to.</param><exception cref="T:System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="method"/> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception><exception cref="T:System.InvalidOperationException"><paramref name="method"/> is null and the equality operator is not defined for <paramref name="left"/>.Type and <paramref name="right"/>.Type.</exception>
        public static BinaryExpression Equal(Expression left, Expression right, bool liftToNull, MethodInfo method)
        {
            if (method == null)
                return Expression.GetEqualityComparisonOperator(ExpressionType.Equal, "op_Equality", left, right, liftToNull);
            else
                return Expression.GetMethodBasedBinaryOperator(ExpressionType.Equal, left, right, method, liftToNull);
        }

    private static BinaryExpression GetEqualityComparisonOperator(ExpressionType binaryType, string opName, Expression left, Expression right, bool liftToNull)
    {
      if (left.Type == right.Type && (TypeUtils.IsNumeric(left.Type) || left.Type == typeof (object) || (TypeUtils.IsBool(left.Type) || TypeUtils.GetNonNullableType(left.Type).IsEnum)))
      {
        if (TypeUtils.IsNullableType(left.Type) && liftToNull)
          return (BinaryExpression) new SimpleBinaryExpression(binaryType, left, right, typeof (bool?));
        else
          return (BinaryExpression) new LogicalBinaryExpression(binaryType, left, right);
      }
      else
      {
        BinaryExpression definedBinaryOperator = Expression.GetUserDefinedBinaryOperator(binaryType, opName, left, right, liftToNull);
        if (definedBinaryOperator != null)
          return definedBinaryOperator;
        if (!TypeUtils.HasBuiltInEqualityOperator(left.Type, right.Type) && !Expression.IsNullComparison(left, right))
          throw Error.BinaryOperatorNotDefined((object) binaryType, (object) left.Type, (object) right.Type);
        if (TypeUtils.IsNullableType(left.Type) && liftToNull)
          return (BinaryExpression) new SimpleBinaryExpression(binaryType, left, right, typeof (bool?));
        else
          return (BinaryExpression) new LogicalBinaryExpression(binaryType, left, right);
      }
    }

*/

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.UnaryExpression"/> that represents a conversion operation for which the implementing method is specified.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.UnaryExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Convert"/> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand"/>, <see cref="P:System.Linq.Expressions.Expression.Type"/>, and <see cref="P:System.Linq.Expressions.UnaryExpression.Method"/> properties set to the specified values.
        /// </returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand"/> property equal to.</param><param name="type">A <see cref="T:System.Type"/> to set the <see cref="P:System.Linq.Expressions.Expression.Type"/> property equal to.</param><param name="method">A <see cref="T:System.Reflection.MethodInfo"/> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Method"/> property equal to.</param><exception cref="T:System.ArgumentNullException"><paramref name="expression"/> or <paramref name="type"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="method"/> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly one argument.</exception><exception cref="T:System.InvalidOperationException">No conversion operator is defined between <paramref name="expression"/>.Type and <paramref name="type"/>.-or-<paramref name="expression"/>.Type is not assignable to the argument type of the method represented by <paramref name="method"/>.-or-The return type of the method represented by <paramref name="method"/> is not assignable to <paramref name="type"/>.-or-<paramref name="expression"/>.Type or <paramref name="type"/> is a nullable value type and the corresponding non-nullable value type does not equal the argument type or the return type, respectively, of the method represented by <paramref name="method"/>.</exception><exception cref="T:System.Reflection.AmbiguousMatchException">More than one method that matches the <paramref name="method"/> description was found.</exception>
        public static UnaryExpression Convert(Expression expression, Type type, MethodInfo method)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.BinaryExpression"/> that represents an arithmetic addition operation that does not have overflow checking.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.BinaryExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Add"/> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left"/> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right"/> properties set to the specified values.
        /// </returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left"/> property equal to.</param><param name="right">A <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right"/> property equal to.</param><exception cref="T:System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception><exception cref="T:System.InvalidOperationException">The addition operator is not defined for <paramref name="left"/>.Type and <paramref name="right"/>.Type.</exception>
        public static BinaryExpression Add(Expression left, Expression right)
        {
            return Expression.Add(left, right, (MethodInfo)null);
        }

        /// <summary>
        /// Creates a <see cref="T:System.Linq.Expressions.BinaryExpression"/> that represents an arithmetic addition operation that does not have overflow checking. The implementing method can be specified.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Linq.Expressions.BinaryExpression"/> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType"/> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Add"/> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left"/>, <see cref="P:System.Linq.Expressions.BinaryExpression.Right"/> and <see cref="P:System.Linq.Expressions.BinaryExpression.Method"/> properties set to the specified values.
        /// </returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left"/> property equal to.</param><param name="right">A <see cref="T:System.Linq.Expressions.Expression"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right"/> property equal to.</param><param name="method">A <see cref="T:System.Reflection.MethodInfo"/> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method"/> property equal to.</param><exception cref="T:System.ArgumentNullException"><paramref name="left"/> or <paramref name="right"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="method"/> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception><exception cref="T:System.InvalidOperationException"><paramref name="method"/> is null and the addition operator is not defined for <paramref name="left"/>.Type and <paramref name="right"/>.Type.</exception>
        public static BinaryExpression Add(Expression left, Expression right, MethodInfo method)
        {
            return MakeBinary(ExpressionType.Add, left, right, false, method);
        }
    }

    public class Expression<TDelegate> : LambdaExpression
    {
        internal Expression(Expression body, string name, bool tailCall, ParameterExpression[] parameters) : base(typeof (TDelegate), name, body, tailCall, parameters)
        {
        }

        public override Expression Accept(ExpressionVisitor visitor)
        {
            return visitor.VisitLambda(this);
        }

        /// <summary>
        /// Produces a delegate that represents the lambda expression.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Delegate"/> that contains the compiled version of the lambda expression.
        /// </returns>
        public new TDelegate Compile()
        {
            var lambdaExpression = this;
            var lambda = Jsni.function(() =>
            {
                var evaluator = new Evaluator(lambdaExpression.Body);
                var index = 0;
                foreach (var parameter in lambdaExpression.Parameters)
                {
                    var value = Jsni.arguments().As<JsArray>()[index];
                    evaluator.AddArgument(parameter, value);
                    index++;
                }
                return evaluator.Evaluate().As<JsObject>();
            });
            return SpecialFunctions.CreateDelegate(null, typeof(TDelegate).thisType, lambda).As<TDelegate>();
        }
    }
}