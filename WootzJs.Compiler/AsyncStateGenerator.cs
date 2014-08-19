using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class AsyncStateGenerator : BaseAsyncStateGenerator
    {
        private AsyncExpressionDecomposer decomposer;
        private Dictionary<string, TypeSyntax> hoistedVariables = new Dictionary<string, TypeSyntax>();
        private Dictionary<string, string> renamedVariables = new Dictionary<string, string>();
        private Stack<AsyncState> breakStates = new Stack<AsyncState>();
        private Stack<AsyncState> continueStates = new Stack<AsyncState>();
        private List<MethodDeclarationSyntax> additionalHostMethods = new List<MethodDeclarationSyntax>();

        public AsyncStateGenerator(Compilation compilation, MethodDeclarationSyntax node) : base(compilation, node)
        {
            decomposer = new AsyncExpressionDecomposer(this);
        }

        public IEnumerable<MethodDeclarationSyntax> AdditionalHostMethods
        {
            get { return additionalHostMethods; }
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

        private void AcceptStatement(StatementSyntax statement, AsyncState breakState = null, AsyncState continueState = null)
        {
            if (breakState != null)
                breakStates.Push(breakState);
            if (continueState != null)
                continueStates.Push(continueState);
            statement.Accept(this);
            if (breakState != null)
                breakStates.Pop();
            if (continueState !=  null)
                continueStates.Pop();
        }

        public override void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            CurrentState.Add((StatementSyntax)node.Accept(decomposer));
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                if (variable.Initializer != null)
                {
                    var assignment = SyntaxFactory.IdentifierName(variable.Identifier.ToString()).Assign((ExpressionSyntax)variable.Initializer.Value.Accept(decomposer));
                    CurrentState.Add(assignment.Express());
                }

                // Hoist the variable into a field
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);
                HoistVariable(variable.Identifier, symbol.Type.ToTypeSyntax());
            }
        }

        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            SetResult(node.Expression);
            CurrentState = GetNextState();             // @Todo: make this currentState = currentState.Next
        }

        private void SetResult(ExpressionSyntax result = null)
        {
            var setResult = SyntaxFactory.IdentifierName(AsyncClassGenerator.builder).Member("SetResult");
            if (result != null)
                CurrentState.Add(setResult.Invoke((ExpressionSyntax)result.Accept(decomposer)).Express());
            else 
                CurrentState.Add(setResult.Invoke().Express());
            CurrentState.Add(Cs.Return());
        }

        protected override void OnBaseStateGenerated()
        {
            base.OnBaseStateGenerated();

            var method = semanticModel.GetDeclaredSymbol(node);
            if (!(CurrentState.Statements.LastOrDefault() is ReturnStatementSyntax) && (method.ReturnsVoid || method.ReturnType.Equals(Context.Instance.Task)))
            {
                SetResult();
//                var returnType = method.ReturnType.GetGenericArgument(Context.Instance.TaskT, 0);
            }
        }

        public override void VisitBlock(BlockSyntax node)
        {
            foreach (var statement in node.Statements)
            {
                AcceptStatement(statement);
            }
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            var afterIfState = GetNextState();
            var ifTrueState = NewState(afterIfState);
            var ifFalseState = node.Else != null ? NewState(afterIfState) : null;

            var newIfStatement = Cs.If(
                (ExpressionSyntax)node.Condition.Accept(decomposer),
                GotoStateBlock(ifTrueState));

            if (node.Else != null)
                newIfStatement = newIfStatement.WithElse(SyntaxFactory.ElseClause(GotoStateBlock(ifFalseState)));

            CurrentState.Add(newIfStatement);
            GotoState(afterIfState);

            CurrentState = ifTrueState;
            AcceptStatement(node.Statement);
            GotoState(afterIfState);

            if (ifFalseState != null)
            {
                CurrentState = ifFalseState;
                AcceptStatement(node.Else.Statement);
                GotoState(afterIfState);
            }

            CurrentState = afterIfState;
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterWhileStatement = GetNextState();
            var bodyState = NewState(afterWhileStatement);

            var newWhileStatement = Cs.While(
                (ExpressionSyntax)node.Condition.Accept(decomposer),
                GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterWhileStatement);

            CurrentState = bodyState;
            AcceptStatement(node.Statement, afterWhileStatement, topOfLoop);
            GotoState(topOfLoop);

            CurrentState = afterWhileStatement;
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {            
            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                if (variable.Initializer != null)
                {
                    var assignment = SyntaxFactory.IdentifierName(variable.Identifier.ToString()).Assign((ExpressionSyntax)variable.Initializer.Value.Accept(decomposer));
                    CurrentState.Add(((ExpressionSyntax)assignment.Accept(decomposer)).Express());
                }

                // Hoist the variable into a field
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);
                HoistVariable(variable.Identifier, symbol.Type.ToTypeSyntax());
            }

            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = NewState();
            var incrementorState = NewState();

            var newWhileStatement = Cs.While(
                (ExpressionSyntax)node.Condition.Accept(decomposer),
                GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterLoop);

            CurrentState = bodyState;
            AcceptStatement(node.Statement, afterLoop, incrementorState);
            GotoState(incrementorState);

            CurrentState = incrementorState;
            foreach (var incrementor in node.Incrementors)
            {
                CurrentState.Add(((ExpressionSyntax)incrementor.Accept(decomposer)).Express());
            }
            GotoState(topOfLoop);

            CurrentState = afterLoop;
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
            CurrentState.Add(SyntaxFactory.IdentifierName(enumerator).Assign(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, StateMachineThisFixer.Fix(node.Expression), SyntaxFactory.IdentifierName("GetEnumerator")))).Express());

            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = NewState(afterLoop);

            var moveNext = SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(enumerator), SyntaxFactory.IdentifierName("MoveNext")));
            var newWhileStatement = Cs.While(moveNext, GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterLoop);

            CurrentState = bodyState;
            CurrentState.Add(SyntaxFactory.IdentifierName(node.Identifier).Assign(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, 
                SyntaxFactory.IdentifierName(enumerator), SyntaxFactory.IdentifierName("Current"))).Express());
            
            AcceptStatement(node.Statement, afterLoop, topOfLoop);

            GotoState(topOfLoop);

            CurrentState = afterLoop;
        }

        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            CurrentState.Add(Cs.Throw((ExpressionSyntax)node.Expression.Accept(decomposer)));
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            var afterTry = GetNextState();
            var newTryStatement = Cs.Try();

            var tryState = NewSubstate();
            GotoState(tryState);

            // Keep track of exception, if any, so we can rethrow
            var exceptionIdentifier = HoistVariable(SyntaxFactory.Identifier("$usingex"), Context.Instance.Exception.ToTypeSyntax());
            CurrentState.Add(SyntaxFactory.IdentifierName(exceptionIdentifier).Assign(Cs.Null()).Express());

            AsyncState finallyState = node.Finally == null ? null : GetNextState();

            if (node.Catches.Any())
            {
                foreach (var catchClause in node.Catches)
                {
                    // Hoist the variable into a field
                    var symbol = semanticModel.GetDeclaredSymbol(catchClause.Declaration);
                    var hasDeclaration = catchClause.Declaration.Identifier.CSharpKind() != SyntaxKind.None;
                    SyntaxToken newIdentifier;
                    if (hasDeclaration)
                        newIdentifier = HoistVariable(catchClause.Declaration.Identifier, symbol.Type.ToTypeSyntax());
                    else
                        newIdentifier = SyntaxFactory.Identifier(GenerateNewName(SyntaxFactory.Identifier("ex")));

                    var catchState = GetNextState();
                    CurrentState = catchState;
                    AcceptStatement(catchClause.Block);
                    if (finallyState != null)
                        GotoState(finallyState);
                    else
                        GotoState(afterTry);

                    var catchStatements = new List<StatementSyntax>();

                    if (node.Finally != null)
                    {
                        catchStatements.Add(SyntaxFactory.IdentifierName(exceptionIdentifier).Assign(SyntaxFactory.IdentifierName(newIdentifier)).Express());
                    }

                    if (hasDeclaration)
                        catchStatements.Add(Cs.This().Member(SyntaxFactory.IdentifierName(newIdentifier)).Assign(SyntaxFactory.IdentifierName(catchClause.Declaration.Identifier)).Express());
                    catchStatements.AddRange(GotoStateStatements(catchState));

                    newTryStatement = newTryStatement.WithCatch(
                        catchClause.Declaration.Type, 
                        newIdentifier.ToString(), 
                        catchStatements.ToArray()
                    );
                }
            }
            else if (node.Finally != null)
            {
                SyntaxToken caughtExceptionIdentifier = SyntaxFactory.Identifier(GenerateNewName(SyntaxFactory.Identifier("$caughtex")));
                newTryStatement = newTryStatement.WithCatches(SyntaxFactory.List(new[] 
                {
                    SyntaxFactory.CatchClause()
                        .WithDeclaration(SyntaxFactory.CatchDeclaration(Context.Instance.Exception.ToTypeSyntax(), caughtExceptionIdentifier))
                        .WithBlock(Cs.Block(
                            new[] { SyntaxFactory.IdentifierName(exceptionIdentifier).Assign(SyntaxFactory.IdentifierName(caughtExceptionIdentifier)).Express() }
                                .Concat(GotoStateStatements(finallyState))
                                .ToArray()
                        ))
                }));
            }

