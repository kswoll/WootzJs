using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class MemberInitExpressionTests
    {
        [Test]
        public void ConstructorNoArgOneInitializer()
        {
            Expression<Func<CreateClass>> lambda = () => new CreateClass { StringProperty = "foo" };
            var memberInitExpression = (MemberInitExpression)lambda.Body;
            var newExpression = memberInitExpression.NewExpression;
            QUnit.AreEqual(newExpression.Type.FullName, typeof(CreateClass).FullName);

            var binding = (MemberAssignment)memberInitExpression.Bindings[0];
            var value = (ConstantExpression)binding.Expression;
            QUnit.AreEqual(value.Value, "foo");
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