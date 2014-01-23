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
using System.Runtime.WootzJs;

namespace WootzJs.Compiler.Tests.Reflection
{
    [TestFixture]
    public class AssemblyTests
    {
        [Test]
        public void FullName()
        {
            var assembly = typeof(TestsApplication).Assembly;
            QUnit.AreEqual(assembly.FullName, "WootzJs.Compiler.Tests");
        }

        [Test]
        public void AllAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var mscorlib = assemblies[0];
            var tests = assemblies[1];

            QUnit.AreEqual(mscorlib.FullName, "mscorlib");
            QUnit.AreEqual(tests.FullName, "WootzJs.Compiler.Tests");
        }

        [Test]
        public void TypeByName()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()[1];
            var type = assembly.GetType("WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass");
            QUnit.IsTrue(type != null);
        }

        [Test]
        public void TypeByNameThrowsOnNotFound()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()[1];
            try
            {
                var type = assembly.GetType("WootzJs.Compiler.Tests.Reflection.AssemblyTests.InvalidClass", true);
                QUnit.IsTrue(false);
            }
            catch (Exception e)
            {
                QUnit.IsTrue(true);
            }
        }

        [Test]
        public void TypeByNameIgnoreCase()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies()[1];
            var type = assembly.GetType("WOOTZJS.COMPILER.TESTS.REFLECTION.ASSEMBLYTESTS.TESTCLASS", false, true);
            QUnit.IsTrue(type != null);
        }
/*

        [Js(Inline = true)]
        public void GetTypes()
        {
            QUnit.RunTest("AssemblyTests.FullName", () =>
            {
                var assembly = typeof(TestsApplication).Assembly;
                QUnit.AreEqual(assembly.FullName, "WootzJs.Compiler.Tests");
            });
        }
*/

        public class TestClass
        {
        }
    }
}
