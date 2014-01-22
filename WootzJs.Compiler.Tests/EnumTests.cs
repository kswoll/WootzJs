using System;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class EnumTests
    {
        [Test]
        public void Name()
        {
            var s = TestEnum.One.ToString();
            QUnit.AreEqual(s, "One");
        }
         
        [Test]
        public void Value()
        {
            QUnit.AreEqual((int)TestEnum.One, 0);
            QUnit.AreEqual((int)TestEnum.Two, 1);
            QUnit.AreEqual((int)TestEnum.Three, 2);
        }
         

        [Test]
        public void Flags()
        {
            var oneAndTwo = FlagsEnum.One | FlagsEnum.Two;

            QUnit.IsTrue((oneAndTwo & FlagsEnum.One) == FlagsEnum.One);
        }

        [Test]
        public void ThreeFlags()
        {
            var oneAndTwo = FlagsEnum.One | FlagsEnum.Two | FlagsEnum.Three;
            QUnit.IsTrue((oneAndTwo & FlagsEnum.One) == FlagsEnum.One);
        }

        public enum TestEnum
        {
            One, Two, Three
        }

        [Flags]
        public enum FlagsEnum
        {
            None = 0,
            One = 1 << 0,
            Two = 1 << 1,
            Three = 1 << 2
        }
    }
}
