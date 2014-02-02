using WootzJs.Web;

namespace WootzJs.Mvc.Mvc.Views
{
    public class LinkPanel : Control    
    {
        private bool useTextMode;

        public LinkPanel() 
        {
        }

        public LinkPanel(string text)
        {
            Text = text;
        }

        protected override Element CreateNode()
        {
            var a = Browser.Document.CreateElement("a");
            a.SetAttribute("href", "javascript:void(0);");
            a.Style.Display = "block";

            return a;
        }

        /// <summary>
        /// Using this propery will remove any existing children added via Add.
        /// </summary>
        public string Text
        {
            get { return Node.NodeValue; }
            set
            {
                Node.InnerHtml = value;
                useTextMode = true;
            }
        }

        /// <summary>
        /// Using this property will remove any text added via Text.
        /// </summary>
        /// <param name="child"></param>
        public void Add(IInlineControl child)
        {
            if (useTextMode)
                Node.InnerHtml = "";

            Add((Control)child);
            useTextMode = false;
        }

        public void Remove(IInlineControl child)
        {
            Remove((Control)child);
        }
    }
}