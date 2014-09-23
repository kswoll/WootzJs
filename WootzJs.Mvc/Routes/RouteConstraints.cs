using System.Collections.Generic;
using WootzJs.Mvc.Routes.Constraints;

namespace WootzJs.Mvc.Routes
{
    public static class RouteConstraints
    {
        private static Dictionary<string, IRouteConstraint> constraints = new Dictionary<string, IRouteConstraint>();

        static RouteConstraints()
        {
            Register("int", new IntRouteConstraint());
        }

        public static void Register(string name, IRouteConstraint constraint)
        {
            constraints[name] = constraint;
        }

        public static IRouteConstraint GetConstraint(string name)
        {
            return constraints[name];
        }
    }
}