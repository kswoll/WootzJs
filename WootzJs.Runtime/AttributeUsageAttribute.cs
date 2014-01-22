namespace System
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class AttributeUsageAttribute : Attribute
    {
        public AttributeUsageAttribute(AttributeTargets validOn)
        {
            
        }

        public AttributeTargets ValidOn { get; private set; }

        public bool AllowMultiple { get; set; }
        public bool Inherited { get; set; }
    }
}
