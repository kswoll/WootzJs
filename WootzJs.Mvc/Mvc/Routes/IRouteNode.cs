using System.Collections.Generic;

namespace WootzJs.Mvc.Mvc.Routes
{
    public interface IRouteNode
    {
        List<RouteNode> Children { get; }
        IRouteNode FindDuplicate(IRouteNode parent);
    }
}