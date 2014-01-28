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
    /// Instructs a compiler to use a specific version number for the Win32 file version resource. The Win32 file version is not required to be the same as the assembly's version number.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false)]
    public sealed class AssemblyFileVersionAttribute : Attribute
    {
        private string _version;

        /// <summary>
        /// Gets the Win32 file version resource name.
        /// </summary>
        /// 
        /// <returns>
        /// A string containing the file version resource name.
        /// </returns>
        public string Version
        {
            get { return this._version; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.AssemblyFileVersionAttribute"/> class, specifying the file version.
        /// </summary>
        /// <param name="version">The file version. </param><exception cref="T:System.ArgumentNullException"><paramref name="version"/> is null. </exception>
        public AssemblyFileVersionAttribute(string version)
        {
            if (version == null)
                throw new ArgumentNullException("version");
            this._version = version;
        }
    }
}