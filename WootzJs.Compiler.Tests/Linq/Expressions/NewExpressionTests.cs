using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class NewExpressionTests 
    {
        [Test]
        public void ConstructorNoArgsOrInitializers()
        {
            Expression<Func<CreateClass>> lambda = () => new CreateClass();
            var newExpression = (NewExpression)lambda.Body;
            QUnit.AreEqual(newExpression.Type.FullName, typeof(CreateClass).FullName);
        }
        
        [Test]
        public void ConstructorOneArgNoInitializers()
        {
            Expression<Func<CreateClass>> lambda = () => new CreateClass("foo");
            var newExpression = (NewExpression)lambda.Body;
            QUnit.AreEqual(newExpression.Type.FullName, typeof(CreateClass).FullName);

            var arg = (ConstantExpression)newExpression.Arguments[0];
            QUnit.AreEqual(arg.Value, "foo");
        }
        
        public class CreateClass
        {
            public string StringProperty { get; set; }

            public CreateClass()
            {
            }

            public CreateClass(string stringProperty)
            {
                StringProperty = stringProperty;
            }
        }
    }
}