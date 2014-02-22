using System.Collections.Generic;

namespace WootzJs.Mvc
{
    internal static class MiscExtensions
    {
        public static string ChopStart(this string s, string start)
        {
            if (!s.StartsWith(start))
                return s;
            return s.Substring(start.Length);
        }
        
        public static string ChopEnd(this string s, string end)
        {
            if (!s.EndsWith(end))
                return s;
            return s.Substring(0, s.Length - end.Length);
        }

        public static string ToHex(this int i, int minimumDigits = 0)
        {
            var s = i.ToString("X" + minimumDigits);
            return s;
        } 

        public static U Get<T, U>(this IDictionary<T, U> dictionary, T key, U returnIfNotFound = default(U))
        {
            if (dictionary == null)
                return returnIfNotFound;
            if (key == null)
                return returnIfNotFound;

            U result;
            if (dictionary.TryGetValue(key, out result))
                return result;
            else
                return returnIfNotFound;
        }
    }
}