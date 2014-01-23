using System.Linq;
using System.Runtime.WootzJs;

namespace System
{
	public class MulticastDelegate : Delegate
	{
        private Delegate[] invocationList;

        public MulticastDelegate(object target, Delegate[] invocationList) : base(target)
        {
            this.invocationList = invocationList;
        }

        [Js(Name = "GetType")]
        public new Type GetType()
        {
            return base.GetType();
        }

        [Js(Extension = true)]
        public Delegate Add(Delegate value)
        {
            var constructor = GetType().GetConstructors()[0];
            var toAdd = new[] { value };
            var newInvocationList = invocationList == null ? toAdd : invocationList.Concat(toAdd).ToArray();
            return new MulticastDelegate(Target, newInvocationList);
//            return constructor.Invoke(new[] { Target }.Concat(newInvocationList).ToArray()).As<Delegate>();            
        }

        [Js(Extension = true)]
        public Delegate Remove(Delegate value)
        {
            var constructor = GetType().GetConstructors()[0];
            var newInvocationList = invocationList.Except(new[] { value }).ToArray();
            return new MulticastDelegate(Target, newInvocationList);
//            return constructor.Invoke(new[] { Target }.Concat(newInvocationList).ToArray()).As<Delegate>();
        }
	}
}
