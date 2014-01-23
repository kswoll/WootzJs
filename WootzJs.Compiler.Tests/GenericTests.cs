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
        
        private bool MethodTypeEqualsString<T>()
        {
            return typeof(T) == typeof(string);
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
}
