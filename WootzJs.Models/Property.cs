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

using System;
using System.Reflection;

namespace WootzJs.Models
{
    public class Property
    {
        public event Action Changed;
        public event Action<Failure[]> Validated;

        private Model model;
        private PropertyInfo propertyInfo;

        public Property(Model model, PropertyInfo propertyInfo)
        {
            this.model = model;
            this.propertyInfo = propertyInfo;
        }

        public Model Model
        {
            get { return model; }
        }

        public string Name
        {
            get { return propertyInfo.Name; }
        }

        public string FullName
        {
            get { return propertyInfo.DeclaringType.FullName + "." + Name; }
        }

        public PropertyInfo PropertyInfo
        {
            get { return propertyInfo; }
        }

        public object Value
        {
            get { return propertyInfo.GetValue(model, null); }
            set { propertyInfo.SetValue(model, value, null); }
        }

        public void NotifyValidated(Failure[] failures)
        {
            OnValidated(failures);
        }

        protected virtual void OnValidated(Failure[] failures)
        {
            var validated = Validated;
            if (validated != null)
                validated(failures);
        }

        internal void NotifyChanged()
        {
            OnChanged();
        }

        protected virtual void OnChanged()
        {
            var changed = Changed;
            if (changed != null)
                changed();
        }
    }

    public class Property<TModel, TValue> : Property where TModel : Model<TModel>
    {
        public Property(TModel model, PropertyInfo propertyInfo) : base(model, propertyInfo)
        {
        }

        public new TValue Value
        {
            get { return (TValue)base.Value; }
            set { base.Value = value; }
        }
    }
}