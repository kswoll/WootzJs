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
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class FieldTests
    {
        [Test]
        public void FieldsDoNotCollide()
        {
            var subClass = new SubClass();
            subClass.GetFoo1().AssertEquals("base");
            subClass.GetFoo2().AssertEquals("sub");
        }

        [Test]
        public void StaticFieldsAreStatic()
        {
            StaticFieldClass.MyField = "foo";
            StaticFieldClass.MyField.AssertEquals("foo");
        }

        [Test]
        public void ReferencedField()
        {
            var reference = new ReferenceClass();
            reference.Target = new TargetClass();
            reference.Target.Foo = "foo";

            reference.Target.Foo.AssertEquals("foo");
        }

        [Test]
        public void PrimitiveFields()
        {
            var primitiveFields = new PrimitiveFieldsClass();
            primitiveFields.Boolean.AssertEquals(false);
            primitiveFields.Byte.AssertEquals(0);
            primitiveFields.SByte.AssertEquals(0);
            primitiveFields.Short.AssertEquals(0);
            primitiveFields.UShort.AssertEquals(0);
            primitiveFields.Int.AssertEquals(0);
            primitiveFields.UInt.AssertEquals(0);
            primitiveFields.Long.AssertEquals(0);
            primitiveFields.ULong.AssertEquals(0);
            primitiveFields.Enum.AssertEquals(0);
        }

        [Test]
        public void ConstField()
        {
            var value = ConstFieldClass.MyString;
            value.AssertEquals("foo");
        }

        public class StaticFieldClass
        {
            public static string MyField;
        }

        public class ConstFieldClass
        {
            public const string MyString = "foo";
        }

        public class BaseClass : Object
        {
            private string foo;

            public BaseClass()
            {
                foo = "base";
            }

            public string GetFoo1()
            {
                return foo;
            }
        }

        public class SubClass : BaseClass
        {
            private string foo;

            public SubClass()
            {
                System.Runtime.CompilerServices.ExtensionAttribute x = null;
                foo = "sub";
            }

            public string GetFoo2()
            {
                GetFoo1();
                return foo;
            }
        }

        public class ReferenceClass
        {
            public TargetClass Target { get; set; }
        }

        public class TargetClass
        {
            public string Foo { get; set; }
        }

        public class PrimitiveFieldsClass
        {
            public bool Boolean;
            public byte Byte;
            public short Short;
            public int Int;
            public long Long;
            public sbyte SByte;
            public ushort UShort;
            public uint UInt;
            public ulong ULong;
            public TestEnum Enum;
        }

        public enum TestEnum {}
    }
}
