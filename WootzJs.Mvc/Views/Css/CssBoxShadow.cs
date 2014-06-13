using System;
using System.Linq;
using System.Text;

namespace WootzJs.Mvc.Views.Css
{
    public class CssBoxShadow : CssDeclaration
    {
        public CssBoxShadow()
        {
        }

        public CssBoxShadow(CssNumericValue hshadow, CssNumericValue vshadow, CssNumericValue blur = null, 
            CssNumericValue spread = null, CssColor color = null, bool inset = false)
        {
            HShadow = hshadow;
            VShadow = vshadow;
            Blur = blur;
            Spread = spread;
            Color = color;
            Inset = inset ? CssInset.Instance : null;
        }

        private string GetComponent(int index)
        {
            var parts = Get("box-shadow").Split(' ');
            if (index < parts.Length)
                return parts[index];
            else
                return null;
        }

        public void SetComponent(int index, CssValue value)
        {
            if (value == null && index < 2)
                throw new Exception("HShadow and VShadow are required");

            var hshadow = HShadow;
            var vshadow = VShadow;
            if (hshadow == null)
                hshadow = 1;
            if (vshadow == null)
                vshadow = 1;
            var blur = Blur;
            if (blur == null && index > 2)
                blur = 1;
            var spread = Spread;
            if (spread == null && index > 3)
                spread = 1;
            var color = Color;
            if (color == null && index > 4)
                color = CssColor.Black;
            var inset = Inset;

            if (value == null)
            {
                if (index < 5)
                    inset = null;
                if (index < 4)
                    color = null;
                if (index < 3)
                    spread = null;
            }

            var args = new CssValue[] { hshadow, vshadow, blur, spread, color, inset };
            args[index] = value;
            args = args.Where(x => x != null).ToArray();
            
            var builder = new StringBuilder();
            foreach (var argument in args)
            {
                if (builder.Length > 0)
                    builder.Append(" ");
                builder.Append(argument);
            }
            Set("box-shadow", builder.ToString());
        }

        public CssNumericValue HShadow
        {
            get { return CssNumericValue.Parse(GetComponent(0)); }
            set { SetComponent(0, value); }
        }

        public CssNumericValue VShadow
        {
            get { return CssNumericValue.Parse(GetComponent(1)); }
            set { SetComponent(1, value); }
        }

        public CssNumericValue Blur
        {
            get { return CssNumericValue.Parse(GetComponent(2)); }
            set { SetComponent(2, value); }
        }

        public CssNumericValue Spread
        {
            get { return CssNumericValue.Parse(GetComponent(3)); }
            set { SetComponent(3, value); }
        }

        public CssColor Color
        {
            get { return CssColor.Parse(GetComponent(4)); }
            set { SetComponent(4, value); }
        }

        public CssInset Inset
        {
            get { return GetComponent(5) == "inset" ? CssInset.Instance : null; }
            set { SetComponent(5, value); }
        }
    }
}