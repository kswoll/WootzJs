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
    public class FieldTests : TestFixture
    {
        [Test]
        public void FieldsDoNotCollide()
        {
            var subClass = new SubClass();
            AssertEquals(subClass.GetFoo1(), "base");
            AssertEquals(subClass.GetFoo2(), "sub");
        }

        [Test]
        public void StaticFieldsAreStatic()
        {
            StaticFieldClass.MyField = "foo";
            AssertEquals(StaticFieldClass.MyField, "foo");
        }

        [Test]
        public void ReferencedField()
        {
            var reference = new ReferenceClass();
            reference.Target = new TargetClass();
            reference.Target.Foo = "foo";

            AssertEquals(reference.Target.Foo, "foo");
        }

        [Test]
        public void PrimitiveFields()
        {
            var primitiveFields = new PrimitiveFieldsClass();
            AssertEquals(primitiveFields.Boolean, false);
            AssertEquals(primitiveFields.Byte, 0);
            AssertEquals(primitiveFields.SByte, 0);
            AssertEquals(primitiveFields.Short, 0);
            AssertEquals(primitiveFields.UShort, 0);
            AssertEquals(primitiveFields.Int, 0);
            AssertEquals(primitiveFields.UInt, 0);
            AssertEquals(primitiveFields.Long, 0);
            AssertEquals(primitiveFields.ULong, 0);
            AssertTrue(primitiveFields.Enum == 0);
            AssertEquals(primitiveFields.Enum, TestEnum.Value1);
        }

        [Test]
        public void ConstField()
        {
            var value = ConstFieldClass.MyString;
            AssertEquals(value, "foo");
        }

        [Test]
        public void EnumAsStaticFieldIsInitializedToDefaultValue()
        {
            AssertTrue(StaticFieldClass.MyTestEnum == 0);
            AssertEquals(StaticFieldClass.MyTestEnum, TestEnum.Value1);
        }

        public class StaticFieldClass
        {
            public static string MyField;
            public static TestEnum MyTestEnum;
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

        public enum TestEnum
        {
            Value1, Value2
        }
    }
}
