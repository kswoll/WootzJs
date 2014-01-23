using System.Runtime.WootzJs;

namespace System
{
    [Js(Export = false)]
    public class CLSCompliantAttribute : Attribute
    {
        private bool _isCompliant;

        public CLSCompliantAttribute(bool isCompliant) {
            _isCompliant = isCompliant;
        }

        public bool IsCompliant {
            get {
                return _isCompliant;
            }
        }
    }
}
