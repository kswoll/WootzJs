using System.Reflection;
using System.Threading.Tasks;

namespace WootzJs.Testing
{
    public class UnitTester
    {
        public static Task RunTest(object instance, MethodInfo method)
        {
            var result = method.Invoke(instance, new object[0]);
            if (typeof(Task).IsAssignableFrom(method.ReturnType))
            {
                var task = (Task)result;
                return task;
            }
            else
            {
                return Task.FromResult<object>(null);
            }
        } 
    }
}