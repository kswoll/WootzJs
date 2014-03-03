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

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Cache of <see cref="ValidationAttribute"/>s
    /// </summary>
    /// <remarks>
    /// This internal class serves as a cache of validation attributes and [Display] attributes.
    /// It exists both to help performance as well as to abstract away the differences between
    /// Reflection and TypeDescriptor.
    /// </remarks>
    internal class ValidationAttributeStore
    {
        private static ValidationAttributeStore _singleton = new ValidationAttributeStore();
        private Dictionary<Type, TypeStoreItem> _typeStoreItems = new Dictionary<Type, TypeStoreItem>();

        /// <summary>
        /// Gets the singleton <see cref="ValidationAttributeStore"/>
        /// </summary>
        internal static ValidationAttributeStore Instance
        {
            get { return _singleton; }
        }

        /// <summary>
        /// Retrieves the type level validation attributes for the given type.
        /// </summary>
        /// <param name="validationContext">The context that describes the type.  It cannot be null.</param>
        /// <returns>The collection of validation attributes.  It could be empty.</returns>
        internal IEnumerable<ValidationAttribute> GetTypeValidationAttributes(ValidationContext validationContext)
        {
            EnsureValidationContext(validationContext);
            TypeStoreItem item = this.GetTypeStoreItem(validationContext.ObjectType);
            return item.ValidationAttributes;
        }

        /// <summary>
        /// Retrieves the <see cref="DisplayAttribute"/> associated with the given type.  It may be null.
        /// </summary>
        /// <param name="validationContext">The context that describes the type.  It cannot be null.</param>
        /// <returns>The display attribute instance, if present.</returns>
        internal DisplayAttribute GetTypeDisplayAttribute(ValidationContext validationContext)
        {
            EnsureValidationContext(validationContext);
            TypeStoreItem item = this.GetTypeStoreItem(validationContext.ObjectType);
            return item.DisplayAttribute;
        }

        /// <summary>
        /// Retrieves the set of validation attributes for the property
        /// </summary>
        /// <param name="validationContext">The context that describes the property.  It cannot be null.</param>
        /// <returns>The collection of validation attributes.  It could be empty.</returns>
        internal IEnumerable<ValidationAttribute> GetPropertyValidationAttributes(ValidationContext validationContext)
        {
            EnsureValidationContext(validationContext);
            TypeStoreItem typeItem = this.GetTypeStoreItem(validationContext.ObjectType);
            PropertyStoreItem item = typeItem.GetPropertyStoreItem(validationContext.MemberName);
            return item.ValidationAttributes;
        }

        /// <summary>
        /// Retrieves the <see cref="DisplayAttribute"/> associated with the given property
        /// </summary>
        /// <param name="validationContext">The context that describes the property.  It cannot be null.</param>
        /// <returns>The display attribute instance, if present.</returns>
        internal DisplayAttribute GetPropertyDisplayAttribute(ValidationContext validationContext)
        {
            EnsureValidationContext(validationContext);
            TypeStoreItem typeItem = this.GetTypeStoreItem(validationContext.ObjectType);
            PropertyStoreItem item = typeItem.GetPropertyStoreItem(validationContext.MemberName);
            return item.DisplayAttribute;
        }

        /// <summary>
        /// Retrieves the Type of the given property.
        /// </summary>
        /// <param name="validationContext">The context that describes the property.  It cannot be null.</param>
        /// <returns>The type of the specified property</returns>
        internal Type GetPropertyType(ValidationContext validationContext)
        {
            EnsureValidationContext(validationContext);
            TypeStoreItem typeItem = this.GetTypeStoreItem(validationContext.ObjectType);
            PropertyStoreItem item = typeItem.GetPropertyStoreItem(validationContext.MemberName);
            return item.PropertyType;
        }

        /// <summary>
        /// Determines whether or not a given <see cref="ValidationContext"/>'s
        /// <see cref="ValidationContext.MemberName"/> references a property on
        /// the <see cref="ValidationContext.ObjectType"/>.
        /// </summary>
        /// <param name="validationContext">The <see cref="ValidationContext"/> to check.</param>
        /// <returns><c>true</c> when the <paramref name="validationContext"/> represents a property, <c>false</c> otherwise.</returns>
        internal bool IsPropertyContext(ValidationContext validationContext)
        {
            EnsureValidationContext(validationContext);
            TypeStoreItem typeItem = this.GetTypeStoreItem(validationContext.ObjectType);
            PropertyStoreItem item = null;
            return typeItem.TryGetPropertyStoreItem(validationContext.MemberName, out item);
        }

        /// <summary>
        /// Retrieves or creates the store item for the given type
        /// </summary>
        /// <param name="type">The type whose store item is needed.  It cannot be null</param>
        /// <returns>The type store item.  It will not be null.</returns>
        private TypeStoreItem GetTypeStoreItem(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            TypeStoreItem item = null;
            if (!this._typeStoreItems.TryGetValue(type, out item))
            {
                IEnumerable<Attribute> attributes =
                        type.GetCustomAttributes(true).Cast<Attribute>();
                item = new TypeStoreItem(type, attributes);
                this._typeStoreItems[type] = item;
            }
            return item;
        }

        /// <summary>
        /// Throws an ArgumentException of the validation context is null
        /// </summary>
        /// <param name="validationContext">The context to check</param>
        private static void EnsureValidationContext(ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }
        }

        /// <summary>
        /// Private abstract class for all store items
        /// </summary>
        private abstract class StoreItem
        {
            private static IEnumerable<ValidationAttribute> _emptyValidationAttributeEnumerable = new ValidationAttribute[0];

            private IEnumerable<ValidationAttribute> _validationAttributes;

            internal StoreItem(IEnumerable<Attribute> attributes)
            {
                this._validationAttributes = attributes.OfType<ValidationAttribute>();
                this.DisplayAttribute = attributes.OfType<DisplayAttribute>().SingleOrDefault();
            }

            internal IEnumerable<ValidationAttribute> ValidationAttributes
            {
                get { return this._validationAttributes; }
            }

            internal DisplayAttribute DisplayAttribute { get; set; }
        }

        /// <summary>
        /// Private class to store data associated with a type
        /// </summary>
        private class TypeStoreItem : StoreItem
        {
            private Type _type;
            private Dictionary<string, PropertyStoreItem> _propertyStoreItems;

            internal TypeStoreItem(Type type, IEnumerable<Attribute> attributes)
                : base(attributes)
            {
                this._type = type;
            }

            internal PropertyStoreItem GetPropertyStoreItem(string propertyName)
            {
                PropertyStoreItem item = null;
                if (!TryGetPropertyStoreItem(propertyName, out item))
                {
                    throw new ArgumentException("propertyName");
                }
                return item;
            }

            internal bool TryGetPropertyStoreItem(string propertyName, out PropertyStoreItem item)
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ArgumentNullException("propertyName");
                }

                if (this._propertyStoreItems == null)
                {
                    if (this._propertyStoreItems == null)
                    {
                        this._propertyStoreItems = this.CreatePropertyStoreItems();
                    }
                }
                if (!this._propertyStoreItems.TryGetValue(propertyName, out item))
                {
                    return false;
                }
                return true;
            }

            private Dictionary<string, PropertyStoreItem> CreatePropertyStoreItems()
            {
                Dictionary<string, PropertyStoreItem> propertyStoreItems = new Dictionary<string, PropertyStoreItem>();

                PropertyInfo[] properties = this._type.GetProperties();
                foreach (PropertyInfo property in properties) {
                    PropertyStoreItem item = new PropertyStoreItem(property.PropertyType, property.GetCustomAttributes(true).Cast<Attribute>());
                    propertyStoreItems[property.Name] = item;
                }

                return propertyStoreItems;
            }
        }

        /// <summary>
        /// Private class to store data associated with a property
        /// </summary>
        private class PropertyStoreItem : StoreItem
        {
            private Type _propertyType;

            internal PropertyStoreItem(Type propertyType, IEnumerable<Attribute> attributes)
                : base(attributes)
            {
                this._propertyType = propertyType;
            }

            internal Type PropertyType
            {
                get { return this._propertyType; }
            }
        }
    }
}