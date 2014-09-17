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
            return (T)FromJsonObject(o, typeof(T));
        }

        public static object FromJsonObject(JsObject o, Type type)
        {
            var result = Activator.CreateInstance(type);
            var properties = type.GetProperties().ToDictionary(x => x.Name.ToUpper());
            foreach (var propertyName in o)
            {
                var value = o[propertyName];
                PropertyInfo property;
                if (properties.TryGetValue(propertyName.ToUpper(), out property))
                {
                    if (property.PropertyType.IsArray)
                    {
                        var arrayValue = value.As<JsArray>();
                        var elementType = property.PropertyType.GetElementType();
                        var array = Array.CreateInstance(elementType, arrayValue.length);
                        for (var i = 0; i < arrayValue.length; i++)
                        {
                            array.SetValue(FromJsonObject(arrayValue[i], elementType), i);
                        }
                        value = array.As<JsObject>();
                    }
                    else if (!property.PropertyType.IsPrimitive && property.PropertyType != typeof(string) && property.PropertyType != typeof(DateTime) && !typeof(Enum).IsAssignableFrom(property.PropertyType))
                    {
                        value = FromJsonObject(value, property.PropertyType).As<JsObject>();
                    }
/*
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        
                    }
*/
                    property.SetValue(result, value, null);
                }
            }
            return result;
        }
    }
}