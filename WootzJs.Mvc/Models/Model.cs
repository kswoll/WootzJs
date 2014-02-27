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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.WootzJs;

namespace WootzJs.Mvc.Models
{
    public interface IModel
    {
        ControllerContext ControllerContext { get; }
    }

    public abstract class Model : IAutoNotifyPropertyChanged, IModel
    {
        public ControllerContext ControllerContext { get; set; }
        public IReadOnlyList<Property> Properties { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                OnPropertyChanged(propertyName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
        }

        public void Validate(ValidateEvent e)
        {
        }
    }

    public class Model<T> : Model where T : Model<T>
    {
        public Model()
        {
            var properties = new List<Property>();
            foreach (var prop in GetType().GetProperties())
            {
                var unconstructedType = typeof(Property<,>);
                var constructedType = unconstructedType.MakeGenericType(typeof(T), prop.PropertyType);
                var constructor = constructedType.GetConstructors()[0];
                var property = constructor.Invoke(null, new object[] { this, prop });
                properties.Add(property);
            }
            Properties = properties;
        }

        public Property GetProperty<TValue>(Expression<Func<T, TValue>> expression)
        {
            var propertyName = expression.GetPropertyName();
            return Properties.Single(x => x.Name == propertyName);
        }
    }
}