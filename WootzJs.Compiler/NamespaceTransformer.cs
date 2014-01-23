using System.Collections.Generic;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class NamespaceTransformer : SyntaxWalker
    {
        private Context context;
        private JsBlockStatement body;
        private HashSet<string> processedNamespaces = new HashSet<string>();

        public NamespaceTransformer(Context context, JsBlockStatement body) 
        {
            this.context = context;
            this.body = body;
        }

        private void ProcessNamespace(string ns)
        {
            if (processedNamespaces.Contains(ns))
                return;
            processedNamespaces.Add(ns);

            var lastDotIndex = ns.LastIndexOf('.');
            var parentNamespace = lastDotIndex != -1 ? ns.Substring(0, lastDotIndex) : null;
            if (parentNamespace != null)
                ProcessNamespace(parentNamespace);

            if (lastDotIndex == -1)
                body.Assign(Js.Reference("window").Member(ns), Js.Object());
            else
                body.Assign(Js.Reference(ns), Js.Object());
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            var semanticModel = context.Compilation.GetSemanticModel(node.SyntaxTree);
            var symbol = semanticModel.GetDeclaredSymbol(node);
            var fullName = context.SymbolNames[symbol, symbol.GetFullName()];
            ProcessNamespace(fullName);
        }
    }
}
