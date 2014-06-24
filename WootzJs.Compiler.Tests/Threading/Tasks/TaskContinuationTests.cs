using System.Threading.Tasks;
using WootzJs.Testing;

namespace WootzJs.Compiler.Tests.Threading.Tasks
{
    public class TaskContinuationTests : TestFixture
    {
        [Test]
        public void SimpleContinuation()
        {
            var task = Task.FromResult("foo");
            var continuation = task.ContinueWith(x => x.Result + "bar");
            AssertEquals("foobar", continuation.Result);
        }

        [Test]
        public void AsyncContinuation()
        {
            var source = new TaskCompletionSource<string>();
            var task = source.Task.ContinueWith(x => x.Result + "bar");
            source.SetResult("foo");
            AssertEquals("foobar", task.Result);
        }
    }
}