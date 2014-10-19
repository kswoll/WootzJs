using System;
using System.Linq;
using System.Threading;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class AnimatedImage : InlineControl
    {
        private string[] sourceFrames;
        private string[] highlightedSourceFrames;
        private bool isAnimating;
        private bool isHighlighted;
        private int currentFrame = 0;
        private Timer timer;
        private CssColor highlightColor;

        public AnimatedImage()
        {
        }

        public AnimatedImage(string[] source, int? width = null, int? height = null)
        {
            sourceFrames = source;
            Source = source.First();
            if (width != null)
                Width = width.Value;
            if (height != null)
                Height = height.Value;
            PreloadFrames();
        }

        public AnimatedImage(string[] defaultSource, string[] highlightedSource, CssColor highlightColor = null, bool isAutomaticHighlighting = false)
        {
            if (defaultSource.Length != highlightedSource.Length)
                throw new Exception("The number of frames must be equal between the default and highlighted frames.");

            this.sourceFrames = defaultSource;
            this.highlightedSourceFrames = highlightedSource;
            this.highlightColor = highlightColor;

            Source = defaultSource.First();

            if (isAutomaticHighlighting)
            {
                MouseEntered += Highlight;
                MouseExited += Unhighlight;
            }
            PreloadFrames();
        }

        public void Highlight()
        {
            isHighlighted = true;
            Source = highlightedSourceFrames[currentFrame];
            if (highlightColor != null)
                Style.BackgroundColor = highlightColor;
        }

        public void Unhighlight()
        {
            isHighlighted = false;
            Source = sourceFrames[currentFrame];
            if (highlightColor != null)
                Style.BackgroundColor = CssColor.Inherit;
        }

        public int Width
        {
            get { return int.Parse(Node.GetAttribute("width")); }
            set { Node.SetAttribute("width", value.ToString()); }
        }

        public int Height
        {
            get { return int.Parse(Node.GetAttribute("height")); }
            set { Node.SetAttribute("height", value.ToString()); }
        }

        public string Source
        {
            get { return Node.GetAttribute("src"); }
            set { Node.SetAttribute("src", value); }
        }

        private void UpdateFrame(object context)
        {
            currentFrame = currentFrame == sourceFrames.Length - 1 ? 0 : currentFrame + 1;
            Source = (isHighlighted ? highlightedSourceFrames : sourceFrames)[currentFrame];
        }

        public void StartAnimating()
        {
            if (timer == null)
            {
                timer = new Timer(UpdateFrame, null, 0, 75);
            }
        }

        public void StopAnimating()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;

                currentFrame = 0;
                Source = (isHighlighted ? highlightedSourceFrames : sourceFrames)[currentFrame];
            }
        }

        protected override Element CreateNode()
        {
            var node = Browser.Document.CreateElement("img");
            node.Style.Display = "block";
            return node;
        }        

        private void PreloadFrames()
        {
            foreach (var frame in sourceFrames)
            {
                var image = Browser.Document.CreateElement("img");
                image.SetAttribute("src", frame);
            }
            if (highlightedSourceFrames != null)
            {
                foreach (var frame in highlightedSourceFrames)
                {
                    var image = Browser.Document.CreateElement("img");
                    image.SetAttribute("src", frame);
                }
            }
        }
    }
}