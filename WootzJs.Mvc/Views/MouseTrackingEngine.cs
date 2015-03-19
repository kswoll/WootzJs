using System;
using System.Runtime.WootzJs;
using System.Threading.Tasks;
using WootzJs.Web;

namespace WootzJs.Mvc.Views
{
    internal class MouseTrackingEngine
    {
        Element lastElement;
        bool isMouseDown;
        Element mouseDownTarget;
        bool wasAtBottom;

        internal void Initialize()
        {
            Browser.Window.AddEventListener("mousemove", OnMouseMove);         
            Browser.Window.AddEventListener("mouseout", OnMouseOut);         
            Browser.Window.AddEventListener("mousedown", OnMouseDown);
            Browser.Window.AddEventListener("mouseup", OnMouseUp);         
            Browser.Window.AddEventListener("wheel", OnWheel);
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

        private void FireMouseUp(Element element)
        {
            var mouseExitedEvent = Browser.Document.CreateCustomEvent("mouseup", null);
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

        private void OnMouseDown(Event evt)
        {
            isMouseDown = true;
            mouseDownTarget = evt.Target;
        }

        private void OnMouseUp(Event evt)
        {
            isMouseDown = false;
            if (evt.Target != mouseDownTarget)
                FireMouseUp(mouseDownTarget);
        }

        private async void OnWheel(Event evt)
        {
//            var wheelEvent = evt.As<WheelEvent>();
            var atBottom = Browser.Window.InnerHeight + Browser.Window.ScrollY == Browser.Document.Body.ScrollHeight;
            if (wasAtBottom != atBottom)
            {
                wasAtBottom = atBottom;

                // This section resets the wasAtBottom state if the scroll bars aren't visible.  This is to allow further
                // triggering after the delay.  Otherwise, once you've gotten the first wasAtBottom change to occur, it
                // would never fire again.
                if (wasAtBottom && Browser.Window.ScrollY == 0)
                {
                    await Task.Delay(3000);
                    wasAtBottom = false;
                }
                if (wasAtBottom && MvcApplication.Instance.View != null)
                {
                    MvcApplication.Instance.NotifyOnBottomBounced();
                }
            }
        }

        public bool IsMouseDown
        {
            get { return isMouseDown; }
        }
    }
}