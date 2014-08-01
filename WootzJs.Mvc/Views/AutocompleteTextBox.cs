using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class AutocompleteTextBox<T> : Control
    {
        private Control content;
        private Control overlay;
        private Element contentNode;
        private Element overlayContainer;
        private DropDownAlignment alignment;
        private T selectedItem;

        protected override Element CreateNode()
        {
            contentNode = Browser.Document.CreateElement("input");
            contentNode.SetAttribute("type", "text");
            contentNode.Style.Height = "100%";

            overlayContainer = Browser.Document.CreateElement("div");
            overlayContainer.Style.Position = "absolute";
            overlayContainer.Style.Display = "none";
            overlayContainer.AppendChild(overlay.Node);
            Add(overlay);

            var overlayAnchor = Browser.Document.CreateElement("div");
            overlayAnchor.Style.Position = "relative";
            overlayAnchor.AppendChild(overlayContainer);

            var result = Browser.Document.CreateElement("div");
            result.AppendChild(contentNode);
            result.AppendChild(overlayAnchor);
            return result;
        }
    }
}