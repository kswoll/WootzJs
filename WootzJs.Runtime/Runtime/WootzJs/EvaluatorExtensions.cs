using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace System.Runtime.WootzJs
{
    public static class EvaluatorExtensions
    {
        public static object Evaluate(this Expression expression)
        {
            return new Evaluator(expression).Evaluate();
        } 

        public static object[] ExtractArguments(this InvocationExpression expression)
        {
            return expression.Arguments.Select(x => x.Evaluate()).ToArray();
        }

        public static Dictionary<string, object> ExtractArguments(this MethodCallExpression expression)
        {
            var parameters = expression.Method.GetParametersNoCopy();
            return expression.Arguments
                .Select((x, i) => new { Name = parameters[i].Name, Value = x.Evaluate() })
                .ToDictionary(x => x.Name, x => x.Value);
        }
    }
}