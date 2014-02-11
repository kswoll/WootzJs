using System;

namespace WootzJs.Injection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class IgnoreAttribute : Attribute
    {
    }
}