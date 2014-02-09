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

namespace System.Reactive.PlatformServices
{
    /// <summary>
    /// (Infrastructure) Interface for enlightenment providers.
    /// </summary>
    /// <remarks>
    /// This type is used by the Rx infrastructure and not meant for public consumption or implementation.
    /// No guarantees are made about forward compatibility of the type's functionality and its usage.
    /// </remarks>
    public interface IPlatformEnlightenmentProvider
    {
        /// <summary>
        /// (Infastructure) Tries to gets the specified service.
        /// </summary>
        /// <typeparam name="T">Service type.</typeparam>
        /// <param name="args">Optional set of arguments.</param>
        /// <returns>Service instance or null if not found.</returns>
        T GetService<T>(params object[] args) where T : class;
    }

    /// <summary>
    /// (Infrastructure) Provider for platform-specific framework enlightenments.
    /// </summary>
    /// <remarks>
    /// This type is used by the Rx infrastructure and not meant for public consumption or implementation.
    /// </remarks>
    public static class PlatformEnlightenmentProvider
    {
        private static IPlatformEnlightenmentProvider s_current;

        /// <summary>
        /// (Infrastructure) Gets the current enlightenment provider. If none is loaded yet, accessing this property triggers provider resolution.
        /// </summary>
        /// <remarks>
        /// This member is used by the Rx infrastructure and not meant for public consumption or implementation.
        /// </remarks>
        public static IPlatformEnlightenmentProvider Current
        {
            get
            {
                if (s_current == null)
                {
                    if (s_current == null)
                    {
                        var ifType = typeof(IPlatformEnlightenmentProvider);
                        var asm = new AssemblyName(ifType.Assembly.FullName);
                        asm.Name = "System.Reactive.PlatformServices";
                        var name = "System.Reactive.PlatformServices.CurrentPlatformEnlightenmentProvider, " + asm.FullName;

                        var t = Type.GetType(name);
                        if (t != null)
                            s_current = (IPlatformEnlightenmentProvider)Activator.CreateInstance(t);
                        else
                            s_current = new DefaultPlatformEnlightenmentProvider();
                    }
                }

                return s_current;
            }

            set
            {
                s_current = value;
            }
        }
    }

    class DefaultPlatformEnlightenmentProvider : IPlatformEnlightenmentProvider
    {
        public T GetService<T>(object[] args) where T : class
        {
            return null;
        }
    }
}