using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class BaseAsyncStateGenerator : CSharpSyntaxWalker
    {
        public const string stateMachine = "$stateMachine";
        public const string state = "$state";
        public const string moveNext = "$moveNext";
        public const string @this = "$this";

        private readonly JsTransformer transformer;

        private int currentStateIndex;
        private Dictionary<LiftedVariableKey, string> hoistedVariables = new Dictionary<LiftedVariableKey, string>();
        private JsBlockStatement stateMachineBody;
        private CSharpSyntaxNode node;
        private Stack<AsyncState> breakStates = new Stack<AsyncState>();
        private Stack<AsyncState> continueStates = new Stack<AsyncState>();
        private Dictionary<string, AsyncState> labeledStates = new Dictionary<string, AsyncState>();
        private IMethodSymbol method;
        private Idioms idioms;
        internal AsyncState topState = new AsyncState();
        
        public BaseAsyncStateGenerator(Func<BaseAsyncStateGenerator, JsTransformer> transformer, CSharpSyntaxNode node, JsBlockStatement stateMachineBody, Idioms idioms, IMethodSymbol method)
        {
            this.transformer = transformer(this);
            this.node = node;
            this.stateMachineBody = stateMachineBody;
            this.method = method;
            this.idioms = idioms;
        }

        public JsTransformer Transformer
        {
            get { return transformer; }
        }

        public IMethodSymbol Method
        {
            get { return method; }
        }

        public Idioms Idioms
        {
            get { return idioms; }
        }

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

        public JsVariableDeclarator HoistVariable(LiftedVariableKey symbol)
        {
            var identifier = symbol.Identifier;
            if (hoistedVariables.ContainsKey(symbol) || hoistedVariables.ContainsKey(new LiftedVariableKey(symbol.Identifier)))
            {
                identifier = GenerateNewNamePrivate(symbol);
                symbol = new LiftedVariableKey(identifier, symbol.Symbol);
            }
            
            // Register the variable so we avoid collisions.
            hoistedVariables[symbol] = identifier;
            if (symbol.Symbol == null)
                hoistedVariables[new LiftedVariableKey(symbol.Identifier)] = identifier;

            // Declare a local variable (of the top-level function so available as closures to the state
            // machine) to store the symbol.
            var declaration = stateMachineBody.Local(identifier, Js.Null());

            // If we have a true symbol associated with the key, then declare it in the base transformer
            if (symbol.Symbol != null)
                transformer.DeclareInCurrentScope(symbol.Symbol, declaration);

            return declaration;
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

        public void GenerateStates()
        {
            topState.CurrentState = NewState();
            node.Accept(this);
            CleanStates(topState);
            if (!topState.Substates.Last().Statements.Any())
                topState.Substates.Remove(topState.Substates.Last());

            OnBaseStateGenerated();
        }

        private void CleanStates(AsyncState parent)
        {
/*
            if (!parent.Statements.Any() && !parent.Substates.Any())
            {
                parent.Add(Js.Reference(state).Assign(Js.Primitive(-1)).Express());
                parent.Add(Js.Break());
            }
            foreach (var childState in parent.Substates)
            {
                CleanStates(childState);
            }
*/
        }

        protected virtual void OnBaseStateGenerated()
        {
        }

        public AsyncState TopState
        {
            get { return topState; }
        }

        protected AsyncState NewState(AsyncState nextState = null)
        {
            var newState = new AsyncState();
            newState.Parent = topState;
            newState.Index = currentStateIndex++;
            newState.Next = nextState;
            topState.Substates.Add(newState);            
            return newState;
        }

        protected AsyncState FindLabeledState(string label)
        {
            if (labeledStates.ContainsKey(label))
                return labeledStates[label];
            else
            {
                var labeledState = new AsyncState();
                labeledState.Index = currentStateIndex++;
                labeledStates[label] = labeledState;
                return labeledState;
            }
        }

        protected AsyncState NewLabeledState(string label)
        {
            if (!labeledStates.ContainsKey(label))
            {
                var labeledState = GetNextState();
                labeledStates[label] = labeledState;
                return labeledState;                
            }
            else
            {
                var labeledState = labeledStates[label];
                labeledState.Parent = topState;
                topState.Substates.Add(labeledState);
                return labeledState;
            }
        }

        protected AsyncState NewSubstate()
        {
            var newState = NewState();
            return newState;
        }

        protected void StartSubstate(AsyncState substate)
        {
            topState = substate;
            CurrentState = NewState();            
        }

        protected void EndSubstate()
        {
            topState.InternalAdd(GenerateSwitch(topState));
            topState = topState.Parent;
        }

        protected AsyncState GetNextState()
        {
            if (topState.CurrentState.Next != null)
            {
                return topState.CurrentState.Next;
            }
            else
            {
                var nextState = NewState();
                return nextState;                
            }
        }

        public AsyncState InsertState()
        {
            var nextState = NewState();
            nextState.Next = topState.CurrentState.Next;
            return nextState;
        }

        public AsyncState CurrentState
        {
            get { return topState.CurrentState; }
            set { topState.CurrentState = value; }
        }

        public JsStatement GotoTop()
        {
            return Js.Continue("$top");
        }

        public JsStatement ChangeState(AsyncState newState)
        {
            return Js.Reference(state).Assign(Js.Primitive(newState.Index)).Express();
        }

        public void GotoState(AsyncState newState)
        {
            if (newState == CurrentState)
                return;
            var lastStatement = CurrentState.Statements.LastOrDefault();
            if (lastStatement is JsContinueStatement || lastStatement is JsBreakStatement || lastStatement is JsReturnStatement)
                return;
            CurrentState.Add(ChangeState(newState));
            CurrentState.Add(GotoTop());
        }

        public JsBlockStatement GotoStateBlock(AsyncState newState)
        {
            return Js.Block(
                ChangeState(newState),
                GotoTop()
            );
        }

        public JsStatement[] GotoStateStatements(AsyncState newState)
        {
            return new[]
            {
                ChangeState(newState),
                GotoTop()                
            };
        }

        public JsStatement GenerateSwitch(AsyncState state)
        {
            var sections = new List<JsSwitchSection>();
            if (state.Parent != null)
            {
                var stateSection = Js.Section(Js.Primitive(state.Index));
                stateSection.Statements.AddRange(GotoStateStatements(state.Substates.First()));
                sections.Add(stateSection);
            }
            sections.AddRange(state.Substates.Select(substate =>
            {
                var section = Js.Section(substate.GetAllIndices().Select(index => Js.Primitive(index)).ToArray());
                section.Statements.AddRange(substate.Statements);
                return section;
            }));
            return state.Wrap(Js.Switch(Js.Reference(StateGenerator.state), sections.ToArray()));
        }

        protected void AcceptStatement(StatementSyntax statement, AsyncState breakState = null, AsyncState continueState = null)
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

        protected void Accept(Action action, AsyncState breakState = null, AsyncState continueState = null)
        {
            if (breakState != null)
                breakStates.Push(breakState);
            if (continueState != null)
                continueStates.Push(continueState);
            action();
            if (breakState != null)
                breakStates.Pop();
            if (continueState !=  null)
                continueStates.Pop();
        }

        public override void VisitBreakStatement(BreakStatementSyntax node)
        {
            GotoState(breakStates.Peek());
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            GotoState(continueStates.Peek());
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
            var ifTrueState = GetNextState();
            var ifFalseState = node.Else != null ? GetNextState() : null;

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

        public override void VisitDoStatement(DoStatementSyntax node)
        {
            var topOfLoop = GetNextState();
            var afterWhileStatement = GetNextState();
            var bodyState = GetNextState();

            // The first thing that needs to happen is that the body should execute once,
            // regardless of the condition.  After that, we can just use a while loop,
            // since from that point on it's equivalent.
            GotoState(bodyState);

            CurrentState = bodyState;
            AcceptStatement(node.Statement, afterWhileStatement, topOfLoop);
            GotoState(topOfLoop);

            CurrentState = topOfLoop;
            var newWhileStatement = Js.While(
                (JsExpression)node.Condition.Accept(Transformer),
                GotoStateBlock(bodyState));

            CurrentState.Add(newWhileStatement);
            GotoState(afterWhileStatement);

            CurrentState = afterWhileStatement;
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            var topOfLoop = GetNextState();

            GotoState(topOfLoop);
            CurrentState = topOfLoop;

            var afterWhileStatement = GetNextState();
            var bodyState = NewState();

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
            if (node.Declaration != null)
            {
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
            }
            else if (node.Initializers.Any())
            {
                foreach (var initializer in node.Initializers)
                {
                    var assignment = (JsExpression)initializer.Accept(Transformer);
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
                node.Condition == null ? Js.Primitive(true) : (JsExpression)node.Condition.Accept(Transformer),
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
            var bodyState = GetNextState();

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
                catchBlock.Add(Js.If(Idioms.Is(exceptionIdentifier.GetReference(), exceptionType), thisCatchStatements));
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

            var sectionStates = node.Sections.Select(x => GetNextState()).ToArray();
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

            Accept(() =>
            {
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
            }, afterSwitchState);

            CurrentState = afterSwitchState;
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

        public override void VisitLabeledStatement(LabeledStatementSyntax node)
        {
            var label = node.Identifier.ToString();
            var labelState = NewLabeledState(label);
            GotoState(labelState);

            CurrentState = labelState;
            AcceptStatement(node.Statement);
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            var label = ((IdentifierNameSyntax)node.Expression).Identifier.ToString();
            var labelState = FindLabeledState(label);
            GotoState(labelState);
        }

        public struct LiftedVariableKey
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