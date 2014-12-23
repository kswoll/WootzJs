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

using System.Runtime.WootzJs;

namespace System.Reflection
{
    [Js(Export = false, Name = "Function")]
    public class JsTypeFunction : JsFunction
    {
        [Js(Name = SpecialNames.TypeField)]
        public Type Type;

        [Js(Name = SpecialNames.TypeName)]
        public string TypeName;

        [Js(Name = SpecialNames.TypeArgs)]
        public JsArray TypeArgs;

        [Js(Name = SpecialNames.BaseType)]
        public JsTypeFunction BaseType;

        [Js(Name = SpecialNames.BaseTypeArgs)]
        public JsArray BaseTypeArgs;

        [Js(Name = SpecialNames.IsTypeParameter)]
        public bool IsTypeParameter;

        [Js(Name = SpecialNames.ElementType)]
        public JsTypeFunction ElementType;

        [Js(Name = SpecialNames.ArrayType)]
        public JsTypeFunction ArrayType;

        [Js(Name = SpecialNames.GetTypeFromType)]
        public JsFunction GetTypeFromType;

        [Js(Name = SpecialNames.TypeInitializer)]
        public JsFunction TypeInitializer;

        [Js(Name = SpecialNames.CreateType)]
        public JsFunction CreateTypeField;

        [Js(Name = SpecialNames.GetAssembly)]
        public JsFunction GetAssembly;

        [Js(Name = SpecialNames.IsPrototypeInitialized)]
        public bool IsPrototypeInitialized;

        [Js(Name = "$CreateType")]
        public Type CreateType()
        {
            return null;
        }
    }
}
