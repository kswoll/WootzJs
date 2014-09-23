namespace WootzJs.Mvc.Routes.Constraints
{
    public class IntRouteConstraint : IRouteConstraint
    {
        public bool Accept(RoutePath path)
        {
            int result;
            return int.TryParse(path.Current, out result);
        }
    }
}