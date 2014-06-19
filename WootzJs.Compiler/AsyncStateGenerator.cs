using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class AsyncStateGenerator : BaseAsyncStateGenerator
    {
        private AsyncExpressionDecomposer decomposer;
        private Dictionary<string, TypeSyntax> hoistedVariables = new Dictionary<string, TypeSyntax>();
        private Dictionary<string, string> renamedVariables = new Dictionary<string, string>();

        public AsyncStateGenerator(Compilation compilation, MethodDeclarationSyntax node) : base(compilation, node)
        {
            decomposer = new AsyncExpressionDecomposer(this);
        }

        private string GenerateNewName(SyntaxToken identifier)
        {
            var counter = 2;
            do
            {
                var currentName = identifier.ToString() + counter++;
                if (!hoistedVariables.ContainsKey(currentName))
                {
                    return currentName;
                }
            }
            while (true);
        }

        protected SyntaxToken HoistVariable(SyntaxToken identifier, TypeSyntax type)
        {
            if (hoistedVariables.ContainsKey(identifier.ToString()))
            {
                var newName = GenerateNewName(identifier);
                var newIdentifier = SyntaxFactory.Identifier(newName);
                renamedVariables[identifier.ToString()] = newIdentifier.ToString();
                identifier = newIdentifier;
            }
            hoistedVariables[identifier.ToString()] = type;
            return identifier;
        }

        public Tuple<SyntaxToken, TypeSyntax>[] HoistedVariables
        {
            get { return hoistedVariables.Select(x => Tuple.Create(SyntaxFactory.Identifier(x.Key), x.Value)).ToArray(); }
        }

        public override void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            currentState.Add((StatementSyntax)node.Accept(decomposer));
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            var semanticModel = compilation.GetSemanticModel(node.SyntaxTree);

            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                if (variable.Initializer != null)
                {
                    var assignment = SyntaxFactory.IdentifierName(variable.Identifier.ToString()).Assign((ExpressionSyntax)variable.Initializer.Value.Accept(decomposer));
                    currentState.Add(Cs.Express(StateMachineThisFixer.Fix(assignment)));
                }

                // Hoist the variable into a field
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);
                HoistVariable(variable.Identifier, symbol.Type.ToTypeSyntax());
            }
        }

        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            var setResult = SyntaxFactory.IdentifierName(AsyncClassGenerator.builder).Member("SetResult");
            if (node.Expression != null)
                currentState.Add(setResult.Invoke((ExpressionSyntax)node.Expression.Accept(decomposer)).Express());
            else 
                currentState.Add(setResult.Invoke().Express());
            currentState.Add(Cs.Return());
            currentState = GetNextState();
        }

        class AsyncExpressionDecomposer : CSharpSyntaxRewriter
        {
            private AsyncStateGenerator stateGenerator;
            private int awaiterCount = 0;

            public AsyncExpressionDecomposer(AsyncStateGenerator stateGenerator)
            {
                this.stateGenerator = stateGenerator;
            }

            public override SyntaxNode VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
            {
                switch (node.CSharpKind())
                {
                    case SyntaxKind.AwaitExpression:
                        awaiterCount++;
                        var operand = (ExpressionSyntax)node.Operand.Accept(this);
                        var semanticModel = stateGenerator.compilation.GetSemanticModel(node.SyntaxTree);
                        var expressionInfo = semanticModel.GetAwaitExpressionInfo(node);
                        var returnsVoid = expressionInfo.GetResultMethod.ReturnsVoid;
//                        var expressionType = semanticModel.GetTypeInfo(node).ConvertedType;
//                        bool voidExpression = expressionType.SpecialType == SpecialType.System_Void;

                        // Store the awaiter in a field
                        var awaiterType = expressionInfo.GetAwaiterMethod.ReturnType;
                        var awaiterIdentifier = SyntaxFactory.Identifier("$awaiter");
                        awaiterIdentifier = stateGenerator.HoistVariable(awaiterIdentifier, awaiterType.ToTypeSyntax());
                        var awaiter = operand.Member("GetAwaiter").Invoke();
                        stateGenerator.currentState.Add(SyntaxFactory.IdentifierName(awaiterIdentifier).Assign(awaiter).Express());

                        var nextState = stateGenerator.GetNextState();

                        // If the await returns a value, store it in a field
                        ExpressionSyntax result = null;
                        if (!returnsVoid)
                        {
                            var resultIdentifier = SyntaxFactory.Identifier("$result");
                            resultIdentifier = stateGenerator.HoistVariable(resultIdentifier, expressionInfo.GetResultMethod.ReturnType.ToTypeSyntax());

                            result = SyntaxFactory.IdentifierName(resultIdentifier);
                        }

                        // Set the state to the next state
                        stateGenerator.currentState.Add(stateGenerator.ChangeState(nextState));

                        stateGenerator.currentState.Add(Cs.If(
                            SyntaxFactory.IdentifierName(awaiterIdentifier).Member("IsCompleted"), 

                            // If the awaiter is already completed, go to the next state
                            stateGenerator.GotoTop(),

                            // Otherwise await for completion
                            Cs.Block(
                                // Start the async process
                                SyntaxFactory.IdentifierName(AsyncClassGenerator.builder)
                                    .Member("AwaitOnCompleted")
                                    .Invoke(SyntaxFactory.IdentifierName(awaiterIdentifier), Cs.This())
                                    .Express()
                            )
                        ));

                        stateGenerator.currentState = nextState;

                        return result ?? Context.Instance.Nop.Invoke();
                }

                return base.VisitPrefixUnaryExpression(node);
            }

            public override SyntaxNode VisitExpressionStatement(ExpressionStatementSyntax node)
            {
                return base.VisitExpressionStatement(node);
            }
        }
    }
}