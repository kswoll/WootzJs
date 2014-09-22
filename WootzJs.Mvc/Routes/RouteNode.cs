using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Mvc.Routes
{
    public class RouteNode : IRouteNode
    {
        public IRoutePart Part { get; set; } 
        public List<RouteNode> Children { get; set; }

        public RouteNode(IRoutePart part)
        {
            Part = part;
            Children = new List<RouteNode>();
        }

        public override string ToString()
        {
            return Part.ToString();
        }
    }
}