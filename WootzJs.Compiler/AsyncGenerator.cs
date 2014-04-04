using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class AsyncGenerator : CSharpSyntaxRewriter
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
                var result = node.AddMembers(asyncClasses.ToArray());
                Console.WriteLine(result.NormalizeWhitespace());
                return result;
            }
            else
            {
                return base.VisitClassDeclaration(node);
            }
        }
    }
}