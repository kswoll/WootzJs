#region License

//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Runtime.WootzJs;

namespace System.Text
{
    public class StringBuilder
    {
        private JsArray chunks = new JsArray();
        private int length;

        public StringBuilder()
        {
        }

        public StringBuilder(string initialText)
        {
            Append(initialText);
        }

        public int Length
        {
            get { return length; }
        }

        public void Append(char c)
        {
            Append(c.As<string>());
        }

        public void Append(string s)
        {
            chunks.push(s.As<JsObject>());
            length += s.Length;
        }

        public void Append(object o)
        {
            if (o != null)
            {
                var s = o.ToString();
                Append(s);
            }
        }

        public void AppendLine()
        {
            Append("\n");
        }

        public void AppendLine(char c)
        {
            Append(c);
            AppendLine();
        }

        public void AppendLine(string s)
        {
            Append(s);
            AppendLine();
        }

        public void Append(string value, int startIndex, int length)
        {
            Append(value.Substring(startIndex, length));
        }

        public StringBuilder AppendFormat(string format, params object[] args)
        {
            return AppendFormat(null, format, args);
        }

        public StringBuilder AppendFormat(IFormatProvider provider, string format, params object[] args)
        {
            FormatHelper(this, provider, format, args);
            return this;
        }

        public StringBuilder AppendFormat(string format, object arg0)
        {
            return AppendFormat(null, format, new object[] { arg0 });
        }

        public StringBuilder AppendFormat(string format, object arg0, object arg1)
        {
            return AppendFormat(null, format, new object[] { arg0, arg1 });
        }

        public StringBuilder AppendFormat(string format, object arg0, object arg1, object arg2)
        {
            return AppendFormat(null, format, new object[] { arg0, arg1, arg2 });
        }

        internal static StringBuilder FormatHelper(StringBuilder result, IFormatProvider provider, string format, params object[] args)
        {
            if (format == null)
                throw new ArgumentNullException("format");
            if (args == null)
                throw new ArgumentNullException("args");

            if (result == null)
            {
                /* Try to approximate the size of result to avoid reallocations */
                int i, len;

                len = 0;
                for (i = 0; i < args.Length; ++i)
                {
                    string s = args[i] as string;
                    if (s != null)
                        len += s.Length;
                    else
                        break;
                }
                result = new StringBuilder();
            }

            int ptr = 0;
            int start = ptr;
            var formatter = provider != null ? provider.GetFormat(typeof (ICustomFormatter)) as ICustomFormatter : null;

            while (ptr < format.Length)
            {
                char c = format[ptr ++];

                if (c == '{')
                {
                    result.Append(format, start, ptr - start - 1);

                    // check for escaped open bracket

                    if (format[ptr] == '{')
                    {
                        start = ptr ++;
                        continue;
                    }

                    // parse specifier

                    int n, width;
                    bool left_align;
                    string arg_format;

                    ParseFormatSpecifier(format, ref ptr, out n, out width, out left_align, out arg_format);
                    if (n >= args.Length)
                        throw new FormatException("Index (zero based) must be greater than or equal to zero and less than the size of the argument list.");

                    // format argument

                    object arg = args[n];

                    string str;
                    if (arg == null)
                        str = "";
                    else if (formatter != null)
                        str = formatter.Format(arg_format, arg, provider);
                    else
                        str = null;

                    if (str == null)
                    {
                        if (arg is IFormattable)
                            str = ((IFormattable)arg).ToString(arg_format, provider);
                        else
                            str = arg.ToString();
                    }

                    // pad formatted string and append to result
                    if (width > str.Length)
                    {
                        const char padchar = ' ';
                        int padlen = width - str.Length;

                        if (left_align)
                        {
                            result.Append(str);
                            result.Append(padchar, padlen);
                        }
                        else
                        {
                            result.Append(padchar, padlen);
                            result.Append(str);
                        }
                    }
                    else
                    {
                        result.Append(str);
                    }

                    start = ptr;
                }
                else if (c == '}' && ptr < format.Length && format[ptr] == '}')
                {
                    result.Append(format, start, ptr - start - 1);
                    start = ptr ++;
                }
                else if (c == '}')
                {
                    throw new FormatException("Input string was not in a correct format.");
                }
            }

            if (start < format.Length)
                result.Append(format, start, format.Length - start);

            return result;
        }

        public StringBuilder Append(char value, int repeatCount)
        {
            if (repeatCount < 0)
                throw new ArgumentOutOfRangeException();

            for (var i = 0; i < repeatCount; i++)
                Append(value);

            return this;
        }

        private static void ParseFormatSpecifier(string str, ref int ptr, out int n, out int width,
            out bool left_align, out string format)
        {
            int max = str.Length;

            // parses format specifier of form:
            //   N,[\ +[-]M][:F]}
            //
            // where:
            // N = argument number (non-negative integer)

            n = ParseDecimal(str, ref ptr);
            if (n < 0)
                throw new FormatException("Input string was not in a correct format.");

            // M = width (non-negative integer)

            if (ptr < max && str[ptr] == ',')
            {
                // White space between ',' and number or sign.
                ++ptr;
                while (ptr < max && Char.IsWhiteSpace(str[ptr]))
                    ++ptr;
                int start = ptr;

                format = str.Substring(start, ptr - start);

                left_align = (ptr < max && str[ptr] == '-');
                if (left_align)
                    ++ ptr;

                width = ParseDecimal(str, ref ptr);
                if (width < 0)
                    throw new FormatException("Input string was not in a correct format.");
            }
            else
            {
                width = 0;
                left_align = false;
                format = "";
            }

            // F = argument format (string)

            if (ptr < max && str[ptr] == ':')
            {
                int start = ++ ptr;
                while (ptr < max && str[ptr] != '}')
                    ++ ptr;

                format += str.Substring(start, ptr - start);
            }
            else
                format = null;

            if ((ptr >= max) || str[ptr ++] != '}')
                throw new FormatException("Input string was not in a correct format.");
        }

        private static int ParseDecimal(string str, ref int ptr)
        {
            int p = ptr;
            int n = 0;
            int max = str.Length;

            while (p < max)
            {
                char c = str[p];
                if (c < '0' || '9' < c)
                    break;

                n = n*10 + c - '0';
                ++ p;
            }

            if (p == ptr || p == max)
                return -1;

            ptr = p;
            return n;
        }

        public override string ToString()
        {
            return chunks.join("".As<JsString>());
        }
    }
}