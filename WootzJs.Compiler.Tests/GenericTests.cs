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

using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class GenericTests : TestFixture
    {
        [Test]
        public void TypeEqualsString()
        {
            AssertTrue(MethodTypeEqualsString<string>());
            AssertTrue(!MethodTypeEqualsString<int>());
        }
        
        [Test]
        public void GenericClasses()
        {
            var stringClass = new GenericClass<string>();
            var intClass = new GenericClass<int>();
            var simpleClass = new GenericClass<SimpleClass>();

            AssertEquals(stringClass.GetName(), "String");
            AssertEquals(intClass.GetName(), "Int32");
            AssertEquals(simpleClass.GetName(), "SimpleClass");
        }
        
        [Test]
        public void GenericClassStaticMethod()
        {
            AssertEquals(GenericClass<string>.GetUpperName(), "STRING");
            AssertEquals(GenericClass<int>.GetUpperName(), "INT32");
            AssertEquals(GenericClass<SimpleClass>.GetUpperName(), "SIMPLECLASS");
        }
        
        [Test]
        public void GenericOuterClassStaticMethod()
        {
            AssertEquals(GenericClass<string>.NestedClass.GetUpperName(), "STRING");
            AssertEquals(GenericClass<int>.NestedClass.GetUpperName(), "INT32");
            AssertEquals(GenericClass<SimpleClass>.NestedClass.GetUpperName(), "SIMPLECLASS");
        }
        
        [Test]
        public void TypeFunctionsAreCached()
        {
            AssertTrue(typeof(GenericClass<string>) == typeof(GenericClass<string>));
            AssertTrue(typeof(GenericClass<string>.NestedClass) == typeof(GenericClass<string>.NestedClass));
        }
        
        [Test]
        public void TopLevelGenericClasses()
        {
            var stringClass = new TopLevelGenericClass<string>();
            var intClass = new TopLevelGenericClass<int>();
            var simpleClass = new TopLevelGenericClass<SimpleClass>();

            AssertEquals(stringClass.GetName(), "String");
            AssertEquals(intClass.GetName(), "Int32");
            AssertEquals(simpleClass.GetName(), "SimpleClass");
        }
        
        [Test]
        public void TopLevelGenericClassStaticMethod()
        {
            AssertEquals(TopLevelGenericClass<string>.GetUpperName(), "STRING");
            AssertEquals(TopLevelGenericClass<int>.GetUpperName(), "INT32");
            AssertEquals(TopLevelGenericClass<SimpleClass>.GetUpperName(), "SIMPLECLASS");
        }
        
        [Test]
        public void TopLevelGenericOuterClassStaticMethod()
        {
            AssertEquals(TopLevelGenericClass<string>.NestedClass.GetUpperName(), "STRING");
            AssertEquals(TopLevelGenericClass<int>.NestedClass.GetUpperName(), "INT32");
            AssertEquals(TopLevelGenericClass<SimpleClass>.NestedClass.GetUpperName(), "SIMPLECLASS");
        }
        
        [Test]
        public void TopLevelTypeFunctionsAreCached()
        {
            AssertTrue(typeof(TopLevelGenericClass<string>) == typeof(TopLevelGenericClass<string>));
            AssertTrue(typeof(TopLevelGenericClass<string>.NestedClass) == typeof(TopLevelGenericClass<string>.NestedClass));
        }

        [Test]
        public void GenericClassWithStaticInitializedFieldIsInitialized()
        {
            AssertEquals(GenericClassWithStaticInitializedField<string>.Foo, "String");
        }

        [Test]
        public void SubStaticClassField()
        {
            AssertEquals(SubStaticClass.StaticField, "StaticField");
        }

        [Test]
        public void SubStaticClassMethod()
        {
            AssertEquals(SubStaticClass.StaticMethod(), "StaticMethod");
        }

        [Test]
        public void SubStaticClassProperty()
        {
            AssertEquals(SubStaticClass.StaticProperty, "StaticProperty");
        }
        
        [Test]
        public void SubGenericStaticClassField()
        {
            AssertEquals(SubGenericStaticClass<string>.StaticField, "StaticFieldString");
        }

        [Test]
        public void SubGenericStaticClassMethod()
        {
            AssertEquals(SubGenericStaticClass<string>.StaticMethod(), "StaticMethodString");
        }

        [Test]
        public void SubGenericStaticClassProperty()
        {
            AssertEquals(SubGenericStaticClass<string>.StaticProperty, "StaticPropertyString");
        }
        
        [Test]
        public void GenericTypeDefinition()
        {
            AssertEquals(typeof(GenericClass<string>).GetGenericTypeDefinition(), typeof(GenericClass<>));
        }

        [Test]
        public void TypeArguments()
        {
            var type = typeof(GenericClass<string>);
            var typeArgument = type.GenericTypeArguments[0];
            AssertEquals(typeArgument, typeof(string));
        }

        [Test]
        public void MakeGenericType()
        {
            var type = typeof(GenericClass<>);
            var stringType = type.MakeGenericType(typeof(string));
            var typeArg = stringType.GenericTypeArguments[0];
            AssertEquals(typeArg, typeof(string));
        }

        [Test]
        public void TypeParameterForMethod()
        {
            var method = typeof(ClassWithGenericMethod).GetMethod("GenericMethod");
            var parameter = method.GetParameters()[0];
            AssertEquals(parameter.ParameterType.Name, "T");
        }

        [Test]
        public void NewConstraint()
        {
            var simpleClass = CreateT<SimpleClass>();
            AssertEquals(simpleClass.GetType().Name, "SimpleClass");
        }

        public bool MethodTypeEqualsString<T>()
        {
            return typeof(T) == typeof(string);
        }

        public T CreateT<T>() where T : new()
        {
            return new T();
        }

        public class GenericClassWithStaticInitializedField<T>
        {
            public static string Foo = typeof(T).FullName;
        }

        public class GenericClass<T>
        {
            public string GetName()
            {
                return typeof(T).Name;
            }

            public static string GetUpperName()
            {
                return typeof(T).Name.ToUpper();
            }

            public class NestedClass
            {
                public static string GetUpperName()
                {
                    return typeof(T).Name.ToUpper();
                }
            }
        }

        public class ClassWithGenericMethod
        {
            public void GenericMethod<T>(T parameter)
            {
            }            
        }

        public class SimpleClass {}
    }

    public class TopLevelGenericClass<T>
    {
        public string GetName()
        {
            return typeof(T).Name;
        }

        public static string GetUpperName()
        {
            return typeof(T).Name.ToUpper();
        }

        public class NestedClass
        {
            public static string GetUpperName()
            {
                return typeof(T).Name.ToUpper();
            }
        }
    }

    public class BaseStaticClass
    {
        public static string StaticField = "StaticField";
        
        public static string StaticProperty { get; set; }

        public static string StaticMethod()
        {
            return "StaticMethod";
        }

        static BaseStaticClass()
        {
            StaticProperty = "StaticProperty";
        }
    }

    public class SubStaticClass : BaseStaticClass
    {
    }

    public class BaseGenericStaticClass<T>
    {
        public static string StaticField = "StaticField" + typeof(T).Name;
        
        public static string StaticProperty { get; set; }

        public static string StaticMethod()
        {
            return "StaticMethod" + typeof(T).Name;
        }

        static BaseGenericStaticClass()
        {
            StaticProperty = "StaticProperty" + typeof(T).Name;
        }
    }

    public class SubGenericStaticClass<T> : BaseGenericStaticClass<T>
    {
    }
}
