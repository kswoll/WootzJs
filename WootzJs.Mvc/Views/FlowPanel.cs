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
        public new void Add(Control control)
        {
            Node.AppendChild(control.Node);
            base.Add(control);
        }

        public new void Remove(Control control)
        {
            control.Node.Remove();
            base.Remove(control);
        }

        protected override Element CreateNode()
        {
            var span = CreateElement("span");
            return span;
        }
    }
}