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

using System.Globalization;
using System.Reflection;

namespace System.ComponentModel.DataAnnotations
{
    internal class LocalizableString
    {
        private string _propertyName;
        private string _propertyValue;
        private Type _resourceType;
        private Func<string> _cachedResult;

        public string Value
        {
            get { return this._propertyValue; }
            set
            {
                if (!(this._propertyValue != value))
                    return;
                this.ClearCache();
                this._propertyValue = value;
            }
        }

        public Type ResourceType
        {
            set
            {
                if (!(this._resourceType != value))
                    return;
                this.ClearCache();
                this._resourceType = value;
            }
        }

        public LocalizableString(string propertyName)
        {
            this._propertyName = propertyName;
        }

        public string GetLocalizableValue()
        {
            if (this._cachedResult == null)
            {
                if (this._propertyValue == null || this._resourceType == (Type)null)
                {
                    this._cachedResult = (Func<string>)(() => this._propertyValue);
                }
                else
                {
                    PropertyInfo property = this._resourceType.GetProperty(this._propertyValue);
                    bool flag = false;
                    if (!this._resourceType.IsVisible || property == (PropertyInfo)null || property.PropertyType != typeof (string))
                    {
                        flag = true;
                    }
                    else
                    {
                        MethodInfo getMethod = property.GetGetMethod();
                        if (getMethod == (MethodInfo)null || !getMethod.IsPublic || !getMethod.IsStatic)
                            flag = true;
                    }
                    if (flag)
                    {
                        this._cachedResult = (Func<string>)(() => { throw new InvalidOperationException("Localization Failed"); });
                    }
                    else
                        this._cachedResult = (Func<string>)(() => (string)property.GetValue((object)null, (object[])null));
                }
            }
            return this._cachedResult();
        }

        private void ClearCache()
        {
            this._cachedResult = (Func<string>)null;
        }
    }
}