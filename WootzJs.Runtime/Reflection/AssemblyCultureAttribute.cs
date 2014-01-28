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

namespace System.Reflection
{
    /// <summary>
    /// Specifies which culture the assembly supports.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    public sealed class AssemblyCultureAttribute : Attribute
    {
        private string m_culture;

        /// <summary>
        /// Gets the supported culture of the attributed assembly.
        /// </summary>
        /// 
        /// <returns>
        /// A string containing the name of the supported culture.
        /// </returns>
        public string Culture
        {
            get { return m_culture; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.AssemblyCultureAttribute"/> class with the culture supported by the assembly being attributed.
        /// </summary>
        /// <param name="culture">The culture supported by the attributed assembly. </param>
        public AssemblyCultureAttribute(string culture)
        {
            m_culture = culture;
        }
    }
}