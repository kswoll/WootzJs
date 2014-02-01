using WootzJs.JQuery;

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

        protected override jQuery CreateNode()
        {
            var a = new jQuery("<a></a>");
            a.attr("href", "javascript:void(0);");
            a.css("display", "block");

            return a;
        }

        /// <summary>
        /// Using this propery will remove any existing children added via Add.
        /// </summary>
        public string Text
        {
            get { return Node.text(); }
            set
            {
                Node.empty();
                Node.text(value);
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
                Node.empty();

            Add((Control)child);
            useTextMode = false;
        }

        public void Remove(IInlineControl child)
        {
            Remove((Control)child);
        }
    }
}