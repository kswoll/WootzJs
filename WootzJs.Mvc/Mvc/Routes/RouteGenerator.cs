using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WootzJs.Mvc.Mvc.Routes
{
    public class RouteGenerator
    {
        public RouteTree GenerateRoutes(Assembly assembly)
        {
            var controllerTypes = assembly.GetTypes().Where(x => typeof(Controller).IsAssignableFrom(x));
            return GenerateRoutes(controllerTypes);
        }

        private RouteTree GenerateRoutes(IEnumerable<Type> controllerTypes)
        {
            var pathTree = new RouteTree();
            foreach (var type in controllerTypes)
            {
                Console.WriteLine(type.FullName);
                GenerateRoutesForController(pathTree, type);
            }
            return pathTree;
        }

        public void GenerateRoutesForController(RouteTree routeTree, Type controllerType)
        {
            var routeAttributes = controllerType.GetCustomAttributes(typeof(RouteAttribute), true);
            var routeAttribute = routeAttributes.Length > 0 ? (RouteAttribute)routeAttributes[0] : null;
            string route;
            if (routeAttribute == null)
                route = GenerateDefaultRouteForController(controllerType);
            else
                route = routeAttribute.Value;
            var routePath = new RoutePath(route);

            var currentNode = (IRouteNode)routeTree;
            var leafNodes = new List<RouteNode>();

            do
            {
                RouteNode nextNode = null;
                if (routePath.Current != null)
                {
                    var routePart = routePath.Consume();
                    var part = new RouteLiteral(routePart, true);
                    nextNode = new RouteNode(part);
                    AddNode(currentNode, nextNode);                    

                    if (routePath.Current == null)
                    {
                        part.RouteData[RouteData.ControllerKey] = controllerType;
                        leafNodes.Add(nextNode);
                    }
                }
                // If defined as a default route, then we don't require the last path part
                if (routePath.Current == null)
                {
                    var defaultAttributes = controllerType.GetCustomAttributes(typeof(DefaultAttribute), true);
                    if (defaultAttributes.Length > 0)
                    {
                        var defaultNode = new RouteNode(new RouteDefault(RouteData.ControllerKey, controllerType));
                        AddNode(currentNode, defaultNode);
                        leafNodes.Add(defaultNode);
                    }
                }
                currentNode = nextNode;
            } 
            while (routePath.Current != null);

            foreach (var method in controllerType.GetMethods().Where(x => x.IsPublic && !x.IsStatic && typeof(ActionResult).IsAssignableFrom(x.ReturnType)))
            {
                GenerateRoutesForAction(routeTree, controllerType, leafNodes, method);
            }
        }

        private void GenerateRoutesForAction(RouteTree routeTree, Type controllerType, List<RouteNode> parentNodes, MethodInfo actionMethod)
        {
            var routeAttributes = actionMethod.GetCustomAttributes(typeof(RouteAttribute), true);
            var routeAttribute = routeAttributes.Length > 0 ? (RouteAttribute)routeAttributes[0] : null;
            string route;
            if (routeAttribute == null)
                route = GenerateDefaultRouteForAction(actionMethod);
            else
                route = routeAttribute.Value;

            string httpMethod = null;
            if (actionMethod.IsDefined(typeof(HttpPostAttribute), false))
            {
                httpMethod = "POST";
            }

            bool addToRoot = false;
            if (route.StartsWith("/"))
            {
                addToRoot = true;
            }

            var effectiveNodes = addToRoot ? new[] { (IRouteNode)routeTree } : parentNodes.ToArray();

            foreach (var node in effectiveNodes)
            {
                var routePath = new RoutePath(route);
                var currentNode = node;
                do
                {
                    RouteNode nextNode = null;

                    if (routePath.Current != null)
                    {
                        var part = routePath.Consume();
                        if (part == "@")
                        {
                            part = GenerateDefaultRouteForAction(actionMethod);
                        }
                        RoutePart routePart;
                        if (part == "*")
                        {
                            var parameter = actionMethod.GetParameters().Single();
                            routePart = new RouteWildcard(parameter);
                        }                        
                        else if (part.StartsWith("{") && part.EndsWith("}"))
                        {
                            var id = part.ChopStart("{").ChopEnd("}");
                            var parameter = actionMethod.GetParameters().Single(x => x.Name == id);
                            routePart = new RouteVariable(routePath.Current == null, parameter);
                        }
                        else
                        {
                            routePart = new RouteLiteral(part, routePath.Current == null);
                        }

                        nextNode = new RouteNode(routePart);

                        if (routePath.Current == null)
                        {
                            routePart.RouteData[RouteData.ActionKey] = actionMethod;
                            routePart.RouteData[RouteData.ControllerKey] = controllerType;
                            if (httpMethod != null)
                                routePart.RouteData[RouteData.RequiredHttpMethodKey] = httpMethod;
                        }                            
                        
                        nextNode = AddNode(currentNode, nextNode);                        
                    }
                    if (routePath.Current == null)
                    {
                        if (actionMethod.IsDefined(typeof(DefaultAttribute), false))
                            AddNode(currentNode, new RouteNode(new RouteDefault(RouteData.ActionKey, actionMethod)));
                    }

                    currentNode = nextNode;
                }
                while (routePath.Current != null);
            }
        }

        private RouteNode AddNode(IRouteNode parent, RouteNode child)
        {
//            var duplicate = child.FindDuplicate(parent);
//            if (duplicate != null)
//            {
//                child.FindDuplicate(parent);
//                throw new DuplicateRouteException(parent, child, duplicate);
//            }
                
            if (child.Part is RouteLiteral)
            {
                var routeLiteral = (RouteLiteral)child.Part;
                if (!routeLiteral.IsTerminal)
                {
                    var commonChild = parent.Children.SingleOrDefault(x => x.Part is RouteLiteral && ((RouteLiteral)x.Part).Literal == routeLiteral.Literal && !((RouteLiteral)x.Part).IsTerminal);
                    if (commonChild != null)
                    {
                        return commonChild;
                    }
                }
            }
            if (child.Part is RouteVariable)
            {
                var routeVariable = (RouteVariable)child.Part;
                if (!routeVariable.IsTerminal)
                {
                    var commonChild = parent.Children.SingleOrDefault(x => x.Part is RouteVariable && !((RouteVariable)x.Part).IsTerminal);
                    if (commonChild != null)
                    {
                        return commonChild;
                    }
                }
            }
            
            if (child.Part.RouteData.ContainsKey(Routes.RouteData.RequiredHttpMethodKey) || child.Part is RouteLiteral)
                parent.Children.Insert(0, child);
            else
                parent.Children.Add(child);
                
            return child;
        }

        private string GenerateDefaultRouteForController(Type controllerType)
        {
            var controllerName = controllerType.Name.ChopEnd("Controller");
            return controllerName;
        }

        private string GenerateDefaultRouteForAction(MethodInfo actionMethod)
        {
            var builder = new StringBuilder();
            builder.Append(actionMethod.Name);
//            foreach (var parameter in actionMethod.GetParameters())
//            {
//                builder.Append("/{");
//                builder.Append(parameter.Name);
//                builder.Append("}");
//            }
            return builder.ToString();
        }
    }
}