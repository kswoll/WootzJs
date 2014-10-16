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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    public class YieldTests : TestFixture
    {
        [Test]
        public void YieldBreak()
        {
            var strings = YieldClass.YieldBreak().ToArray();
            AssertEquals(0, strings.Length);
        }

        [Test]
        public void YieldIsEnumerator()
        {
            var yieldBreak = YieldClass.YieldBreak();
            AssertTrue(yieldBreak is IEnumerable<string>);
        }

        [Test]
        public void ReturnOne()
        {
            var strings = YieldClass.ReturnOne().ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "one");
        }

        [Test]
        public void ReturnTwo()
        {
            var strings = YieldClass.ReturnTwo().ToArray();
            AssertEquals(strings.Length, 2);
            AssertEquals(strings[0], "one");
            AssertEquals(strings[1], "two");
        }

        [Test]
        public void IfStatementTrue()
        {
            var strings = YieldClass.IfStatement(true).ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "true");
        }

        [Test]
        public void IfStatementFalse()
        {
            var strings = YieldClass.IfStatement(false).ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "false");
        }

        [Test]
        public void IfStatementTwoItemsTrue()
        {
            var strings = YieldClass.IfStatementTwoItems(true).ToArray();
            AssertEquals(strings.Length, 2);
            AssertEquals(strings[0], "one");
            AssertEquals(strings[1], "two");
        }

        [Test]
        public void IfStatementTwoItemsFalse()
        {
            var strings = YieldClass.IfStatementTwoItems(false).ToArray();
            AssertEquals(strings.Length, 2);
            AssertEquals(strings[0], "three");
            AssertEquals(strings[1], "four");
        }

        [Test]
        public void NestedIfTrueTrue()
        {
            var strings = YieldClass.NestedIf(true, true).ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "one");
        }

        [Test]
        public void NestedIfTrueFalse()
        {
            var strings = YieldClass.NestedIf(true, false).ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "two");
        }

        [Test]
        public void NestedIfFalseTrue()
        {
            var strings = YieldClass.NestedIf(false, true).ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "three");
        }

        [Test]
        public void NestedIfFalseFalse()
        {
            var strings = YieldClass.NestedIf(false, false).ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "four");
        }

        [Test]
        public void NestedIfTwoStatementsTrueTrue()
        {
            var strings = YieldClass.NestedIfTwoStatements(true, true).ToArray();
            AssertEquals(strings.Length, 2);
            AssertEquals(strings[0], "one");
            AssertEquals(strings[1], "two");
        }

        [Test]
        public void NestedIfTwoStatementsTrueFalse()
        {
            var strings = YieldClass.NestedIfTwoStatements(true, false).ToArray();
            AssertEquals(strings.Length, 2);
            AssertEquals(strings[0], "three");
            AssertEquals(strings[1], "four");
        }

        [Test]
        public void NestedIfTwoStatementsFalseTrue()
        {
            var strings = YieldClass.NestedIfTwoStatements(false, true).ToArray();
            AssertEquals(strings.Length, 2);
            AssertEquals(strings[0], "five");
            AssertEquals(strings[1], "six");
        }

        [Test]
        public void ReturnAfterIfTrue()
        {
            var strings = YieldClass.ReturnAfterIf(true).ToArray();
            AssertEquals(strings.Length, 5);
            AssertEquals(strings[0], "zero");
            AssertEquals(strings[1], "one");
            AssertEquals(strings[2], "two");
            AssertEquals(strings[3], "five");
            AssertEquals(strings[4], "six");
        }

        [Test]
        public void ReturnAfterIfFalse()
        {
            var strings = YieldClass.ReturnAfterIf(false).ToArray();
            AssertEquals(strings.Length, 5);
            AssertEquals(strings[0], "zero");
            AssertEquals(strings[1], "three");
            AssertEquals(strings[2], "four");
            AssertEquals(strings[3], "five");
            AssertEquals(strings[4], "six");
        }

        [Test]
        public void IterateVariable()
        {
            var strings = YieldClass.InitializeVariable().ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "foo");
        }

        [Test]
        public void WhileLoop()
        {
            var ints = YieldClass.WhileLoop().ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 0);
            AssertEquals(ints[1], 1);
            AssertEquals(ints[2], 2);
        }

        [Test]
        public void IfWithErrataAfterYield()
        {
            var ints = YieldClass.IfWithErrataAfterYield(true).ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 0);
            AssertEquals(ints[1], 1);
        }

        [Test]
        public void ForLoop()
        {
            var ints = YieldClass.ForLoop().ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 0);
            AssertEquals(ints[1], 1);
            AssertEquals(ints[2], 2);
        }

        [Test]
        public void ForLoopNoVariableWithInitializer()
        {
            var ints = YieldClass.ForLoopNoVariableWithInitializer().ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 0);
            AssertEquals(ints[1], 1);
            AssertEquals(ints[2], 2);
        }

        [Test]
        public void ForLoopNoVariableNoInitializer()
        {
            var ints = YieldClass.ForLoopNoVariableNoInitializer().ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 0);
            AssertEquals(ints[1], 1);
            AssertEquals(ints[2], 2);
        }

        [Test]
        public void ForLoopNoVariableNoInitializerNoIncrementor()
        {
            var ints = YieldClass.ForLoopNoVariableNoInitializerNoIncrementor().ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 0);
            AssertEquals(ints[1], 1);
            AssertEquals(ints[2], 2);
        }

        [Test]
        public void ForLoopTwoVariablesTwoIncrementors()
        {
            var ints = YieldClass.ForLoopTwoVariablesTwoIncrementors().ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 1);
            AssertEquals(ints[1], 3);
            AssertEquals(ints[2], 5);
        }

        [Test]
        public void NestedLoops()
        {
            var ints = YieldClass.NestedLoops().ToArray();
            AssertEquals(ints.Length, 6);
            AssertEquals(ints[0], 0);
            AssertEquals(ints[1], 1);
            AssertEquals(ints[2], 0);
            AssertEquals(ints[3], 1);
            AssertEquals(ints[4], 2);
            AssertEquals(ints[5], 1);
        }

        [Test]
        public void TypeParameter()
        {
            var strings = YieldClass.TypeParameter<YieldClass>().ToArray();
            AssertEquals(strings.Length, 1);
            AssertEquals(strings[0], "WootzJs.Compiler.Tests.YieldTests.YieldClass");
        }

        [Test]
        public void Foreach()
        {
            var strings = YieldClass.Foreach().ToArray();
            AssertEquals(strings.Length, 3);
            AssertEquals(strings[0], "one");
            AssertEquals(strings[1], "two");
            AssertEquals(strings[2], "three");
        }

        [Test]
        public void DoWhileFalse()
        {
            var ints = YieldClass.DoWhileFalse().ToArray();
            AssertEquals(ints.Length, 1);
            AssertEquals(ints[0], 1);
        }

        [Test]
        public void DoWhileLessThan3()
        {
            var ints = YieldClass.DoWhileLessThan3().ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 1);            
            AssertEquals(ints[1], 2);
        }

        [Test]
        public void SwitchOne()
        {
            var ints = YieldClass.Switch("one").ToArray();
            AssertEquals(ints.Length, 1);
            AssertEquals(ints[0], 1);            
        }

        [Test]
        public void SwitchTwo()
        {
            var ints = YieldClass.Switch("two").ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 1);            
            AssertEquals(ints[1], 2);            
        }

        [Test]
        public void SwitchThree()
        {
            var ints = YieldClass.Switch("three").ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 1);            
            AssertEquals(ints[1], 2);            
            AssertEquals(ints[2], 3);
        }

        [Test]
        public void SwitchDefault()
        {
            var ints = YieldClass.Switch("foo").ToArray();
            AssertEquals(ints.Length, 1);
            AssertEquals(ints[0], -1);            
        }

        [Test]
        public void BreakWhile()
        {
            var ints = YieldClass.BreakWhile().ToArray();
            AssertEquals(ints.Length, 1);
            AssertEquals(ints[0], 1);            
        }

        [Test]
        public void ContinueWhile()
        {
            var ints = YieldClass.ContinueWhile().ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 2);            
            AssertEquals(ints[1], 3);            
        }

        [Test]
        public void BreakFor()
        {
            var ints = YieldClass.BreakFor().ToArray();
            AssertEquals(ints.Length, 1);
            AssertEquals(ints[0], 1);            
        }

        [Test]
        public void ContinueFor()
        {
            var ints = YieldClass.ContinueFor().ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 2);            
            AssertEquals(ints[1], 3);            
        }

        [Test]
        public void BreakForeach()
        {
            var ints = YieldClass.BreakForeach().ToArray();
            AssertEquals(ints.Length, 1);
            AssertEquals(ints[0], 1);            
        }

        [Test]
        public void ContinueForeach()
        {
            var ints = YieldClass.ContinueForeach().ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 2);            
            AssertEquals(ints[1], 3);            
        }

        [Test]
        public void BreakDoWhile()
        {
            var ints = YieldClass.BreakDoWhile().ToArray();
            AssertEquals(ints.Length, 1);
            AssertEquals(ints[0], 1);            
        }

