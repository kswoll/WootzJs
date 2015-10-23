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
using System.Text;
using WootzJs.Web;

namespace WootzJs.Mvc.Views.Css
{
    public class CssDeclaration
    {
        protected ElementStyle node;
        protected List<ICssDeclarationAction> actions = new List<ICssDeclarationAction>();

        internal virtual void Attach(ElementStyle node)
        {
            this.node = node;

            foreach (var action in actions)
            {
                action.Act(this);
            }
        }

        protected void Act(string name, string value)
        {
            Act(new CssSetAction(name, value));
        }

        protected void Act(ICssDeclarationAction action)
        {
            if (node == null)
                actions.Add(action);
            else
                action.Act(this);
        }

        protected string Get(string name)
        {
            if (node != null)
                return node[name];

            throw new InvalidOperationException("Not attached");
        }

        protected internal void Set(string name, object value)
        {
            var val = value.ToString();
            if (node == null)
                Act(name, val);
            else
                SetValue(name, val);
        }

        protected internal void SetValue(string name, string value)
        {
            node[name] = value;
        }

        protected internal bool IsSet(string name)
        {
            return node[name] != "";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var property in GetType().GetProperties())
            {
                var value = property.GetValue(this, null);
                if (value != null)
                {
                    builder.Append(property.Name + ":" + value + ";");
                }
            }
            return builder.ToString();
        } 
    }
}