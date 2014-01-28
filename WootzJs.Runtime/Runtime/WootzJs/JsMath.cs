namespace System.Runtime.WootzJs
{
    [Js(Name = "Math", Export = false)]
    public class JsMath
    {
// ReSharper disable UnassignedReadonlyField
        public readonly JsNumber E;
        public readonly JsNumber LN10;
        public readonly JsNumber LN2;
        public readonly JsNumber LOG10E;
        public readonly JsNumber LOG2E;
        public readonly JsNumber PI;
        public readonly JsNumber SQRT1_2;
        public readonly JsNumber SQRT2;
// ReSharper restore UnassignedReadonlyField

        public static extern JsNumber abs(JsNumber x);
        public static extern JsNumber acos(JsNumber x);
        public static extern JsNumber acosh(JsNumber x);
        public static extern JsNumber asin(JsNumber x);
        public static extern JsNumber asinh(JsNumber x);
        public static extern JsNumber atan(JsNumber x);
        public static extern JsNumber atan2(JsNumber x, JsNumber y);
        public static extern JsNumber atanh(JsNumber x);
        public static extern JsNumber cbrt(JsNumber x);
        public static extern JsNumber ceil(JsNumber x);
        public static extern JsNumber cos(JsNumber x);
        public static extern JsNumber cosh(JsNumber x);
        public static extern JsNumber exp(JsNumber x);
        public static extern JsNumber expm1(JsNumber x);
        public static extern JsNumber floor(JsNumber x);
        public static extern JsNumber fround(JsNumber x);
        public static extern JsNumber hypot(params JsNumber[] x);
        public static extern JsNumber imul(JsNumber x);
        public static extern JsNumber log(JsNumber x);
        public static extern JsNumber log10(JsNumber x);
        public static extern JsNumber log1p(JsNumber x);
        public static extern JsNumber log2(JsNumber x);
        public static extern JsNumber max(params JsNumber[] x);
        public static extern JsNumber min(params JsNumber[] x);
        public static extern JsNumber pow(JsNumber exponentBase, JsNumber exponent);
        public static extern JsNumber random();
        public static extern JsNumber round(JsNumber x);
        public static extern JsNumber sign(JsNumber x);
        public static extern JsNumber sin(JsNumber x);
        public static extern JsNumber sinh(JsNumber x);
        public static extern JsNumber sqrt(JsNumber x);
        public static extern JsNumber tan(JsNumber x);
        public static extern JsNumber tanh(JsNumber x);
        public static extern JsNumber trunc(JsNumber x);
    }
}