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

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class GenericTests
    {
        [Test]
        public void TypeEqualsString()
        {
            QUnit.IsTrue(MethodTypeEqualsString<string>());
            QUnit.IsTrue(!MethodTypeEqualsString<int>());
        }
        
        [Test]
        public void GenericClasses()
        {
            var stringClass = new GenericClass<string>();
            var intClass = new GenericClass<int>();
            var simpleClass = new GenericClass<SimpleClass>();

            QUnit.AreEqual(stringClass.GetName(), "String");
            QUnit.AreEqual(intClass.GetName(), "Int32");
            QUnit.AreEqual(simpleClass.GetName(), "SimpleClass");
        }
        
        [Test]
        public void GenericClassStaticMethod()
        {
            QUnit.AreEqual(GenericClass<string>.GetUpperName(), "STRING");
            QUnit.AreEqual(GenericClass<int>.GetUpperName(), "INT32");
            QUnit.AreEqual(GenericClass<SimpleClass>.GetUpperName(), "SIMPLECLASS");
        }
        
        [Test]
        public void GenericOuterClassStaticMethod()
        {
            QUnit.AreEqual(GenericClass<string>.NestedClass.GetUpperName(), "STRING");
            QUnit.AreEqual(GenericClass<int>.NestedClass.GetUpperName(), "INT32");
            QUnit.AreEqual(GenericClass<SimpleClass>.NestedClass.GetUpperName(), "SIMPLECLASS");
        }
        
        [Test]
        public void TypeFunctionsAreCached()
        {
            QUnit.IsTrue(typeof(GenericClass<string>) == typeof(GenericClass<string>));
            QUnit.IsTrue(typeof(GenericClass<string>.NestedClass) == typeof(GenericClass<string>.NestedClass));
        }
        
        [Test]
        public void TopLevelGenericClasses()
        {
            var stringClass = new TopLevelGenericClass<string>();
            var intClass = new TopLevelGenericClass<int>();
            var simpleClass = new TopLevelGenericClass<SimpleClass>();

            QUnit.AreEqual(stringClass.GetName(), "String");
            QUnit.AreEqual(intClass.GetName(), "Int32");
            QUnit.AreEqual(simpleClass.GetName(), "SimpleClass");
        }
        
        [Test]
        public void TopLevelGenericClassStaticMethod()
        {
            QUnit.AreEqual(TopLevelGenericClass<string>.GetUpperName(), "STRING");
            QUnit.AreEqual(TopLevelGenericClass<int>.GetUpperName(), "INT32");
            QUnit.AreEqual(TopLevelGenericClass<SimpleClass>.GetUpperName(), "SIMPLECLASS");
        }
        
        [Test]
        public void TopLevelGenericOuterClassStaticMethod()
        {
            QUnit.AreEqual(TopLevelGenericClass<string>.NestedClass.GetUpperName(), "STRING");
            QUnit.AreEqual(TopLevelGenericClass<int>.NestedClass.GetUpperName(), "INT32");
            QUnit.AreEqual(TopLevelGenericClass<SimpleClass>.NestedClass.GetUpperName(), "SIMPLECLASS");
        }
        
        [Test]
        public void TopLevelTypeFunctionsAreCached()
        {
            QUnit.IsTrue(typeof(TopLevelGenericClass<string>) == typeof(TopLevelGenericClass<string>));
            QUnit.IsTrue(typeof(TopLevelGenericClass<string>.NestedClass) == typeof(TopLevelGenericClass<string>.NestedClass));
        }

        [Test]
        public void GenericClassWithStaticInitializedFieldIsInitialized()
        {
            QUnit.AreEqual(GenericClassWithStaticInitializedField<string>.Foo, "String");
        }

        [Test]
        public void SubStaticClassField()
        {
            QUnit.AreEqual(SubStaticClass.StaticField, "StaticField");
        }

        [Test]
        public void SubStaticClassMethod()
        {
            QUnit.AreEqual(SubStaticClass.StaticMethod(), "StaticMethod");
        }

        [Test]
        public void SubStaticClassProperty()
        {
            QUnit.AreEqual(SubStaticClass.StaticProperty, "StaticProperty");
        }
        
        [Test]
        public void SubGenericStaticClassField()
        {
            QUnit.AreEqual(SubGenericStaticClass<string>.StaticField, "StaticFieldString");
        }

        [Test]
        public void SubGenericStaticClassMethod()
        {
            QUnit.AreEqual(SubGenericStaticClass<string>.StaticMethod(), "StaticMethodString");
        }

        [Test]
        public void SubGenericStaticClassProperty()
        {
            QUnit.AreEqual(SubGenericStaticClass<string>.StaticProperty, "StaticPropertyString");
        }
        
        [Test]
        public void GenericTypeDefinition()
        {
            QUnit.AreEqual(typeof(GenericClass<string>).GetGenericTypeDefinition(), typeof(GenericClass<>));
        }

        [Test]
        public void TypeArguments()
        {
            var type = typeof(GenericClass<string>);
            var typeArgument = type.GenericTypeArguments[0];
            QUnit.AreEqual(typeArgument, typeof(string));
        }

        [Test]
        public void MakeGenericType()
        {
            var type = typeof(GenericClass<>);
            var stringType = type.MakeGenericType(typeof(string));
            var typeArg = stringType.GenericTypeArguments[0];
            QUnit.AreEqual(typeArg, typeof(string));
        }

        [Test]
        public void TypeParameterForMethod()
        {
            var method = typeof(ClassWithGenericMethod).GetMethod("GenericMethod");
            var parameter = method.GetParameters()[0];
            QUnit.AreEqual(parameter.ParameterType.Name, "T");
        }

        [Test]
        public void NewConstraint()
        {
            var simpleClass = CreateT<SimpleClass>();
            QUnit.AreEqual(simpleClass.GetType().Name, "SimpleClass");
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
