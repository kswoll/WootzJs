using System;
using System.Reflection;
using System.Web;

namespace WootzJs.Mvc.Mvc.Routes
{
    public class RouteVariable : RoutePart
    {
        public bool IsTerminal { get; private set; }
        public ParameterInfo Parameter { get; private set; }

        public RouteVariable(bool isTerminal, ParameterInfo parameter) : base()
        {
            IsTerminal = isTerminal;
            Parameter = parameter;
        }

        protected override bool IsDuplicate(IRoutePart part)
        {
            return base.IsDuplicate(part) && IsTerminal && (part is RouteLiteral && ((RouteLiteral)part).IsTerminal || part is RouteVariable && ((RouteVariable)part).IsTerminal);
        }

        protected override bool Accept(RoutePath path)
        {
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