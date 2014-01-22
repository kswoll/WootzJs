using System;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class TypeTests
    {
        [Test]
        public void FullName()
        {
            var type = typeof(TestClass);
            QUnit.AreEqual(type.FullName, "WootzJs.Compiler.Tests.TypeTests.TestClass");
        }                  

        [Test]
        public void InnerClassName()
        {
            var type = typeof(ClassWithInnerClass.InnerClass);
            QUnit.AreEqual(type.Name, "InnerClass");
        }                  

        [Test]
        public void BaseType()
        {
            var type = typeof(SubClass);
            QUnit.AreEqual(type.FullName, "WootzJs.Compiler.Tests.TypeTests.SubClass");
            QUnit.AreEqual(type.BaseType.FullName, "WootzJs.Compiler.Tests.TypeTests.TestClass");
        }                  

        [Test]
        public void IsAssignableFrom()
        {
            var subClass = typeof(SubClass);
            var baseClass = typeof(TestClass);
            QUnit.IsTrue(baseClass.IsAssignableFrom(subClass));
        }                  

        [Test]
        public void IsInstanceOfType()
        {
            var subClass = new SubClass();
            var baseClass = typeof(TestClass);
            QUnit.IsTrue(baseClass.IsInstanceOfType(subClass));
        }                  

        [Test]
        public void GetFields()
        {
            var fields = typeof(FieldsClass).GetFields();
            QUnit.AreEqual(fields.Length, 1);
            var field = fields[0];
            QUnit.AreEqual(field.Name, "MyString");
        }        
        
        [Test]
        public void GetTypeByName()
        {
            var type = Type.GetType("WootzJs.Compiler.Tests.TypeTests.TestClass");
            QUnit.IsTrue(type != null);
        }

        public class TestClass
        {
        }

        public class SubClass : TestClass
        {
        }

        public class FieldsClass
        {
            public string MyString;
        }

        public class ClassWithInnerClass
        {
            public class InnerClass
            {
            }
        }
    }
}
