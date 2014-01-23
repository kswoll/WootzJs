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

using System.Globalization;

namespace System.Reflection
{
    /// <summary>
    /// Describes an assembly's unique identity in full.
    /// </summary>
    public sealed class AssemblyName 
    {
        private CultureInfo _CultureInfo;
        private string _CodeBase;

        /// <summary>
        /// Gets or sets the simple name of the assembly. This is usually, but not necessarily, the file name of the manifest file of the assembly, minus its extension.
        /// </summary>
        /// 
        /// <returns>
        /// The simple name of the assembly.
        /// </returns>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the culture supported by the assembly.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents the culture supported by the assembly.
        /// </returns>
        public CultureInfo CultureInfo
        {
            get { return this._CultureInfo; }
            set { this._CultureInfo = value; }
        }

        /// <summary>
        /// Gets or sets the name of the culture associated with the assembly.
        /// </summary>
        /// 
        /// <returns>
        /// The culture name.
        /// </returns>
        public string CultureName
        {
            get
            {
                if (this._CultureInfo != null)
                    return this._CultureInfo.Name;
                else
                    return (string)null;
            }
        }

        /// <summary>
        /// Gets or sets the location of the assembly as a URL.
        /// </summary>
        /// 
        /// <returns>
        /// A string that is the URL location of the assembly.
        /// </returns>
        public string CodeBase
        {
            get { return this._CodeBase; }
            set { this._CodeBase = value; }
        }

        /// <summary>
        /// Gets the full name of the assembly, also known as the display name.
        /// </summary>
        /// 
        /// <returns>
        /// A string that is the full name of the assembly, also known as the display name.
        /// </returns>
        public string FullName
        {
            get { return Name; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.AssemblyName"/> class.
        /// </summary>
        public AssemblyName()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.AssemblyName"/> class with the specified display name.
        /// </summary>
        /// <param name="assemblyName">The display name of the assembly, as returned by the <see cref="P:System.Reflection.AssemblyName.FullName"/> property.</param><exception cref="T:System.ArgumentNullException"><paramref name="assemblyName"/> is null.</exception><exception cref="T:System.ArgumentException"><paramref name="assemblyName"/> is a zero length string.</exception><exception cref="T:System.IO.FileLoadException">The referenced assembly could not be found, or could not be loaded.</exception>
        public AssemblyName(string assemblyName)
        {
            this.Name = assemblyName;
        }

        /// <summary>
        /// Returns the full name of the assembly, also known as the display name.
        /// </summary>
        /// 
        /// <returns>
        /// The full name of the assembly, or the class name if the full name cannot be determined.
        /// </returns>
        public override string ToString()
        {
            return this.FullName ?? base.ToString();
        }
    }
}
