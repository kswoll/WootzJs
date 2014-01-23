using System;
using System.Linq.Expressions;
using System.Reflection;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class MemberExpressionTests
    {
        [Test]
        public void Property()
        {
            Expression<Func<ClassWithMembers, string>> lambda = x => x.StringProperty;
            var memberExpression = (MemberExpression)lambda.Body;
            QUnit.AreEqual(memberExpression.Expression, lambda.Parameters[0]);
            QUnit.IsTrue(memberExpression.Member is PropertyInfo);
            QUnit.AreEqual(memberExpression.Member.Name, "StringProperty");
        }
         
/*
 *  The x => x.IntField crashes the compiler, so fields are not supported for now.
        [JsMethod(GlobalCode = true)]
        public static void Field()
        {
            QUnit.RunTest("MemberExpressionTests.Field", () =>
            {
                Expression<Func<ClassWithMembers, int>> lambda = x => x.IntField;
                var memberExpression = (MemberExpression)lambda.Body;
                QUnit.AreEqual(memberExpression.Expression, lambda.Parameters[0]);
                QUnit.IsTrue(memberExpression.Member is FieldInfo);
                QUnit.AreEqual(memberExpression.Member.Name, "IntField");
            });
        }
*/

        public class ClassWithMembers
        {
            public string StringProperty { get; set; }
            public int IntField;
        }
    }
}