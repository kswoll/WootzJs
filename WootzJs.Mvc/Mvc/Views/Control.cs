using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Action> click;
        private List<Action> mouseEnter;
        private List<Action> mouseLeave;

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
                Node.AddEventListener("mouseentered", OnJsMouseEnter);
                Node.AddEventListener("mouseexited", OnJsMouseLeave);
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

        public void Click(Action handler)
        {
            if (click == null)
            {
                Node.AddEventListener("click", OnJsClick);
                click = new List<Action>();
            }
            click.Add(handler);
        }

        public void UnClick(Action handler)
        {
            if (click != null)
            {
                click.Remove(handler);
                if (!click.Any())
                {
                    click = null;
                    Node.RemoveEventListener("click", OnJsClick);
                }
            }
        }

        public void MouseEnter(Action handler)
        {
            if (mouseEnter == null)
            {
//                Node.AddEventListener("mouseentered", OnJsMouseEnter);
                mouseEnter = new List<Action>();
            }
            mouseEnter.Add(handler);
        }

        public void UnMouseEnter(Action handler)
        {
            if (mouseEnter != null)
            {
                mouseEnter.Remove(handler);
                if (!mouseEnter.Any())
                {
                    mouseEnter = null;
                    Node.RemoveEventListener("mouseentered", OnJsMouseEnter);
                }
            }
        }

        public void MouseLeave(Action handler)
        {
            if (mouseLeave == null)
            {
//                Node.AddEventListener("mouseexited", OnJsMouseLeave);
                mouseLeave = new List<Action>();
            }
            mouseLeave.Add(handler);
        }

        public void UnMouseLeave(Action handler)
        {
            if (mouseLeave != null)
            {
                mouseLeave.Remove(handler);
                if (!mouseLeave.Any())
                {
                    mouseLeave = null;
                    Node.RemoveEventListener("mouseexited", OnJsMouseLeave);
                }
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
            if (this.click != null)
            {
                var click = this.click.ToArray();
                foreach (var handler in click)
                    handler();
            }
        }

        protected virtual void OnMouseEnter()
        {
            if (this.mouseEnter != null)
            {
                var mouseEnter = this.mouseEnter.ToArray();
                foreach (var handler in mouseEnter)
                    handler();
            }
        }

        protected virtual void OnMouseLeave()
        {
            if (this.mouseLeave != null)
            {
                var mouseLeave = this.mouseLeave.ToArray();
                foreach (var handler in mouseLeave)
                    handler();
            }
        }

        public static implicit operator Control(string text)
        {
            return new Text(text);
        }
    }
}