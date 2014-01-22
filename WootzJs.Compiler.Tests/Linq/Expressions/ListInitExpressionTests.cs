using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class ListInitExpressionTests
    {
        [Test]
        public void ListWithInitializer()
        {
            Expression<Func<List<string>>> lambda = () => new List<string> { "foo" };
            var listInitExpression = (ListInitExpression)lambda.Body;
            var newExpression = listInitExpression.NewExpression;
            QUnit.AreEqual(newExpression.Type.FullName, typeof(List<string>).FullName);

            var binding = listInitExpression.Initializers[0];
            var value = (ConstantExpression)binding.Arguments[0];
            QUnit.AreEqual(value.Value, "foo");
        }

        [Test]
        public void ListWithInitializerTwoElements()
        {
            Expression<Func<List<string>>> lambda = () => new List<string> { "foo", "bar" };
            var listInitExpression = (ListInitExpression)lambda.Body;
            var newExpression = listInitExpression.NewExpression;
            QUnit.AreEqual(newExpression.Type.FullName, typeof(List<string>).FullName);

            var binding1 = listInitExpression.Initializers[0];
            var binding2 = listInitExpression.Initializers[1];
            var value1 = (ConstantExpression)binding1.Arguments[0];
            var value2 = (ConstantExpression)binding2.Arguments[0];
            QUnit.AreEqual(value1.Value, "foo");
            QUnit.AreEqual(value2.Value, "bar");
        }
        
        [Test]
        public void DictionaryWithInitializer()
        {
            Expression<Func<Dictionary<string, int>>> lambda = () => new Dictionary<string, int> { { "foo", 5 } };
            var listInitExpression = (ListInitExpression)lambda.Body;
            var newExpression = listInitExpression.NewExpression;
            QUnit.AreEqual(newExpression.Type.FullName, typeof(Dictionary<string, int>).FullName);

            var binding = listInitExpression.Initializers[0];
            var key = (ConstantExpression)binding.Arguments[0];
            var value = (ConstantExpression)binding.Arguments[1];
            QUnit.AreEqual(key.Value, "foo");
            QUnit.AreEqual(value.Value, 5);
        }
    }
}