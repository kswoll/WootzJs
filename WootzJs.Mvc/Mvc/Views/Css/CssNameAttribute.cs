using System;

namespace WootzJs.Mvc.Mvc.Views.Css
{
    public class CssNameAttribute : Attribute
    {
        private string name;

        public CssNameAttribute(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }
    }
}