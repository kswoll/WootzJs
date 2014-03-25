namespace System.Threading
{
    /// <summary>
    ///     Propagates notification that operations should be canceled.
    /// </summary>
    public struct CancellationToken
    {
        private static readonly Action<object> s_ActionToActionObjShunt = ActionToActionObjShunt;
        private CancellationTokenSource m_source;

        static CancellationToken()
        {
        }

        internal CancellationToken(CancellationTokenSource source)
        {
            m_source = source;
        }

        /// <summary>
        ///     Initializes the <see cref="T:System.Threading.CancellationToken" />.
        /// </summary>
        /// <param name="canceled">The canceled state for the token.</param>
        public CancellationToken(bool canceled)
        {
            this = new CancellationToken();
            if (!canceled)
                return;
            m_source = CancellationTokenSource.InternalGetStaticSource(canceled);
        }

        /// <summary>
        ///     Returns an empty CancellationToken value.
        /// </summary>
        /// <returns>
        ///     Returns an empty CancellationToken value.
        /// </returns>
        public static CancellationToken None
        {
            get
            {
                return new CancellationToken();
            }
        }

        /// <summary>
        ///     Gets whether cancellation has been requested for this token.
        /// </summary>
        /// <returns>
        ///     true if cancellation has been requested for this token; otherwise false.
        /// </returns>
        public bool IsCancellationRequested
        {
            get
            {
                if (m_source != null)
                    return m_source.IsCancellationRequested;
                else
                    return false;
            }
        }

        /// <summary>
        ///     Gets whether this token is capable of being in the canceled state.
        /// </summary>
        /// <returns>
        ///     true if this token is capable of being in the canceled state; otherwise false.
        /// </returns>
        public bool CanBeCanceled
        {
            get
            {
                if (m_source != null)
                    return m_source.CanBeCanceled;
                else
                    return false;
            }
        }

        /// <summary>
        ///     Gets a <see cref="T:System.Threading.WaitHandle" /> that is signaled when the token is canceled.
        /// </summary>
        /// <returns>
        ///     A <see cref="T:System.Threading.WaitHandle" /> that is signaled when the token is canceled.
        /// </returns>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     The associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
/*
        public WaitHandle WaitHandle
        {
            get
            {
                if (m_source == null)
                    InitializeDefaultSource();
                return m_source.WaitHandle;
            }
        }
*/

        /// <summary>
        ///     Determines whether two <see cref="T:System.Threading.CancellationToken" /> instances are equal.
        /// </summary>
        /// <returns>
        ///     True if the instances are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     An associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
        public static bool operator ==(CancellationToken left, CancellationToken right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two <see cref="T:System.Threading.CancellationToken" /> instances are not equal.
        /// </summary>
        /// <returns>
        ///     True if the instances are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The first instance.</param>
        /// <param name="right">The second instance.</param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     An associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
        public static bool operator !=(CancellationToken left, CancellationToken right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Registers a delegate that will be called when this <see cref="T:System.Threading.CancellationToken" /> is canceled.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Threading.CancellationTokenRegistration" /> instance that can be used to deregister the
        ///     callback.
        /// </returns>
        /// <param name="callback">
        ///     The delegate to be executed when the <see cref="T:System.Threading.CancellationToken" /> is
        ///     canceled.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     The associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="callback" /> is null.</exception>
        public CancellationTokenRegistration Register(Action callback)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");
            else
                return Register(s_ActionToActionObjShunt, callback, false, true);
        }

        /// <summary>
        ///     Registers a delegate that will be called when this <see cref="T:System.Threading.CancellationToken" /> is canceled.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Threading.CancellationTokenRegistration" /> instance that can be used to deregister the
        ///     callback.
        /// </returns>
        /// <param name="callback">
        ///     The delegate to be executed when the <see cref="T:System.Threading.CancellationToken" /> is
        ///     canceled.
        /// </param>
        /// <param name="useSynchronizationContext">
        ///     A Boolean value that indicates whether to capture the current
        ///     <see cref="T:System.Threading.SynchronizationContext" /> and use it when invoking the <paramref name="callback" />.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     The associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="callback" /> is null.</exception>
        public CancellationTokenRegistration Register(Action callback, bool useSynchronizationContext)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");
            else
                return Register(s_ActionToActionObjShunt, callback, useSynchronizationContext, true);
        }

        /// <summary>
        ///     Registers a delegate that will be called when this <see cref="T:System.Threading.CancellationToken" /> is canceled.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Threading.CancellationTokenRegistration" /> instance that can be used to deregister the
        ///     callback.
        /// </returns>
        /// <param name="callback">
        ///     The delegate to be executed when the <see cref="T:System.Threading.CancellationToken" /> is
        ///     canceled.
        /// </param>
        /// <param name="state">
        ///     The state to pass to the <paramref name="callback" /> when the delegate is invoked. This may be
        ///     null.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     The associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="callback" /> is null.</exception>
        public CancellationTokenRegistration Register(Action<object> callback, object state)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");
            else
                return Register(callback, state, false, true);
        }

        /// <summary>
        ///     Registers a delegate that will be called when this <see cref="T:System.Threading.CancellationToken" /> is canceled.
        /// </summary>
        /// <returns>
        ///     The <see cref="T:System.Threading.CancellationTokenRegistration" /> instance that can be used to deregister the
        ///     callback.
        /// </returns>
        /// <param name="callback">
        ///     The delegate to be executed when the <see cref="T:System.Threading.CancellationToken" /> is
        ///     canceled.
        /// </param>
        /// <param name="state">
        ///     The state to pass to the <paramref name="callback" /> when the delegate is invoked. This may be
        ///     null.
        /// </param>
        /// <param name="useSynchronizationContext">
        ///     A Boolean value that indicates whether to capture the current
        ///     <see cref="T:System.Threading.SynchronizationContext" /> and use it when invoking the <paramref name="callback" />.
        /// </param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     The associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="callback" /> is null.</exception>
        public CancellationTokenRegistration Register(Action<object> callback, object state,
            bool useSynchronizationContext)
        {
            return Register(callback, state, useSynchronizationContext, true);
        }

        internal CancellationTokenRegistration InternalRegisterWithoutEC(Action<object> callback, object state)
        {
            return Register(callback, state, false, false);
        }

        private CancellationTokenRegistration Register(Action<object> callback, object state,
            bool useSynchronizationContext, bool useExecutionContext)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");
            if (!CanBeCanceled)
                return new CancellationTokenRegistration();
            return m_source.InternalRegister(callback, state);
        }

        /// <summary>
        ///     Determines whether the current <see cref="T:System.Threading.CancellationToken" /> instance is equal to the
        ///     specified token.
        /// </summary>
        /// <returns>
        ///     True if the instances are equal; otherwise, false. Two tokens are equal if they are associated with the same
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> or if they were both constructed from public
        ///     CancellationToken constructors and their
        ///     <see cref="P:System.Threading.CancellationToken.IsCancellationRequested" /> values are equal.
        /// </returns>
        /// <param name="other">The other <see cref="T:System.Threading.CancellationToken" /> to which to compare this instance.</param>
        public bool Equals(CancellationToken other)
        {
            if (m_source == null && other.m_source == null)
                return true;
            if (m_source == null)
                return other.m_source == CancellationTokenSource.InternalGetStaticSource(false);
            if (other.m_source == null)
                return m_source == CancellationTokenSource.InternalGetStaticSource(false);
            else
                return m_source == other.m_source;
        }

        /// <summary>
        ///     Determines whether the current <see cref="T:System.Threading.CancellationToken" /> instance is equal to the
        ///     specified <see cref="T:System.Object" />.
        /// </summary>
        /// <returns>
        ///     True if <paramref name="other" /> is a <see cref="T:System.Threading.CancellationToken" /> and if the two instances
        ///     are equal; otherwise, false. Two tokens are equal if they are associated with the same
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> or if they were both constructed from public
        ///     CancellationToken constructors and their
        ///     <see cref="P:System.Threading.CancellationToken.IsCancellationRequested" /> values are equal.
        /// </returns>
        /// <param name="other">The other object to which to compare this instance.</param>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     An associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
        public override bool Equals(object other)
        {
            if (other is CancellationToken)
                return Equals((CancellationToken) other);
            else
                return false;
        }

        /// <summary>
        ///     Serves as a hash function for a <see cref="T:System.Threading.CancellationToken" />.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="T:System.Threading.CancellationToken" /> instance.
        /// </returns>
        public override int GetHashCode()
        {
            if (m_source == null)
                return CancellationTokenSource.InternalGetStaticSource(false).GetHashCode();
            else
                return m_source.GetHashCode();
        }

        /// <summary>
        ///     Throws a <see cref="T:System.OperationCanceledException" /> if this token has had cancellation requested.
        /// </summary>
        /// <exception cref="T:System.OperationCanceledException">The token has had cancellation requested.</exception>
        /// <exception cref="T:System.ObjectDisposedException">
        ///     The associated
        ///     <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.
        /// </exception>
        public void ThrowIfCancellationRequested()
        {
            if (!IsCancellationRequested)
                return;
            ThrowOperationCanceledException();
        }

        internal void ThrowIfSourceDisposed()
        {
            if (m_source == null || !m_source.IsDisposed)
                return;
            ThrowObjectDisposedException();
        }

        private void ThrowOperationCanceledException()
        {
            throw new OperationCanceledException(this, "OperationCanceled");
        }

        private static void ActionToActionObjShunt(object obj)
        {
            (obj as Action)();
        }

        private static void ThrowObjectDisposedException()
        {
            throw new ObjectDisposedException("CancellationToken_SourceDisposed");
        }

        private void InitializeDefaultSource()
        {
            m_source = CancellationTokenSource.InternalGetStaticSource(false);
        }
    }
}