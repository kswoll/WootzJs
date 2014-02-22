using System.Collections.Generic;
using WootzJs.Mvc.Routes;

namespace WootzJs.Mvc
{
    public class NavigationRequest
    {
        /// <summary>
        /// Contains the portion of the url after the host/port and before the query string.
        /// </summary>
        public string Path { get; set; }

        public Dictionary<string, string> QueryString { get; set; }

        public RouteData RouteData { get; set; }
    }
}