namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class OperatorOverloadTests
    {
        [Test]
        public void Add()
        {
            var three = new IntValue(3);
            var five = new IntValue(5);
            var threePlusFive = three + five;
            QUnit.AreEqual(threePlusFive.Value, 8);
        }

        public class IntValue
        {
            public int Value { get; private set; }

            public IntValue(int value)
            {
                Value = value;
            }

            public static IntValue operator +(IntValue left, IntValue right)
            {
                return new IntValue(left.Value + right.Value);
            }
        }
    }
}
