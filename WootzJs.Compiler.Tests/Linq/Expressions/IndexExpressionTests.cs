using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class IndexExpressionTests
    {
        [Test]
        public void IndexIntoList()
        {
            var list = new List<int> { 1, 2 };
            Expression<Func<int>> lambda = () => list[1];
            var callExpression = (IndexExpression)lambda.Body;
            var target = (ConstantExpression)callExpression.Object;
            QUnit.AreEqual(target.Value, list);
            var index = (ConstantExpression)callExpression.Arguments[0];
            QUnit.AreEqual(index.Value, 1);
        }         

        [Test]
        public void IndexIntoDictionary()
        {
            var dictionary = new Dictionary<int, string> { { 1, "foo" }, { 2, "bar" } };
            Expression<Func<string>> lambda = () => dictionary[1];
            var callExpression = (IndexExpression)lambda.Body;
            var target = (ConstantExpression)callExpression.Object;
            QUnit.AreEqual(target.Value, dictionary);
            var index = (ConstantExpression)callExpression.Arguments[0];
            QUnit.AreEqual(index.Value, 1);
        }         
    }
}