using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class YieldGenerator : SyntaxRewriter
    {
        private Compilation compilation;
        private SyntaxTree syntaxTree;
        private SemanticModel semanticModel;

        public YieldGenerator(Compilation compilation, SyntaxTree syntaxTree, SemanticModel semanticModel)
        {
            this.compilation = compilation;
            this.syntaxTree = syntaxTree;
            this.semanticModel = semanticModel;
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var yieldClasses = new List<ClassDeclarationSyntax>();
            int currentGeneratorNameIndex = 1;
            foreach (var method in node.Members.OfType<MethodDeclarationSyntax>().Where(x => YieldChecker.HasYield(x)))
            {
                var yieldGenerator = new YieldClassGenerator(compilation, method);
                var enumerator = yieldGenerator.CreateEnumerator();
                yieldClasses.Add(enumerator);
            }

            if (yieldClasses.Any())
            {
                return node.AddMembers(yieldClasses.ToArray());
            }
            else
            {
                return base.VisitClassDeclaration(node);
            }
        }

        public JsNode ReturnNewGenerator()
        {
            return null;
//            return Js.Return(transformer.idioms.)
        }
    }
}