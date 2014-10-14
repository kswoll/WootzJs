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
        private Stack<AsyncState> breakStates = new Stack<AsyncState>();
        private Stack<AsyncState> continueStates = new Stack<AsyncState>();
        private IMethodSymbol method;
        private Idioms idioms;

        public const string builder = "$builder";

        public AsyncStateGenerator(Idioms idioms, JsBlockStatement stateMachineBody, CSharpSyntaxNode node, IMethodSymbol method) : base(x => new AsyncExpressionDecomposer((AsyncStateGenerator)x, idioms), node, stateMachineBody)
        {
            this.method = method;
            this.idioms = idioms;
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
            CurrentState.Add(((JsExpression)node.Expression.Accept(Transformer)).Express());
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                // Hoist the variable into a field
                var symbol = (ILocalSymbol)Transformer.Model.GetDeclaredSymbol(variable);
                var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));

                if (variable.Initializer != null)
                {
                    var assignment = identifier.GetReference().Assign((JsExpression)variable.Initializer.Value.Accept(Transformer));
                    CurrentState.Add(assignment.Express());
                }
            }
        }

        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            SetResult(node.Expression);
            CurrentState = GetNextState();             // @Todo: make this currentState = currentState.Next
        }

        private void SetResult(ExpressionSyntax result = null)
        {
            var setResult = Js.Reference(builder).Member("SetResult");
            if (result != null)
                CurrentState.Add(setResult.Invoke((JsExpression)result.Accept(Transformer)).Express());
            else 
                CurrentState.Add(setResult.Invoke().Express());
            CurrentState.Add(Js.Return());
        }

        protected override void OnBaseStateGenerated()
        {
            base.OnBaseStateGenerated();

            if (!(CurrentState.Statements.LastOrDefault() is JsReturnStatement) && (method.ReturnsVoid || method.ReturnType.Equals(Context.Instance.Task)))
            {
                SetResult();
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

            var newIfStatement = Js.If(
                (JsExpression)node.Condition.Accept(Transformer),
                GotoStateBlock(ifTrueState));

            if (node.Else != null)
                newIfStatement.IfFalse = GotoStateBlock(ifFalseState);

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

            var newWhileStatement = Js.While(
                (JsExpression)node.Condition.Accept(Transformer),
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
                // Hoist the variable into a field
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(Transformer.Model, variable);
                var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));

                if (variable.Initializer != null)
                {
                    var assignment = identifier.GetReference().Assign((JsExpression)variable.Initializer.Value.Accept(Transformer));
                    CurrentState.Add(assignment.Express());
                }
            }

            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = NewState();
            var incrementorState = NewState();

            var newWhileStatement = Js.While(
                (JsExpression)node.Condition.Accept(Transformer),
                GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterLoop);

            CurrentState = bodyState;
            AcceptStatement(node.Statement, afterLoop, incrementorState);
            GotoState(incrementorState);

            CurrentState = incrementorState;
            foreach (var incrementor in node.Incrementors)
            {
                CurrentState.Add(((JsExpression)incrementor.Accept(Transformer)).Express());
            }
            GotoState(topOfLoop);

            CurrentState = afterLoop;
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            // Hoist the variable into a field
            var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(Transformer.Model, node);
            var identifier = HoistVariable(new LiftedVariableKey(node.Identifier, symbol));

            // Hoist the enumerator into a field
            var enumerator = HoistVariable(new LiftedVariableKey(identifier.Name + "$enumerator"));
            CurrentState.Add(
                enumerator.GetReference().Assign(
                    ((JsExpression)node.Expression.Accept(Transformer)).Member("GetEnumerator").Invoke()
                ).Express()
            );

            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = NewState(afterLoop);

            var moveNext = enumerator.GetReference().Member("MoveNext").Invoke();
            var newWhileStatement = Js.While(moveNext, GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterLoop);

            CurrentState = bodyState;
            CurrentState.Add(identifier.GetReference().Assign(enumerator.GetReference().Member("get_Current").Invoke()).Express());
            
            AcceptStatement(node.Statement, afterLoop, topOfLoop);

            GotoState(topOfLoop);

            CurrentState = afterLoop;
        }

        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            var exception = node.Expression;
            
            // For naked "throw" statements, we need to find the exception object
            if (exception == null)
            {
                var catchClause = node.FirstAncestorOrSelf<CatchClauseSyntax>();
                var symbol = Transformer.model.GetDeclaredSymbol(catchClause.Declaration);
                var identifier = Transformer.ReferenceDeclarationInScope(symbol);
                CurrentState.Add(Js.Throw(identifier.GetReference()));
            }
            else
            {
                CurrentState.Add(Js.Throw((JsExpression)exception.Accept(Transformer)));
            }
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            var afterTry = GetNextState();
            var newTryStatement = Js.Try();

            var tryState = NewSubstate();
            GotoState(tryState);

            // Keep track of exception, if any, so we can rethrow
            var exceptionIdentifier = HoistVariable(new LiftedVariableKey("$ex"));
            var exceptionVariable = UniqueName("$caughtex");

            AsyncState finallyState = node.Finally == null ? null : GetNextState();

            // Declare a block to store all the catch statements the try statement's only catch clause. (No
            // type-specific catch clauses in Javascript
            var catchBlock = Js.Block();

            // Make sure that the exception is stored in a variable accessible to the entire state machine.
            catchBlock.Express(exceptionIdentifier.GetReference().Assign(Js.Reference(exceptionVariable)));

            foreach (var catchClause in node.Catches)
            {
                // Get the symbol that represents the exception declaration (identifier and type)
                var symbol = Transformer.Model.GetDeclaredSymbol(catchClause.Declaration);
                var exceptionType = symbol == null ? null : symbol.Type;
                if (exceptionType == null && catchClause.Declaration != null && catchClause.Declaration.Type != null)
                    exceptionType = (ITypeSymbol)Transformer.Model.GetSymbolInfo(catchClause.Declaration.Type).Symbol;

                // True if it is actually declaring the variable (as opposed to a catch clause that specifies
                // merely an exception type
                var hasDeclaration = catchClause.Declaration.Identifier.CSharpKind() != SyntaxKind.None;

                // A variable to store the new unique identifier to store the exception
                IJsDeclaration newIdentifier;

                // Hoist the variable into a field
                if (hasDeclaration)
                    newIdentifier = HoistVariable(new LiftedVariableKey(catchClause.Declaration.Identifier, symbol));
                else
                    newIdentifier = HoistVariable(new LiftedVariableKey(SyntaxFactory.Identifier("ex")));

                // Collect all the catch statements into the catchState by making that state current
                var catchState = GetNextState();
                CurrentState = catchState;
                AcceptStatement(catchClause.Block);

                // Add onto the catch state some commands to go to the next state.  
                if (finallyState != null)
                    GotoState(finallyState);
                else
                    GotoState(afterTry);

                // Create the statements that will live in the actual catch handler, which directs the logic
                // to the actual catch state and also stores the exception in the correct identifier.
                var thisCatchStatements = Js.Block();
                thisCatchStatements.Express(newIdentifier.SetReference().Assign(exceptionIdentifier.GetReference()));
                thisCatchStatements.AddRange(GotoStateStatements(catchState));

                // Only do the above if the current exception is of the type expected by the catch handler.
                catchBlock.Add(Js.If(idioms.Is(exceptionIdentifier.GetReference(), exceptionType), thisCatchStatements));
            }
            if (node.Finally != null)
            {
                // Collect the statements of the finally block into the finally state
                CurrentState = finallyState;
                AcceptStatement(node.Finally.Block);

                // If the exception object is not null, then rethrow it.  In other words, if this is a finally 
                // clause that has responded to an exception, we need to propagate the exception rather than 
                // continue after the try statement.  Otherwise, go to the code after the try block.
                CurrentState.Add(Js.If(exceptionIdentifier.GetReference().NotEqualTo(Js.Null()), 
                    Js.Throw(exceptionIdentifier.GetReference()), 
                    Js.Block(GotoStateStatements(afterTry))));

                // Finally, at the very end of the catch clause (and we can only get here if the logic didn't break
                // out as it would with the logic in the catch handlers) go to the finally state.
                catchBlock.AddRange(GotoStateStatements(finallyState).ToArray());
            }

            newTryStatement.Catch = Js.Catch(Js.Variable(exceptionVariable));
            newTryStatement.Catch.Body = catchBlock;
            tryState.Wrap = switchStatement =>
            {
                newTryStatement.Body = Js.Block(switchStatement);
                return newTryStatement;
            };

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
            var newSwitchStatement = Js.Switch(
                (JsExpression)node.Expression.Accept(Transformer),
                node.Sections
                    .Select((x, i) =>
                    {
                        var section = Js.Section(x.Labels.Select(y => y.Value != null ? Js.CaseLabel((JsExpression)y.Value.Accept(Transformer)) : Js.DefaultLabel()).ToArray());
                        section.Statements.AddRange(GotoStateStatements(sectionStates[i]));
                        return section;
                    })
                    .ToArray());

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
            var newTryStatement = Js.Try();

            // Keep track of exception, if any, so we can rethrow
            var exceptionIdentifier = HoistVariable(new LiftedVariableKey("$usingex"));

            // Identifier for caught exception
            var caughtExceptionIdentifier = UniqueName("$caughtex");

            // Hoist the variable into a field
            var disposables = new List<JsExpression>();
            if (node.Declaration != null) 
            {
                foreach (var variable in node.Declaration.Variables)
                {
                    var symbol = (ILocalSymbol)Transformer.Model.GetDeclaredSymbol(variable);
                    var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));
                    var name = identifier.GetReference();
                    disposables.Add(name);
                    CurrentState.Add(name.Assign((JsExpression)variable.Initializer.Value.Accept(Transformer)).Express());
                }
            }
            if (node.Expression != null)
            {
                var identifier = Js.Reference(UniqueName("$using"));
                disposables.Add(identifier);
                CurrentState.Add(identifier.Assign((JsExpression)node.Expression.Accept(Transformer)).Express());
            }

            var tryState = NewSubstate();
            GotoState(tryState);

            var finallyState = GetNextState();
            CurrentState = finallyState;
            foreach (var disposable in disposables)
            {
                CurrentState.Add(disposable.Member("Dispose").Invoke().Express());
            }
            CurrentState.Add(Js.If(exceptionIdentifier.GetReference().NotEqualTo(Js.Null()), Js.Throw(exceptionIdentifier.GetReference())));
            GotoState(afterTry);
            newTryStatement.Catch = Js.Catch(Js.Variable(caughtExceptionIdentifier));
            newTryStatement.Catch.Body = Js.Block(
                new[] { exceptionIdentifier.GetReference().Assign(Js.Reference(caughtExceptionIdentifier)).Express() }
                    .Concat(GotoStateStatements(finallyState))
                    .ToArray()
            );

            tryState.Wrap = switchStatement =>
            {
                newTryStatement.Body = Js.Block(switchStatement);
                return newTryStatement;
            };

            StartSubstate(tryState);
            AcceptStatement(node.Statement);
            GotoState(finallyState);
            EndSubstate();

            CurrentState = afterTry;
        }

        class AsyncExpressionDecomposer : JsTransformer
        {
            private BaseAsyncStateGenerator stateGenerator;

            public AsyncExpressionDecomposer(AsyncStateGenerator stateGenerator, Idioms idioms) : base(idioms)
            {
                this.stateGenerator = stateGenerator;
            }

            public override JsNode VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
            {
                switch (node.CSharpKind())
                {
                    case SyntaxKind.AwaitExpression:
                        var operand = (JsExpression)node.Operand.Accept(this);
                        var expressionInfo = stateGenerator.Transformer.model.GetAwaitExpressionInfo(node);
                        var returnsVoid = expressionInfo.GetResultMethod.ReturnsVoid;
                        var operandType = model.GetTypeInfo(node.Operand).ConvertedType;
                        var awaiterMethodName = ((INamedTypeSymbol)operandType).GetMethodByName("GetAwaiter").GetMemberName();

                        // Store the awaiter in a field
                        var awaiterIdentifier = stateGenerator.HoistVariable(new LiftedVariableKey("$awaiter"));
                        var awaiter = awaiterIdentifier.GetReference();
                        stateGenerator.CurrentState.Add(awaiter.Assign(operand.Member(awaiterMethodName).Invoke()).Express());

                        var nextState = stateGenerator.InsertState();

                        JsExpression result = null;
                        if (!returnsVoid)
                        {
                            // If the await returns a value, store it in a field
                            var resultIdentifier = stateGenerator.HoistVariable(new LiftedVariableKey("$result"));
                            result = resultIdentifier.GetReference();

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

                        stateGenerator.CurrentState.Add(Js.If(
                            awaiter.Member("get_IsCompleted").Invoke(), 

                            // If the awaiter is already completed, go to the next state
                            stateGenerator.GotoTop(),

                            // Otherwise await for completion
                            Js.Block(
                                // Start the async process
                                Js.Reference(builder)
                                    .Member("TrueAwaitOnCompleted")
                                    .Invoke(awaiterIdentifier.GetReference(), Js.Reference(stateMachine))
                                    .Express(),
                                Js.Return()
                            )
                        ));

                        stateGenerator.CurrentState = nextState;

                        return result ?? Js.Null();
                }

                return base.VisitPrefixUnaryExpression(node);
            }
        }
    }
}