/*
        [Test]
        public void ContinueDoWhile()
        {
            var ints = YieldClass.ContinueDoWhile().ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 2);            
            AssertEquals(ints[1], 3);            
        }

        [Test]
        public void TryFinally()
        {
            var ints = YieldClass.TryFinally().ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 1);            
            AssertEquals(ints[1], 2);            
            AssertEquals(ints[2], 3);            
        }

        [Test]
        public void NestedTryFinally()
        {
            var ints = YieldClass.NestedTryFinally().ToArray();
            AssertEquals(ints.Length, 6);
            AssertEquals(ints[0], 1);            
            AssertEquals(ints[1], 2);            
            AssertEquals(ints[2], 3);            
            AssertEquals(ints[3], 4);            
            AssertEquals(ints[4], 11);            
            AssertEquals(ints[5], 22);            
        }

        [Test]
        public void TryFinallyThrowsException()
        {
            var enumerator = YieldClass.TryFinallyThrowsException(true).GetEnumerator();
            AssertTrue(enumerator.MoveNext());
            AssertEquals(enumerator.Current, 1);
            try
            {
                enumerator.MoveNext();
                AssertTrue(false);
            }
            catch (Exception)
            {
                AssertTrue(true);
            }
        }

        [Test]
        public void LabeledStatementGotoFirst()
        {
            var ints = YieldClass.LabeledStatementGotoFirst(true).ToArray();
            AssertEquals(ints.Length, 1);
            AssertEquals(ints[0], 1);

            ints = YieldClass.LabeledStatementGotoFirst(false).ToArray();
            AssertEquals(ints.Length, 2);
            AssertEquals(ints[0], 1);
            AssertEquals(ints[1], 2);
        }

        [Test]
        public void LabeledStatementGotoSecond()
        {
            var ints = YieldClass.LabeledStatementGotoSecond().ToArray();
            AssertEquals(ints.Length, 3);
            AssertEquals(ints[0], 1);
            AssertEquals(ints[1], 2);
            AssertEquals(ints[2], 3);
        }

        [Test]
        public void CollidingForeach()
        {
            var ints = YieldClass.CollidingForeach().ToArray();
            AssertEquals(ints.Length, 4);
            AssertEquals(ints[0], 1);
            AssertEquals(ints[1], 2);
            AssertEquals(ints[2], 3);
            AssertEquals(ints[3], 4);
        }

        [Test]
        public void CollidingFor()
        {
            var ints = YieldClass.CollidingForeach().ToArray();
            AssertEquals(ints.Length, 4);
            AssertEquals(ints[0], 1);
            AssertEquals(ints[1], 2);
            AssertEquals(ints[2], 3);
            AssertEquals(ints[3], 4);
        }

        [Test]
        public void ReuseEnumerable()
        {
            var enumerable = YieldClass.ReturnTwo();
            var strings = enumerable.ToArray();
            AssertEquals(strings.Length, 2);
            AssertEquals(strings[0], "one");
            AssertEquals(strings[1], "two");
            
            strings = enumerable.ToArray();
            AssertEquals(strings.Length, 2);
            AssertEquals(strings[0], "one");
            AssertEquals(strings[1], "two");
        }
*/
        public class YieldClass
        {
            public static IEnumerable<string> YieldBreak()
            {
                yield break;
            }

            public static IEnumerable<string> ReturnOne()
            {
                yield return "one";
            }

            public static IEnumerable<string> ReturnTwo()
            {
                yield return "one";
                yield return "two";
            }

            public static IEnumerable<string> IfStatement(bool flag)
            {
                if (flag)
                {
                    yield return "true";
                }
                else
                {
                    yield return "false";
                }
            }

            public static IEnumerable<string> IfStatementTwoItems(bool flag)
            {
                if (flag)
                {
                    yield return "one";
                    yield return "two";
                }
                else
                {
                    yield return "three";
                    yield return "four";
                }
            }

            public static IEnumerable<string> NestedIf(bool flag1, bool flag2)
            {
                if (flag1)
                {
                    if (flag2)
                    {
                        yield return "one";
                    }
                    else
                    {
                        yield return "two";
                    }
                }
                else
                {
                    if (flag2)
                    {
                        yield return "three";
                    }
                    else
                    {
                        yield return "four";
                    }
                }
            }

            public static IEnumerable<string> NestedIfTwoStatements(bool flag1, bool flag2)
            {
                if (flag1)
                {
                    if (flag2)
                    {
                        yield return "one";
                        yield return "two";
                    }
                    else
                    {
                        yield return "three";
                        yield return "four";
                    }
                }
                else
                {
                    if (flag2)
                    {
                        yield return "five";
                        yield return "six";
                    }
                    else
                    {
                        yield return "seven";
                        yield return "eight";
                    }
                }
            }

            public static IEnumerable<string> ReturnAfterIf(bool flag)
            {
                yield return "zero";
                if (flag)
                {
                    yield return "one";
                    yield return "two";
                }
                else
                {
                    yield return "three";
                    yield return "four";
                }
                yield return "five";
                yield return "six";
            }

            public static IEnumerable<string> InitializeVariable()
            {
                var s = "foo";
                yield return s;
            }

            public static IEnumerable<int> WhileLoop()
            {
                var i = 0;
                while (i < 3)
                {
                    yield return i;
                    i++;
                }
            }

            public static IEnumerable<int> IfWithErrataAfterYield(bool flag)
            {
                var i = 0;
                if (flag)
                {
                    yield return i;
                    i++;
                }
                yield return i;
            }

            public static IEnumerable<int> ForLoop()
            {
                for (var i = 0; i < 3; i++)
                {
                    yield return i;
                }
            }

            public static IEnumerable<int> ForLoopNoVariableWithInitializer()
            {
                int i;
                for (i = 0; i < 3; i++)
                {
                    yield return i;
                }
            }

            public static IEnumerable<int> ForLoopNoVariableNoInitializer()
            {
                int i = 0;
                for (; i < 3; i++)
                {
                    yield return i;
                }
            }

            public static IEnumerable<int> ForLoopNoVariableNoInitializerNoIncrementor()
            {
                int i = 0;
                for (; i < 3;)
                {
                    yield return i;
                    i++;
                }
            }

            public static IEnumerable<int> ForLoopTwoVariablesTwoIncrementors()
            {
                for (int i = 0, j = 1; i < 3; i++, j++)
                {
                    yield return i + j;
                }
            }

            public static IEnumerable<int> NestedLoops()
            {
                for (var i = 0; i < 2; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        yield return i + j;
                    }
                    yield return i;
                }
            }

            public static IEnumerable<string> TypeParameter<T>()
            {
                yield return typeof(T).FullName;
            }

            public static IEnumerable<string> Foreach()
            {
                foreach (var s in new[] { "one", "two", "three" })
                {
                    yield return s;
                }
            }

            public static IEnumerable<int> DoWhileFalse()
            {
                var i = 1;
                do
                {
                    yield return i;
                    i++;
                }
                while (false);
            }

            public static IEnumerable<int> DoWhileLessThan3()
            {
                var i = 1;
                do
                {
                    yield return i;
                    i++;
                }
                while (i < 3);
            }

            public static IEnumerable<int> Switch(string s)
            {
                switch (s)
                {
                    case "one":
                        yield return 1;
                        break;
                    case "two":
                        yield return 1;
                        yield return 2;
                        break;
                    case "three":
                        yield return 1;
                        yield return 2;
                        yield return 3;
                        break;
                    default:
                        yield return -1;
                        break;
                }
            }

            public static IEnumerable<int> BreakWhile()
            {
                var i = 0;
                while (true)
                {
                    i++;
                    yield return i;
                    break;
                }
            }

            public static IEnumerable<int> ContinueWhile()
            {
                var i = 0;
                while (i < 3)
                {
                    i++;
                    if (i < 2)
                        continue;
                    yield return i;
                }
            }

            public static IEnumerable<int> BreakFor()
            {
                for (var i = 0;;)
                {
                    i++;
                    yield return i;
                    break;
                }
            }

            public static IEnumerable<int> ContinueFor()
            {
                for (var i = 0; i < 3;)
                {
                    i++;
                    if (i < 2)
                        continue;
                    yield return i;
                }
            }

            public static IEnumerable<int> BreakForeach()
            {
                foreach (var i in new[] { 1, 2, 3 })
                {
                    yield return i;
                    break;
                }
            }

            public static IEnumerable<int> ContinueForeach()
            {
                foreach (var i in new[] { 1, 2, 3 })
                {
                    if (i < 2)
                        continue;
                    yield return i;
                }
            }

            public static IEnumerable<int> BreakDoWhile()
            {
                var i = 0;
                do
                {
                    i++;
                    yield return i;
                    break;
                }
                while (true);
            }

