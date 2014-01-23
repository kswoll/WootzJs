using System.Linq;
using System.Runtime.WootzJs;

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
            QUnit.AreEqual(stringField.Name, "StringField");
            QUnit.AreEqual(intField.Name, "IntField");
            QUnit.AreEqual(staticField.Name, "StaticField");
            QUnit.AreEqual(protectedField.Name, "ProtectedField");
            QUnit.AreEqual(privateField.Name, "PrivateField");
            QUnit.AreEqual(internalField.Name, "InternalField");
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
            QUnit.IsTrue(stringField.IsPublic);
            QUnit.IsTrue(intField.IsPublic);
            QUnit.IsTrue(staticField.IsPublic);
            QUnit.IsTrue(staticField.IsStatic);
            QUnit.IsTrue(protectedField.IsFamily);
            QUnit.IsTrue(!protectedField.IsPublic);
            QUnit.IsTrue(privateField.IsPrivate);
            QUnit.IsTrue(!privateField.IsPublic);
            QUnit.IsTrue(internalField.IsAssembly);
            QUnit.IsTrue(!internalField.IsPublic);
            QUnit.IsTrue(!protectedInternalField.IsPublic);
            QUnit.IsTrue(protectedInternalField.IsFamilyOrAssembly);
            QUnit.IsTrue(readonlyField.IsInitOnly);
            QUnit.IsTrue(constantField.IsLiteral);
        }                  
         
        [Test]
        public void ConstantValue()
        {
            var type = typeof(FieldClass);
            var fields = type.GetFields();
            var constantField = fields.Single(x => x.Name == "ConstantField");
            var constantValue = constantField.GetRawConstantValue();
            QUnit.AreEqual(constantValue, "foo");
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
            QUnit.AreEqual(stringFieldValue, "bar");

            var staticFieldValue = staticField.GetValue(null);
            QUnit.AreEqual(staticFieldValue, "foobar");
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
            QUnit.AreEqual(stringFieldValue, "bar2");

            var staticFieldValue = staticField.GetValue(null);
            QUnit.AreEqual(staticFieldValue, "foobar2");
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
