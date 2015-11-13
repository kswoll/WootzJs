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

using System.Linq;
using System.Runtime.WootzJs;

namespace System
{
	public class MulticastDelegate : Delegate
	{
        private Delegate only;
        private Delegate[] all;

        public MulticastDelegate(object target, Delegate invocationList) : base(target)
        {
            only = invocationList;
        }

        public MulticastDelegate(object target, Delegate[] invocationList) : base(target)
        {
            all = invocationList;
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
            var newInvocationList = only == null && all == null ? toAdd : only == null ? all.Concat(toAdd).ToArray() : new[] { only }.Concat(toAdd).ToArray();
            return new MulticastDelegate(Target, newInvocationList);
//            return constructor.Invoke(new[] { Target }.Concat(newInvocationList).ToArray()).As<Delegate>();            
        }

        [Js(Extension = true)]
        public Delegate Remove(Delegate value)
        {
            var constructor = GetType().GetConstructors()[0];
            var newInvocationList = only == null && all == null ? null : all == null ? new[] { only }.Except(new[] { value }).ToArray() : all.Except(new[] { value }).ToArray();
            if (newInvocationList.Length == 0)
                return null;
            return new MulticastDelegate(Target, newInvocationList);
//            return constructor.Invoke(new[] { Target }.Concat(newInvocationList).ToArray()).As<Delegate>();
        }
	}
}
