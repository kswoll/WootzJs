using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class YieldStateGenerator : SyntaxWalker
    {
        private Compilation compilation;
        private MethodDeclarationSyntax node;
        internal List<YieldState> states = new List<YieldState>();
        private YieldState currentState;
        private Dictionary<string, TypeSyntax> hoistedVariables = new Dictionary<string, TypeSyntax>();
        private int exceptionNameCounter = 1;
        private Dictionary<object, YieldState> labelStates = new Dictionary<object, YieldState>();

        const string state = YieldClassGenerator.state;
        
        public YieldStateGenerator(Compilation compilation, MethodDeclarationSyntax node)
        {
            this.compilation = compilation;
            this.node = node;
        }

        private string GenerateNewName(SyntaxToken identifier)
        {
            var counter = 2;
            do
            {
                var currentName = identifier.ToString() + counter;
                if (!hoistedVariables.ContainsKey(currentName))
                {
                    return currentName;
                }
            }
            while (true);
        }

        private SyntaxNode HoistVariable(SyntaxNode node, SyntaxToken identifier, TypeSyntax type)
        {
            if (hoistedVariables.ContainsKey(identifier.ToString()))
            {
                var newName = GenerateNewName(identifier);
                var newIdentifier = Syntax.Identifier(newName);
                node = IdentifierRenamer.RenameIdentifier(node, identifier, newIdentifier);
                identifier = newIdentifier;
            }
            hoistedVariables[identifier.ToString()] = type;
            return node;
        }

        public void GenerateStates()
        {
            var lastState = new YieldState(this);
            lastState.Statements.Add(Cs.Return(Cs.False()));

            currentState = new YieldState(this) { NextState = lastState };
            node.Accept(this);

            // Post-process goto statements
            if (labelStates.Any())
            {
                var gotoSubstituter = new GotoSubstituter(compilation, labelStates);
                foreach (var state in states)
                {
                    state.Statements = state.Statements.Select(x => (StatementSyntax)x.Accept(gotoSubstituter)).ToList();
                }
            }
        }

        public YieldState[] States
        {
            get { return states.ToArray(); }
        }

        public Tuple<SyntaxToken, TypeSyntax>[] HoistedVariables
        {
            get { return hoistedVariables.Select(x => Tuple.Create(Syntax.Identifier(x.Key), x.Value)).ToArray(); }
        }

        private YieldState GetNextState(StatementSyntax node)
        {
            var nextState = currentState.NextState;
            var next = node.GetNextStatement();
            if (next != null && !(next is EmptyStatementSyntax))
            {
                nextState = new YieldState(this) { NextState = currentState.NextState, Germ = currentState.Germ };
            }
            return nextState;
        }

        private void SetClosed(YieldState yieldState)
        {
            yieldState.IsClosed = true;
            if (yieldState.Germ != null)
                yieldState.Germ(yieldState);
        }

        public void Close(YieldState yieldState)
        {
            CloseTo(yieldState, yieldState.NextState);
        }

        public void CloseTo(YieldState fromState, YieldState toState)
        {
            if (fromState.IsClosed)
                return;
            if (toState == null)
                throw new ArgumentNullException("toState");

            fromState.Add(ChangeState(toState));
            fromState.Add(GotoTop());                        
            SetClosed(fromState);
        }

        public static StatementSyntax ChangeState(YieldState newState)
        {
            return Cs.Express(Cs.Assign(Cs.This().Member(state), Cs.Integer(newState.Index)));
        }

        private StatementSyntax GotoTop()
        {
            return Syntax.GotoStatement(SyntaxKind.GotoStatement, Syntax.IdentifierName("$top"));
        }

        private void MaybeCreateNewState()
        {
            if (currentState.Statements.Any())
            {
                var thisState = new YieldState(this);
                var oldNextState = currentState.NextState;
                thisState.NextState = oldNextState;
                currentState.NextState = thisState;
                Close(currentState);
                currentState = thisState;
            }
        }

        private StatementSyntax[] CaptureState(SyntaxNode node, YieldState nextState, YieldState breakState)
        {
            var catchBatch = new YieldState(this, true) { NextState = nextState };
            var oldState = currentState;
            currentState = catchBatch;
            node.Accept(this);
            // If after walking the node, it might leave the current state in an unclosed state.  We want to make sure it's closed.
            if (currentState != breakState && currentState != catchBatch && currentState != nextState && currentState != oldState)
            {
                Close(currentState);
            }
            return catchBatch.Statements.ToArray();
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            var semanticModel = compilation.GetSemanticModel(node.SyntaxTree);

            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                if (variable.Initializer != null)
                {
                    var assignment = Cs.Assign(Syntax.IdentifierName(variable.Identifier.ToString()), variable.Initializer.Value);
                    currentState.Add(Cs.Express(assignment));
                }

                // Hoist the variable into a field
                var symbol = (LocalSymbol)semanticModel.GetDeclaredSymbol(variable);
                node = (LocalDeclarationStatementSyntax)HoistVariable(node, variable.Identifier, symbol.Type.ToTypeSyntax());
            }
        }

        public override void VisitYieldStatement(YieldStatementSyntax node)
        {
            var nextState = GetNextState(node);

            if (node.ReturnOrBreakKeyword.Kind == SyntaxKind.BreakKeyword)
            {
                currentState.Add(ChangeState(nextState));
                currentState.Add(Cs.Return(Cs.False()));
            }
            else
            {
                currentState.Add(ChangeState(nextState));
                currentState.Add(Cs.Express(Cs.Assign(Cs.This().Member("Current"), node.Expression)));
                currentState.Add(Cs.Return(Cs.True()));
            }
            SetClosed(currentState);

            currentState = nextState;
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(node);
            }
            else
            {
                if (node.Catches.Any())
                    throw new Exception("Yield statements cannot be contained inside try/catch blocks.");

                var nextState = GetNextState(node);

                MaybeCreateNewState();

                var tryState = currentState;
                tryState.NextState = nextState;

                var exceptionName = Syntax.Identifier("$ex" + exceptionNameCounter++);
                var finallyState = new YieldState(this) { NextState = nextState, BreakState = nextState };
                foreach (var finallyStatement in node.Finally.Block.Statements)
                    finallyState.Add(finallyStatement);
                finallyState.Add(Cs.If(Cs.This().Member(exceptionName).NotEqualTo(Cs.Null()), Cs.Throw(Cs.This().Member(exceptionName))));
                Close(finallyState);

                node = (TryStatementSyntax)HoistVariable(node, exceptionName, Syntax.ParseTypeName("System.Exception"));

                tryState.NextState = finallyState;
                tryState.Germ = yieldState =>
                {
                    var gotoFinally = Syntax.Block(
                        Cs.Express(Cs.Assign(Cs.This().Member(exceptionName), Syntax.IdentifierName(exceptionName))),
                        ChangeState(finallyState), 
                        GotoTop()
                    );

                    var statements = yieldState.Statements.ToArray();
                    yieldState.Statements.Clear();
                    yieldState.Statements.Add(Cs.Try().WithBlock(Cs.Block(statements)).WithCatches(
                        Syntax.CatchClause(Syntax.CatchDeclaration(Syntax.ParseTypeName("System.Exception"), exceptionName), gotoFinally)));
                };

                node.Block.Accept(this);

                if (!tryState.IsClosed)
                {
                    CloseTo(tryState, finallyState);
                }

                currentState = nextState;            
            }
        }

        public override void VisitDoStatement(DoStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(node);
            }
            else
            {
                MaybeCreateNewState();

                var nextState = GetNextState(node);

                var conditionState = new YieldState(this) { BreakState = nextState };

                var iterationState = currentState;

                conditionState.Add(Cs.If(node.Condition, ChangeState(iterationState), ChangeState(nextState)));
                conditionState.Add(GotoTop());
                SetClosed(conditionState);
                iterationState.NextState = conditionState;

                node.Statement.Accept(this);
                if (currentState != nextState)
                {
                    Close(currentState);
                }

                currentState = nextState;
            }
        }

        public override void VisitWhileStatement(WhileStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(node);
            }
            else
            {
                MaybeCreateNewState();

                var nextState = GetNextState(node);
                var iterationState = currentState;
                iterationState.NextState = nextState;
                iterationState.BreakState = nextState;

                node = node.WithStatement(Syntax.Block(CaptureState(node.Statement, iterationState, nextState)));
                iterationState.Statements.Add(node);

                Close(iterationState);

                currentState = nextState;
            }
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(node);
            }
            else
            {
                var semanticModel = compilation.GetSemanticModel(node.SyntaxTree);

                // Convert the variable declarations in the for loop
                if (node.Declaration != null)
                {
                    foreach (var variable in node.Declaration.Variables.Where(x => x.Initializer != null))
                    {
                        var assignment = Cs.Assign(Syntax.IdentifierName(variable.Identifier.ToString()), variable.Initializer.Value);
                        currentState.Add(Cs.Express(assignment));

                        var symbol = (LocalSymbol)semanticModel.GetDeclaredSymbol(variable);

                        // Hoist the variable into a field
                        node = (ForStatementSyntax)HoistVariable(node, variable.Identifier, Syntax.ParseTypeName(symbol.Type.GetFullName()));
                    }
                }
                foreach (var initializer in node.Initializers)
                {
                    currentState.Add(Cs.Express(initializer));
                }

                MaybeCreateNewState();

                var nextState = GetNextState(node);
                var iterationState = currentState;

                // postState determines where the flow goes after each iteration.  If there are incrementors, it goes
                // to a state that handles the incrementing, then goes back to the iteration state.  Otherwise, the 
                // iteration state just points back to itself like the while loop.
                YieldState postState;
                if (node.Incrementors.Any())
                {
                    postState = new YieldState(this);
                    postState.NextState = iterationState;

                    foreach (var incrementor in node.Incrementors)
                    {
                        postState.Add(Cs.Express(incrementor));
                    }
                    Close(postState);
                }
                else
                {
                    postState = iterationState;
                }
                iterationState.NextState = nextState;
                iterationState.BreakState = nextState;

                var forStatement = Syntax.WhileStatement(node.Condition ?? Cs.True(), Syntax.Block(CaptureState(node.Statement, postState, nextState)));
                iterationState.Statements.Add(forStatement);

                Close(iterationState);

                currentState = nextState;
            }
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(node);
            }
            else
            {
                // Convert the variable declaration in the for loop
                var semanticModel = compilation.GetSemanticModel(node.SyntaxTree);
                var symbol = semanticModel.GetDeclaredSymbol(node);

                // Hoist the variable into a field
                node = (ForEachStatementSyntax)HoistVariable(node, node.Identifier, Syntax.ParseTypeName(symbol.Type.GetFullName()));

                // Hoist the enumerator into a field
                var enumerator = Syntax.Identifier(node.Identifier + "$enumerator");
                node = (ForEachStatementSyntax)HoistVariable(node, enumerator, Syntax.ParseTypeName("System.Collections.IEnumerator"));
                currentState.Add(Cs.Express(Cs.Assign(
                    Syntax.IdentifierName(enumerator), 
                    Syntax.InvocationExpression(Syntax.MemberAccessExpression(SyntaxKind.MemberAccessExpression, node.Expression, Syntax.IdentifierName("GetEnumerator"))))));

                // Mostly the same as while loop from here (key word, "mostly"; hence the lack of factoring here)
                MaybeCreateNewState();

                var nextState = GetNextState(node);
                var iterationState = currentState;

                iterationState.NextState = iterationState;
                iterationState.BreakState = nextState;

                var bodyBatch = new YieldState(this, true) { NextState = iterationState.NextState };

                // Assign current item
                bodyBatch.Add(Cs.Express(Cs.Assign(Syntax.IdentifierName(node.Identifier), 
                    Syntax.MemberAccessExpression(SyntaxKind.MemberAccessExpression, 
                    Syntax.IdentifierName(enumerator), Syntax.IdentifierName("Current")))));

                currentState = bodyBatch;
                node.Statement.Accept(this);

                var moveNext = Syntax.InvocationExpression(Syntax.MemberAccessExpression(SyntaxKind.MemberAccessExpression, Syntax.IdentifierName(enumerator), Syntax.IdentifierName("MoveNext")));
                var forStatement = Syntax.WhileStatement(moveNext, Syntax.Block(bodyBatch.Statements));
                iterationState.Statements.Add(forStatement);

                CloseTo(iterationState, nextState);
                if (currentState != nextState)
                {
                    Close(currentState);
                }

                currentState = nextState;
            }
        }

        public override void VisitSwitchStatement(SwitchStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(node);
            }
            else
            {
                var nextState = GetNextState(node);
                var switchState = currentState;
                switchState.NextState = nextState;

                var switchStatement = Cs.Switch(node.Expression);

                foreach (var section in node.Sections.Select(x => x.WithStatements(Syntax.List(x.Statements.Select(y => BreakStatementStripper.StripStatements(y))))))
                {
                    switchStatement = switchStatement.AddSections(Cs.Section(section.Labels, CaptureState(section, switchState.NextState, nextState)));
                }

                switchState.Statements.Add(switchStatement);

                Close(switchState);

                currentState = nextState;
            }
        }

        public override void VisitIfStatement(IfStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(node);
            }
            else
            {
                var nextState = GetNextState(node);
                var ifState = currentState;
                ifState.NextState = nextState;

                var ifStatement = node;
                ifStatement = ifStatement.WithStatement(Syntax.Block(CaptureState(node.Statement, ifState.NextState, nextState)));

                if (node.Else != null)
                {
                    ifStatement = ifStatement.WithElse(Syntax.ElseClause(Syntax.Block(CaptureState(node.Else, ifState.NextState, nextState))));
                }

                ifState.Statements.Add(ifStatement);

                Close(ifState);
                currentState = nextState;
            }
        }

        public override void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            currentState.Add(node);
        }

        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            currentState.Add(node);
        }

        public override void VisitEmptyStatement(EmptyStatementSyntax node)
        {
        }

        public override void VisitLabeledStatement(LabeledStatementSyntax node)
        {
            MaybeCreateNewState();
            
            var nextState = GetNextState(node);

            var labelState = currentState;
            labelStates[node.Identifier.ToString()] = labelState;
            labelState.NextState = nextState;

            node.Statement.Accept(this);
            if (currentState != nextState)
            {
                Close(currentState);
            }

            currentState = nextState;
        }

        public override void VisitGotoStatement(GotoStatementSyntax node)
        {
            currentState.Add(node);
            currentState.Add(GotoTop());                        
            SetClosed(currentState);
        }

        public override void VisitBreakStatement(BreakStatementSyntax node)
        {
            if (currentState.NextState.BreakState == null)
                throw new Exception();

            CloseTo(currentState, currentState.NextState.BreakState);
        }

        public override void VisitContinueStatement(ContinueStatementSyntax node)
        {
            CloseTo(currentState, currentState.NextState);
        }

        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            throw new Exception();          // Yield methods can't have normal return statements.
        }

        public override void VisitUsingStatement(UsingStatementSyntax node)
        {
            base.VisitUsingStatement(node);
        }

        public override void VisitFixedStatement(FixedStatementSyntax node)
        {
            throw new NotSupportedException();
        }

        public override void VisitCheckedStatement(CheckedStatementSyntax node)
        {
            throw new NotSupportedException();
        }

        public override void VisitUnsafeStatement(UnsafeStatementSyntax node)
        {
            throw new NotSupportedException();
        }

        public override void VisitLockStatement(LockStatementSyntax node)
        {
            throw new NotSupportedException();
        }

        public override void VisitGlobalStatement(GlobalStatementSyntax node)
        {
            throw new NotSupportedException();
        }
    }
}