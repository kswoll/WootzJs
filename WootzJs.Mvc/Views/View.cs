using System;
using System.Collections.Generic;
using WootzJs.Mvc.Views.Binders;

namespace WootzJs.Mvc.Views
{
    public class View : IDisposable
    {
        public event Action Attached;
        public event Action Detached;

        public Layout Layout { get; private set; }
        public Type LayoutType { get; set; }
        public string Title { get; set; }
        public ViewContext ViewContext { get; private set; }

        private Control content;
        private bool isInitialized;
        private IDictionary<string, Control> sections;
        private bool isDisposed;

        public MvcApplication Application => MvcApplication.Instance;
        public NavigationContext NavigationContext => Application.NavigationContext;
        public NavigationRequest Request => NavigationContext.Request;

        public void Dispose()
        {
            if (isDisposed)
                throw new Exception("Cannot dispose a view that has already been disposed.");
            isDisposed = true;
            Content.Dispose();
        }

        public void Initialize(ViewContext context)
        {
            isInitialized = true;
            ViewContext = context;
            OnInitialize();
        }

        protected virtual void OnInitialize()
        {
            Content?.NotifyOnAddedToView();
        }

        public Control Content
        {
            get { return content; }
            set
            {
                content?.NotifyOnRemovedFromView();
                content = value;
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

        public IDictionary<string, Control> Sections => sections ?? (sections = new Dictionary<string, Control>());

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
            Attached?.Invoke();
        }

        protected virtual void OnViewDetached()
        {
            Detached?.Invoke();
        }
    }

    public class View<TModel> : View, IModelContainer<TModel> 
    {
        public TModel Model { get; }
        public Bindings<TModel> Binders { get; private set; }

        public View(TModel model)
        {
            Model = model;
            Binders = new Bindings<TModel>(model);
        }
    }
}