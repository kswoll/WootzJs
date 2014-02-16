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
using System.Linq;

namespace System.Runtime.WootzJs
{
    public static class JsObjectConverter
    {
        public static JsObject ToJsonObject(this object o)
        {
            var result = new JsObject();
            foreach (var property in o.GetType().GetProperties())
            {
                result[property.Name] = property.GetValue(o, null).As<JsObject>();
            }
            return result;
        }

        public static T FromJsonObject<T>(this JsObject o) where T : new()
        {
            var result = new T();
            var properties = typeof(T).GetProperties().ToDictionary(x => x.Name.ToUpper());
            foreach (var propertyName in o)
            {
                var value = o[propertyName];
                PropertyInfo property;
                if (properties.TryGetValue(propertyName.ToUpper(), out property))
                {
                    property.SetValue(result, value, null);
                }
            }
            return result;
        }
    }
}