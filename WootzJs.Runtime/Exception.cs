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
