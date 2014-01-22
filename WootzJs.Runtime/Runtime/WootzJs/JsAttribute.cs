namespace System.Runtime.WootzJs
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Constructor | AttributeTargets.Enum | AttributeTargets.Struct | AttributeTargets.Parameter)]
    public class JsAttribute : Attribute
    {
        /// <summary>
        /// If false (defaults to true), the given symbol will not be exported to Javascript.
        /// </summary>
        public bool Export { get; set; }

        /// <summary>
        /// If not null, this name will be used to identify the symbol, rather than the compiler-generated
        /// name.  This is useful when integrating external Javascript APIs.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If true, all invocations to the method or property will be invoked by proxy.  method.apply(this, arguments);
        /// This can be useful when creating a stand-in class that represents a built-in type.
        /// </summary>
        public bool Extension { get; set; }

        /// <summary>
        /// Allows you to supply a native javascript implementation.
        /// </summary>
        public string Native { get; set; }

        /// <summary>
        /// When true, the class declaration will not be written out, but all the member declarations will.  This allows you to
        /// instrument an existing built-in type.
        /// </summary>
        public bool BuiltIn { get; set; }

        public JsAttribute()
        {
            Export = true;
        }
    }
}
