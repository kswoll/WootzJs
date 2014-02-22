using System.Runtime.WootzJs;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    internal class MouseTrackingEngine
    {
        Element lastElement;

        internal void Initialize()
        {
            Browser.Window.AddEventListener("mousemove", OnMouseMove);         
            Browser.Window.AddEventListener("mouseout", OnMouseOut);         
        }

        private void OnMouseMove(Event evt)
        {
            var currentElement = evt.Target;
            if (lastElement != currentElement)
            {
                var current = currentElement;
                while (current != null)
                {
                    var hasMouse = current.As<JsObject>().member("$hasMouse");
                    if (!hasMouse)
                        FireMouseEntered(current);
                    else
                        break;
                    current = current.ParentElement;
                }

                // If the new element is not contained in the last element...
                if (lastElement != null && !currentElement.IsDescendentOf(lastElement))
                {
                    var last = lastElement;
                    while (last != null)
                    {
                        if (!last.Contains(currentElement))
                            FireMouseExited(last);
                        else
                            break;
                        last = last.ParentElement;
                    }
                }

                lastElement = currentElement;
            }
        }

        private void FireMouseEntered(Element element)
        {
            element.As<JsObject>().memberset("$hasMouse", true);
            var mouseEnterEvent = Browser.Document.CreateCustomEvent("mouseentered", null);
            element.DispatchEvent(mouseEnterEvent);            
        }

        private void FireMouseExited(Element element)
        {
            element.As<JsObject>().memberset("$hasMouse", false);
            var mouseExitedEvent = Browser.Document.CreateCustomEvent("mouseexited", null);
            element.DispatchEvent(mouseExitedEvent);                                
        }

        private void OnMouseOut(Event evt)
        {
            if (evt.RelatedTarget == null)
            {
                var current = lastElement;
                while (current != null)
                {
                    FireMouseExited(lastElement);                
                    current = current.ParentElement;
                }
            }
        }
    }
}