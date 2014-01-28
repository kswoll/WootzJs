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

namespace System.Runtime.WootzJs
{
    [Js(Export = false)]
    public static class Jsni
    {
        public static extern JsRegExp regex(string pattern, string suffix = null);
        public static extern JsObject @new(JsObject target);
        public static extern JsObject arguments();
        public static extern JsObject @this();
        public static extern JsObject apply(JsObject target, JsObject thisReference, JsArray arguments);
        public static extern JsObject call(JsObject target, JsObject thisReference, params JsObject[] arguments);
        public static extern JsObject apply<T>(Action<T> method, JsObject thisReference, JsArray arguments);
        public static extern JsObject call<T>(Action<T> method, JsObject thisReference, params JsObject[] arguments);
        public static extern void delete(JsObject o);
        public static extern JsFunction procedure(Action a);
        public static extern JsFunction procedure(Action<JsObject> a, string nameOverride1 = null);
        public static extern JsFunction procedure(Action<JsObject, JsObject> a, string nameOverride1 = null, string nameOverride2 = null);
        public static extern JsFunction procedure(Action<JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null);
        public static extern JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null);
        public static extern JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null);
        public static extern JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null);
        public static extern JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a, 
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null);
        public static extern JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null, string nameOverride8 = null);
        public static extern JsFunction function(Func<JsObject> a);
        public static extern JsFunction function(Func<JsObject, JsObject> a, string nameOverride1 = null);
        public static extern JsFunction function(Func<JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null);
        public static extern JsFunction function(Func<JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null);
        public static extern JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null);
        public static extern JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null);
        public static extern JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null);
        public static extern JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null);
        public static extern JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null, string nameOverride8 = null);
        public static extern JsString _typeof(JsObject o);
        public static extern JsObject member(JsObject target, string name);
        public static extern JsObject memberset(JsObject target, string name, JsObject value);
        public static extern JsArray array(params JsObject[] elements);
        public static extern JsObject invoke(JsObject target, params JsObject[] arguments);
// ReSharper disable once UnusedTypeParameter
        public static extern JsTypeFunction type<T>();
        public static extern JsTypeFunction type(Type type);
        public static extern JsObject reference(string identifier);
        public static extern JsNumber parseInt(string s, int radix = 0);
        public static extern JsNumber parseFloat(string s, int radix = 0);
        public static extern bool isNaN(JsNumber number);
        public static extern bool instanceof(JsObject expression, JsObject type);
        public static extern JsObject @object(object o, bool compact = false);
    }
}
