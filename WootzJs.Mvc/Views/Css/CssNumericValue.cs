using System;
using System.Text;

namespace WootzJs.Mvc.Views.Css
{
    public class CssNumericValue : CssValue
    {
        public static readonly CssNumericValue OneHundredPercent = new CssNumericValue(100, CssUnit.Percent);

        public string Value { get; set; }
        public CssUnit Unit { get; set; }

        public CssNumericValue(string value, CssUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public CssNumericValue(CssUnit unit)
        {
            Unit = unit;
        }

        public CssNumericValue(int value, CssUnit unit) : this(value.ToString(), unit)
        {
        }

        public override string ToString()
        {
            if (Unit == CssUnit.Auto)
                return "auto";

            return Value + Unit.GetAbbreviation();
        }

        public static implicit operator CssNumericValue(int value)
        {
            return new CssNumericValue(value.ToString(), CssUnit.Pixels);
        }

        public new static CssNumericValue Parse(string value)
        {
            if (value == null)
                return null;
            if (value == "auto")
                return new CssNumericValue(0, CssUnit.Auto);

            var numeric = new StringBuilder();
            foreach (var c in value)
            {
                if (char.IsDigit(c))
                    numeric.Append(c);
                else
                    break;
            }
            var number = numeric.ToString();
            var unit = value.Substring(number.Length);
            if (number.Length == 0)
                return null;
            var cssUnit = CssUnits.Parse(unit);
            return new CssNumericValue(number, cssUnit);
        }

        public static explicit operator int(CssNumericValue numeric)
        {
            if (numeric.Unit == CssUnit.Pixels)
                return int.Parse(numeric.Value);
            else
                throw new Exception("Cannot cast a non-pixel numeric into an int");
        }
    }
}