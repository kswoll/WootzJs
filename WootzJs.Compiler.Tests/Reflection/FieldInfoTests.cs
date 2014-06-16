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
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class FieldInfoTests
    {
        [Test]
        public void Name()
        {
            var type = typeof(FieldClass);
            var fields = type.GetFields();
            var stringField = fields.Single(x => x.Name == "StringField");
            var intField = fields.Single(x => x.Name == "IntField");
            var staticField = fields.Single(x => x.Name == "StaticField");
            var protectedField = fields.Single(x => x.Name == "ProtectedField");
            var privateField = fields.Single(x => x.Name == "PrivateField");
            var internalField = fields.Single(x => x.Name == "InternalField");
            Assert.AssertEquals(stringField.Name, "StringField");
            Assert.AssertEquals(intField.Name, "IntField");
            Assert.AssertEquals(staticField.Name, "StaticField");
            Assert.AssertEquals(protectedField.Name, "ProtectedField");
            Assert.AssertEquals(privateField.Name, "PrivateField");
            Assert.AssertEquals(internalField.Name, "InternalField");
        }                  
         
        [Test]
        public void Visibility()
        {
            var type = typeof(FieldClass);
            var fields = type.GetFields();
            var stringField = fields.Single(x => x.Name == "StringField");
            var intField = fields.Single(x => x.Name == "IntField");
            var staticField = fields.Single(x => x.Name == "StaticField");
            var protectedField = fields.Single(x => x.Name == "ProtectedField");
            var privateField = fields.Single(x => x.Name == "PrivateField");
            var internalField = fields.Single(x => x.Name == "InternalField");
            var protectedInternalField = fields.Single(x => x.Name == "ProtectedInternalField");
            var readonlyField = fields.Single(x => x.Name == "ReadonlyField");
            var constantField = fields.Single(x => x.Name == "ConstantField");
            Assert.AssertTrue(stringField.IsPublic);
            Assert.AssertTrue(intField.IsPublic);
            Assert.AssertTrue(staticField.IsPublic);
            Assert.AssertTrue(staticField.IsStatic);
            Assert.AssertTrue(protectedField.IsFamily);
            Assert.AssertTrue(!protectedField.IsPublic);
            Assert.AssertTrue(privateField.IsPrivate);
            Assert.AssertTrue(!privateField.IsPublic);
            Assert.AssertTrue(internalField.IsAssembly);
            Assert.AssertTrue(!internalField.IsPublic);
            Assert.AssertTrue(!protectedInternalField.IsPublic);
            Assert.AssertTrue(protectedInternalField.IsFamilyOrAssembly);
            Assert.AssertTrue(readonlyField.IsInitOnly);
            Assert.AssertTrue(constantField.IsLiteral);
        }                  
         
        [Test]
        public void ConstantValue()
        {
            var type = typeof(FieldClass);
            var fields = type.GetFields();
            var constantField = fields.Single(x => x.Name == "ConstantField");
            var constantValue = constantField.GetRawConstantValue();
            Assert.AssertEquals(constantValue, "foo");
        }                  
         
        [Test]
        public void GetValue()
        {
            var o = new FieldClass();
            var type = o.GetType();
            var fields = type.GetFields();
            var stringField = fields.Single(x => x.Name == "StringField");
            var staticField = fields.Single(x => x.Name == "StaticField");
                
            var stringFieldValue = stringField.GetValue(o);
            Assert.AssertEquals(stringFieldValue, "bar");

            var staticFieldValue = staticField.GetValue(null);
            Assert.AssertEquals(staticFieldValue, "foobar");
        }                  
         
        [Test]
        public void SetValue()
        {
            var o = new FieldClass();
            var type = o.GetType();
            var fields = type.GetFields();
            var stringField = fields.Single(x => x.Name == "StringField");
            var staticField = fields.Single(x => x.Name == "StaticField");
                
            stringField.SetValue(o, "bar2");
            staticField.SetValue(o, "foobar2");

            var stringFieldValue = stringField.GetValue(o);
            Assert.AssertEquals(stringFieldValue, "bar2");

            var staticFieldValue = staticField.GetValue(null);
            Assert.AssertEquals(staticFieldValue, "foobar2");
        }                  
         
        public class FieldClass
        {
            public string StringField = "bar";
            public int IntField;
            public static string StaticField = "foobar";
            protected bool ProtectedField;
            private FieldClass PrivateField;
            internal string InternalField;
            protected internal string ProtectedInternalField;
            public readonly string ReadonlyField;
            public const string ConstantField = "foo";
        }
    }
}
