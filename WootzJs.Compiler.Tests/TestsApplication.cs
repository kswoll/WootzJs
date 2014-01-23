using System;
using System.Linq;

namespace WootzJs.Compiler.Tests
{
    public class TestsApplication 
    {
        public static void Main()
        {
            Console.WriteLine("Entry points be working!");
            var assembly = typeof(TestsApplication).Assembly;
            Console.WriteLine(assembly.FullName);

            foreach (var type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeof(TestFixtureAttribute), false).Any())
                {
                    Console.WriteLine(type.FullName);
                    foreach (var currentMethod in type.GetMethods())
                    {
                        if (currentMethod.GetCustomAttributes(typeof(TestAttribute), false).Any())
                        {
                            Console.WriteLine(currentMethod.Name);

                            var instance = type.GetConstructors()[0].Invoke(new object[0]);
                            QUnit.RunTest(type.FullName + "." + currentMethod.Name, () => currentMethod.Invoke(instance, new object[0]));
                        }
                    }
                }
            }
        }
    }
}
