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
using System.Reflection;

namespace System
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public abstract class Attribute
    {
        protected Attribute()
        {
        }

        /// <summary>
        /// Determines whether any custom attributes are applied to a member of a type. Parameters specify the member, and the type of the custom attribute to search for.
        /// </summary>
        /// 
        /// <returns>
        /// true if a custom attribute of type <paramref name="attributeType"/> is applied to <paramref name="element"/>; otherwise, false.
        /// </returns>
        /// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo"/> class that describes a constructor, event, field, method, type, or property member of a class. </param><param name="attributeType">The type, or a base type, of the custom attribute to search for.</param><exception cref="T:System.ArgumentNullException"><paramref name="element"/> or <paramref name="attributeType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="attributeType"/> is not derived from <see cref="T:System.Attribute"/>. </exception><exception cref="T:System.NotSupportedException"><paramref name="element"/> is not a constructor, method, property, event, type, or field. </exception><filterpriority>1</filterpriority>
        public static bool IsDefined(MemberInfo element, Type attributeType)
        {
            return IsDefined(element, attributeType, true);
        }

        /// <summary>
        /// Determines whether any custom attributes are applied to a member of a type. Parameters specify the member, the type of the custom attribute to search for, and whether to search ancestors of the member.
        /// </summary>
        /// 
        /// <returns>
        /// true if a custom attribute of type <paramref name="attributeType"/> is applied to <paramref name="element"/>; otherwise, false.
        /// </returns>
        /// <param name="element">An object derived from the <see cref="T:System.Reflection.MemberInfo"/> class that describes a constructor, event, field, method, type, or property member of a class. </param><param name="attributeType">The type, or a base type, of the custom attribute to search for.</param><param name="inherit">If true, specifies to also search the ancestors of <paramref name="element"/> for custom attributes. </param><exception cref="T:System.ArgumentNullException"><paramref name="element"/> or <paramref name="attributeType"/> is null. </exception><exception cref="T:System.ArgumentException"><paramref name="attributeType"/> is not derived from <see cref="T:System.Attribute"/>. </exception><exception cref="T:System.NotSupportedException"><paramref name="element"/> is not a constructor, method, property, event, type, or field. </exception><filterpriority>1</filterpriority>
        public static bool IsDefined(MemberInfo element, Type attributeType, bool inherit)
        {
            if (element == null)
                throw new ArgumentNullException("element");
            if (attributeType == null)
                throw new ArgumentNullException("attributeType");
            if (!typeof(Attribute).IsAssignableFrom(attributeType))
                throw new ArgumentException("Argument must subclass Attribute");
            return element.GetCustomAttributes(attributeType, inherit).Any();
        }
    }
}