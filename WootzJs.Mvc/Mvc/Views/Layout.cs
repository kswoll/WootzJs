using System;
using System.Collections.Generic;

namespace WootzJs.Mvc.Mvc.Views
{
    public abstract class Layout : View
    {
        public abstract void AddView(View view);

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