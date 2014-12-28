using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.WootzJs;
using System.Threading;
using System.Threading.Tasks;
using WootzJs.Mvc.Views.Css;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class AutocompleteTextBox<T> : Control
    {
        public event Action Changed;
        public event Func<string, Action<T[]>, Task> Search;

        public bool Multiselect { get; set; }

        private Control content;
        private ListView<T> overlay;
        private InputElement contentNode;
        private Element overlayContainer;
        private Element contentContainerRow;
        private DropDownAlignment alignment;
        private List<T> selectedItems = new List<T>();
        private CancellationTokenSource canceller;
        private Func<T, string> textProvider;
        private Element contentNodeCell;
        private Dictionary<T, Element> selectedWidgets = new Dictionary<T, Element>();
        private Icon loadingIcon;

        public AutocompleteTextBox(Func<T, string> textProvider)
        {
            this.textProvider = textProvider;
            overlay = new ListView<T>(textProvider);
            loadingIcon = new Icon { Source = IconType.Spinner, IsSpinning = true };
            loadingIcon.Style.Font.Size = new CssNumericValue(75, CssUnit.Percent);

            overlay.Style.MinWidth = new CssNumericValue(300, CssUnit.Pixels);
            overlay.Style.MinHeight = new CssNumericValue(200, CssUnit.Pixels);
            overlay.Style.Cursor = CssCursor.Default;
            overlay.Changed += OverlayChanged;
            AddChild(overlay);

            loadingIcon.Style.Display = CssDisplay.None;
            AddChild(loadingIcon);
        }

        public string Text
        {
            get { return contentNode.Value; }
            set { contentNode.Value = value; }
        }

        public string Placeholder
        {
            get { return contentNode.GetAttribute("placeholder"); }
            set { contentNode.SetAttribute("placeholder", value); }
        }

        public Icon LoadingIcon
        {
            get { return loadingIcon; }
        }

        public T SelectedItem
        {
            get { return selectedItems.FirstOrDefault(); }
            set
            {
                ClearSelectedItems();
                selectedItems.Add(value);
                Text = value == null ? "" : textProvider(value);                                
            }
        }

        public IEnumerable<T> SelectedItems
        {
            get { return selectedItems; }
        }

        public void ClearSelectedItems()
        {
            while (selectedItems.Any())
            {
                RemoveSelectedItem(selectedItems.First());
            }            
        }

        public void AddSelectedItem(T item)
        {
            var itemWidget = Browser.Document.CreateElement("div");
            itemWidget.Style.WhiteSpace = "nowrap";
            itemWidget.Style.FontSize = "60%";
            itemWidget.Style.Border = "1px black solid";
            itemWidget.Style.BorderRadius = "5px";
            itemWidget.Style.PaddingLeft = "3px";
            itemWidget.Style.PaddingRight = "3px";
            itemWidget.Style.Cursor = "default";
            itemWidget.Title = "Click to remove";
            itemWidget.AddEventListener("click", evt =>
            {
                RemoveSelectedItem(item);
                contentNode.Focus();
            });
            itemWidget.AppendChild(Browser.Document.CreateTextNode(textProvider(item)));

            var itemCell = Browser.Document.CreateElement("td");
            itemCell.Style.PaddingLeft = "2px";
            itemCell.AppendChild(itemWidget);

            itemCell.InsertBefore(contentNodeCell);

            selectedWidgets[item] = itemWidget;
            selectedItems.Add(item);
        }

        public void RemoveSelectedItem(T item)
        {
            var itemWidget = selectedWidgets[item];
            selectedWidgets.Remove(item);
            selectedItems.Remove(item);
            contentContainerRow.RemoveChild(itemWidget.ParentElement);
        }

        protected override Element CreateNode()
        {
            var contentContainer = Browser.Document.CreateElement("table");
            contentContainer.Style.Width = "100%";

            contentContainerRow = Browser.Document.CreateElement("tr");
            contentContainer.AppendChild(contentContainerRow);

//            contentContainer.Style.Height = "100%";

            contentNodeCell = Browser.Document.CreateElement("td");
            contentNodeCell.Style.Width = "100%";
            contentContainerRow.AppendChild(contentNodeCell);

            var contentNodeCellDiv = Browser.Document.CreateElement("div");
            contentNodeCellDiv.Style.Height = "100%";
            contentNodeCellDiv.Style.Width = "100%";
            contentNodeCell.AppendChild(contentNodeCellDiv);

            var loadingIconCell = Browser.Document.CreateElement("td");
            loadingIconCell.AppendChild(loadingIcon.Node);
            loadingIconCell.SetAttribute("align", "center");
            loadingIconCell.Style.VerticalAlign = "middle";
            loadingIconCell.Style.LineHeight = ".1";
            loadingIconCell.Style.PaddingRight = "2px";
            contentContainerRow.AppendChild(loadingIconCell);

            contentNode = Browser.Document.CreateElement("input").As<InputElement>();
            contentNode.SetAttribute("type", "text");
            contentNode.Style.Border = "0px black solid";
            contentNode.Style.Height = "100%";
            contentNode.Style.Width = "100%";
            contentNode.Style.PaddingLeft = "5px";
            contentNode.Style.Outline = "none";
            contentNode.AddEventListener("keydown", OnKeyDown);
            contentNode.AddEventListener("keypress", OnKeyPress);
            contentNode.AddEventListener("blur", OnBlur);
            contentNodeCellDiv.AppendChild(contentNode);

            overlayContainer = Browser.Document.CreateElement("div");
            overlayContainer.Style.Position = "absolute";
            overlayContainer.Style.Display = "none";
            overlayContainer.AppendChild(overlay.Node);

            // This prevents mouse events from forcing an onblur on the input control.  Basically,
            // we prevent the mousedown from propagating to the input control and so it cannot 
            // recognize the loss of focus.
            overlayContainer.AddEventListener("mousedown", e =>
            {
                e.StopImmediatePropagation();
                e.PreventDefault();
            });
            overlayContainer.AddEventListener("focus", e => Console.WriteLine("focus"));

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

        private void OnKeyDown(Event @event)
        {
            if (@event.KeyCode == KeyCode.DownArrow)
            {
                overlay.SelectNextItem();
                @event.StopImmediatePropagation();
                @event.PreventDefault();
            }
            else if (@event.KeyCode == KeyCode.UpArrow)
            {
                overlay.SelectPreviousItem();
                @event.StopImmediatePropagation();
                @event.PreventDefault();
            }
            else if (@event.KeyCode == KeyCode.Escape)
            {
                CloseUp();
                @event.StopImmediatePropagation();
                @event.PreventDefault();
            }
            else if (@event.KeyCode == KeyCode.Enter)
            {
                Commit();
                CloseUp();
                @event.StopImmediatePropagation();
                @event.PreventDefault();
            }
        }

        private async void OnKeyPress(Event @event)
        {
            if (canceller != null)
            {
                canceller.Cancel();
            }

            canceller = new CancellationTokenSource();
            try
            {
                await Task.Delay(1000, canceller.Token);
                await OnSearch(contentNode.Value, PopulateItems);
            }
            catch (TaskCanceledException)
            {
                // We don't care if the task has been cancelled -- that's the point
            }
        }

        private void OnBlur(Event @event)
        {
            CloseUp();
        }

        private async Task OnSearch(string text, Action<T[]> populateItems)
        {
            loadingIcon.Style.Display = CssDisplay.Inherit;
            if (Search != null)
                await Search(text, populateItems);
            loadingIcon.Style.Display = CssDisplay.None;
        }

        private void PopulateItems(T[] items)
        {
            overlay.Clear();
            foreach (var item in items)
            {
                overlay.Add(item);
            }
            DropDown();
        }

        private void OverlayChanged()
        {
            if (!Multiselect)
            {
                SelectedItem = overlay.SelectedItem;
            }
        }

        private void Commit()
        {
            if (Multiselect)
            {
                AddSelectedItem(overlay.SelectedItem);
                Text = "";
            }
        }
    }
}