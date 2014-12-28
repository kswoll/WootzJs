using System;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public enum DropDownAlignment { Left, Right }

    public class DropDown : Control
    {
        private Control content;
        private Control overlay;
        private Element contentNode;
        private Element overlayContainer;
        private DropDownAlignment alignment;

        public DropDown()
        {
        }

        public DropDown(Control content, Control overlay) 
        {
            Content = content;
            Overlay = overlay;
        }

        public DropDownAlignment Alignment
        {
            get { return alignment; }
            set
            {
                EnsureNodeExists();
                alignment = value;
                switch (alignment)
                {
                    case DropDownAlignment.Left:
                        overlayContainer.Style.Right = "inherit";
                        break;
                    case DropDownAlignment.Right:
                        overlayContainer.Style.Right = "0px";
                        break;
                }
            }
        }

        public Control Content
        {
            get { return content; }
            set
            {
                EnsureNodeExists();
                if (content != null)
                {
                    RemoveChild(content);
                    content.Node.Remove();
                }
                content = value;
                if (content != null)
                {
                    contentNode.AppendChild(content.Node);
                    AddChild(value);
                }
            }
        }

        public Control Overlay
        {
            get { return overlay; }
            set
            {
                EnsureNodeExists();
                if (overlay != null)
                {
                    RemoveChild(overlay);
                    overlay.Node.Remove();
                }
                overlay = value;
                if (overlay != null)
                {
                    overlayContainer.AppendChild(overlay.Node);
                    AddChild(overlay);
                }
            }
        }

        protected override Element CreateNode()
        {
            contentNode = Browser.Document.CreateElement("div");
            contentNode.Style.Height = "100%";

            overlayContainer = Browser.Document.CreateElement("div");
            overlayContainer.Style.Position = "absolute";
            overlayContainer.Style.Display = "none";

            var overlayAnchor = Browser.Document.CreateElement("div");
            overlayAnchor.Style.Position = "relative";
            overlayAnchor.AppendChild(overlayContainer);

            var result = Browser.Document.CreateElement("div");
            result.AppendChild(contentNode);
            result.AppendChild(overlayAnchor);
            result.AddEventListener("mouseentered", OnJsContentMouseEnter);
            result.AddEventListener("mouseexited", OnJsContentMouseLeave);
            result.AddEventListener("click", OnJsContentClick);
            return result;
        }

        private void OnJsContentClick(Event arg)
        {
            OnJsContentMouseLeave(arg);     // Hide the dropdown when there's a click
        }

        private void OnJsContentMouseEnter(Event arg)
        {
            if (overlay != null)
                overlayContainer.Style.Display = "";
        }

        private void OnJsContentMouseLeave(Event arg)
        {
            if (overlay != null)
                overlayContainer.Style.Display = "none";
        }
    }
}