/*
            if (!node.Catches.Any(x => x.Declaration == null))
            {
                
            }
*/

            if (node.Finally != null)
            {
                CurrentState = finallyState;
                AcceptStatement(node.Finally.Block);

                // If the exception object is not null, then rethrow it.  Otherwise, go to the code after the try block
                CurrentState.Add(Cs.If(SyntaxFactory.IdentifierName(exceptionIdentifier).NotEqualTo(Cs.Null()), 
                    Cs.Throw(SyntaxFactory.IdentifierName(exceptionIdentifier)), 
                    Cs.Block(GotoStateStatements(afterTry))));
            }

            tryState.Wrap = switchStatement => newTryStatement.WithBlock(Cs.Block(switchStatement));

            StartSubstate(tryState);
            AcceptStatement(node.Block);
            if (node.Finally != null)
                GotoState(finallyState);
            else
                GotoState(afterTry);
            EndSubstate();

            CurrentState = afterTry;
        }

        public override void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            var afterSwitchState = GetNextState();

            var sectionStates = node.Sections.Select(x => NewState(afterSwitchState)).ToArray();
            var newSwitchStatement = Cs.Switch((ExpressionSyntax)node.Expression.Accept(decomposer),
                node.Sections.Select((x, i) => Cs.Section(
                    SyntaxFactory.List(x.Labels.Select(y => SyntaxFactory.SwitchLabel(SyntaxKind.CaseSwitchLabel, (ExpressionSyntax)y.Value.Accept(decomposer)))),
                    GotoStateStatements(sectionStates[i])
                )).ToArray());

            CurrentState.Add(newSwitchStatement);
            GotoState(afterSwitchState);

            breakStates.Push(afterSwitchState);
            for (var i = 0; i < node.Sections.Count; i++)
            {
                var section = node.Sections[i];
                var sectionState = sectionStates[i];
                CurrentState = sectionState;
                foreach (var statement in section.Statements)
                {
                    AcceptStatement(statement);
                }
            }
            breakStates.Pop();

            CurrentState = afterSwitchState;
        }

        public override void VisitBreakStatement(BreakStatementSyntax node)
        {
            GotoState(breakStates.Peek());
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            GotoState(continueStates.Peek());
        }

        public override void VisitUsingStatement(UsingStatementSyntax node)
        {
            var afterTry = GetNextState();
            var newTryStatement = Cs.Try();

            // Keep track of exception, if any, so we can rethrow
            var exceptionIdentifier = HoistVariable(SyntaxFactory.Identifier("$usingex"), Context.Instance.Exception.ToTypeSyntax());
            CurrentState.Add(SyntaxFactory.IdentifierName(exceptionIdentifier).Assign(Cs.Null()).Express());

            // Identifier for caught exception
            var caughtExceptionIdentifier = SyntaxFactory.Identifier(GenerateNewName(SyntaxFactory.Identifier("$caughtex")));

            // Hoist the variable into a field
            var disposables = new List<IdentifierNameSyntax>();
            if (node.Declaration != null) 
            {
                foreach (var variable in node.Declaration.Variables)
                {
                    var symbol = (ILocalSymbol)semanticModel.GetDeclaredSymbol(variable);
                    HoistVariable(variable.Identifier, symbol.Type.ToTypeSyntax());
                    var name = SyntaxFactory.IdentifierName(variable.Identifier);
                    disposables.Add(name);
                    CurrentState.Add(name.Assign((ExpressionSyntax)variable.Initializer.Value.Accept(decomposer)).Express());
                }
            }
            if (node.Expression != null)
            {
                var identifier = SyntaxFactory.IdentifierName(GenerateNewName(SyntaxFactory.Identifier("$using")));
                disposables.Add(identifier);
                CurrentState.Add(identifier.Assign((ExpressionSyntax)node.Expression.Accept(decomposer)).Express());
            }

            var tryState = NewSubstate();
            GotoState(tryState);

            var finallyState = GetNextState();
            CurrentState = finallyState;
            foreach (var disposable in disposables)
            {
                CurrentState.Add(disposable.Member("Dispose").Invoke().Express());
            }
            CurrentState.Add(Cs.If(SyntaxFactory.IdentifierName(exceptionIdentifier).NotEqualTo(Cs.Null()), Cs.Throw(SyntaxFactory.IdentifierName(exceptionIdentifier))));
            GotoState(afterTry);
            newTryStatement = newTryStatement.WithCatches(SyntaxFactory.List(new[] 
            {
                SyntaxFactory.CatchClause()
                    .WithDeclaration(SyntaxFactory.CatchDeclaration(Context.Instance.Exception.ToTypeSyntax(), caughtExceptionIdentifier))
                    .WithBlock(Cs.Block(
                        new[] { SyntaxFactory.IdentifierName(exceptionIdentifier).Assign(SyntaxFactory.IdentifierName(caughtExceptionIdentifier)).Express() }
                            .Concat(GotoStateStatements(finallyState))
                            .ToArray()
                    ))
            }));

            tryState.Wrap = switchStatement => newTryStatement.WithBlock(Cs.Block(switchStatement));

            StartSubstate(tryState);
            AcceptStatement(node.Statement);
            GotoState(finallyState);
            EndSubstate();

            CurrentState = afterTry;
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
                        stateGenerator.CurrentState.Add(awaiter.Assign(operand.Member("GetAwaiter").Invoke()).Express());

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
                        stateGenerator.CurrentState.Add(stateGenerator.ChangeState(nextState));

                        stateGenerator.CurrentState.Add(Cs.If(
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

                        stateGenerator.CurrentState = nextState;

                        return result ?? Context.Instance.Nop.Invoke();
                }

                return base.VisitPrefixUnaryExpression(node);
            }

            public override SyntaxNode VisitExpressionStatement(ExpressionStatementSyntax node)
            {
                return base.VisitExpressionStatement(node);
            }

            public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
            {
                var model = stateGenerator.semanticModel;
                var symbol = model.GetSymbolInfo(node).Symbol;
                var method = (IMethodSymbol)symbol;

                if (node.Expression is MemberAccessExpressionSyntax)
                {
                    var methodTargetSyntax = ((MemberAccessExpressionSyntax)node.Expression).Expression;
                    if (methodTargetSyntax is BaseExpressionSyntax)
                    {
                        var baseMethodName = "Base" + method.Name;
                        if (!stateGenerator.additionalHostMethods.Any(x => x.Identifier.ToString() == baseMethodName))
                        {
                            var baseMethodShim = SyntaxFactory.MethodDeclaration(method.ReturnType.ToTypeSyntax(), baseMethodName)
                                .WithModifiers(SyntaxFactory.TokenList(Cs.Token(SyntaxKind.PrivateKeyword)))
                                .WithParameterList(method.Parameters.ToParameterList())
                                .WithBody(Cs.Block(SyntaxFactory.BaseExpression().Member(method.Name).Invoke(method.Parameters.Select(x => Cs.IdentifierName(x.Name)).ToArray()).Express()));
                            stateGenerator.additionalHostMethods.Add(baseMethodShim);
                        }

                        return node.WithExpression(Cs.IdentifierName(baseMethodName));
                    }
                }            

                return base.VisitInvocationExpression(node);
            }
        }
    }
}