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
using System.Linq;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Reflection
{
    public class PropertyInfoTests : TestFixture
    {
        [Test]
        public void Name()
        {
            var properties = typeof(PropertyClass).GetProperties();
            var staticProperty = properties.Single(x => x.Name == "StaticProperty");
            var stringProperty = properties.Single(x => x.Name == "StringProperty");

            AssertEquals(staticProperty.Name, "StaticProperty");
            AssertEquals(stringProperty.Name, "StringProperty");
        }

        [Test]
        public void PropertyType()
        {
            var property = typeof(PropertyClass).GetProperty("StaticProperty");
            AssertEquals(property.PropertyType.Name, "String");
        }

        [Test]
        public void GenericProperty()
        {
            var property = typeof(GenericPropertyClass<string>).GetProperty("Property");
            AssertEquals(property.PropertyType.FullName, "String");
        }

        [Test]
        public void NestedGenericProperty()
        {
            var property = typeof(NestedGenericPropertyClass<string>).GetProperty("Property");
            AssertEquals(property.PropertyType.GenericTypeArguments[0].Name, "String");
        }

        [Test]
        public void GenericArrayProperty()
        {
            var property = typeof(GenericArrayPropertyClass<string>).GetProperty("Rows");
            AssertEquals(property.PropertyType.GetElementType().Name, "String");
        }

        [Test]
        public void GenericClassWithListOther()
        {
            var type = typeof(GenericClassWithListOtherClass<string>);
            var property = type.GetProperty("TheList");
            var propertyListType = property.PropertyType.GetGenericArguments()[0];
            AssertEquals(propertyListType, typeof(PropertyClass));
        }

        [Test]
        public void SubClassIncludesBaseClassProperties()
        {
            var type = typeof(SubClass);
            var properties = type.GetProperties();
            AssertEquals(properties.Length, 2);
        }

        public class PropertyClass
        {
            public static string StaticProperty { get; set; }
            public string StringProperty { get; set; }
        }

        public class GenericPropertyClass<T>
        {
            public T Property { get; set; }
        }

        public class NestedGenericPropertyClass<T>
        {
            public GenericPropertyClass<T> Property { get; set; }
        }

        public class GenericArrayPropertyClass<T>
        {
            public T[] Rows { get; set; }
        }

        public class GenericClassWithListOtherClass<T>
        {
            public T Value { get; set; }
            public List<PropertyClass> TheList { get; set; }
        }

        public class BaseClass
        {
            public string BaseClassProperty { get; set; }
        }

        public class SubClass : BaseClass
        {
            public string SubClassProeprty { get; set; }
        }
    }
}
