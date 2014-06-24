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
            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                if (variable.Initializer != null)
                {
                    var assignment = SyntaxFactory.IdentifierName(variable.Identifier.ToString()).Assign((ExpressionSyntax)variable.Initializer.Value.Accept(decomposer));
                    currentState.Add(((ExpressionSyntax)assignment.Accept(decomposer)).Express());
                }

                // Hoist the variable into a field
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);
                HoistVariable(variable.Identifier, symbol.Type.ToTypeSyntax());
            }
        }

        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            SetResult(node.Expression);
            currentState = GetNextState();             // @Todo: make this currentState = currentState.Next
        }

        private void SetResult(ExpressionSyntax result = null)
        {
            var setResult = SyntaxFactory.IdentifierName(AsyncClassGenerator.builder).Member("SetResult");
            if (result != null)
                currentState.Add(setResult.Invoke((ExpressionSyntax)result.Accept(decomposer)).Express());
            else 
                currentState.Add(setResult.Invoke().Express());
            currentState.Add(Cs.Return());
        }

        protected override void OnBaseStateGenerated()
        {
            base.OnBaseStateGenerated();

            var method = semanticModel.GetDeclaredSymbol(node);
            if (!(currentState.Statements.LastOrDefault() is ReturnStatementSyntax) && (method.ReturnsVoid || method.ReturnType.Equals(Context.Instance.Task)))
            {
                SetResult();
//                var returnType = method.ReturnType.GetGenericArgument(Context.Instance.TaskT, 0);
            }
        }

        public override void VisitBlock(BlockSyntax node)
        {
            foreach (var statement in node.Statements)
            {
                statement.Accept(this);
            }
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            var afterIfState = GetNextState();
            var ifTrueState = NewState(afterIfState);
            var ifFalseState = node.Else != null ? NewState(afterIfState) : null;

            var newIfStatement = Cs.If(
                (ExpressionSyntax)node.Condition.Accept(decomposer),
                GotoState(ifTrueState));

            if (node.Else != null)
                newIfStatement = newIfStatement.WithElse(SyntaxFactory.ElseClause(GotoState(ifFalseState)));

            currentState.Add(newIfStatement);
            currentState.Add(GotoState(afterIfState));

            currentState = ifTrueState;
            node.Statement.Accept(this);
            currentState.Add(GotoState(afterIfState));

            if (ifFalseState != null)
            {
                currentState = ifFalseState;
                node.Else.Statement.Accept(this);
                currentState.Add(GotoState(afterIfState));
            }

            currentState = afterIfState;
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            var topOfLoop = GetNextState();

            currentState.Add(GotoState(topOfLoop));
            currentState = topOfLoop;

            var afterWhileStatement = GetNextState();
            var bodyState = NewState(afterWhileStatement);

            var newWhileStatement = Cs.While(
                (ExpressionSyntax)node.Condition.Accept(decomposer),
                GotoState(bodyState));

            currentState.Add(newWhileStatement);
            currentState.Add(GotoState(afterWhileStatement));

            currentState = bodyState;
            node.Statement.Accept(this);
            currentState.Add(GotoState(topOfLoop));

            currentState = afterWhileStatement;
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {            
            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                if (variable.Initializer != null)
                {
                    var assignment = SyntaxFactory.IdentifierName(variable.Identifier.ToString()).Assign((ExpressionSyntax)variable.Initializer.Value.Accept(decomposer));
                    currentState.Add(((ExpressionSyntax)assignment.Accept(decomposer)).Express());
                }

                // Hoist the variable into a field
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);
                HoistVariable(variable.Identifier, symbol.Type.ToTypeSyntax());
            }

            var topOfLoop = GetNextState();

            currentState.Add(GotoState(topOfLoop));
            currentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = NewState(afterLoop);

            var newWhileStatement = Cs.While(
                (ExpressionSyntax)node.Condition.Accept(decomposer),
                GotoState(bodyState));

            currentState.Add(newWhileStatement);
            currentState.Add(GotoState(afterLoop));

            currentState = bodyState;
            node.Statement.Accept(this);

            foreach (var incrementor in node.Incrementors)
            {
                currentState.Add(((ExpressionSyntax)incrementor.Accept(decomposer)).Express());
            }

            currentState.Add(GotoState(topOfLoop));

            currentState = afterLoop;
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            // Hoist the variable into a field
            var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, node);
            HoistVariable(node.Identifier, symbol.Type.ToTypeSyntax());

            // Hoist the enumerator into a field
            var targetType = ModelExtensions.GetTypeInfo(semanticModel, node.Expression);
            var enumerator = SyntaxFactory.Identifier(node.Identifier + "$enumerator");
            var genericEnumeratorType = compilation.FindType("System.Collections.Generic.IEnumerable`1");
            var elementType = targetType.ConvertedType.GetGenericArgument(genericEnumeratorType, 0);
            var enumeratorType = elementType == null ?
                SyntaxFactory.ParseTypeName("System.Collections.IEnumerator") :
                SyntaxFactory.ParseTypeName("System.Collections.Generic.IEnumerator<" + elementType.ToDisplayString() + ">");
            HoistVariable(enumerator, enumeratorType);
            currentState.Add(SyntaxFactory.IdentifierName(enumerator).Assign(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, StateMachineThisFixer.Fix(node.Expression), SyntaxFactory.IdentifierName("GetEnumerator")))).Express());

            var topOfLoop = GetNextState();

            currentState.Add(GotoState(topOfLoop));
            currentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = NewState(afterLoop);

            var moveNext = SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(enumerator), SyntaxFactory.IdentifierName("MoveNext")));
            var newWhileStatement = Cs.While(moveNext, GotoState(bodyState));

            currentState.Add(newWhileStatement);
            currentState.Add(GotoState(afterLoop));

            currentState = bodyState;
            currentState.Add(SyntaxFactory.IdentifierName(node.Identifier).Assign(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, 
                SyntaxFactory.IdentifierName(enumerator), SyntaxFactory.IdentifierName("Current"))).Express());
            
            node.Statement.Accept(this);

            currentState.Add(GotoState(topOfLoop));

            currentState = afterLoop;
        }

        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            currentState.Add(Cs.Throw((ExpressionSyntax)node.Expression.Accept(decomposer)));
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            var originalState = currentState;
//            var afterTry = GetNextState();

            var tryBlockState = new AsyncState();
            currentState = tryBlockState;
            node.Block.Accept(this);

            var newTryStatement = Cs.Try()
                .WithBlock(Cs.Block(currentState.Statements/*.Concat(new[] { GotoState(afterTry) })*/.ToArray()));

            foreach (var catchClause in node.Catches)
            {
                // Hoist the variable into a field
                var symbol = semanticModel.GetDeclaredSymbol(catchClause.Declaration);
                var newIdentifier = HoistVariable(catchClause.Declaration.Identifier, symbol.Type.ToTypeSyntax());

                var catchState = new AsyncState();
                currentState = catchState;
                catchClause.Block.Accept(this);
                newTryStatement = newTryStatement.WithCatch(catchClause.Declaration.Type, newIdentifier.ToString(), catchState.Statements.ToArray());
            }

            originalState.Add(newTryStatement);
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
                        var expressionInfo = stateGenerator.semanticModel.GetAwaitExpressionInfo(node);
                        var returnsVoid = expressionInfo.GetResultMethod.ReturnsVoid;
