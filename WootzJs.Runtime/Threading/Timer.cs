using System.Runtime.WootzJs;

namespace System.Threading
{
    public class Timer : IDisposable
    {
        private TimerCallback callback;
        private object state;
        private JsObject timeoutHandle;
        private JsObject intervalHandle;

        public Timer(TimerCallback callback)
        {
            this.callback = callback;
        }

        public Timer(TimerCallback callback, object state, long dueTime, long period) : this(callback, state, TimeSpan.FromMilliseconds(dueTime), TimeSpan.FromMilliseconds(period))
        {
        }

        public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
        {
            this.callback = callback;
            this.state = state;
            Change(dueTime, period);
        }

        public void Change(long dueTime, long period)
        {
            Change(TimeSpan.FromMilliseconds(dueTime), TimeSpan.FromMilliseconds(period));
        }

        public void Change(TimeSpan dueTime, TimeSpan period)
        {
            // Clear any existing timers
            Stop();
  
            // Set up a timeout to fire the timer
            if (dueTime.TotalMilliseconds > 0)
            {
                intervalHandle = Jsni.setInterval(OnTimeout, (int)dueTime.TotalMilliseconds);
            }
            else
            {
                timeoutHandle = Jsni.setTimeout(OnTimeout, (int)dueTime.TotalMilliseconds);
            }
        }

        public void Dispose()
        {
            Stop();
        }

        public void Stop() 
        {
            if (timeoutHandle != null)
            {
                Jsni.clearTimeout(timeoutHandle);
                timeoutHandle = null;
            }
            if (intervalHandle != null)
            {
                Jsni.clearInterval(intervalHandle);
                intervalHandle = null;
            }
        }

        private void OnTimeout()
        {
            callback(state);
        }
    }
}