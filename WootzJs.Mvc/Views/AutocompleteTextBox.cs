using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class AutocompleteTextBox<T> : Control
    {
        private Control content;
        private Control overlay;
        private Element contentNode;
        private Element overlayContainer;
        private Element contentContainerRow;
        private DropDownAlignment alignment;
        private T selectedItem;

        public AutocompleteTextBox()
        {
            overlay = new ListView<T>();
            overlay.Style.MinWidth = new CssNumericValue(300, CssUnit.Pixels);
            overlay.Style.MinHeight = new CssNumericValue(200, CssUnit.Pixels);
            Add(overlay);
        }

        protected override Element CreateNode()
        {
            var contentContainer = Browser.Document.CreateElement("table");
            contentContainer.Style.Width = "100%";

            contentContainerRow = Browser.Document.CreateElement("tr");
            contentContainer.AppendChild(contentContainerRow);

//            contentContainer.Style.Height = "100%";

            var contentNodeCell = Browser.Document.CreateElement("td");
            contentContainerRow.AppendChild(contentNodeCell);

            var contentNodeCellDiv = Browser.Document.CreateElement("div");
            contentNodeCellDiv.Style.Height = "100%";
            contentNodeCellDiv.Style.Width = "100%";
            contentNodeCell.AppendChild(contentNodeCellDiv);

            contentNode = Browser.Document.CreateElement("input");
            contentNode.SetAttribute("type", "text");
            contentNode.Style.Border = "0px black solid";
            contentNode.Style.Height = "100%";
            contentNode.Style.Width = "100%";
            contentNode.Style.PaddingLeft = "5px";
            contentNode.AddEventListener("keypress", OnTextChanged);
            contentNodeCellDiv.AppendChild(contentNode);

            overlayContainer = Browser.Document.CreateElement("div");
            overlayContainer.Style.Position = "absolute";
            overlayContainer.Style.Display = "none";
            overlayContainer.AppendChild(overlay.Node);

            var overlayAnchor = Browser.Document.CreateElement("div");
            overlayAnchor.Style.Position = "relative";
            overlayAnchor.AppendChild(overlayContainer);

            var result = Browser.Document.CreateElement("div");
            result.Style.Border = "1px solid #999";
            result.AppendChild(contentContainer);
            result.AppendChild(overlayAnchor);
            return result;
        }

        public void DropDown()
        {
            if (overlay != null)
                overlayContainer.Style.Display = "";
        }

        public void CloseUp()
        {
            if (overlay != null)
                overlayContainer.Style.Display = "none";
        }

        private void OnTextChanged(Event @event)
        {
            DropDown();
        }
    }
}