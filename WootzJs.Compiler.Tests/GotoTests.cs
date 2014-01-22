namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class GotoTests
    {
        [Test]
        public void LabeledBreak()
        {
            int counter = 0;

            top:
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (i == 1)
                        goto top;
                    counter++;
                }
            }

            QUnit.AreEqual(counter, 6);
        }
    }
}