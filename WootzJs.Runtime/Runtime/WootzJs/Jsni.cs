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
    /// <summary>
    /// This class contains a suite of methods that are handled specially by the compiler to allow
    /// you to express Javascript constructs that would either be impossible or more verbose to
    /// express in plain C#.
    /// </summary>
    [Js(Export = false)]
    public static class Jsni
    {
        /// <summary>
        /// This allows you to create a Javascript regular expression literal.  The result of invoking 
        /// this method will be the javascript `/pattern` (or `/pattern/suffix`).  
        /// </summary>
        public static extern JsRegExp regex(string pattern, string suffix = null);

        /// <summary>
        /// Normally when you `new` a class in C#, it will go through several hops, assuming it to be 
        /// a C# class with a constructor.  Using `Jsni.new` you can simply generate Javascript that 
        /// will apply the `new` operator to any 'ol expression.  The result of 
        /// `Jsni.new(Jsni.reference("Date"))` would be `new Date()`.
        /// </summary>
        public static extern JsObject @new(JsObject target, params JsObject[] arguments);

        /// <summary>
        /// Returns the special `arguments` "array" that represents the arguments passed to the 
        /// current function.
        /// </summary>
        public static extern JsObject arguments();

        /// <summary>
        /// Usually compiles to the same output as `this`.  However, for scenarios where there is
        /// no `this` in the current scope (i.e. static methods) you can use `Jsni.@this()` to 
        /// represent `this` regardless.  
        /// </summary>
        public static extern JsObject @this();
        public static extern JsObject apply(this JsObject target, JsObject thisReference, JsArray arguments);
        public static extern JsObject call(this JsObject target, JsObject thisReference, params JsObject[] arguments);
        public static extern JsObject apply<T>(Action<T> method, JsObject thisReference, JsArray arguments);
        public static extern JsObject call<T>(Action<T> method, JsObject thisReference, params JsObject[] arguments);

        /// <summary>
        /// Deletes a property from a Javascript object.  Compiles to the Javascript `delete` expression.
        /// `Jsni.delete(o.foo)` is compiled to `delete o.foo`.  It is imperative that the expression
        /// passed to this method represents a member reference expression (since the `delete` keyword
        /// makes the same restriction -- it's how it identifies both the property to delete and its
        /// containing object.)
        /// </summary>
        /// <param name="o"></param>
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
        public static extern JsObject member(this JsObject target, string name);
        public static extern JsObject memberset(this JsObject target, string name, JsObject value);

        /// <summary>
        /// Represents Javascript array-literal syntax.  For example:
        /// 
        /// var array = Jsni.Array(new[] { 1, 2, 3, 4 });
        /// 
        /// Will get compiled to:
        /// 
        /// var array = [1, 2, 3, 4];
        /// 
        /// Normally array creation will pass through some helper functions to ensure that it
        /// retains C# type information.
        /// </summary>
        /// <param name="elements">The elements of the array</param>
        /// <returns>The newly created Javascript array literal</returns>
        public static extern JsArray array(params JsObject[] elements);

        public static extern JsObject invoke(this JsObject target, params JsObject[] arguments);
// ReSharper disable once UnusedTypeParameter
        public static extern JsTypeFunction type<T>();
        public static extern JsTypeFunction type(Type type);

        /// <summary>
        /// Used to reference any arbitary Javascript identifier.  The specified identifier
        /// is compiled directly into Javascript as an identifier.  The specified string 
        /// MUST be a C# string-literal as the reference must be determined at compile-time.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static extern JsObject reference(string identifier);

        /// <summary>
        /// Standin for the parseInt() global Javascript function.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static extern JsNumber parseInt(string s, int radix = 0);

        /// <summary>
        /// Standin for the parseFloat() global Javascript function.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static extern JsNumber parseFloat(string s, int radix = 0);

        /// <summary>
        /// Standin for the isNaN() global Javascript function.
        /// </summary>
        /// <param name="number">The number to test whether it's a number</param>
        /// <returns>True if the specified number is not a number.</returns>
        public static extern bool isNaN(JsNumber number);

        /// <summary>
        /// Allows you to represent a Javascript `instanceof` expression in C#.  
        /// 
        /// Jsni.instanceOf(foo, Foo)
        /// 
        /// is compiled to:
        /// 
        /// foo instanceof Foo
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static extern bool instanceof(JsObject expression, JsObject type);

        /// <summary>
        /// Used to create raw Javascript objects.  The parameter `o` *must* be a literal
        /// anonymous type expression (as opposed to either a reference to an existing one, or
        /// some other object.)
        /// 
        /// For example, if you call:
        /// var o = Jsni.object(new { Foo = "bar" });
        /// 
        /// The generated Javascript will be:
        /// var o = { Foo: "bar" };
        /// 
        /// This is in contrast to how this would be compiled without the `Jsni.object` wrapper.
        /// In that (normal) scenario, the anonymous type would be treated as a C# anonymous 
        /// type, which means getters, setters, etc. will be generated for the type.  
        /// 
        /// Using this method can be helpful when interoperating with other Javascript libraries
        /// that expect ordinary Javascript objects.
        /// </summary>
        /// <param name="o">An anonymous type expression that represents the Javascript object
        /// literal you want to be output.</param>
        /// <param name="compact">Whether you want the Javascript output to be minified into a 
        /// single line.  This can be convenient when you don't want the generated object to
        /// distract readers of your Javascript from the surrounding code.</param>
        /// <returns>A JsObject that represents the newly created object.</returns>
        public static extern JsObject @object(object o, bool compact = false);

        public static extern string encodeURIComponent(string s);
        public static extern string decodeURIComponent(string s);

        // todo: Move this to Window object in WootzJs.Mvc
        public static extern JsObject getComputedStyle(JsObject element);

        public static extern void forin(this JsObject obj, Action<JsObject> iteration);
    }
}
