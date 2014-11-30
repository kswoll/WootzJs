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
using System.Reflection;
using System.Runtime.WootzJs;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Reflection
{
    public class AssemblyTests : TestFixture
    {
        [Test]
        public void FullName()
        {
            var assembly = typeof(TestsApplication).Assembly;
            AssertEquals(assembly.FullName, "WootzJs.Compiler.Tests");
        }

/*
 * This test is too brittle.  Commenting out.
        [Test]
        public void AllAssemblies()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var mscorlib = assemblies[0];
            var system = assemblies[1];
            var systemComponentModelDataAnnotations = assemblies[2];
            var tests = assemblies[5];

            AssertEquals(mscorlib.FullName, "mscorlib");
            AssertEquals(system.FullName, "System");
            AssertEquals(systemComponentModelDataAnnotations.FullName, "System.ComponentModel.DataAnnotations");
            AssertEquals(tests.FullName, "WootzJs.Compiler.Tests");
        }
*/

        [Test]
        public void TypeByName()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Last();
            var type = assembly.GetType("WootzJs.Compiler.Tests.Reflection.AssemblyTests.TestClass");
            AssertTrue((type != null));
        }

        [Test]
        public void TypeByNameThrowsOnNotFound()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Last();
            try
            {
                var type = assembly.GetType("WootzJs.Compiler.Tests.Reflection.AssemblyTests.InvalidClass", true);
                AssertTrue(false);
            }
            catch (Exception e)
            {
                AssertTrue(true);
            }
        }

        [Test]
        public void TypeByNameIgnoreCase()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Last();
            var type = assembly.GetType("WOOTZJS.COMPILER.TESTS.REFLECTION.ASSEMBLYTESTS.TESTCLASS", false, true);
            AssertTrue((type != null));
        }

        [Test]
        public void AssemblyTitle()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().Last();
            var assemblyTitleAttribute = (AssemblyTitleAttribute)assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];
            AssertEquals(assemblyTitleAttribute.Title, "WootzJs.Compiler.Tests");
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
