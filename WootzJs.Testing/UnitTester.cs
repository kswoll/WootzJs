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

        public void QueueTest(TestFixture instance, MethodInfo method)
        {
            var unitTest = new UnitTest
            {
                Instance = instance,
                Method = method
            };
            unitTests.Add(unitTest);
            instance.SetUnitTest(unitTest);
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
            var result = test.Method.Invoke(test.Instance, new object[0]);
            if (test.Method.ReturnType != typeof(void) && typeof(Task).IsAssignableFrom(test.Method.ReturnType))
            {
                var task = (Task)result;
                await task;
            }

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
            var passed = unitTests.Where(x => x.Assertions.All(y => y.Status == AssertionStatus.Passed) && x.Assertions.Any());
            var empty = unitTests.Where(x => !x.Assertions.Any());
            var failed = unitTests.Where(x => x.Assertions.Any(y => y.Status == AssertionStatus.Failed));
            var errored = unitTests.Where(x => x.Assertions.Any(y => y.Status == AssertionStatus.Errored));

            Console.WriteLine("Finished.");
            Console.WriteLine(passed.Count() + " passed.");
            Console.WriteLine(empty.Count() + " failed to make any assertions.");
            Console.WriteLine(failed.Count() + " had one or more assertions fail.");
            Console.WriteLine(errored.Count() + " threw an unhandled exception.");

            if (empty.Any())
            {
                Console.WriteLine("No Assertions:");
                foreach (var test in empty)
                {
                    Console.WriteLine(test.Method);
                }
            }
            if (failed.Any() || errored.Any())
            {
                Console.WriteLine("Failures:");
                foreach (var test in failed)
                {
                    Console.WriteLine(test.Method);
                    foreach (var assertion in test.Assertions.Where(x => x.Status == AssertionStatus.Failed || x.Status == AssertionStatus.Errored))
                    {
                        if (assertion.Status == AssertionStatus.Failed)
                        {
                            Console.WriteLine("Failed: " + assertion.Message);
                        }
                        else
                        {
                            Console.WriteLine("Error: " + assertion.Error);
                        }
                    }
                }
            }
        }
    }
}