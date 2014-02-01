using System;
using System.Reflection;

namespace WootzJs.Mvc.Mvc.Views
{
    public class View 
    {
        public Layout Layout { get; private set; }
        public Type LayoutType { get; set; }
        public string Title { get; set; }
        public ViewContext ViewContext { get; private set; }

        private Control _content;

        public void Initialize(ViewContext context)
        {
            ViewContext = context;
        }

        public Control Content
        {
            get { return _content; }
            set
            {
                _content = value;
                value.View = this;
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