using System;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class TryTests
    {
        [Test]
        public void ExceptionCaught()
        {
            try
            {
                throw new Exception();
                QUnit.IsTrue(false);
            }
            catch (Exception e)
            {
                QUnit.IsTrue(true);
            }
        }
         
        [Test]
        public void FinallyExecuted()
        {
            bool success = false;
            try
            {
                try
                {
                    throw new Exception();
                }
                finally
                {
                    success = true;
                }
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception e)
            {
            }
            QUnit.IsTrue(success);
        }
         
        [Test]
        public void NakedCatchClause()
        {
            try
            {
                throw new Exception();
                QUnit.IsTrue(false);
            }
            catch 
            {
                QUnit.IsTrue(true);
            }
        }
/*
         
        [Js(Inline = true)]
        public void MultipleCatchClauses()
        {
            QUnit.RunTest("TryTests.MultipleCatchClauses", () =>
            {
                try
                {
                    throw new Exception();
                    QUnit.IsTrue(false);
                }
                catch 
                {
                    QUnit.IsTrue(true);
                }
           });
        }
*/
    }
}
