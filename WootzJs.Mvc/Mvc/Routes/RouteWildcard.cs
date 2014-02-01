using System;
using System.Reflection;

namespace WootzJs.Mvc.Mvc.Routes
{
    public class RouteWildcard : RoutePart
    {
        private ParameterInfo parameter;

        public RouteWildcard(ParameterInfo parameter)
        {
            this.parameter = parameter;
        }

        protected override bool Accept(RoutePath path)
        {
            if (path.Current != null)
            {
                path.ConsumeAll();
                return true;                
            }
            return false;
        }

        protected override void ConsumePath(RoutePath path)
        {
        }

        public override void ProcessData(RoutePath path, RouteData data)
        {
            base.ProcessData(path, data);
            var s = path.ConsumeAll();
            data[parameter.Name] = Convert.ChangeType(s, parameter.ParameterType);
        }
    }
}