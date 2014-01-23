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

using System.Reflection;

namespace System.Runtime.WootzJs
{
    [Js(Export = false)]
    public static class Jsni
    {
        public static JsObject @new(JsObject target)
        {
            return null;
        }

        public static JsObject arguments()
        {
            return null;
        }

        public static JsObject @this()
        {
            return null;
        }

        public static JsObject apply(JsObject target, JsObject thisReference, JsArray arguments)
        {
            return null;
        }

        public static JsObject call(JsObject target, JsObject thisReference, params JsObject[] arguments)
        {
            return null;
        }

        public static JsObject apply<T>(Action<T> method, JsObject thisReference, JsArray arguments)
        {
            return null;
        }

        public static JsObject call<T>(Action<T> method, JsObject thisReference, params JsObject[] arguments)
        {
            return null;
        }

        public static void delete(JsObject o)
        {
        }

        public static JsFunction procedure(Action a)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject> a, string nameOverride1 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject> a, string nameOverride1 = null, string nameOverride2 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a, 
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null)
        {
            return null;
        }

        public static JsFunction procedure(Action<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null, string nameOverride8 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject> a)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject> a,
            string nameOverride1 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null)
        {
            return null;
        }

        public static JsFunction function(Func<JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject, JsObject> a,
            string nameOverride1 = null, string nameOverride2 = null, string nameOverride3 = null, string nameOverride4 = null, string nameOverride5 = null, 
            string nameOverride6 = null, string nameOverride7 = null, string nameOverride8 = null)
        {
            return null;
        }

        public static JsString _typeof(JsObject o)
        {
            return null;
        }

        public static JsObject member(JsObject target, string name)
        {
            return null;
        }

        public static JsObject memberset(JsObject target, string name, JsObject value)
        {
            return null;
        }

        public static JsArray array(params JsObject[] elements)
        {
            return null;
        }

        public static JsObject invoke(JsObject target, params JsObject[] arguments)
        {
            return null;
        }

        public static JsTypeFunction type<T>()
        {
            return null;
        }

        public static JsTypeFunction type(Type type)
        {
            return null;
        }

        public static JsObject reference(string identifier)
        {
            return null;
        }

        public static JsNumber parseInt(string s, int radix = 0)
        {
            return null;
        }

        public static bool isNaN(JsNumber number)
        {
            return false;
        }

        public static bool instanceof(JsObject expression, JsObject type)
        {
            return false;
        }
    }
}
