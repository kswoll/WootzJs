namespace WootzJs.Mvc.Views.Css
{
    public class CssSetAction : ICssDeclarationAction
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public CssSetAction(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public void Act(CssDeclaration declaration)
        {
            declaration.SetValue(Name, Value);
        }

        public ICssDeclarationAction Clone()
        {
            return new CssSetAction(Name, Value);
        }
    }
}