using System.Collections.Generic;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class SymbolNameMap
    {
        private Dictionary<Symbol, string> names;

        public SymbolNameMap(Dictionary<Symbol, string> names)
        {
            this.names = names;
        }

        public string this[Symbol symbol, string fallbackName]
        {
            get
            {
                string result;
                if (!names.TryGetValue(symbol, out result))
                    return fallbackName;

                if (symbol is NamespaceSymbol && !symbol.ContainingNamespace.IsGlobalNamespace)
                    result = this[symbol.ContainingNamespace, symbol.ContainingNamespace.GetFullName()] + "." + result;
                    
                return result;
            }
        }
    }
}