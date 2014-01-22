namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class DoWhileTests
    {
        [Test]
        public void DoWhile()
        {
            var i = 0;
            do
            {
                i++;
            } while (i < 5);

            QUnit.AreEqual(i, 5);
        }
    }
}