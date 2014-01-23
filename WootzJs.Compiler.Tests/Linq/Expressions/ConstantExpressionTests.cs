using System;
using System.Linq.Expressions;

namespace WootzJs.Compiler.Tests.Linq.Expressions
{
    [TestFixture]
    public class ConstantExpressionTests
    {
        [Test]
        public void LocalClosedVariable()
        {
            var s = "foo";              // This variable is being closed and should result in a 
                                        // ConstantExpression when constructing the expression
                                        // tree since it's value is known at that time.
            Expression<Func<string, string>> lambda = x => s;
            var constantExpression = (ConstantExpression)lambda.Body;
            QUnit.AreEqual(constantExpression.Value, "foo");            
        }

        [Test]
        public void Integer()
        {
            Expression<Func<string, int>> lambda = x => 5;
            var constantExpression = (ConstantExpression)lambda.Body;
            QUnit.AreEqual(constantExpression.Value, 5);
        }

        [Test]
        public void Float()
        {
            Expression<Func<string, float>> lambda = x => 5.4f;
            var constantExpression = (ConstantExpression)lambda.Body;
            QUnit.AreEqual(constantExpression.Value, 5.4);
        }

        [Test]
        public void Double()
        {
            Expression<Func<string, double>> lambda = x => 3.40282347E+40;
            var constantExpression = (ConstantExpression)lambda.Body;
            QUnit.AreEqual(constantExpression.Value, 3.40282347E+40);
        }
         
        [Test]
        public void String()
        {
            Expression<Func<string, string>> lambda = x => "foo";
            var constantExpression = (ConstantExpression)lambda.Body;
            QUnit.AreEqual(constantExpression.Value, "foo");                
        }
         
        [Test]
        public void Boolean()
        {
            Expression<Func<string, bool>> lambda = x => true;
            var constantExpression = (ConstantExpression)lambda.Body;
            QUnit.AreEqual(constantExpression.Value, true);                
        }
    }
}