using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    public class ConditionalExpressionTests
    {
        [Test]
        public static void Conditional()
        {
            Expression<Func<bool, string>> lambda = x => x ? "yes" : "no";
            var conditional = (ConditionalExpression)lambda.Body;

            QUnit.AreEqual(conditional.Test, lambda.Parameters[0]);

            var ifTrue = (ConstantExpression)conditional.IfTrue;
            var ifFalse = (ConstantExpression)conditional.IfFalse;

            QUnit.AreEqual(ifTrue.Value, "yes");
            QUnit.AreEqual(ifFalse.Value, "no");
        }
    }
}