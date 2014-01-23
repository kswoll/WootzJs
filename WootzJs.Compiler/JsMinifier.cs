using System.Collections.Generic;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class JsMinifier : JsWalker
    {
        private int generatedNameCounter = 1;
        private Dictionary<string, string> generatedNames = new Dictionary<string, string>();

        private string Minify(string s)
        {
            string result;
            if (!generatedNames.TryGetValue(s, out result))
            {
                result = "$" + generatedNameCounter++;
                generatedNames[s] = result;
            }
            return result;
        }

        public override void Visit(JsVariableReferenceExpression node)
        {
            base.Visit(node);
            node.Name = Minify(node.Name);
        }
    }
}