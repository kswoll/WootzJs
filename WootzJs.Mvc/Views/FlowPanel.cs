using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    /// <summary>
    /// This panel renders its children as a normal series of HTML elements.  If you wish to to 
    /// align images and other content to the left or right so that content flows around it, 
    /// you'll need to use this panel in conjunction with AlignPanel.
    /// </summary>
    public class FlowPanel : Control
    {
        public void Add(Control control)
        {
            Node.AppendChild(control.Node);
            AddChild(control);
        }

        public void Remove(Control control)
        {
            RemoveChild(control);
        }

        protected override void RemoveChild(Control child)
        {
            child.Node.Remove();
            base.RemoveChild(child);
        }

        public new void RemoveAll()
        {
            base.RemoveAll();
        }

        protected override Element CreateNode()
        {
            var span = CreateElement("span");
            return span;
        }
    }
}