namespace WootzJs.Mvc.Views.Css
{
    public class CssColor : CssValue
    {
        public static readonly CssColor Inherit = new CssColor("inherit");
        public static readonly CssColor Black = new CssColor("black");
        public static readonly CssColor Blue = new CssColor("blue");
        public static readonly CssColor Fuchsia = new CssColor("fuchsia");
        public static readonly CssColor Gray = new CssColor("gray");
        public static readonly CssColor Green = new CssColor("green");
        public static readonly CssColor Lime = new CssColor("lime");
        public static readonly CssColor Maroon = new CssColor("maroon");
        public static readonly CssColor Navy = new CssColor("navy");
        public static readonly CssColor Olive = new CssColor("olive");
        public static readonly CssColor Orange = new CssColor("orange");
        public static readonly CssColor Purple = new CssColor("purple");
        public static readonly CssColor Red = new CssColor("red");
        public static readonly CssColor Silver = new CssColor("silver");
        public static readonly CssColor Teal = new CssColor("teal");
        public static readonly CssColor White = new CssColor("white");
        public static readonly CssColor Yellow = new CssColor("yellow");

        public string value;

        public CssColor(string value)
        {
            this.value = value;
        }

        public CssColor(int red, int green, int blue)
        {
            var _red = red.ToHex(2);
            var _green = green.ToHex(2);
            var _blue = blue.ToHex(2);

            value = "#" + _red + _green + _blue;
        }

        public string Value { get; set; }

        public override string ToString()
        {
            return value;
        }

        public new static CssColor Parse(string s)
        {
            if (s == null)
                return null;
            if (s.StartsWith("#"))
                return new CssColor(s);
            if (s == "inherit")
                return new CssColor(s);

            switch (s)
            {
                case "red":
                case "green":
                case "blue":
                case "black":
                case "fuchsia":
                case "gray":
                case "lime":
                case "maroon":
                case "navy":
                case "orange":
                case "purple":
                case "silver":
                case "teal":
                case "white":
                case "yellow":
                    return new CssColor(s);
            }

            return null;
        }
    }
}