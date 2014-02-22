using System;
using System.Collections.Generic;

namespace WootzJs.Mvc.Views
{
    public class View 
    {
        public Layout Layout { get; private set; }
        public Type LayoutType { get; set; }
        public string Title { get; set; }
        public ViewContext ViewContext { get; private set; }

        private Control _content;
        private bool isInitialized;
        private IDictionary<string, Control> sections;

        public void Initialize(ViewContext context)
        {
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

        public IDictionary<string, Control> Sections
        {
            get { return sections ?? (sections = new Dictionary<string, Control>()); }
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
            return (Layout)ViewContext.ControllerContext.Application.DependencyResolver.GetService(LayoutType);
        }
    }
}