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
            Assert.AssertEquals(s, "FOO");
        }

        [Test]
        public void ToLower()
        {
            var s = "FOO";
            s = s.ToLower();
            Assert.AssertEquals(s, "foo");
        }

        [Test]
        public void Length()
        {
            var s = "FOO";
            int length = s.Length;
            Assert.AssertEquals(length, 3);
        }

        [Test]
        public void EndsWith()
        {
            var s = "HelloWorld";
            Assert.AssertTrue(s.EndsWith("World"));
        }

        [Test]
        public void StartsWith()
        {
            var s = "HelloWorld";
            Assert.AssertTrue(s.StartsWith("Hello"));
        }

        [Test]
        public void Compare()
        {
            Assert.AssertEquals(string.Compare("a", "b"), -1);
            Assert.AssertEquals(string.Compare("b", "a"), 1);
            Assert.AssertEquals(string.Compare("a", "a"), 0);
        }

        [Test]
        public void IndexOf()
        {
            var s = "12341234";
            String two = "2";
            Assert.AssertEquals(s.IndexOf(two), 1);
            Assert.AssertEquals(s.IndexOf("2", 4), 5);
            Assert.AssertEquals(s.IndexOf('2'), 1);
            Assert.AssertEquals(s.IndexOf('2', 4), 5);
        }

        [Test]
        public void LastIndexOf()
        {
            var s = "12341234";
            Assert.AssertEquals(s.LastIndexOf("2"), 5);
            Assert.AssertEquals(s.LastIndexOf("2", 4), 1);
            Assert.AssertEquals(s.LastIndexOf('2'), 5);
            Assert.AssertEquals(s.LastIndexOf('2', 4), 1);
        }

        [Test]
        public void Substring()
        {
            var s = "12341234";
            Assert.AssertEquals(s.Substring(4, 2), "12");
            Assert.AssertEquals(s.Substring(6), "34");
        }

        [Test]
        public void SplitCharArray()
        {
            var s = "12a34b56c78";
            var parts = s.Split('a', 'b', 'c');
            Assert.AssertEquals(parts.Length, 4);
            Assert.AssertEquals(parts[0], "12");
            Assert.AssertEquals(parts[1], "34");
            Assert.AssertEquals(parts[2], "56");
            Assert.AssertEquals(parts[3], "78");
        }

        [Test]
        public void SplitCharArrayWithCount()
        {
            var s = "12a34b56c78";
            var parts = s.Split(new[] { 'a', 'b', 'c' }, 3);
            Assert.AssertEquals(parts.Length, 3);    
            Assert.AssertEquals(parts[0], "12");
            Assert.AssertEquals(parts[1], "34");
            Assert.AssertEquals(parts[2], "56");
        }

        [Test]
        public void CharCode()
        {
            char b = 'b';
            char a = 'a';
            int i = b - a;
            Assert.AssertEquals(i, 1);
        }

        [Test]
        public void PreIncrementCharacter()
        {
            char b = 'b';
            var c = ++b;
            Assert.AssertEquals(b, 'c');
            Assert.AssertEquals(c, 'c');
        }

        [Test]
        public void PostIncrementCharacter()
        {
            char b = 'b';
            var stillB = b++;
            Assert.AssertEquals(b, 'c');
            Assert.AssertEquals(stillB, 'b');
        }

        [Test]
        public void StringFormat()
        {
            var s = "1) {0} 2) {1}";
            var result = string.Format(s, 1, 2);
            Assert.AssertEquals(result, "1) 1 2) 2");
        }

        [Test]
        public void Foreach()
        {
            var s = "1234";
            var chars = s.ToArray();
            Assert.AssertEquals(chars[0], '1');
            Assert.AssertEquals(chars[1], '2');
            Assert.AssertEquals(chars[2], '3');
            Assert.AssertEquals(chars[3], '4');
        }

        [Test]
        public void Contains()
        {
            var s = "hello world";
            Assert.AssertTrue(s.Contains("world"));
        }

        [Test]
        public void IsWhiteSpace()
        {
            Assert.AssertTrue(char.IsWhiteSpace(' '));
            Assert.AssertTrue(char.IsWhiteSpace('\t'));
            Assert.AssertTrue(char.IsWhiteSpace('\r'));
            Assert.AssertTrue(char.IsWhiteSpace('\n'));
            Assert.AssertTrue(!char.IsWhiteSpace('a'));
        }

        [Test]
        public void IsDigit()
        {
            Assert.AssertTrue(char.IsDigit('0'));
            Assert.AssertTrue(char.IsDigit('3'));
            Assert.AssertTrue(char.IsDigit('9'));
            Assert.AssertTrue(!char.IsDigit('a'));
        }

        [Test]
        public void ToStringOnNull()
        {
            object o = null;
            var s = "foo" + o;
            Assert.AssertEquals(s, "foo");
        }

        [Test]
        public void SingleQuotesInsideStringAreNotEscaped()
        {
            var s = "'foo'";
            Assert.AssertEquals(s.Length, 5);
        }
    }
}
