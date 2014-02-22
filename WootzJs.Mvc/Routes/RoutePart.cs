using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Mvc.Routes
{
    public abstract class RoutePart : IRoutePart
    {
        protected abstract bool Accept(RoutePath path);

        public IDictionary<string, object> RouteData { get; private set; }
        
        protected RoutePart(IDictionary<string, object> routeData = null)
        {
            RouteData = routeData ?? new Dictionary<string, object>();
        }
        
        public IRoutePart FindDuplicate(IEnumerable<IRoutePart> parts)
        {
            return parts.FirstOrDefault(x => IsDuplicate(x));
        }        
        
        protected virtual bool IsDuplicate(IRoutePart part)
        {
            object otherMethodObj;
            part.RouteData.TryGetValue(Routes.RouteData.RequiredHttpMethodKey, out otherMethodObj);
            var otherMethod = (string)otherMethodObj;
            bool result = (RequiredHttpMethod == null && otherMethod == null) || RequiredHttpMethod == otherMethod;
            return result;
        }
        
        public string RequiredHttpMethod
        {
            get
            {
                object requiredHttpMethod;
                if (RouteData.TryGetValue(Routes.RouteData.RequiredHttpMethodKey, out requiredHttpMethod))
                {
                    return (string)requiredHttpMethod;
                }
                return null;
            }
            set
            {
                RouteData[Routes.RouteData.RequiredHttpMethodKey] = value;
            }
        }

        protected RoutePart(string key, object value) :
            this(new Dictionary<string, object> {{ key, value }})
        {
        }
        
        public bool AcceptPath(RoutePath path, string httpMethod)
        {
            var requiredHttpMethod = RequiredHttpMethod;
            if (requiredHttpMethod != null && httpMethod != (string)requiredHttpMethod)
                return false;
            return Accept(path);
        }

        protected virtual void ConsumePath(RoutePath path)
        {
            path.Consume();
        }
 
        public virtual void ProcessData(RoutePath path, RouteData data)
        {
            ConsumePath(path);
            foreach (var item in RouteData)
            {
                data[item.Key] = item.Value;
            }
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", RouteData.Select(x => x.Key + "=" + x.Value)) + " }";
        }
    }
}