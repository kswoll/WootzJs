using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Mvc.Mvc.Routes
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

        public IRouteNode FindDuplicate(IRouteNode parent)
        {
            var duplicate = Part.FindDuplicate(parent.Children.Select(x => x.Part));
            if (duplicate != null)
            {
                return parent.Children.Single(x => x.Part == duplicate);
            }
            return null;
        }

        public override string ToString()
        {
            return Part.ToString();
        }
    }
}