using System;
using System.Collections.Generic;
using WootzJs.Mvc.Views.Binders;

namespace WootzJs.Mvc.Views
{
    public class View 
    {
        public event Action Attached;
        public event Action Detached;

        public Layout Layout { get; private set; }
        public Type LayoutType { get; set; }
        public string Title { get; set; }
        public ViewContext ViewContext { get; private set; }

        private Control _content;
        private bool isInitialized;
        private IDictionary<string, Control> sections;

        public MvcApplication Application
        {
            get { return MvcApplication.Instance; }
        }

        public NavigationContext NavigationContext
        {
            get {  return Application.NavigationContext; }
        }

        public NavigationRequest Request
        {
            get { return NavigationContext.Request; }
        }

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

        public UrlHelper Url
        {
            get
            {
                if (ViewContext != null)
                    return ViewContext.Url;
                else
                    return MvcApplication.Instance.Url;
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

        internal void NotifyViewAttached()
        {
            OnViewAttached();
        }

        internal void NotifyViewDetached()
        {
            OnViewDetached();
        }

        protected virtual void OnViewAttached()
        {
            if (Attached != null)
                Attached();
        }

        protected virtual void OnViewDetached()
        {
            if (Detached != null)
                Detached();
        }
    }

    public class View<TModel> : View, IModelContainer<TModel> 
    {
        public TModel Model { get; private set; }
        public Bindings<TModel> Binders { get; private set; }

        public View(TModel model)
        {
            Model = model;
            Binders = new Bindings<TModel>(model);
        }
    }
}