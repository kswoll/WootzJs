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

namespace System.Runtime.WootzJs
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Constructor | AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Parameter)]
    public class JsAttribute : Attribute
    {
        /// <summary>
        /// If false (defaults to true), the given symbol will not be exported to Javascript.
        /// </summary>
        public bool Export { get; set; }

        /// <summary>
        /// If not null, this name will be used to identify the symbol, rather than the compiler-generated
        /// name.  This is useful when integrating external Javascript APIs.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If true, all invocations to the method or property will be invoked by proxy.  method.apply(this, arguments);
        /// This can be useful when creating a stand-in class that represents a built-in type.
        /// </summary>
        public bool Extension { get; set; }

        /// <summary>
        /// When true, the class declaration will not be written out, but all the member declarations will.  This allows you to
        /// instrument an existing built-in type.
        /// </summary>
        public bool BuiltIn { get; set; }

        /// <summary>
        /// Allows you to specify additional built-in types that will be instrumented.
        /// </summary>
        public string[] ExtraBuiltInExports { get; set; }

        /// <summary>
        /// Forces the class to behave as though it were subclassing this type.  This is mostly used for
        /// native structs that cannot subclass in C# but where it is desired to inherit behavior from a 
        /// common type.
        /// </summary>
        public Type BaseType { get; set; }

        /// <summary>
        /// Replaces instantiations of this class with invocations of the class as though it were a function.
        /// For example, the jQuery class uses this value in conjunction with overriding the name to `$` such
        /// that instead of `new jQuery(...)` resolving to `new $(...)` it instead generates `$(...)`.
        /// </summary>
        public bool InvokeConstructorAsClass { get; set; }

        /// <summary>
        /// If present, the body of the method is irrelevant and thus should be declared extern.  Instead, the body
        /// will be populated by the string contained in this property.  This text should be raw Javascript, not 
        /// C#.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// This property is very similar to Code except that the text of the property is treated as inline code
        /// rather than as the body of the method.
        /// </summary>
        public string Inline { get; set; }

        public JsAttribute()
        {
            Export = true;
        }
    }
}
