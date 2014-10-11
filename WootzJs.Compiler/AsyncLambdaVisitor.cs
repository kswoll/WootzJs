using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class AsyncLambdaVisitor : CSharpSyntaxWalker
    {
        private Compilation compilation;
        private SemanticModel model;
        private List<ClassDeclarationSyntax> asyncClasses;
        private List<MethodDeclarationSyntax> additionalMethods;
        private int index = 1;

        public AsyncLambdaVisitor(Compilation compilation, SemanticModel model, List<ClassDeclarationSyntax> asyncClasses, List<MethodDeclarationSyntax> additionalMethods)
        {
            this.compilation = compilation;
            this.model = model;
            this.asyncClasses = asyncClasses;
            this.additionalMethods = additionalMethods;
        }

        public override void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node)
        {
            base.VisitParenthesizedLambdaExpression(node);

            if (node.AsyncKeyword.CSharpKind() == SyntaxKind.AsyncKeyword)
            {
                var delegateType = (INamedTypeSymbol)model.GetTypeInfo(node).ConvertedType;
                var delegateInvokeMethod = delegateType.DelegateInvokeMethod;
                var method = delegateType.GetMethodByName("Invoke");
                var containingMethod = node.GetContainingMethod();
                var containingMethodDeclaration = node.FirstAncestorOrSelf<MethodDeclarationSyntax>();
                var containingType = containingMethodDeclaration.GetContainingType();

                // We need to ensure the parameter list includes those from the containing method. (and
                // possibly the containing lambda if there is a bunch of nesting < todo)
                // Also need to grab any locally declared variable that is in scope and comes before the current node
                var parameterList = delegateInvokeMethod.Parameters
                    .Select(x => new Tuple<string, ITypeSymbol>(x.Name, x.Type));
                if (!containingMethod.IsAsync)
                {
                    parameterList = parameterList
                        .Concat(containingMethod.Parameters.Select(x => new Tuple<string, ITypeSymbol>(x.Name, x.Type)))
                        .Concat(FindDeclaredVariablesInScope(containingMethodDeclaration, node)
                            .SelectMany(x => x.Variables, (declaration, declarator) => new { Declaration = declaration, Declarator = declarator, Symbol = ((ILocalSymbol)model.GetDeclaredSymbol(declarator)).Type })
                            .Select(x => new Tuple<string, ITypeSymbol>(x.Declarator.Identifier.ToString(), Context.Instance.ActionT.Construct(x.Symbol))));                    
                }
                else
                {
                    parameterList = parameterList
                        .Concat(containingMethod.Parameters
                            .Select(x => new Tuple<string, ITypeSymbol>(x.Name, Context.Instance.LiftedVariableAccessor)))
                        .Concat(FindDeclaredVariablesInScope(containingMethodDeclaration, node)
                            .SelectMany(x => x.Variables, (declaration, declarator) => new { Declaration = declaration, Declarator = declarator, Symbol = ((ILocalSymbol)model.GetDeclaredSymbol(declarator)).Type })
                            .Select(x => new Tuple<string, ITypeSymbol>(x.Declarator.Identifier.ToString(), Context.Instance.LiftedVariableAccessor)));                                        
                }

                var asyncMethodType = SyntaxFactory.ParseTypeName(containingType.GetFullName() + ".Async$" + method.GetMemberName());
                var asyncGenerator = new AsyncClassGenerator(compilation, node, method, parameterList.ToList(), SyntaxFactory.TypeParameterList(), containingMethod.ContainingType, index++.ToString(), containingMethod.IsAsync ? asyncMethodType : null);
                var enumerator = asyncGenerator.CreateStateMachine();
                asyncClasses.Add(enumerator);
                foreach (var additionalMethod in asyncGenerator.AdditionalHostMethods)
                {
                    if (!additionalMethods.Any(x => x.Identifier.ToString() == additionalMethod.Identifier.ToString()))
                        additionalMethods.Add(additionalMethod);
                }
            }
        }

        private IEnumerable<VariableDeclarationSyntax> FindDeclaredVariablesInScope(MethodDeclarationSyntax method, ParenthesizedLambdaExpressionSyntax lambda)
        {
            var locator = new VariableDeclarationsLocator(lambda);
            method.Accept(locator);
            return locator.Variables;
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