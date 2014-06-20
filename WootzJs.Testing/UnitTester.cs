using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace WootzJs.Testing
{
    public class UnitTester
    {
        private List<UnitTest> unitTests = new List<UnitTest>();

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
        } 
    }
}