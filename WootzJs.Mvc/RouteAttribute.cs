using System;

namespace WootzJs.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RouteAttribute : Attribute
    {
        public string Value { get; set; }

        public RouteAttribute(string value)
        {
            Value = value;
        }
    }
}