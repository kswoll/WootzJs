using System;

namespace WootzJs.Mvc.Views.Css
{
    public class CssSetAction : ICssDeclarationAction
    {
        public Func<string> Name { get; set; }
        public string Value { get; set; }

        public CssSetAction(Func<string> name, string value)
        {
            Name = name;
            Value = value;
        }

        public void Act(CssDeclaration declaration)
        {
            declaration.SetValue(Name(), Value);
        }

        public ICssDeclarationAction Clone()
        {
            return new CssSetAction(Name, Value);
        }
    }
}