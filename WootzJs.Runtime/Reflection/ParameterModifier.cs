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
    public struct ParameterModifier
    {
        private bool[] _byRef;

        internal bool[] IsByRefArray
        {
            get { return this._byRef; }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the parameter at the specified index position is to be modified by the current <see cref="T:System.Reflection.ParameterModifier"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the parameter at this index position is to be modified by this <see cref="T:System.Reflection.ParameterModifier"/>; otherwise, false.
        /// </returns>
        /// <param name="index">The index position of the parameter whose modification status is being examined or set. </param>
        public bool this[int index]
        {
            get { return this._byRef[index]; }
            set { this._byRef[index] = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Reflection.ParameterModifier"/> structure representing the specified number of parameters.
        /// </summary>
        /// <param name="parameterCount">The number of parameters. </param><exception cref="T:System.ArgumentException"><paramref name="parameterCount"/> is negative. </exception>
        public ParameterModifier(int parameterCount)
        {
            if (parameterCount <= 0)
                throw new ArgumentException("Arg_ParmArraySize");
            this._byRef = new bool[parameterCount];
        }
    }
}
