using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    public class DropDown : Control
    {
        private Control content;
        private Control overlay;
        private jQuery contentNode;
        private jQuery overlayContainer;

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
                    content.Node.remove();
                }
                content = value;
                if (content != null)
                {
                    Add(value);
                    contentNode.append(content.Node);
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
                    overlay.Node.remove();
                }
                overlay = value;
                if (overlay != null)
                {
                    Add(overlay);
                    overlayContainer.append(overlay.Node);
                }
            }
        }

        protected override jQuery CreateNode()
        {
            contentNode = new jQuery("<div></div>");

            overlayContainer = new jQuery("<div></div>");
            overlayContainer.css("position", "absolute");
            overlayContainer.css("display", "none");

            var overlayAnchor = new jQuery("<div></div>");
            overlayAnchor.css("position", "relative");
            overlayAnchor.append(overlayContainer);

            var result = new jQuery("<div></div>");
            result.append(contentNode);
            result.append(overlayAnchor);
            result.mouseenter(OnJsContentMouseEnter);
            result.mouseleave(OnJsContentMouseLeave);
            return result;
        }

        private void OnJsContentMouseEnter(JqEvent arg)
        {
            if (overlay != null)
                overlayContainer.css("display", "");
        }

        private void OnJsContentMouseLeave(JqEvent arg)
        {
            if (overlay != null)
                overlayContainer.css("display", "none");
        }
    }
}