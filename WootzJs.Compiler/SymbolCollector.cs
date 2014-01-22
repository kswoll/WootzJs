using System.Collections.Generic;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class SymbolCollector : SymbolWalker
    {
        private List<Symbol> symbols = new List<Symbol>();

        public override void DefaultVisit(Symbol node)
        {
            base.DefaultVisit(node);
            symbols.Add(node);
        }

        public Symbol[] Symbols
        {
            get { return symbols.ToArray(); }
        }
    }
}