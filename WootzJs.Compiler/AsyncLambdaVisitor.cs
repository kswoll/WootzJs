using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class AsyncLambdaVisitor : CSharpSyntaxWalker
    {
        public List<ClassDeclarationSyntax> AsyncClasses { get; private set; }
        private Compilation compilation;
        private SemanticModel model;

        public AsyncLambdaVisitor(Compilation compilation, SemanticModel model)
        {
            this.compilation = compilation;
            this.model = model;
            AsyncClasses = new List<ClassDeclarationSyntax>();
        }

        public override void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            base.VisitParenthesizedLambdaExpression(node);

            if (node.AsyncKeyword.CSharpKind() == SyntaxKind.AsyncKeyword)
            {
                var asyncGenerator = new AsyncClassGenerator(compilation, method);
                var enumerator = asyncGenerator.CreateStateMachine();
                asyncClasses.Add(enumerator);
                foreach (var additionalMethod in asyncGenerator.AdditionalHostMethods)
                {
                    if (!additionalMethods.Any(x => x.Identifier.ToString() == additionalMethod.Identifier.ToString()))
                        additionalMethods.Add(additionalMethod);
                }
            }
        }

        public override void VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node)
        {
            base.VisitSimpleLambdaExpression(node);

            if (node.AsyncKeyword.CSharpKind() == SyntaxKind.AsyncKeyword)
            {
                Console.WriteLine("Foo");
            }
        }    }
}