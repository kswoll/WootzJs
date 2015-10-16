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
using System.Runtime.WootzJs;
using System.Linq;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Reflection
{
    public class MethodInfoTests : TestFixture
    {
        [Test]
        public void Name()
        {
            var methods = typeof(MethodClass).GetMethods();
            var method = methods.Single(x => x.Name == "VoidMethod");
            AssertTrue(true);
        }

        [Test]
        public void InvokeInstanceMethod()
        {
            var methods = typeof(MethodClass).GetMethods();
            var method = methods.Single(x => x.Name == "InstanceMethod");
            var instance = new MethodClass();
            var result = (string)method.Invoke(instance, new object[0]);
            AssertEquals(result, "InstanceMethod");
        }

        [Test]
        public void InvokeStaticMethod()
        {
            var methods = typeof(MethodClass).GetMethods();
            var method = methods.Single(x => x.Name == "StaticMethod");
            var result = (string)method.Invoke(null, new object[0]);
            AssertEquals(result, "StaticMethod");
        }

        [Test]
        public void InvokeInterfaceMethod()
        {
            var methods = typeof(IMethodClass).GetMethods();
            var method = methods.Single(x => x.Name == "InstanceMethod");
            var instance = new MethodClass();
            var result = (string)method.Invoke(instance, new object[0]);
            AssertEquals(result, "InstanceMethod");
        }

        [Test]
        public void NameForOverload()
        {
            var method = typeof(MethodClass).GetMethod("Overload", new[] { typeof(int) });
            AssertEquals(method.GetParameters()[0].ParameterType, typeof(int));

            method = typeof(MethodClass).GetMethod("Overload", new[] { typeof(string) });
            AssertEquals(method.GetParameters()[0].ParameterType, typeof(string));
        }

        [Test]
        public void GenericParameter()
        {
            var method = typeof(MethodClass).GetMethod("MethodWithDictionary");
            var parameter = method.GetParameters()[0];
            AssertEquals(parameter.ParameterType, typeof(IDictionary<string, int>));
        }

        [Test]
        public void GenericReturnType()
        {
            var method = typeof(MethodClass).GetMethod("GenericReturnType");
            var returnType = method.ReturnType;
            AssertEquals(returnType, typeof(List<string>));            
        }

        [Test]
        public void GenericMethod()
        {
            var method = typeof(GenericMethodClass<string, int>).GetMethod("Foo");
            AssertEquals(method.ReturnType.FullName, "String");
            AssertEquals(method.GetParameters()[0].ParameterType.FullName, "System.Int32");
        }

        [Test]
        public void NestedGenericProperty()
        {
            var property = typeof(NestedGenericMethodClass<string, int>).GetProperty("Property");
            AssertEquals(property.PropertyType.GenericTypeArguments[0].Name, "String");
            AssertEquals(property.PropertyType.GenericTypeArguments[1].FullName, "System.Int32");
        }

        [Test]
        public void SubClassIncludesBaseClassMethods()
        {
            var type = typeof(SubClass);
            var methods = type.GetMethods().Where(x => x.DeclaringType != typeof(object)).ToArray();
            AssertEquals(methods.Length, 2);
        }

        public class GenericMethodClass<T, U>
        {
            public T Foo(U arg)
            {
                return default(T);
            }
        }

        public class NestedGenericMethodClass<T, U>
        {
            public GenericMethodClass<T, U> Property { get; set; }
        }

        public interface IMethodClass
        {
            string InstanceMethod();
        }

        public class MethodClass : IMethodClass
        {
            public void VoidMethod()
            {
            }

            public string InstanceMethod()
            {
                return "InstanceMethod";
            }

            public static string StaticMethod()
            {
                return "StaticMethod";
            }

            private string PrivateMethod()
            {
                return "PrivateMethod";
            }

            internal string InternalMethod()
            {
                return "InternalMethod";
            }

            protected string ProtectedMethod()
            {
                return "ProtectedMethod";
            }

            public string Overload(int i)
            {
                return "int: " + i;
            }

            public string Overload(string s)
            {
                return "string: " + s;
            }

            public static void MethodWithDictionary(IDictionary<string, int> dict)
            {
            }

            public static List<string> GenericReturnType()
            {
                return null;
            }
        }

        public class BaseClass
        {
            public void BaseClassMethod() {}
        }

        public class SubClass : BaseClass
        {
            public void SubClassMethod() {}
        }
    }
}
