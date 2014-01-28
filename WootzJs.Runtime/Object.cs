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

using System.Reflection;
using System.Runtime.WootzJs;

namespace System
{
	public class Object
	{
        [Js(Name = SpecialNames.TypeField, Export = false)]
        internal JsTypeFunction ___type;

	    /// <summary>
		/// Retrieves the type associated with an object instance.
		/// </summary>
		/// <returns>The type of the object.</returns>
		public Type GetType()
		{
			return Type._GetTypeFromInstance(this.As<JsObject>());
		}

		/// <summary>
		/// Converts an object to its string representation.
		/// </summary>
		/// <returns>The string representation of the object.</returns>
		public virtual string ToString()
		{
// ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (this == null)
                return "";
			return this.As<JsObject>().toString();
		}

		/// <summary>
		/// Converts an object to its culture-sensitive string representation.
		/// </summary>
		/// <returns>The culture-sensitive string representation of the object.</returns>
		public virtual string ToLocaleString()
		{
			return null;
		}

        public virtual bool Equals(object obj)
        {
            return this == obj;
        }

        public virtual int GetHashCode()
        {
            return GetStringHashCode().GetHashCode();
        }

        /// <summary>
        /// This is the more important hash function in Javascript, since we use Javascript objects with strings as keys as the base for 
        /// dictionary data structures.
        /// </summary>
        /// <returns></returns>
        public virtual string GetStringHashCode()
        {
            return this.As<JsObject>().toString();
        }

        /// <summary>
        /// All == comparisons are reference comparisons in Javascript, so this method is implemented just that way.  The compiler will unwrap
        /// this method so that o1 is compared to o2 as an == comparison.  However, this method still serves its original function -- if you 
        /// want to bypass == overloading, this is the way to go.
        /// </summary>
        /// <param name="o1">The left side of the comparison</param>
        /// <param name="o2">The right side of the comparison</param>
        /// <returns>True if o1 is literally the same object as o2.</returns>
        public static bool ReferenceEquals(object o1, object o2)
        {
            return true;
        }

        public Type MakeArrayType()
        {
            return MakeArrayType(1);
        }

        public Type MakeArrayType(int rank)
        {
            if (rank > 1)
                throw new InvalidOperationException("Rank must be 1");
            return Type._GetTypeFromTypeFunc(SpecialFunctions.MakeArrayType(___type));
        }
	}
}
