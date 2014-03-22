namespace System.Runtime.ExceptionServices
{
    /// <summary>
    ///     Represents an exception whose state is captured at a certain point in code.
    /// </summary>
    public sealed class ExceptionDispatchInfo
    {
        private Exception m_Exception;
        private object m_stackTrace;

        private ExceptionDispatchInfo(Exception exception)
        {
            m_Exception = exception;
            m_stackTrace = exception.StackTrace;
        }

        internal object BinaryStackTraceArray
        {
            get { return m_stackTrace; }
        }

        /// <summary>
        ///     Gets the exception that is represented by the current instance.
        /// </summary>
        /// <returns>
        ///     The exception that is represented by the current instance.
        /// </returns>
        public Exception SourceException
        {
            get
            {
                return m_Exception;
            }
        }

        /// <summary>
        ///     Creates an <see cref="T:System.Runtime.ExceptionServices.ExceptionDispatchInfo" /> object that represents the
        ///     specified exception at the current point in code.
        /// </summary>
        /// <returns>
        ///     An object that represents the specified exception at the current point in code.
        /// </returns>
        /// <param name="source">The exception whose state is captured, and which is represented by the returned object. </param>
        /// <exception cref="T:System.ArgumentException"><paramref name="source" /> is null. </exception>
        public static ExceptionDispatchInfo Capture(Exception source)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            else
                return new ExceptionDispatchInfo(source);
        }

        /// <summary>
        ///     Throws the exception that is represented by the current
        ///     <see cref="T:System.Runtime.ExceptionServices.ExceptionDispatchInfo" /> object, after restoring the state that was
        ///     saved when the exception was captured.
        /// </summary>
        public void Throw()
        {
            throw m_Exception;
        }
    }
}