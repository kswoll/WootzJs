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
        public event Action AttachedToDom;

        protected string TagName { get; set; }

        private Element node;
        private List<Control> children = new List<Control>();
        private Style style;
        private Action<Event> click;
        private Action mouseEntered;
        private Action mouseExited;
        private Action mouseDown;
        private Action mouseUp;
        private bool isAttachedToDom;
        private View view;

        public Control(string tagName = "div")
        {
            TagName = tagName;
        }

        public Control(Element node)
        {
            Node = node;
            isAttachedToDom = node.IsAttachedToDom();
        }

        public View View
        {
            get { return view; }
            internal set { view = value; }
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

        protected virtual void Clear()
        {
            foreach (var child in Children.ToArray())
            {
                Remove(child);
            }
        }

        public int Count
        {
            get { return children.Count; }
        }

        public bool IsAttachedToDom
        {
            get { return isAttachedToDom; }
        }

        public IEnumerable<Control> Children
        {
            get { return children; }
        }

        protected virtual void OnAdded()
        {
            if (Parent.isAttachedToDom)
                OnAttachedToDom();
        }

        protected virtual void OnRemoved()
        {
        }

        public event Action<Event> Click
        {
            add
            {
                if (click == null)
                    Node.AddEventListener("click", OnJsClick);
                click = (Action<Event>)Delegate.Combine(click, value);
            }
            remove
            {
                click = (Action<Event>)Delegate.Remove(click, value);
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

        public event Action MouseDown
        {
            add
            {
                if (mouseDown == null)
                    Node.AddEventListener("mousedown", OnJsMouseDown);
                mouseDown = (Action)Delegate.Combine(mouseDown, value);
            }
            remove
            {
                mouseDown = (Action)Delegate.Remove(mouseDown, value);
                if (mouseDown == null)
                    Node.RemoveEventListener("mousedown", OnJsMouseDown);
            }
        }

        public event Action MouseUp
        {
            add
            {
                if (mouseUp == null)
                    Node.AddEventListener("mouseup", OnJsMouseUp);
                mouseUp = (Action)Delegate.Combine(mouseUp, value);
            }
            remove
            {
                mouseUp = (Action)Delegate.Remove(mouseUp, value);
                if (mouseUp == null)
                    Node.RemoveEventListener("mouseup", OnJsMouseUp);
            }
        }

        private void OnJsClick(Event evt)
        {
            OnClick(evt);
        }

        private void OnJsMouseEnter(Event evt)
        {
            OnMouseEnter();
        }

        private void OnJsMouseLeave(Event evt)
        {
            OnMouseLeave();
        }

        private void OnJsMouseDown(Event evt)
        {
            OnMouseDown();
        }

        private void OnJsMouseUp(Event evt)
        {
            OnMouseUp();
        }

        protected void OnClick(Event evt)
        {
            var click = this.click;
            if (click != null)
                click(evt);
        }

        private void OnMouseEnter()
        {
            var mouseEntered = this.mouseEntered;
            if (mouseEntered != null)
                mouseEntered();
        }

        private void OnMouseLeave()
        {
            var mouseExited = this.mouseExited;
            if (mouseExited != null)
                mouseExited();
        }

        private void OnMouseDown()
        {
            var mouseDown = this.mouseDown;
            if (mouseDown != null)
                mouseDown();
        }

        private void OnMouseUp()
        {
            var mouseUp = this.mouseUp;
            if (mouseUp != null)
                mouseUp();
        }

        public static implicit operator Control(string text)
        {
            return new Text(text);
        }

        protected virtual void OnAttachedToDom()
        {
            isAttachedToDom = true;
            var attachedToDom = AttachedToDom;
            if (attachedToDom != null)
                attachedToDom();

            foreach (var child in Children)
            {
                child.OnAttachedToDom();
            }
        }

        protected virtual void OnAddedToView()
        {
            foreach (var child in Children)
            {
                child.View = View;
                child.OnAddedToView();
            }
        }

        internal void NotifyOnAddedToView()
        {
            OnAddedToView();
        }
    }
}