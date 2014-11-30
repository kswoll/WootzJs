using System.Collections.Generic;

namespace WootzJs.Compiler
{
    public static class DictionaryExtensions
    {
        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue result;
            dictionary.TryGetValue(key, out result);
            return result;
        } 
    }
}