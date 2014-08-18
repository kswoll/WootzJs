using System.Collections.Generic;

namespace System.Threading
{
    public struct CancellationToken
    {
        private List<Action> callbacks;

        public void Register(Action callback)
        {
            callbacks = callbacks ?? new List<Action>();
            callbacks.Add(callback);
        }

        internal void Cancel()
        {
            if (callbacks != null)
            {
                foreach (var callback in callbacks)
                {
                    callback();
                }
            }
        }
    }
}