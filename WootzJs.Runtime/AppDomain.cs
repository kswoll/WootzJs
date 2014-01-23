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
    public class AppDomain
    {
        private static AppDomain instance = new AppDomain();

        public static AppDomain CurrentDomain
        {
            get { return instance; }
        }

        /// <summary>
        /// Gets the assemblies that have been loaded into the execution context of this application domain.
        /// </summary>
        /// 
        /// <returns>
        /// An array of assemblies in this application domain.
        /// </returns>
        /// <exception cref="T:System.AppDomainUnloadedException">The operation is attempted on an unloaded application domain. </exception><filterpriority>2</filterpriority>
        public Assembly[] GetAssemblies()
        {
            var array = Jsni.reference("$assemblies").As<JsArray>();
            var result = new Assembly[array.length];
            for (var i = 0; i < result.Length; i++)
            {
                var getAssembly = array[i].As<JsFunction>();
                result[i] = getAssembly.invoke().As<Assembly>();
            }

            return result;
        }
    }
}
