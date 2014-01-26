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
            QUnit.AreEqual(s, "FOO");
        }

        [Test]
        public void ToLower()
        {
            var s = "FOO";
            s = s.ToLower();
            QUnit.AreEqual(s, "foo");
        }

        [Test]
        public void Length()
        {
            var s = "FOO";
            int length = s.Length;
            QUnit.AreEqual(length, 3);
        }

        [Test]
        public void EndsWith()
        {
            var s = "HelloWorld";
            QUnit.IsTrue(s.EndsWith("World"));
        }

        [Test]
        public void StartsWith()
        {
            var s = "HelloWorld";
            QUnit.IsTrue(s.StartsWith("Hello"));
        }

        [Test]
        public void Compare()
        {
            QUnit.AreEqual(string.Compare("a", "b"), -1);
            QUnit.AreEqual(string.Compare("b", "a"), 1);
            QUnit.AreEqual(string.Compare("a", "a"), 0);
        }

        [Test]
        public void IndexOf()
        {
            var s = "12341234";
            String two = "2";
            QUnit.AreEqual(s.IndexOf(two), 1);
            QUnit.AreEqual(s.IndexOf("2", 4), 5);
            QUnit.AreEqual(s.IndexOf('2'), 1);
            QUnit.AreEqual(s.IndexOf('2', 4), 5);
        }

        [Test]
        public void LastIndexOf()
        {
            var s = "12341234";
            QUnit.AreEqual(s.LastIndexOf("2"), 5);
            QUnit.AreEqual(s.LastIndexOf("2", 4), 1);
            QUnit.AreEqual(s.LastIndexOf('2'), 5);
            QUnit.AreEqual(s.LastIndexOf('2', 4), 1);
        }

        [Test]
        public void Substring()
        {
            var s = "12341234";
            QUnit.AreEqual(s.Substring(4, 2), "12");
            QUnit.AreEqual(s.Substring(6), "34");
        }

        [Test]
        public void SplitCharArray()
        {
            var s = "12a34b56c78";
            var parts = s.Split('a', 'b', 'c');
            QUnit.AreEqual(parts.Length, 4);
            QUnit.AreEqual(parts[0], "12");
            QUnit.AreEqual(parts[1], "34");
            QUnit.AreEqual(parts[2], "56");
            QUnit.AreEqual(parts[3], "78");
        }

        [Test]
        public void SplitCharArrayWithCount()
        {
            var s = "12a34b56c78";
            var parts = s.Split(new[] { 'a', 'b', 'c' }, 3);
            QUnit.AreEqual(parts.Length, 3);    
            QUnit.AreEqual(parts[0], "12");
            QUnit.AreEqual(parts[1], "34");
            QUnit.AreEqual(parts[2], "56");
        }

        [Test]
        public void CharCode()
        {
            char b = 'b';
            char a = 'a';
            int i = b - a;
            QUnit.AreEqual(i, 1);
        }

        [Test]
        public void PreIncrementCharacter()
        {
            char b = 'b';
            var c = ++b;
            QUnit.AreEqual(b, 'c');
            QUnit.AreEqual(c, 'c');
        }

        [Test]
        public void PostIncrementCharacter()
        {
            char b = 'b';
            var stillB = b++;
            QUnit.AreEqual(b, 'c');
            QUnit.AreEqual(stillB, 'b');
        }

        [Test]
        public void StringFormat()
        {
            var s = "1) {0} 2) {1}";
            var result = string.Format(s, 1, 2);
            QUnit.AreEqual(result, "1) 1 2) 2");
        }

        [Test]
        public void Foreach()
        {
            var s = "1234";
            var chars = s.ToArray();
            QUnit.AreEqual(s[0], '1');
            QUnit.AreEqual(s[1], '2');
            QUnit.AreEqual(s[2], '3');
            QUnit.AreEqual(s[3], '4');
        }
    }
}
