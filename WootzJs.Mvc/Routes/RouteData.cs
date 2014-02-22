using System;
using System.Collections.Generic;
using System.Reflection;

namespace WootzJs.Mvc.Routes
{
    public class RouteData
    {
        public const string ControllerKey = "@controller";
        public const string ActionKey = "@action";
        public const string RequiredHttpMethodKey = "@requiredHttpMethod";

        private Dictionary<string, object> values = new Dictionary<string, object>();

        public object this[string key]
        {
            get { return values.Get(key); }
            set { values[key] = value; }
        }
        
        public MethodInfo Action 
        {
            get { return (MethodInfo)this[ActionKey]; }
        }
        
        public Type Controller
        {
            get { return (Type)this[ControllerKey]; }
        }
        
        public string RequiredHttpMethod
        {
            get { return (string)this[RequiredHttpMethod]; }
        }
         
    }
}