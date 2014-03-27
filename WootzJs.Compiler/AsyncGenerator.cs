using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class AsyncGenerator : SyntaxRewriter
    {
        private Compilation compilation;
        private SyntaxTree syntaxTree;
        private SemanticModel semanticModel;

        public AsyncGenerator(Compilation compilation, SyntaxTree syntaxTree, SemanticModel semanticModel)
        {
            this.compilation = compilation;
            this.syntaxTree = syntaxTree;
            this.semanticModel = semanticModel;
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var asyncClasses = new List<ClassDeclarationSyntax>();
            foreach (var method in node.Members.OfType<MethodDeclarationSyntax>().Where(x => x.IsAsync()))
            {
                var asyncGenerator = new AsyncClassGenerator(compilation, method);
                var enumerator = asyncGenerator.CreateStateMachine();
                asyncClasses.Add(enumerator);
            }

            if (asyncClasses.Any())
            {
                return node.AddMembers(asyncClasses.ToArray());
            }
            else
            {
                return base.VisitClassDeclaration(node);
            }
        }
    }
}