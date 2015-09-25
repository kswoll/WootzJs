using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class AnimatedImage : InlineControl
    {
        private Element[] sourceFrames;
        private Element[] highlightedSourceFrames;
        private bool isHighlighted;
        private int currentFrame;
        private Timer timer;
        private CssColor highlightColor;

        public AnimatedImage()
        {
        }

        public AnimatedImage(string[] source, int? width = null, int? height = null)
        {
            PreloadFrames(source, null, width, height);
            SetSource(sourceFrames.First());
        }

        public AnimatedImage(string[] defaultSource, string[] highlightedSource, int? width = null, int? height = null, CssColor highlightColor = null, bool isAutomaticHighlighting = false)
        {
            if (defaultSource.Length != highlightedSource.Length)
                throw new Exception("The number of frames must be equal between the default and highlighted frames.");

            this.highlightColor = highlightColor;

            if (isAutomaticHighlighting)
            {
                MouseEntered += Highlight;
                MouseExited += Unhighlight;
            }
            PreloadFrames(defaultSource, highlightedSource, width, height);
            SetSource(sourceFrames.First());
        }

        public void Highlight()
        {
            isHighlighted = true;
            SetSource(highlightedSourceFrames[currentFrame]);
            if (highlightColor != null)
                Style.BackgroundColor = highlightColor;
        }

        public void Unhighlight()
        {
            isHighlighted = false;
            SetSource(sourceFrames[currentFrame]);
            if (highlightColor != null)
                Style.BackgroundColor = CssColor.Inherit;
        }

/*
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
*/

        public void SetSource(Element value)
        {
            Node.Clear();
            Node.AppendChild(value);
        }

        private void UpdateFrame(object context)
        {
            currentFrame = currentFrame == sourceFrames.Length - 1 ? 0 : currentFrame + 1;
            SetSource((isHighlighted ? highlightedSourceFrames : sourceFrames)[currentFrame]);
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
                SetSource((isHighlighted ? highlightedSourceFrames : sourceFrames)[currentFrame]);
            }
        }

        protected override Element CreateNode()
        {
            var node = Browser.Document.CreateElement("div");
//            node.Style.Display = "block";
            return node;
        }        

        private void PreloadFrames(string[] sourceFrames, string[] highlightedSourceFrames, int? width = null, int? height = null)
        {
            var sourceFramesList = new List<Element>();
            foreach (var frame in sourceFrames)
            {
                var image = Browser.Document.CreateElement("img");
                image.Style.Display = "block";
                image.SetAttribute("width", width.ToString());
                image.SetAttribute("height", height.ToString());
                image.SetAttribute("src", frame);
                sourceFramesList.Add(image);
            }
            this.sourceFrames = sourceFramesList.ToArray();
            if (highlightedSourceFrames != null)
            {
                var highlightedSourceFramesList = new List<Element>();
                foreach (var frame in highlightedSourceFrames)
                {
                    var image = Browser.Document.CreateElement("img");
                    image.Style.Display = "block";
                    image.SetAttribute("width", width.ToString());
                    image.SetAttribute("height", height.ToString());
                    image.SetAttribute("src", frame);
                    highlightedSourceFramesList.Add(image);
                }
                this.highlightedSourceFrames = highlightedSourceFramesList.ToArray();
            }
        }
    }
}