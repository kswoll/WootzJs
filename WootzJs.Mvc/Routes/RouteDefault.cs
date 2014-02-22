using System.Collections.Generic;

namespace WootzJs.Mvc.Routes
{
    public class RouteDefault : RoutePart
    {
        public RouteDefault(IDictionary<string, object> routeData = null) : base(routeData)
        {
        }

        public RouteDefault(string key, object value) : base(key, value)
        {
        }
        
        protected override bool IsDuplicate(IRoutePart part)
        {
            return part is RouteDefault;
        }

        protected override bool Accept(RoutePath path)
        {
            // We only want to apply default routes if there's nothing left in the path
            return path.Current == null;
        }

        protected override void ConsumePath(RoutePath path)
        {
        }

        public override string ToString()
        {
            return "(default) " + base.ToString();
        }
    }
}