namespace WootzJs.Mvc.Mvc.Views.Css
{
    public class CssString : CssValue
    {
        private string value;

        public CssString(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get { return value; }
        }

        public override string ToString()
        {
            return value; 
        }
    }
}