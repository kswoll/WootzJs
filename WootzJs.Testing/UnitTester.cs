using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.WootzJs;
using System.Threading.Tasks;
using System.Linq;

namespace WootzJs.Testing
{
    public class UnitTester
    {
        private List<UnitTest> unitTests = new List<UnitTest>();
        private HashSet<UnitTest> outstandingTests;

        public void QueueTest(object instance, MethodInfo method)
        {
            var unitTest = new UnitTest
            {
                Instance = instance,
                Method = method
            };
            unitTests.Add(unitTest);
        }

        public void RunTests()
        {
            outstandingTests = new HashSet<UnitTest>(unitTests);
            foreach (var test in unitTests)
            {
                RunTest(test);
            }
        }

        public async void RunTest(UnitTest test)
        {
            Assert.CurrentTest = test;
            var result = test.Method.Invoke(test.Instance, new object[0]);
            if (test.Method.ReturnType != typeof(void) && typeof(Task).IsAssignableFrom(test.Method.ReturnType))
            {
                var task = (Task)result;
                await task;
            }
            test.Assertions.Add(new Assertion());
            Assert.CurrentTest = null;

            ReportTest(test);
        } 

        private void ReportTest(UnitTest test)
        {
            Console.WriteLine(test.Method);
            Console.WriteLine("Passed: " + test.Assertions.Count(x => x.Status == AssertionStatus.Passed) + 
                ", Failed: " + test.Assertions.Count(x => x.Status == AssertionStatus.Errored) + 
                ", Errored: " + test.Assertions.Count(x => x.Status == AssertionStatus.Errored));

            outstandingTests.Remove(test);
            if (!outstandingTests.Any())
                Finished();
            if (outstandingTests.Count == 2)
            {
                foreach (var outstandingTest in outstandingTests)
                {
                    Console.WriteLine("Problem: " + outstandingTest.Method);
                }
            }
        }

        private void Finished()
        {
            Console.WriteLine("Finished.");
            Console.WriteLine(unitTests.Count(x => x.Assertions.All(y => y.Status == AssertionStatus.Passed)) + " passed.");
            Console.WriteLine(unitTests.Count(x => x.Assertions.All(y => y.Status == AssertionStatus.Failed)) + " had one or more assertions fail.");
            Console.WriteLine(unitTests.Count(x => x.Assertions.All(y => y.Status == AssertionStatus.Errored)) + " threw an unhandled exception.");
        }
    }
}