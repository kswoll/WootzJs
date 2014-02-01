using WootzJs.JQuery;

namespace WootzJs.Mvc.Mvc.Views
{
    public class Link : Control, IInlineControl
    {
        private bool useTextMode;

        public Link() 
        {
        }

        public Link(string text)
        {
            Text = text;
        }

        protected override jQuery CreateNode()
        {
            var a = new jQuery("<a></a>");
            a.attr("href", "javascript:void(0);");

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
                if (!useTextMode)
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