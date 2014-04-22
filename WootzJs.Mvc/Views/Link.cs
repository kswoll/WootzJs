using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    public class Link : Control
    {
        private bool useTextMode;
        private string localHref;

        public Link() 
        {
        }

        public Link(string text)
        {
            Text = text;
        }

        public void FireClick()
        {
            OnClick(new Event("click"));
        }

        public string LocalHref
        {
            get { return localHref; }
            set
            {
                EnsureNodeExists();
                if (localHref != null)
                {
                    Node.SetAttribute("href", "javascript:void(0);");
                    Click -= LocalHrefClick;
                }

                localHref = value;

                if (localHref != null)
                {
                    Node.SetAttribute("href", value);
                    Click += LocalHrefClick;
                }
            }
        }

        private void LocalHrefClick(Event evt)
        {
            ViewContext.ControllerContext.Application.Open(Node.GetAttribute("href"), null);
            evt.PreventDefault();
        }

        protected override Element CreateNode()
        {
            var a = Browser.Document.CreateElement("a");
            a.SetAttribute("href", "javascript:void(0);");
            a.Style.Display = "inline-block";

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
        public new void Add(Control child)
        {
            if (useTextMode)
                Node.InnerHtml = "";

            base.Add(child);
            Node.AppendChild(child.Node);
            useTextMode = false;
        }

        public new void Remove(Control child)
        {
            base.Remove(child);
            Node.RemoveChild(child.Node);
        }
    }
}