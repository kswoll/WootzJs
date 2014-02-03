using System;
using System.Collections.Generic;
using System.Runtime.WootzJs;
using WootzJs.Web;
using Style = WootzJs.Mvc.Mvc.Views.Css.Style;

namespace WootzJs.Mvc.Mvc.Views
{
    public class Control
    {
        static Control()
        {
            new MouseTrackingEngine().Initialize();
        }

        public Control Parent { get; private set; }
        public View View { get; internal set; }

        protected string TagName { get; set; }

        private Element node;
        private List<Control> children = new List<Control>();
        private Style style;
        private Action click;
        private Action mouseEntered;
        private Action mouseExited;

        public Control()
        {
            TagName = "div";
        }

        public Control(Element node)
        {
            Node = node;
        }

        public ViewContext ViewContext
        {
            get
            {
                if (View != null)
                    return View.ViewContext;
                else if (Parent != null)
                    return Parent.ViewContext;
                else
                    return null;
            }
        }

        public Style Style 
        {
            get
            {
                if (style == null)
                    Style = new Style();
                return style;
            }
            set
            {
                style = value;
                style.Attach(Node.Style);
            }
        }

        public Element Node
        {
            get { return EnsureNodeExists(); }
            private set
            {
                node = value;
                node.As<JsObject>().memberset("$control", this.As<JsObject>());
            }
        }

        public static Control GetControlForElement(Element element)
        {
            return element.As<JsObject>().member("$control").As<Control>();
        }

        protected virtual Element CreateNode()
        {
            return Browser.Document.CreateElement(TagName);
        }

        protected Element EnsureNodeExists()
        {
            if (node == null)
            {
                Node = CreateNode();
                node.SetAttribute("data-class-name", GetType().FullName);
                if (style != null)
                    style.Attach(node.Style);
            }
            return node;
        }

        protected void Add(Control child)
        {
            if (child.Parent == this)
                throw new Exception("The speciifed child is already present in this container");
            children.Add(child);
            child.Parent = this;
            EnsureNodeExists();
            child.OnAdded();
        }

        protected void Remove(Control child)
        {
            if (child.Parent != this)
                throw new Exception("The specified child is not contained in this container");

            children.Remove(child);
            child.Parent = null;

            child.OnRemoved();
        }

        public int Count
        {
            get { return children.Count; }
        }

        public IEnumerable<Control> Children
        {
            get { return children; }
        }

        protected virtual void OnAdded()
        {
        }

        protected virtual void OnRemoved()
        {
        }

        public event Action Click
        {
            add
            {
                if (click == null)
                    Node.AddEventListener("click", OnJsClick);
                click = (Action)Delegate.Combine(click, value);
            }
            remove
            {
                click = (Action)Delegate.Remove(click, value);
                if (click == null)
                    Node.RemoveEventListener("click", OnJsClick);
            }
        }

        public event Action MouseEntered
        {
            add
            {
                if (mouseEntered == null)
                    Node.AddEventListener("mouseentered", OnJsMouseEnter);
                mouseEntered = (Action)Delegate.Combine(mouseEntered, value);
            }
            remove
            {
                mouseEntered = (Action)Delegate.Remove(mouseEntered, value);
                if (mouseEntered == null)
                    Node.RemoveEventListener("mouseentered", OnJsMouseEnter);
            }
        }

        public event Action MouseExited
        {
            add
            {
                if (mouseExited == null)
                    Node.AddEventListener("mouseexited", OnJsMouseLeave);
                mouseExited = (Action)Delegate.Combine(mouseExited, value);
            }
            remove
            {
                mouseExited = (Action)Delegate.Remove(mouseExited, value);
                if (mouseExited == null)
                    Node.RemoveEventListener("mouseexited", OnJsMouseLeave);
            }
        }

        private void OnJsClick(Event evt)
        {
            OnClick();
        }

        private void OnJsMouseEnter(Event evt)
        {
            OnMouseEnter();
        }

        private void OnJsMouseLeave(Event evt)
        {
            OnMouseLeave();
        }

        protected virtual void OnClick()
        {
            var click = this.click;
            if (click != null)
                click();
        }

        protected virtual void OnMouseEnter()
        {
            var mouseEntered = this.mouseEntered;
            if (mouseEntered != null)
                mouseEntered();
        }

        protected virtual void OnMouseLeave()
        {
            var mouseExited = this.mouseExited;
            if (mouseExited != null)
                mouseExited();
        }

        public static implicit operator Control(string text)
        {
            return new Text(text);
        }
    }
}