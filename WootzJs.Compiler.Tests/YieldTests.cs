using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class YieldTests
    {
        [Test]
        public void YieldBreak()
        {
            var strings = YieldClass.YieldBreak().ToArray();
            QUnit.AreEqual(0, strings.Length);
        }

        [Test]
        public void ReturnOne()
        {
            var strings = YieldClass.ReturnOne().ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "one");
        }

        [Test]
        public void ReturnTwo()
        {
            var strings = YieldClass.ReturnTwo().ToArray();
            QUnit.AreEqual(strings.Length, 2);
            QUnit.AreEqual(strings[0], "one");
            QUnit.AreEqual(strings[1], "two");
        }

        [Test]
        public void IfStatementTrue()
        {
            var strings = YieldClass.IfStatement(true).ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "true");
        }

        [Test]
        public void IfStatementFalse()
        {
            var strings = YieldClass.IfStatement(false).ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "false");
        }

        [Test]
        public void IfStatementTwoItemsTrue()
        {
            var strings = YieldClass.IfStatementTwoItems(true).ToArray();
            QUnit.AreEqual(strings.Length, 2);
            QUnit.AreEqual(strings[0], "one");
            QUnit.AreEqual(strings[1], "two");
        }

        [Test]
        public void IfStatementTwoItemsFalse()
        {
            var strings = YieldClass.IfStatementTwoItems(false).ToArray();
            QUnit.AreEqual(strings.Length, 2);
            QUnit.AreEqual(strings[0], "three");
            QUnit.AreEqual(strings[1], "four");
        }

        [Test]
        public void NestedIfTrueTrue()
        {
            var strings = YieldClass.NestedIf(true, true).ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "one");
        }

        [Test]
        public void NestedIfTrueFalse()
        {
            var strings = YieldClass.NestedIf(true, false).ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "two");
        }

        [Test]
        public void NestedIfFalseTrue()
        {
            var strings = YieldClass.NestedIf(false, true).ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "three");
        }

        [Test]
        public void NestedIfFalseFalse()
        {
            var strings = YieldClass.NestedIf(false, false).ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "four");
        }

        [Test]
        public void NestedIfTwoStatementsTrueTrue()
        {
            var strings = YieldClass.NestedIfTwoStatements(true, true).ToArray();
            QUnit.AreEqual(strings.Length, 2);
            QUnit.AreEqual(strings[0], "one");
            QUnit.AreEqual(strings[1], "two");
        }

        [Test]
        public void NestedIfTwoStatementsTrueFalse()
        {
            var strings = YieldClass.NestedIfTwoStatements(true, false).ToArray();
            QUnit.AreEqual(strings.Length, 2);
            QUnit.AreEqual(strings[0], "three");
            QUnit.AreEqual(strings[1], "four");
        }

        [Test]
        public void NestedIfTwoStatementsFalseTrue()
        {
            var strings = YieldClass.NestedIfTwoStatements(false, true).ToArray();
            QUnit.AreEqual(strings.Length, 2);
            QUnit.AreEqual(strings[0], "five");
            QUnit.AreEqual(strings[1], "six");
        }

        [Test]
        public void ReturnAfterIfTrue()
        {
            var strings = YieldClass.ReturnAfterIf(true).ToArray();
            QUnit.AreEqual(strings.Length, 5);
            QUnit.AreEqual(strings[0], "zero");
            QUnit.AreEqual(strings[1], "one");
            QUnit.AreEqual(strings[2], "two");
            QUnit.AreEqual(strings[3], "five");
            QUnit.AreEqual(strings[4], "six");
        }

        [Test]
        public void ReturnAfterIfFalse()
        {
            var strings = YieldClass.ReturnAfterIf(false).ToArray();
            QUnit.AreEqual(strings.Length, 5);
            QUnit.AreEqual(strings[0], "zero");
            QUnit.AreEqual(strings[1], "three");
            QUnit.AreEqual(strings[2], "four");
            QUnit.AreEqual(strings[3], "five");
            QUnit.AreEqual(strings[4], "six");
        }

        [Test]
        public void IterateVariable()
        {
            var strings = YieldClass.InitializeVariable().ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "foo");
        }

        [Test]
        public void WhileLoop()
        {
            var ints = YieldClass.WhileLoop().ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 0);
            QUnit.AreEqual(ints[1], 1);
            QUnit.AreEqual(ints[2], 2);
        }

        [Test]
        public void IfWithErrataAfterYield()
        {
            var ints = YieldClass.IfWithErrataAfterYield(true).ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 0);
            QUnit.AreEqual(ints[1], 1);
        }

        [Test]
        public void ForLoop()
        {
            var ints = YieldClass.ForLoop().ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 0);
            QUnit.AreEqual(ints[1], 1);
            QUnit.AreEqual(ints[2], 2);
        }

        [Test]
        public void ForLoopNoVariableWithInitializer()
        {
            var ints = YieldClass.ForLoopNoVariableWithInitializer().ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 0);
            QUnit.AreEqual(ints[1], 1);
            QUnit.AreEqual(ints[2], 2);
        }

        [Test]
        public void ForLoopNoVariableNoInitializer()
        {
            var ints = YieldClass.ForLoopNoVariableNoInitializer().ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 0);
            QUnit.AreEqual(ints[1], 1);
            QUnit.AreEqual(ints[2], 2);
        }

        [Test]
        public void ForLoopNoVariableNoInitializerNoIncrementor()
        {
            var ints = YieldClass.ForLoopNoVariableNoInitializerNoIncrementor().ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 0);
            QUnit.AreEqual(ints[1], 1);
            QUnit.AreEqual(ints[2], 2);
        }

        [Test]
        public void ForLoopTwoVariablesTwoIncrementors()
        {
            var ints = YieldClass.ForLoopTwoVariablesTwoIncrementors().ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 1);
            QUnit.AreEqual(ints[1], 3);
            QUnit.AreEqual(ints[2], 5);
        }

        [Test]
        public void NestedLoops()
        {
            var ints = YieldClass.NestedLoops().ToArray();
            QUnit.AreEqual(ints.Length, 6);
            QUnit.AreEqual(ints[0], 0);
            QUnit.AreEqual(ints[1], 1);
            QUnit.AreEqual(ints[2], 0);
            QUnit.AreEqual(ints[3], 1);
            QUnit.AreEqual(ints[4], 2);
            QUnit.AreEqual(ints[5], 1);
        }

        [Test]
        public void TypeParameter()
        {
            var strings = YieldClass.TypeParameter<YieldClass>().ToArray();
            QUnit.AreEqual(strings.Length, 1);
            QUnit.AreEqual(strings[0], "WootzJs.Compiler.Tests.YieldTests.YieldClass");
        }

        [Test]
        public void Foreach()
        {
            var strings = YieldClass.Foreach().ToArray();
            QUnit.AreEqual(strings.Length, 3);
            QUnit.AreEqual(strings[0], "one");
            QUnit.AreEqual(strings[1], "two");
            QUnit.AreEqual(strings[2], "three");
        }

        [Test]
        public void DoWhileFalse()
        {
            var ints = YieldClass.DoWhileFalse().ToArray();
            QUnit.AreEqual(ints.Length, 1);
            QUnit.AreEqual(ints[0], 1);
        }

        [Test]
        public void DoWhileLessThan3()
        {
            var ints = YieldClass.DoWhileLessThan3().ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 1);            
            QUnit.AreEqual(ints[1], 2);
        }

        [Test]
        public void SwitchOne()
        {
            var ints = YieldClass.Switch("one").ToArray();
            QUnit.AreEqual(ints.Length, 1);
            QUnit.AreEqual(ints[0], 1);            
        }

        [Test]
        public void SwitchTwo()
        {
            var ints = YieldClass.Switch("two").ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 1);            
            QUnit.AreEqual(ints[1], 2);            
        }

        [Test]
        public void SwitchThree()
        {
            var ints = YieldClass.Switch("three").ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 1);            
            QUnit.AreEqual(ints[1], 2);            
            QUnit.AreEqual(ints[2], 3);
        }

        [Test]
        public void SwitchDefault()
        {
            var ints = YieldClass.Switch("foo").ToArray();
            QUnit.AreEqual(ints.Length, 1);
            QUnit.AreEqual(ints[0], -1);            
        }

        [Test]
        public void BreakWhile()
        {
            var ints = YieldClass.BreakWhile().ToArray();
            QUnit.AreEqual(ints.Length, 1);
            QUnit.AreEqual(ints[0], 1);            
        }

        [Test]
        public void ContinueWhile()
        {
            var ints = YieldClass.ContinueWhile().ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 2);            
            QUnit.AreEqual(ints[1], 3);            
        }

        [Test]
        public void BreakFor()
        {
            var ints = YieldClass.BreakFor().ToArray();
            QUnit.AreEqual(ints.Length, 1);
            QUnit.AreEqual(ints[0], 1);            
        }

        [Test]
        public void ContinueFor()
        {
            var ints = YieldClass.ContinueFor().ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 2);            
            QUnit.AreEqual(ints[1], 3);            
        }

        [Test]
        public void BreakForeach()
        {
            var ints = YieldClass.BreakForeach().ToArray();
            QUnit.AreEqual(ints.Length, 1);
            QUnit.AreEqual(ints[0], 1);            
        }

        [Test]
        public void ContinueForeach()
        {
            var ints = YieldClass.ContinueForeach().ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 2);            
            QUnit.AreEqual(ints[1], 3);            
        }

        [Test]
        public void BreakDoWhile()
        {
            var ints = YieldClass.BreakDoWhile().ToArray();
            QUnit.AreEqual(ints.Length, 1);
            QUnit.AreEqual(ints[0], 1);            
        }

        [Test]
        public void ContinueDoWhile()
        {
            var ints = YieldClass.ContinueDoWhile().ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 2);            
            QUnit.AreEqual(ints[1], 3);            
        }

        [Test]
        public void TryFinally()
        {
            var ints = YieldClass.TryFinally().ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 1);            
            QUnit.AreEqual(ints[1], 2);            
            QUnit.AreEqual(ints[2], 3);            
        }

        [Test]
        public void NestedTryFinally()
        {
            var ints = YieldClass.NestedTryFinally().ToArray();
            QUnit.AreEqual(ints.Length, 6);
            QUnit.AreEqual(ints[0], 1);            
            QUnit.AreEqual(ints[1], 2);            
            QUnit.AreEqual(ints[2], 3);            
            QUnit.AreEqual(ints[3], 4);            
            QUnit.AreEqual(ints[4], 11);            
            QUnit.AreEqual(ints[5], 22);            
        }

        [Test]
        public void TryFinallyThrowsException()
        {
            var enumerator = YieldClass.TryFinallyThrowsException(true).GetEnumerator();
            QUnit.IsTrue(enumerator.MoveNext());
            QUnit.AreEqual(enumerator.Current, 1);
            try
            {
                enumerator.MoveNext();
                QUnit.IsTrue(false);
            }
            catch (Exception)
            {
                QUnit.IsTrue(true);
            }
        }

        [Test]
        public void LabeledStatementGotoFirst()
        {
            var ints = YieldClass.LabeledStatementGotoFirst(true).ToArray();
            QUnit.AreEqual(ints.Length, 1);
            QUnit.AreEqual(ints[0], 1);

            ints = YieldClass.LabeledStatementGotoFirst(false).ToArray();
            QUnit.AreEqual(ints.Length, 2);
            QUnit.AreEqual(ints[0], 1);
            QUnit.AreEqual(ints[1], 2);
        }

        [Test]
        public void LabeledStatementGotoSecond()
        {
            var ints = YieldClass.LabeledStatementGotoSecond().ToArray();
            QUnit.AreEqual(ints.Length, 3);
            QUnit.AreEqual(ints[0], 1);
            QUnit.AreEqual(ints[1], 2);
            QUnit.AreEqual(ints[2], 3);
        }

        [Test]
        public void CollidingForeach()
        {
            var ints = YieldClass.CollidingForeach().ToArray();
            QUnit.AreEqual(ints.Length, 4);
            QUnit.AreEqual(ints[0], 1);
            QUnit.AreEqual(ints[1], 2);
            QUnit.AreEqual(ints[2], 3);
            QUnit.AreEqual(ints[3], 4);
        }

        [Test]
        public void CollidingFor()
        {
            var ints = YieldClass.CollidingForeach().ToArray();
            QUnit.AreEqual(ints.Length, 4);
            QUnit.AreEqual(ints[0], 1);
            QUnit.AreEqual(ints[1], 2);
            QUnit.AreEqual(ints[2], 3);
            QUnit.AreEqual(ints[3], 4);
        }

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
        }
    }
}