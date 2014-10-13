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
        private Dictionary<LiftedVariableKey, string> hoistedVariables = new Dictionary<LiftedVariableKey, string>();
        private Stack<AsyncState> breakStates = new Stack<AsyncState>();
        private Stack<AsyncState> continueStates = new Stack<AsyncState>();
        private List<MethodDeclarationSyntax> additionalHostMethods = new List<MethodDeclarationSyntax>();
        private IMethodSymbol method;
        private JsTransformer transformer;
        private JsBlockStatement stateMachineBody;
        private Idioms idioms;

        public const string stateMachine = "$stateMachine";
        public const string state = "$state";
        public const string builder = "$builder";
        public const string moveNext = "$moveNext";

        public AsyncStateGenerator(Compilation compilation, JsTransformer transformer, Idioms idioms, JsBlockStatement stateMachineBody, CSharpSyntaxNode node, IMethodSymbol method) : base(compilation, node)
        {
            this.method = method;
            this.transformer = transformer;
            this.stateMachineBody = stateMachineBody;
            this.idioms = idioms;
            decomposer = new AsyncExpressionDecomposer(this);
        }

        public IEnumerable<MethodDeclarationSyntax> AdditionalHostMethods
        {
            get { return additionalHostMethods; }
        }

/*
        private string GetIdentifier(LiftedVariableKey id)
        {
            string identifier;
            if (!hoistedVariables.TryGetValue(id, out identifier))
                identifier = id.Identifier;
            return identifier;
        }

*/
        private string GenerateNewNamePrivate(LiftedVariableKey symbol)
        {
            var counter = 2;
            do
            {
                var currentName = symbol.Identifier + counter++;
                if (!hoistedVariables.ContainsKey(new LiftedVariableKey(SyntaxFactory.Identifier(currentName))))
                {
                    return currentName;
                }
            }
            while (true);
        }

        protected string HoistVariable(LiftedVariableKey symbol)
        {
            var identifier = symbol.Identifier;
            if (hoistedVariables.ContainsKey(symbol) || hoistedVariables.ContainsKey(new LiftedVariableKey(symbol.Identifier)))
            {
                identifier = GenerateNewNamePrivate(symbol);
                hoistedVariables[symbol] = identifier;
                if (symbol.Symbol == null)
                    hoistedVariables[new LiftedVariableKey(symbol.Identifier)] = identifier;
            }
            stateMachineBody.Local(identifier, Js.Null());
            return identifier;
        }

        protected string UniqueName(string identifier)
        {
            var key = new LiftedVariableKey(identifier);
            if (hoistedVariables.ContainsKey(key))
            {
                identifier = GenerateNewNamePrivate(key);
                hoistedVariables[key] = identifier;
            }
            return identifier;            
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
            CurrentState.Add((JsStatement)node.Accept(decomposer));
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                // Hoist the variable into a field
                var symbol = (ILocalSymbol)semanticModel.GetDeclaredSymbol(variable);
                var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));

                if (variable.Initializer != null)
                {
                    var assignment = Js.Reference(identifier).Assign((JsExpression)variable.Initializer.Value.Accept(decomposer));
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
                CurrentState.Add(setResult.Invoke((JsExpression)result.Accept(decomposer)).Express());
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
                (JsExpression)node.Condition.Accept(decomposer),
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
                (JsExpression)node.Condition.Accept(decomposer),
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
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);
                var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));

                if (variable.Initializer != null)
                {
                    var assignment = Js.Reference(identifier).Assign((JsExpression)variable.Initializer.Value.Accept(decomposer));
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
                (JsExpression)node.Condition.Accept(decomposer),
                GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterLoop);

            CurrentState = bodyState;
            AcceptStatement(node.Statement, afterLoop, incrementorState);
            GotoState(incrementorState);

            CurrentState = incrementorState;
            foreach (var incrementor in node.Incrementors)
            {
                CurrentState.Add(((JsExpression)incrementor.Accept(decomposer)).Express());
            }
            GotoState(topOfLoop);

            CurrentState = afterLoop;
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            // Hoist the variable into a field
            var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, node);
            var identifier = HoistVariable(new LiftedVariableKey(node.Identifier, symbol));

            // Hoist the enumerator into a field
            var enumerator = identifier + "$enumerator";
            enumerator = HoistVariable(new LiftedVariableKey(enumerator));
            CurrentState.Add(
                Js.Reference(enumerator).Assign(
                    ((JsExpression)node.Expression.Accept(decomposer)).Member("GetEnumerator").Invoke()
                ).Express()
            );

            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterLoop = GetNextState();
            var bodyState = NewState(afterLoop);

            var moveNext = Js.Reference(enumerator).Member("MoveNext").Invoke();
            var newWhileStatement = Js.While(moveNext, GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterLoop);

            CurrentState = bodyState;
            CurrentState.Add(Js.Reference(identifier).Assign(Js.Reference(enumerator).Member("Current")).Express());
            
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
                exception = SyntaxFactory.IdentifierName(catchClause.Declaration.Identifier);
            }
            CurrentState.Add(Js.Throw((JsExpression)exception.Accept(decomposer)));
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
            catchBlock.Express(Js.Reference(exceptionIdentifier).Assign(Js.Reference(exceptionVariable)));

            foreach (var catchClause in node.Catches)
            {
                // Get the symbol that represents the exception declaration (identifier and type)
                var symbol = semanticModel.GetDeclaredSymbol(catchClause.Declaration);

                // True if it is actually declaring the variable (as opposed to a catch clause that specifies
                // merely an exception type
                var hasDeclaration = catchClause.Declaration.Identifier.CSharpKind() != SyntaxKind.None;

                // A variable to store the new unique identifier to store the exception
                string newIdentifier;

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
                thisCatchStatements.Express(Js.Reference(newIdentifier).Assign(Js.Reference(exceptionIdentifier)));
                thisCatchStatements.AddRange(GotoStateStatements(catchState));

                // Only do the above if the current exception is of the type expected by the catch handler.
                catchBlock.Add(Js.If(idioms.Is(Js.Reference(exceptionIdentifier), symbol.Type), thisCatchStatements));
            }
            if (node.Finally != null)
            {
                // Collect the statements of the finally block into the finally state
                CurrentState = finallyState;
                AcceptStatement(node.Finally.Block);

                // If the exception object is not null, then rethrow it.  In other words, if this is a finally 
                // clause that has responded to an exception, we need to propagate the exception rather than 
                // continue after the try statement.  Otherwise, go to the code after the try block.
                CurrentState.Add(Js.If(Js.Reference(exceptionIdentifier).NotEqualTo(Js.Null()), 
                    Js.Throw(Js.Reference(exceptionIdentifier)), 
                    Js.Block(GotoStateStatements(afterTry))));

                // Finally, at the very end of the catch clause (and we can only get here if the logic didn't break
                // out as it would with the logic in the catch handlers) go to the finally state.
                catchBlock.AddRange(GotoStateStatements(finallyState).ToArray());
            }

            newTryStatement.Catch = Js.Catch(Js.Variable(exceptionIdentifier));
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
                (JsExpression)node.Expression.Accept(decomposer),
                node.Sections
                    .Select((x, i) =>
                    {
                        var section = Js.Section(x.Labels.Select(y => y.Value != null ? Js.CaseLabel((JsExpression)y.Value.Accept(decomposer)) : Js.DefaultLabel()).ToArray());
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
                    var symbol = (ILocalSymbol)semanticModel.GetDeclaredSymbol(variable);
                    var identifier = HoistVariable(new LiftedVariableKey(variable.Identifier, symbol));
                    var name = Js.Reference(identifier);
                    disposables.Add(name);
                    CurrentState.Add(name.Assign((JsExpression)variable.Initializer.Value.Accept(decomposer)).Express());
                }
            }
            if (node.Expression != null)
            {
                var identifier = Js.Reference(UniqueName("$using"));
                disposables.Add(identifier);
                CurrentState.Add(identifier.Assign((JsExpression)node.Expression.Accept(decomposer)).Express());
            }

            var tryState = NewSubstate();
            GotoState(tryState);

            var finallyState = GetNextState();
            CurrentState = finallyState;
            foreach (var disposable in disposables)
            {
                CurrentState.Add(disposable.Member("Dispose").Invoke().Express());
            }
            CurrentState.Add(Js.If(Js.Reference(exceptionIdentifier).NotEqualTo(Js.Null()), Js.Throw(Js.Reference(exceptionIdentifier))));
            GotoState(afterTry);
            newTryStatement.Catch = Js.Catch(Js.Variable(caughtExceptionIdentifier));
            newTryStatement.Catch.Body = Js.Block(
                new[] { Js.Reference(exceptionIdentifier).Assign(Js.Reference(caughtExceptionIdentifier)).Express() }
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
            private AsyncStateGenerator stateGenerator;

            public AsyncExpressionDecomposer(AsyncStateGenerator stateGenerator) : base(stateGenerator.transformer.syntaxTree, stateGenerator.transformer.model)
            {
                this.stateGenerator = stateGenerator;
            }

            public override JsNode VisitPrefixUnaryExpression(PrefixUnaryExpressionSyntax node)
            {
                switch (node.CSharpKind())
                {
                    case SyntaxKind.AwaitExpression:
                        var operand = (JsExpression)node.Operand.Accept(this);
                        var expressionInfo = stateGenerator.semanticModel.GetAwaitExpressionInfo(node);
                        var returnsVoid = expressionInfo.GetResultMethod.ReturnsVoid;

                        // Store the awaiter in a field
                        var awaiterIdentifier = "$awaiter";
                        awaiterIdentifier = stateGenerator.HoistVariable(new LiftedVariableKey(awaiterIdentifier));
                        var awaiter = Js.Reference(awaiterIdentifier);
                        stateGenerator.CurrentState.Add(awaiter.Assign(operand.Member("GetAwaiter").Invoke()).Express());

                        var nextState = stateGenerator.InsertState();

                        JsExpression result = null;
                        if (!returnsVoid)
                        {
                            // If the await returns a value, store it in a field
                            var resultIdentifier = "$result";
                            resultIdentifier = stateGenerator.HoistVariable(new LiftedVariableKey(resultIdentifier));
                            result = Js.Reference(resultIdentifier);

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
                            awaiter.Member("IsCompleted"), 

                            // If the awaiter is already completed, go to the next state
                            stateGenerator.GotoTop(),

                            // Otherwise await for completion
                            Js.Block(
                                // Start the async process
                                Js.Reference(builder)
                                    .Member("AwaitOnCompleted")
                                    .Invoke(Js.Reference(awaiterIdentifier), Js.This())
                                    .Express(),
                                Js.Return()
                            )
                        ));

                        stateGenerator.CurrentState = nextState;

                        return result ?? Js.Null();
                }

                return base.VisitPrefixUnaryExpression(node);
            }

