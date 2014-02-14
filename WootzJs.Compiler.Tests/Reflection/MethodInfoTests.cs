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
using System.Linq;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class MethodInfoTests
    {
        [Test]
        public void Name()
        {
            var methods = typeof(MethodClass).GetMethods();
            var method = methods.Single(x => x.Name == "VoidMethod");
            QUnit.IsTrue(true);
        }

        [Test]
        public void InvokeInstanceMethod()
        {
            var methods = typeof(MethodClass).GetMethods();
            var method = methods.Single(x => x.Name == "InstanceMethod");
            var instance = new MethodClass();
            var result = (string)method.Invoke(instance, new object[0]);
            QUnit.AreEqual(result, "InstanceMethod");
        }

        [Test]
        public void NameForOverload()
        {
            var method = typeof(MethodClass).GetMethod("Overload", new[] { typeof(int) });
            QUnit.AreEqual(method.GetParameters()[0].ParameterType, typeof(int));

            method = typeof(MethodClass).GetMethod("Overload", new[] { typeof(string) });
            QUnit.AreEqual(method.GetParameters()[0].ParameterType, typeof(string));
        }

        public class MethodClass
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
        }
    }
}
