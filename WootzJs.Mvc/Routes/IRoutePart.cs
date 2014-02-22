using System.Collections.Generic;

namespace WootzJs.Mvc.Routes
{
    public interface IRoutePart
    {
        bool AcceptPath(RoutePath path, string httpMethod);
        void ProcessData(RoutePath path, RouteData data);
        IRoutePart FindDuplicate(IEnumerable<IRoutePart> parts);
        IDictionary<string, object> RouteData { get; }
    }
}