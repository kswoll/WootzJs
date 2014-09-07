using System.Text;

namespace WootzJs.Mvc.Extensions
{
    public static class StringExtensions
    {
        public static string CamelcaseToSlug(this string s, char slug = '_')
        {
            var builder = new StringBuilder();
            foreach (var c in s)
            {
                if (char.IsUpper(c))
                {
                    builder.Append(slug);
                    builder.Append(char.ToLower(c));
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }

        public static string SlugToCamelcase(this string s, char slug = '_')
        {
            var builder = new StringBuilder();
            var wasSlug = false;
            foreach (var c in s)
            {
                if (c == slug)
                {
                    wasSlug = true;
                }
                else if (wasSlug)
                {
                    builder.Append(char.ToUpper(c));
                    wasSlug = false;
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }         

        public static string Capitalize(this string s)
        {
            return Capitalize(s, false);
        }

        public static string Capitalize(this string s, bool correctCase)
        {
            StringBuilder builder = new StringBuilder();
            if (s.Length > 0)
                builder.Append(char.ToUpper(s[0]));
            for (int i = 1; i < s.Length; i++)
            {
                builder.Append(correctCase ? char.ToLower(s[i]) : s[i]);
            }
            return builder.ToString();
        }

        public static string Decapitalize(this string s)
        {
            return Decapitalize(s, false);
        }

        public static string Decapitalize(this string s, bool correctCase)
        {
            StringBuilder builder = new StringBuilder();
            if (s.Length > 0)
                builder.Append(char.ToLower(s[0]));
            for (int i = 1; i < s.Length; i++)
            {
                builder.Append(correctCase ? char.ToLower(s[i]) : s[i]);
            }
            return builder.ToString();
        }
    }
}