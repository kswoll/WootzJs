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
    public class StringTests : TestFixture
    {
        [Test]
        public void ToUpper()
        {
            var s = "foo";
            s = s.ToUpper();
            AssertEquals(s, "FOO");
        }

        [Test]
        public void ToLower()
        {
            var s = "FOO";
            s = s.ToLower();
            AssertEquals(s, "foo");
        }

        [Test]
        public void Length()
        {
            var s = "FOO";
            int length = s.Length;
            AssertEquals(length, 3);
        }

        [Test]
        public void EndsWith()
        {
            var s = "HelloWorld";
            AssertTrue(s.EndsWith("World"));
        }

        [Test]
        public void StartsWith()
        {
            var s = "HelloWorld";
            AssertTrue(s.StartsWith("Hello"));
        }

        [Test]
        public void Compare()
        {
            AssertEquals(string.Compare("a", "b"), -1);
            AssertEquals(string.Compare("b", "a"), 1);
            AssertEquals(string.Compare("a", "a"), 0);
        }

        [Test]
        public void IndexOf()
        {
            var s = "12341234";
            String two = "2";
            AssertEquals(s.IndexOf(two), 1);
            AssertEquals(s.IndexOf("2", 4), 5);
            AssertEquals(s.IndexOf('2'), 1);
            AssertEquals(s.IndexOf('2', 4), 5);
        }

        [Test]
        public void LastIndexOf()
        {
            var s = "12341234";
            AssertEquals(s.LastIndexOf("2"), 5);
            AssertEquals(s.LastIndexOf("2", 4), 1);
            AssertEquals(s.LastIndexOf('2'), 5);
            AssertEquals(s.LastIndexOf('2', 4), 1);
        }

        [Test]
        public void Substring()
        {
            var s = "12341234";
            AssertEquals(s.Substring(4, 2), "12");
            AssertEquals(s.Substring(6), "34");
        }

        [Test]
        public void SplitCharArray()
        {
            var s = "12a34b56c78";
            var parts = s.Split('a', 'b', 'c');
            AssertEquals(parts.Length, 4);
            AssertEquals(parts[0], "12");
            AssertEquals(parts[1], "34");
            AssertEquals(parts[2], "56");
            AssertEquals(parts[3], "78");
        }

        [Test]
        public void SplitCharArrayWithCount()
        {
            var s = "12a34b56c78";
            var parts = s.Split(new[] { 'a', 'b', 'c' }, 3);
            AssertEquals(parts.Length, 3);    
            AssertEquals(parts[0], "12");
            AssertEquals(parts[1], "34");
            AssertEquals(parts[2], "56");
        }

        [Test]
        public void CharCode()
        {
            char b = 'b';
            char a = 'a';
            int i = b - a;
            AssertEquals(i, 1);
        }

        [Test]
        public void PreIncrementCharacter()
        {
            char b = 'b';
            var c = ++b;
            AssertEquals(b, 'c');
            AssertEquals(c, 'c');
        }

        [Test]
        public void PostIncrementCharacter()
        {
            char b = 'b';
            var stillB = b++;
            AssertEquals(b, 'c');
            AssertEquals(stillB, 'b');
        }

        [Test]
        public void StringFormat()
        {
            var s = "1) {0} 2) {1}";
            var result = string.Format(s, 1, 2);
            AssertEquals(result, "1) 1 2) 2");
        }

        [Test]
        public void Foreach()
        {
            var s = "1234";
            var chars = s.ToArray();
            AssertEquals(chars[0], '1');
            AssertEquals(chars[1], '2');
            AssertEquals(chars[2], '3');
            AssertEquals(chars[3], '4');
        }

        [Test]
        public void Contains()
        {
            var s = "hello world";
            AssertTrue(s.Contains("world"));
        }

        [Test]
        public void IsWhiteSpace()
        {
            AssertTrue(char.IsWhiteSpace(' '));
            AssertTrue(char.IsWhiteSpace('\t'));
            AssertTrue(char.IsWhiteSpace('\r'));
            AssertTrue(char.IsWhiteSpace('\n'));
            AssertTrue((!char.IsWhiteSpace('a')));
        }

        [Test]
        public void IsDigit()
        {
            AssertTrue(char.IsDigit('0'));
            AssertTrue(char.IsDigit('3'));
            AssertTrue(char.IsDigit('9'));
            AssertTrue((!char.IsDigit('a')));
        }

        [Test]
        public void ToStringOnNull()
        {
            object o = null;
            var s = "foo" + o;
            AssertEquals(s, "foo");
        }

        [Test]
        public void SingleQuotesInsideStringAreNotEscaped()
        {
            var s = "'foo'";
            AssertEquals(s.Length, 5);
        }

        [Test]
        public void Interpolation()
        {
            var number = 54;
            var str = "hello";
            var s = $"Output: {str}: {number}";
            AssertEquals(s, "Output: hello: 54");
        }
    }
}
