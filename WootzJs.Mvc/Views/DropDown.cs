using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class DropDown : Control
    {
        private Control content;
        private Control overlay;
        private Element contentNode;
        private Element overlayContainer;

        public DropDown()
        {
        }

        public DropDown(Control content, Control overlay) 
        {
            Content = content;
            Overlay = overlay;
        }

        public Control Content
        {
            get { return content; }
            set
            {
                EnsureNodeExists();
                if (content != null)
                {
                    Remove(content);
                    content.Node.Remove();
                }
                content = value;
                if (content != null)
                {
                    contentNode.AppendChild(content.Node);
                    Add(value);
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
                    Remove(overlay);
                    overlay.Node.Remove();
                }
                overlay = value;
                if (overlay != null)
                {
                    overlayContainer.AppendChild(overlay.Node);
                    Add(overlay);
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
            return result;
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