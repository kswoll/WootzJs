using System.Runtime.WootzJs;

namespace System
{
	public abstract class Delegate
	{
		public static readonly Delegate Empty;

        private object target;
        private JsFunction jsFunction;

		public Delegate(object target)
		{
            this.target = target;
            this.jsFunction = this.As<JsFunction>();
		}

	    public object Target
	    {
	        get { return target; }
	    }

		public static Delegate Combine(Delegate a, Delegate b)
		{
			if (a == null)
                return b;
            else if (b == null)
                return a;
            else if (a is MulticastDelegate)
                return ((MulticastDelegate)a).Add(b);
            else
                return new MulticastDelegate(a.Target, new[] { a, b });
		}

		public static Delegate Remove(Delegate source, Delegate value)
		{
			if (source == value || source == null)
                return null;
            else
			{
			    var multicast = source as MulticastDelegate;
                if (multicast != null)
                {
                    return multicast.Remove(value);
                }
                else
                {
                    return source;
                }
			}
		}

/*
		public static Delegate Create(object instance, Function f)
		{
			return null;
		}
*/
		public static string CreateExport(Delegate d)
		{
			return null;
		}
		public static string CreateExport(Delegate d, bool multiUse)
		{
			return null;
		}
		public static string CreateExport(Delegate d, bool multiUse, string name)
		{
			return null;
		}
		public static void DeleteExport(string name)
		{
		}

        [Js(Export = false)]
        public static bool operator ==(Delegate d1, Delegate d2)
        {
            return false;
        }

        [Js(Export = false)]
        public static bool operator !=(Delegate d1, Delegate d2)
        {
            return false;
        }
    }
}