//                        var expressionType = semanticModel.GetTypeInfo(node).ConvertedType;
//                        bool voidExpression = expressionType.SpecialType == SpecialType.System_Void;

                        // Store the awaiter in a field
                        var awaiterType = expressionInfo.GetAwaiterMethod.ReturnType;
                        var awaiterIdentifier = SyntaxFactory.Identifier("$awaiter");
                        awaiterIdentifier = stateGenerator.HoistVariable(awaiterIdentifier, awaiterType.ToTypeSyntax());
                        var awaiter = SyntaxFactory.IdentifierName(awaiterIdentifier);
                        stateGenerator.currentState.Add(awaiter.Assign(operand.Member("GetAwaiter").Invoke()).Express());

                        var nextState = stateGenerator.InsertState();

                        ExpressionSyntax result = null;
                        if (!returnsVoid)
                        {
                            // If the await returns a value, store it in a field
                            var resultIdentifier = SyntaxFactory.Identifier("$result");
                            resultIdentifier = stateGenerator.HoistVariable(resultIdentifier, expressionInfo.GetResultMethod.ReturnType.ToTypeSyntax());
                            result = SyntaxFactory.IdentifierName(resultIdentifier);

                            // Make sure the field gets set from the awaiter at the beginning of the next state.
                            nextState.Add(result.Assign(awaiter.Member("GetResult").Invoke()).Express());
                        }
                        else
                        {
                            // We still need to call GetResult even if void in order to propagate exceptions
                            nextState.Add(awaiter.Member("GetResult").Invoke().Express());
                        }

                        // Set the state to the next state
                        stateGenerator.currentState.Add(stateGenerator.ChangeState(nextState));

                        stateGenerator.currentState.Add(Cs.If(
                            awaiter.Member("IsCompleted"), 

                            // If the awaiter is already completed, go to the next state
                            stateGenerator.GotoTop(),

                            // Otherwise await for completion
                            Cs.Block(
                                // Start the async process
                                SyntaxFactory.IdentifierName(AsyncClassGenerator.builder)
                                    .Member("AwaitOnCompleted")
                                    .Invoke(SyntaxFactory.IdentifierName(awaiterIdentifier), Cs.This())
                                    .Express(),
                                Cs.Return()
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