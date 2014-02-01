using System;
using System.Collections.Generic;
using System.Linq;

namespace WootzJs.Mvc.Mvc.Routes
{
    public class RouteTree : IRouteNode
    {
        public List<RouteNode> RootPaths { get; set; }

        public RouteTree()
        {
            RootPaths = new List<RouteNode>();
        }

        public List<RouteNode> Children
        {
            get { return RootPaths; }
        }

        public IRouteNode FindDuplicate(IRouteNode parent)
        {
            return null;
        }

        public RouteData Apply(string path, string method)
        {
            path = path.ChopEnd("/");
            var routePath = new RoutePath(path.ToLower());
            var route = CalculateRoute(path, method);
            if (route == null)
            {
                throw new InvalidOperationException("Could not apply the URL path '" + path + "'.  No route supports this path.");
            }

            var routeData = new RouteData();
            routePath = new RoutePath(path);

            foreach (var part in route)
            {
                part.ProcessData(routePath, routeData);
            }

            return routeData;
        }

        private IRoutePart[] CalculateRoute(string path, string httpMethod)
        {
            var routePath = new RoutePath(path);
            var route = new RouteBuilder();
            
            foreach (var node in RootPaths)
            {
                if (CalculateRoute(routePath, httpMethod, route, node))
                {
                    return route.ToArray();
                }
            }

            return null;
        }

        private bool CalculateRoute(RoutePath path, string httpMethod, RouteBuilder route, RouteNode node)
        {
            using (path.Pin())
            using (var pin = route.Pin())
            {
                if (node.Part.AcceptPath(path, httpMethod))
                {
                    route.Add(node.Part);
                    
                    if (node.Children.Any())
                    {
                        foreach (var child in node.Children)
                        {
                            if (CalculateRoute(path, httpMethod, route, child))
                            {
                                pin.Accept();
                                return true;
                            }
                        }                    
                    }
                    else if (!path.Any())
                    {
                        pin.Accept();
                        return true;
                    }
                }
                return false;
            }
        }

        public override string ToString()
        {
            return "(root)";
        }
    }
}