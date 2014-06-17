using System.Threading.Tasks;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Threading.Tasks
{
    [TestFixture]
    public class TaskContinuationTests
    {
        [Test]
        public void SimpleContinuation()
        {
            var task = Task.FromResult("foo");
            var continuation = task.ContinueWith(x => x.Result + "bar");
            "foobar".AssertEquals(continuation.Result);
        }

        [Test]
        public void AsyncContinuation()
        {
            var source = new TaskCompletionSource<string>();
            var task = source.Task.ContinueWith(x => x.Result + "bar");
            source.SetResult("foo");
            "foobar".AssertEquals(task.Result);
        }
    }
}