using System.Runtime.WootzJs;

namespace System.Collections.Generic
{
    public class DefaultComparer<T> : EqualityComparer<T>
    {
        public override bool Equals(T x, T y)
        {
            var xObj = x.As<JsObject>();
            var yObj = y.As<JsObject>();
            if (xObj == yObj)
                return true;
            if (xObj == null || yObj == null)
                return false;
            return xObj.Equals(yObj);
        }

        public override int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}