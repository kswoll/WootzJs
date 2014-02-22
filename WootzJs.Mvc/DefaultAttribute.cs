using System;

namespace WootzJs.Mvc
{
    /// <summary>
    /// Apply to a controller or an action to indicate that the controller (or action)
    /// should be chosen anyway even if the controller (or action) route name was not 
    /// provided.  For example, with this controller:
    /// 
    /// public class FooController() 
    /// {
    ///     public void BarAction() { ... }
    /// }
    /// 
    /// The default route would be /foo/bar.  If you apply this attribute to the controller
    /// then both the aforementioned route plus the route /bar would also reach BarAction.
    /// Furthermore, if you apply this attribute to the action then the route /foo would reach 
    /// BarAction.  Finally, if you apply this attribute to both, then the route / would reach
    /// BarAction.  Consider how you use this attribute, as collisions are possible and will
    /// fail fast with an error.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DefaultAttribute : Attribute
    {
    }
}