/*
            public static IEnumerable<int> ContinueDoWhile()
            {
                var i = 0;
                do
                {
                    i++;
                    if (i < 2)
                        continue;
                    yield return i;
                }
                while (i < 3);
            }

            public static IEnumerable<int> TryFinally()
            {
                var i = 0;
                try
                {
                    i++;
                    yield return i;
                    i++;
                    yield return i;
                }
                finally
                {
                    i++;
                }
                yield return i;
            }

            public static IEnumerable<int> NestedTryFinally()
            {
                var i = 0;
                try
                {
                    yield return 1;
                    yield return 2;
                    try
                    {
                        yield return 3;
                        yield return 4;
                    }
                    finally
                    {
                        i++;
                    }
                    yield return i + 10;
                }
                finally
                {
                    i++;
                }
                yield return i + 20;
            }

            public static IEnumerable<int> TryFinallyThrowsException(bool flag)
            {
                var i = 0;
                try
                {
                    i++;
                    yield return i;
                    if (flag)
                        throw new Exception();
                }
                finally
                {
                    i++;
                }
                yield return i;
            }

            public static IEnumerable<int> LabeledStatementGotoFirst(bool flag)
            {
                var i = 1;
                if (flag)
                    goto label;
                yield return i;
                i++;
                label:
                yield return i;
            }

            public static IEnumerable<int> LabeledStatementGotoSecond()
            {
                var i = 0;
                label:
                i++;
 
                yield return i;
                if (i < 3)
                    goto label;
            }

            public static IEnumerable<int> CollidingForeach()
            {
                foreach (var item in new[] { 1, 2 })
                {
                    yield return item;
                }
                foreach (var item in new[] { 3, 4 })
                {
                    yield return item;
                }
            }

            public static IEnumerable<int> CollidingFor()
            {
                for (var i = 0; i < 3; i++)
                {
                    yield return i;
                }
                for (var i = 2; i < 5; i++)
                {
                    yield return i;
                }
            }
*/
        }
    }
}
