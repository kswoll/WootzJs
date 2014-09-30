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
using System.Linq;
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Reflection
{
    public class AttributeTests : TestFixture
    {
        [Test]
        public void Method()
        {
            var method = typeof(TestClass).GetMethods().Single(x => x.Name == "Method");
            var attribute = (FooAttribute)method.GetCustomAttributes(typeof(FooAttribute), false)[0];
            AssertEquals(attribute.ConstructorValue, 1);
            AssertEquals(attribute.PropertyValue, "One");
        }

        [Test]
        public void Field()
        {
            var field1 = typeof(TestClass).GetFields().Single(x => x.Name == "Field1");
            var field2 = typeof(TestClass).GetFields().Single(x => x.Name == "Field2");
            var attribute1 = (FooAttribute)field1.GetCustomAttributes(typeof(FooAttribute), false)[0];
            var attribute2 = (FooAttribute)field2.GetCustomAttributes(typeof(FooAttribute), false)[0];
            AssertEquals(attribute1.ConstructorValue, 2);
            AssertEquals(attribute1.PropertyValue, "Two");
            AssertEquals(attribute2.ConstructorValue, 3);
        }

        [Test]
        public void Parameter()
        {
            var method = typeof(TestClass).GetMethods().Single(x => x.Name == "Parameter");
            var parameter1 = method.GetParameters()[0];
            var parameter2 = method.GetParameters()[1];
            var attribute1 = (FooAttribute)parameter1.GetCustomAttributes(typeof(FooAttribute), false)[0];
            var attribute2 = (FooAttribute)parameter2.GetCustomAttributes(typeof(FooAttribute), false)[0];
            AssertEquals(attribute1.ConstructorValue, 4);
            AssertEquals(attribute1.PropertyValue, "Four");
            AssertEquals(attribute2.ConstructorValue, 5);
            AssertEquals(attribute2.PropertyValue, "Five");
        }

        [Test]
        public void EnumMember()
        {
            var field = typeof(TestEnum).GetFields().Where(x => x.DeclaringType == typeof(TestEnum)).Single();
            var attribute = (FooAttribute)field.GetCustomAttributes(typeof(FooAttribute), false)[0];
            AssertEquals(attribute.ConstructorValue, 6);
            AssertEquals(attribute.PropertyValue, "Six");
        }

        public class FooAttribute : Attribute
        {
            public string PropertyValue { get; set; }

            private int constructorValue;

            public FooAttribute(int constructorValue)
            {
                this.constructorValue = constructorValue;
            }

            public int ConstructorValue
            {
                get { return constructorValue; }
            }
        }

        public class TestClass
        {
            [Foo(2, PropertyValue = "Two")]
            public object Field1;

            [Foo(3)]
            public object Field2;

            [Foo(1, PropertyValue = "One")]
            public void Method()
            {
            }

            public void Parameter([Foo(4, PropertyValue = "Four")]int parameter1, [Foo(5, PropertyValue = "Five")]string parameter2)
            {
            }
        }

        public enum TestEnum
        {
            [Foo(6, PropertyValue = "Six")]
            One
        }
    }
}
