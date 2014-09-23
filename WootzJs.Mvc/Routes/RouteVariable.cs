using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace WootzJs.Mvc.Routes
{
    public class RouteVariable : RoutePart
    {
        public bool IsTerminal { get; private set; }
        public ParameterInfo Parameter { get; private set; }
        public IList<IRouteConstraint> Constraints { get; private set; }

        public RouteVariable(bool isTerminal, ParameterInfo parameter) : base()
        {
            IsTerminal = isTerminal;
            Parameter = parameter;
            Constraints = new List<IRouteConstraint>();
        }

        protected override bool Accept(RoutePath path)
        {
            foreach (var constraint in Constraints)
            {
                if (!constraint.Accept(path))
                    return false;
            }
            if (path.Current != null)
            {
                path.Consume();
                return true;                
            }
            return false;
        }

        protected override void ConsumePath(RoutePath path)
        {
            // Prevent default consume since we're going to consume it ourselves below
        }

        public override void ProcessData(RoutePath path, RouteData data)
        {
            base.ProcessData(path, data);

            var part = path.Consume();
            part = HttpUtility.UrlDecode(part);
            var value = Convert.ChangeType(part, Parameter.ParameterType);
            data[Parameter.Name] = value;
        }

        public override string ToString()
        {
            return "{" + Parameter.Name + "} " + base.ToString();
        }
    }
}