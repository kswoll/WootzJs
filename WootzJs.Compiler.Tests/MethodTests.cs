#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class MethodTests : TestFixture
    {
        [Test]
        public void StaticMethod()
        {
            var s = ClassWithStaticMethods.S();
            AssertEquals(s, "foo");
        }
         
        [Test]
        public void ExtensionMethod()
        {
            var s = 5.MyExtension();
            AssertEquals(s, "5");
        }
         
        [Test]
        public void OutParameter()
        {
            string x;
            ClassWithStaticMethods.OutParameter(out x);
            AssertEquals(x, "foo");
        }         
         
        [Test]
        public void TwoOutParameters()
        {
            string x;
            string y;
            ClassWithStaticMethods.TwoOutParameters(out x, out y);
            AssertEquals(x, "foo1");
            AssertEquals(y, "foo2");
        }         
         
        [Test]
        public void RefParameter()
        {
            int x = 5;
            ClassWithStaticMethods.RefParameter(ref x);
            AssertEquals(x, 6);
        }         
         
        [Test]
        public void TwoRefParameters()
        {
            int x = 5;
            int y = 6;
            ClassWithStaticMethods.TwoRefParameters(ref x, ref y);
            AssertEquals(x, 6);
            AssertEquals(y, 12);
        }         
         
        [Test]
        public void RefAndOutParameter()
        {
            int x = 5;
            int y;
            ClassWithStaticMethods.RefAndOutParameter(ref x, out y);
            AssertEquals(x, 6);
            AssertEquals(y, 10);
        }         
         
        [Test]
        public void InterfaceMethod()
        {
            ITestInterface test = new TestImplementation();
            var s = test.Method();
            AssertEquals(s, "foo");
        }         
         
        [Test]
        public void CollisionImplementationBothExplicit()
        {
            var o = new CollisionImplementationBothExplicit();
            ITestInterface test = o;
            ITestInterface2 test2 = o;
            var s = test.Method();
            var s2 = test2.Method();
            AssertEquals(s, "ITestInterface");
            AssertEquals(s2, "ITestInterface2");
        }         
         
        [Test]
        public void CollisionImplementationOneExplicit()
        {
            var o = new CollisionImplementationOneExplicit();
            ITestInterface test = o;
            ITestInterface2 test2 = o;
            var s = test.Method();
            var s2 = test2.Method();
            AssertEquals(s, "ITestInterface");
            AssertEquals(s2, "ITestInterface2");
        }         

        [Test]
        public void ExternMethod()
        {
            var max = ExternTest.max(8, 3, 9, 5);
            AssertEquals(max, 9);
        }

        [Test]
        public void NamedArguments()
        {
            var result = ClassWithStaticMethods.Add(one: 1, two: 2, three: 3, four: 4);
            AssertEquals(result, 4321);

            result = ClassWithStaticMethods.Add(two: 1, three: 2, four: 3);
            AssertEquals(result, 3210);

            result = ClassWithStaticMethods.Add(four: 1, three: 2, two: 3, one: 4);
            AssertEquals(result, 1234);
        }
    }

    public static class ClassWithStaticMethods
    {
        public static int Add(int one = 0, int two = 0, int three = 0, int four = 0)
        {
            return one + two*10 + three*100+ four*1000;
        }

        public static string S()
        {
            return "foo";
        }

        public static string MyExtension(this int i)
        {
            return i.ToString();
        }

        public static void OutParameter(out string s)
        {
            s = "foo";
        }

        public static void TwoOutParameters(out string s1, out string s2)
        {
            s1 = "foo1";
            s2 = "foo2";
        }

        public static void RefParameter(ref int i)
        {
            i = i + 1;
        }

        public static void TwoRefParameters(ref int i, ref int j)
        {
            i = i + 1;
            j = j * 2;
        }

        public static void RefAndOutParameter(ref int i, out int j)
        {
            i = i + 1;
            j = 10;
        }
    }

    public interface ITestInterface
    {
        string Method();
    }

    public class TestImplementation : ITestInterface 
    {
        public string Method()
        {
            return "foo";
        }
    }

    public interface ITestInterface2
    {
        string Method();
    }

    public class CollisionImplementationBothExplicit : ITestInterface, ITestInterface2
    {
        string ITestInterface.Method()
        {
            return "ITestInterface";
        }

        string ITestInterface2.Method()
        {
            return "ITestInterface2";
        }
    }

    public class CollisionImplementationOneExplicit : ITestInterface, ITestInterface2
    {
        public string Method()
        {
            return "ITestInterface";
        }

        string ITestInterface2.Method()
        {
            return "ITestInterface2";
        }
    }

    [Js(Name = "Math", Export = false)]
    public class ExternTest
    {
        public static extern int max(params int[] ints);
    }
}
