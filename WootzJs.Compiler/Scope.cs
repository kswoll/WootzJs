using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class Scope
    {
        private Symbol symbol;
        private List<IJsDeclaration> declarations = new List<IJsDeclaration>();
        private Dictionary<string, IJsDeclaration> declarationsByName = new Dictionary<string, IJsDeclaration>();
        private int currentAnonymousNameIndex = 1;

        public Scope(Symbol symbol)
        {
            this.symbol = symbol;
        }

        public void AddDeclarations(params IJsDeclaration[] declarations)
        {
            foreach (var declaration in declarations)
            {
                if (declarationsByName.ContainsKey(declaration.Name))
                    throw new InvalidOperationException("Declaration already declared in this scope: " + declaration);
                declarationsByName[UnwrapName(declaration)] = declaration;
            }
            this.declarations.AddRange(declarations);
        }

        private string UnwrapName(IJsDeclaration declaration)
        {
            var current = declaration;
            while (current is Idioms.WrappedParent)
            {
                current = ((Idioms.WrappedParent)current).Parent;
            }
            return current.Name;
        }

        public IJsDeclaration this[string name]
        {
            get
            {
                IJsDeclaration result;
                declarationsByName.TryGetValue(name, out result);
                return result;
            }
        }

        public IReadOnlyCollection<IJsDeclaration> Declarations
        {
            get { return declarations; }
        }
    }
}
