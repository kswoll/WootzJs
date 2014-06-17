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
using System.Linq;
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests
{
    [TestFixture]
    public class StringTests
    {
        [Test]
        public void ToUpper()
        {
            var s = "foo";
            s = s.ToUpper();
            s.AssertEquals("FOO");
        }

        [Test]
        public void ToLower()
        {
            var s = "FOO";
            s = s.ToLower();
            s.AssertEquals("foo");
        }

        [Test]
        public void Length()
        {
            var s = "FOO";
            int length = s.Length;
            length.AssertEquals(3);
        }

        [Test]
        public void EndsWith()
        {
            var s = "HelloWorld";
            s.EndsWith("World").AssertTrue();
        }

        [Test]
        public void StartsWith()
        {
            var s = "HelloWorld";
            s.StartsWith("Hello").AssertTrue();
        }

        [Test]
        public void Compare()
        {
            string.Compare("a", "b").AssertEquals(-1);
            string.Compare("b", "a").AssertEquals(1);
            string.Compare("a", "a").AssertEquals(0);
        }

        [Test]
        public void IndexOf()
        {
            var s = "12341234";
            String two = "2";
            s.IndexOf(two).AssertEquals(1);
            s.IndexOf("2", 4).AssertEquals(5);
            s.IndexOf('2').AssertEquals(1);
            s.IndexOf('2', 4).AssertEquals(5);
        }

        [Test]
        public void LastIndexOf()
        {
            var s = "12341234";
            s.LastIndexOf("2").AssertEquals(5);
            s.LastIndexOf("2", 4).AssertEquals(1);
            s.LastIndexOf('2').AssertEquals(5);
            s.LastIndexOf('2', 4).AssertEquals(1);
        }

        [Test]
        public void Substring()
        {
            var s = "12341234";
            s.Substring(4, 2).AssertEquals("12");
            s.Substring(6).AssertEquals("34");
        }

        [Test]
        public void SplitCharArray()
        {
            var s = "12a34b56c78";
            var parts = s.Split('a', 'b', 'c');
            parts.Length.AssertEquals(4);
            parts[0].AssertEquals("12");
            parts[1].AssertEquals("34");
            parts[2].AssertEquals("56");
            parts[3].AssertEquals("78");
        }

        [Test]
        public void SplitCharArrayWithCount()
        {
            var s = "12a34b56c78";
            var parts = s.Split(new[] { 'a', 'b', 'c' }, 3);
            parts.Length.AssertEquals(3);    
            parts[0].AssertEquals("12");
            parts[1].AssertEquals("34");
            parts[2].AssertEquals("56");
        }

        [Test]
        public void CharCode()
        {
            char b = 'b';
            char a = 'a';
            int i = b - a;
            i.AssertEquals(1);
        }

        [Test]
        public void PreIncrementCharacter()
        {
            char b = 'b';
            var c = ++b;
            b.AssertEquals('c');
            c.AssertEquals('c');
        }

        [Test]
        public void PostIncrementCharacter()
        {
            char b = 'b';
            var stillB = b++;
            b.AssertEquals('c');
            stillB.AssertEquals('b');
        }

        [Test]
        public void StringFormat()
        {
            var s = "1) {0} 2) {1}";
            var result = string.Format(s, 1, 2);
            result.AssertEquals("1) 1 2) 2");
        }

        [Test]
        public void Foreach()
        {
            var s = "1234";
            var chars = s.ToArray();
            chars[0].AssertEquals('1');
            chars[1].AssertEquals('2');
            chars[2].AssertEquals('3');
            chars[3].AssertEquals('4');
        }

        [Test]
        public void Contains()
        {
            var s = "hello world";
            s.Contains("world").AssertTrue();
        }

        [Test]
        public void IsWhiteSpace()
        {
            char.IsWhiteSpace(' ').AssertTrue();
            char.IsWhiteSpace('\t').AssertTrue();
            char.IsWhiteSpace('\r').AssertTrue();
            char.IsWhiteSpace('\n').AssertTrue();
            (!char.IsWhiteSpace('a')).AssertTrue();
        }

        [Test]
        public void IsDigit()
        {
            char.IsDigit('0').AssertTrue();
            char.IsDigit('3').AssertTrue();
            char.IsDigit('9').AssertTrue();
            (!char.IsDigit('a')).AssertTrue();
        }

        [Test]
        public void ToStringOnNull()
        {
            object o = null;
            var s = "foo" + o;
            s.AssertEquals("foo");
        }

        [Test]
        public void SingleQuotesInsideStringAreNotEscaped()
        {
            var s = "'foo'";
            s.Length.AssertEquals(5);
        }
    }
}
