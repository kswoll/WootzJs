namespace System.Runtime.WootzJs
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class JsCompilerOptionsAttribute : Attribute
    {
        public bool IsReflectionMinimized { get; set; }
        public bool IsCultureInfoExportDisabled { get; set; }
        public bool AreAutoPropertiesMinimized { get; set; }
        public bool AreDelegatesMinimized { get; set; }

        /// <summary>
        /// If true, all types for this assembly will be emitted regardless of whether or not it is used.
        /// </summary>
        public bool AreAllTypesPreserved { get; set; }
    }
}