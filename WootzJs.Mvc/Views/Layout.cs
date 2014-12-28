using System;
using System.Collections.Generic;

namespace WootzJs.Mvc.Views
{
    public abstract class Layout : View
    {
        private List<View> subviews = new List<View>();

        public void AddView(View view)
        {
            OnAddView(view);
            subviews.Add(view);
            view.NotifyViewAttached();
        }

        public void RemoveView(View view)
        {
            subviews.Remove(view);
            view.NotifyViewDetached();
        }

        protected virtual void OnAddView(View view)
        {
        }

        public virtual Layout FindLayout(Type layoutType)
        {
            if (layoutType == GetType())
                return this;
            else
                return null;
        }

        public virtual void LoadSections(IDictionary<string, Control> sections)
        {
        }
    }
}