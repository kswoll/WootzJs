namespace WootzJs.Mvc.Views.Css
{
    public class CssBorderSideAction : ICssDeclarationAction
    {
        private CssBorderSide side;
        private string property;
        private string value;

        public CssBorderSideAction(CssBorderSide side, string property, string value)
        {
            this.side = side;
            this.property = property;
            this.value = value;
        }

        public void Act(CssDeclaration declaration)
        {
            var property = this.property.Replace("{0}", side.side);
            declaration.SetValue(property, value);
        }
    }
}