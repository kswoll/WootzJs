using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace WootzJs.Compiler
{
    public class Profiler
    {
        public static TextWriter Output = Console.Out;

        public static Task Time(string name, Func<Task> action)
        {
            return Time<Task>(name, async () =>
            {
                await action();
                return null;
            });
        } 

        public static async Task<T> Time<T>(string name, Func<Task<T>> action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = await action();
            stopwatch.Stop();
            Output.WriteLine(name + ": "+ stopwatch.Elapsed);
            Output.Flush();
            return result;
        }

        public static void Time(string name, Action action)
        {
            Time(name, (Func<object>)(() => 
            {
                action();
                return null;
            }));
        }

        public static T Time<T>(string name, Func<T> action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = action();
            stopwatch.Stop();
            Output.WriteLine(name + ": "+ stopwatch.Elapsed);
            Output.Flush();
            return result;
        }
    }
}