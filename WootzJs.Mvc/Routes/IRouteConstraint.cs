namespace WootzJs.Mvc.Routes
{
    public interface IRouteConstraint
    {
        bool Accept(RoutePath path); 
    }
}