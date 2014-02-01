using System;
using System.Collections.Generic;

namespace WootzJs.Mvc.Mvc.Routes
{
    public class RouteLiteral : RoutePart
    {
        public string Literal { get; private set; }
        public bool IsTerminal { get; private set; }

        public RouteLiteral(string literal, bool isTerminal, IDictionary<string, object> routeData = null) : base(routeData)
        {
            Literal = literal.ToLower();
            IsTerminal = isTerminal;
        }

        public RouteLiteral(string literal, bool isTerminal, string key, string value) : 
            this(literal, isTerminal, new Dictionary<string, object> {{key, value}})
        {
        }

        protected override bool IsDuplicate(IRoutePart part)
        {
            return base.IsDuplicate(part) && (part is RouteLiteral && ((RouteLiteral)part).IsTerminal ? ((RouteLiteral)part).Literal == Literal && IsTerminal : part is RouteVariable && ((RouteVariable)part).IsTerminal);
        }

        protected override bool Accept(RoutePath path)
        {
            if (path.Current != null && path.Current.Equals(Literal, StringComparison.OrdinalIgnoreCase))
            {
                path.Consume();
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Literal + " " + base.ToString();
        }
    }
}