/*
            public override JsNode VisitInvocationExpression(InvocationExpressionSyntax node)
            {
                var model = stateGenerator.semanticModel;
                var symbol = model.GetSymbolInfo(node).Symbol;
                var method = (IMethodSymbol)symbol;

                if (node.Expression is MemberAccessExpressionSyntax)
                {
                    var methodTargetSyntax = ((MemberAccessExpressionSyntax)node.Expression).Expression;
                    if (methodTargetSyntax is BaseExpressionSyntax)
                    {
                        var baseMethodName = "Base$" + method.Name;
                        if (!stateGenerator.additionalHostMethods.Any(x => x.Identifier.ToString() == baseMethodName))
                        {
                            var body = SyntaxFactory.BaseExpression().Member(method.Name).Invoke(method.Parameters.Select(x => Cs.IdentifierName(x.Name)).ToArray());

                            var baseMethodShim = SyntaxFactory.MethodDeclaration(method.ReturnType.ToTypeSyntax(), baseMethodName)
                                .WithModifiers(SyntaxFactory.TokenList(Cs.Token(SyntaxKind.PrivateKeyword)))
                                .WithParameterList(method.Parameters.ToParameterList())
                                .WithBody(Cs.Block(method.ReturnType.SpecialType == SpecialType.System_Void ? (StatementSyntax)body.Express() : Cs.Return(body)));
                            stateGenerator.additionalHostMethods.Add(baseMethodShim);
                        }

                        return 
                        return node.WithExpression((ExpressionSyntax)Js.Reference(baseMethodName).Accept(stateGenerator.decomposer));
                    }
                }            

                return base.VisitInvocationExpression(node);
            }
*/
        }

        protected struct LiftedVariableKey
        {
            private readonly string identifier;
            private readonly ISymbol symbol;

            public LiftedVariableKey(SyntaxToken identifier, ISymbol symbol)
            {
                this.identifier = identifier.ToString();
                this.symbol = symbol;
            }

            public LiftedVariableKey(string identifier, ISymbol symbol)
            {
                this.identifier = identifier;
                this.symbol = symbol;
            }

            public LiftedVariableKey(SyntaxToken identifier) : this()
            {
                this.identifier = identifier.ToString();
            }

            public LiftedVariableKey(string identifier) : this()
            {
                this.identifier = identifier;
            }

            public string Identifier
            {
                get { return identifier; }
            }

            public ISymbol Symbol
            {
                get { return symbol; }
            }

            public bool Equals(LiftedVariableKey other)
            {
                return string.Equals(identifier, other.identifier) && (Equals(symbol, other.symbol) || symbol == null || other.symbol == null);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is LiftedVariableKey && Equals((LiftedVariableKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return identifier.GetHashCode();
                }
            }
        }
    }
}