using System;
using System.Collections.Generic;
using System.Reflection;

namespace WootzJs.Mvc.Mvc.Views
{
    public class View 
    {
        public Layout Layout { get; private set; }
        public Type LayoutType { get; set; }
        public string Title { get; set; }
        public ViewContext ViewContext { get; private set; }
        public IDictionary<string, Control> Sections { get; private set; }

        private Control _content;
        private bool isInitialized;

        public void Initialize(ViewContext context)
        {
            Sections = new Dictionary<string, Control>();
            isInitialized = true;
            ViewContext = context;
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
            if (Content != null)
                Content.NotifyOnAddedToView();
        }

        public Control Content
        {
            get { return _content; }
            set
            {
                _content = value;
                value.View = this;
                if (isInitialized)
                    value.NotifyOnAddedToView();
            }
        }

        protected void VerifyLayouts()
        {
            if (Layout == null && LayoutType != null)
            {
                Layout = CreateLayout();
                if (ViewContext == null)
                    throw new Exception("ControllerContext not set yet");
                Layout.Initialize(ViewContext);
                Layout.AddView(this);
            }
        }

        public View GetRootView()
        {
            VerifyLayouts();
            if (Layout != null)
                return Layout.GetRootView();
            else
                return this;
        }

        protected virtual Layout CreateLayout()
        {
            return (Layout)Activator.CreateInstance(LayoutType);
        }
    }
}