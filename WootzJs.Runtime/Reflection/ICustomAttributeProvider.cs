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

namespace System.Reflection
{
    /// <summary>
    /// Provides custom attributes for reflection objects that support them.
    /// </summary>
    public interface ICustomAttributeProvider
    {
        /// <summary>
        /// Returns an array of custom attributes defined on this member, identified by type, or an empty array if there are no custom attributes of that type.
        /// </summary>
        /// 
        /// <returns>
        /// An array of Objects representing custom attributes, or an empty array.
        /// </returns>
        /// <param name="attributeType">The type of the custom attributes. </param><param name="inherit">When true, look up the hierarchy chain for the inherited custom attribute. </param><exception cref="T:System.TypeLoadException">The custom attribute type cannot be loaded. </exception><exception cref="T:System.Reflection.ArgumentNullException"><paramref name="attributeType"/> is null.</exception>
        object[] GetCustomAttributes(Type attributeType, bool inherit);

        /// <summary>
        /// Returns an array of all of the custom attributes defined on this member, excluding named attributes, or an empty array if there are no custom attributes.
        /// </summary>
        /// 
        /// <returns>
        /// An array of Objects representing custom attributes, or an empty array.
        /// </returns>
        /// <param name="inherit">When true, look up the hierarchy chain for the inherited custom attribute. </param><exception cref="T:System.TypeLoadException">The custom attribute type cannot be loaded. </exception><exception cref="T:System.Reflection.AmbiguousMatchException">There is more than one attribute of type <paramref name="attributeType"/> defined on this member. </exception>
        object[] GetCustomAttributes(bool inherit);

        /// <summary>
        /// Indicates whether one or more instance of <paramref name="attributeType"/> is defined on this member.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <paramref name="attributeType"/> is defined on this member; false otherwise.
        /// </returns>
        /// <param name="attributeType">The type of the custom attributes. </param><param name="inherit">When true, look up the hierarchy chain for the inherited custom attribute. </param>
        bool IsDefined(Type attributeType, bool inherit);
    }
}
