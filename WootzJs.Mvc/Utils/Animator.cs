using System;
using WootzJs.Web;

namespace WootzJs.Mvc.Utils
{
    public class Animator
    {
        public delegate void FrameHandler(double progress);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="duration">Milliseconds</param>
        /// <param name="onDone"></param>
        public static void Animate(FrameHandler frame, double duration, Action onDone = null)
        {
            int? start = null;
            Action<int> step = null;
            step = timestamp =>
            {
                start = start ?? timestamp;
                var progress = (timestamp - start.Value) / duration;
                frame(progress);
                if (progress < 1)
                {
                    Browser.Window.RequestAnimationFrame(step);
                }
                else
                {
                    onDone();
                }
            };
            Browser.Window.RequestAnimationFrame(step);            
        }
    }
}