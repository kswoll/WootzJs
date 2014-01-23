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

using System.Collections;
using System.Runtime.WootzJs;
using System.Text;

namespace System
{
	public class Exception
	{
        public Exception InnerException { get; private set; }

        [Js(Name = "message")]
        private string toStringSaved;

        private string _message;

        [Js(Name = "stacktrace")]
        private string stacktrace;

	    public Exception()
	    {
	    }

	    public Exception(string message) : this()
		{
            Message = message;
		}

	    public Exception(string message, Exception innerException)
	    {
	        Message = message;
	        InnerException = innerException;
	    }

        public Exception InternalInit(JsError error)
        {
            stacktrace = error.stack;
            toStringSaved = toString();
            return this;
        }

	    public string Message
	    {
	        get { return _message; }
            private set { _message = value; }
	    }
		
	    public string StackTrace
	    {
	        get { return stacktrace; }
	    }

        [Js(Name = "toString")]
        private string toString()
        {
            return ToString();
        }

	    public object this[string key]
		{
			get
			{
				return null;
			}
		}

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(GetType().FullName);
            if (Message != null)
                builder.AppendLine(": " + Message);
            else
                builder.AppendLine();
            builder.AppendLine(StackTrace);
            return builder.ToString();
        }
	}
}
