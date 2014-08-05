using System.Runtime.WootzJs;

namespace System
{
    public class JsException : Exception
    {
        private JsError nativeException;

        public JsException(JsError nativeException)
        {
            this.nativeException = nativeException;
        }

        public override Exception InternalInit(JsError error)
        {
            return base.InternalInit(nativeException);
        }
    }
}