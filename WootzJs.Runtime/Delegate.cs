#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

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
            else if (a.As<JsObject>().member("all"))
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
			    if (source.As<JsObject>().member("all"))
			        return ((MulticastDelegate)source).Remove(value);
			    else
			        return source;
			}
		}

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static extern bool operator ==(Delegate d1, Delegate d2);
        public static extern bool operator !=(Delegate d1, Delegate d2);

        public object DynamicInvoke(params object[] args)
        {
            return Jsni.apply(this.As<JsObject>(), this.As<JsObject>(), args.As<JsArray>());
        }
    }
}
