using System.Collections;

namespace System.Collections.Generic
{
  internal class ObjectComparer<T> : Comparer<T>
  {
    public ObjectComparer()
    {
    }

    public override int Compare(T x, T y)
    {
      return Comparer.Default.Compare((object) x, (object) y);
    }

    public override bool Equals(object obj)
    {
      return obj is ObjectComparer<T>;
    }

    public override int GetHashCode()
    {
      return this.GetType().Name.GetHashCode();
    }
  }
}