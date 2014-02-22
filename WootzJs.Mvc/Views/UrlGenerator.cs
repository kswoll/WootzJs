using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.WootzJs;
using System.Text;

namespace WootzJs.Mvc.Views
{
    public class UrlGenerator
    {
        public static string GenerateUrl(LambdaExpression action)
        {
            var result = new StringBuilder();

            var methodCallExpression = (MethodCallExpression)action.Body;
            var method = methodCallExpression.Method;
            var controllerDefaultAttribute = (DefaultAttribute)method.DeclaringType.GetCustomAttributes(typeof(DefaultAttribute), false).SingleOrDefault();
            var routeAttribute = (RouteAttribute)method.GetCustomAttributes(typeof(RouteAttribute), false).SingleOrDefault();
            var defaultAttribute = (DefaultAttribute)method.GetCustomAttributes(typeof(DefaultAttribute), false).SingleOrDefault();
            if (controllerDefaultAttribute != null && defaultAttribute != null)
                result.Append("/");
            else if (defaultAttribute != null)
                result.Append("/" + GetControllerNameFromType(method.DeclaringType));
            else if (routeAttribute != null && routeAttribute.Value != null)
                result.Append(GenerateUrlFromTemplate(routeAttribute.Value));
            else 
                result.Append(GenerateUrlFromMethod(method));

            bool hasAddedArgument = false;
            var args = methodCallExpression.ExtractArguments();
            foreach (var argument in args)
            {
                if (!hasAddedArgument)
                    result.Append("?");
                else
                    result.Append("&");
                hasAddedArgument = true;
                result.Append(argument.Key);
                result.Append("=");
                result.Append(argument.Value);
            }

            return result.ToString();
        }

        private static string GenerateUrlFromTemplate(string template)
        {
            return template;
        }

        private static string GenerateUrlFromMethod(MethodInfo method)
        {
            var controller = GetControllerNameFromType(method.DeclaringType);
            var action = method.Name.ToLower();

            return "/" + controller + "/" + action;
        }

        private static string GetControllerNameFromType(Type type)
        {
            return type.Name.Substring(0, type.Name.Length - "Controller".Length).ToLower();
        }
    }
}