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

            var additionalMethods = new List<MethodDeclarationSyntax>();
            foreach (var method in node.Members.OfType<MethodDeclarationSyntax>().Where(x => x.IsAsync()))
            {
                var methodSymbol = semanticModel.GetDeclaredSymbol(method);
                var asyncGenerator = new AsyncClassGenerator(compilation, method, methodSymbol, method.ParameterList, method.TypeParameterList, methodSymbol.ContainingType, methodSymbol.GetMemberName());
                var enumerator = asyncGenerator.CreateStateMachine();
                asyncClasses.Add(enumerator);
                foreach (var additionalMethod in asyncGenerator.AdditionalHostMethods)
                {
                    if (!additionalMethods.Any(x => x.Identifier.ToString() == additionalMethod.Identifier.ToString()))
                        additionalMethods.Add(additionalMethod);
                }
            }

            var lambdaVisitor = new AsyncLambdaVisitor(compilation, semanticModel, asyncClasses, additionalMethods);
            node.Accept(lambdaVisitor);

            if (asyncClasses.Any())
            {
                var result = ((ClassDeclarationSyntax)base.VisitClassDeclaration(node)).AddMembers(asyncClasses.ToArray()).AddMembers(additionalMethods.ToArray());
                Console.WriteLine(result.NormalizeWhitespace());
                System.Diagnostics.Debug.Write(result.NormalizeWhitespace());
                return result;
            }
            else
            {
                return base.VisitClassDeclaration(node);
            }
        }
    }
}