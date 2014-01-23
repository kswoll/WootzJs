using System;
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests
{
    [Js(Export = false, Name = "QUnit")]
    public class QUnit
    {
        [Js(Name = "test")]
        public static void RunTest(string testName, Action action)
        {
        }

        [Js(Name = "equal")]
        public static void AreEqual(object expected, object actual) 
        {
        }

        [Js(Name = "ok")]
        public static void IsTrue(bool condition)
        {
        }
    }
}
