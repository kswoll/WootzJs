using System.Collections.Generic;

namespace WootzJs.Mvc.Routes
{
    public interface IRouteNode
    {
        List<RouteNode> Children { get; }
    }
}