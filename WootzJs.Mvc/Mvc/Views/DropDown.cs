using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views
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
                if (content != null)
                {
                    Remove(content);
                    content.Node.Remove();
                }
                content = value;
                if (content != null)
                {
                    Add(value);
                    contentNode.AppendChild(content.Node);
                }
            }
        }

        public Control Overlay
        {
            get { return overlay; }
            set
            {
                if (overlay != null)
                {
                    Remove(overlay);
                    overlay.Node.Remove();
                }
                overlay = value;
                if (overlay != null)
                {
                    Add(overlay);
                    overlayContainer.AppendChild(overlay.Node);
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