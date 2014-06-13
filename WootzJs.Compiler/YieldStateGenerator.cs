#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class YieldStateGenerator : StateGenerator
    {
        public YieldStateGenerator(Compilation compilation, MethodDeclarationSyntax node) : base(compilation, node)
        {
        }

        public override void VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        {
            var semanticModel = compilation.GetSemanticModel(node.SyntaxTree);

            // Convert the variable declaration to an assignment expression statement
            foreach (var variable in node.Declaration.Variables)
            {
                if (variable.Initializer != null)
                {
                    var assignment = SyntaxFactory.IdentifierName(variable.Identifier.ToString()).Assign(variable.Initializer.Value);
                    currentState.Add(Cs.Express(YieldThisFixer.Fix(assignment)));
                }

                // Hoist the variable into a field
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);
                node = (LocalDeclarationStatementSyntax)HoistVariable(node, variable.Identifier, symbol.Type.ToTypeSyntax());
            }
        }

        public override void VisitYieldStatement(YieldStatementSyntax node)
        {
            var nextState = GetNextState(node);

            if (node.ReturnOrBreakKeyword.IsKind(SyntaxKind.BreakKeyword))
            {
                currentState.Add(ChangeState(nextState));
                currentState.Add(Cs.Return(Cs.False()));
            }
            else
            {
                currentState.Add(ChangeState(nextState));
                currentState.Add(Cs.Express(Cs.This().Member("Current").Assign(YieldThisFixer.Fix(node.Expression))));
                currentState.Add(Cs.Return(Cs.True()));
            }
            SetClosed(currentState);

            currentState = nextState;
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(YieldThisFixer.Fix(node));
            }
            else
            {
                if (node.Catches.Any())
                    throw new Exception("Yield statements cannot be contained inside try/catch blocks.");

                var nextState = GetNextState(node);

                MaybeCreateNewState();

                var tryState = currentState;
                tryState.NextState = nextState;

                var exceptionName = SyntaxFactory.Identifier("$ex" + exceptionNameCounter++);
                var finallyState = new State(this) { NextState = nextState, BreakState = nextState };
                foreach (var finallyStatement in node.Finally.Block.Statements)
                    finallyState.Add(finallyStatement);
                finallyState.Add(Cs.If(Cs.This().Member(exceptionName).NotEqualTo(Cs.Null()), Cs.Throw(Cs.This().Member(exceptionName))));
                Close(finallyState);

                node = (TryStatementSyntax)HoistVariable(node, exceptionName, SyntaxFactory.ParseTypeName("System.Exception"));

                tryState.NextState = finallyState;
                tryState.Germ = yieldState =>
                {
                    var gotoFinally = SyntaxFactory.Block(
                        Cs.Express(Cs.This().Member(exceptionName).Assign(SyntaxFactory.IdentifierName(exceptionName))),
                        ChangeState(finallyState), 
                        GotoTop()
                    );

                    var statements = yieldState.Statements.ToArray();
                    yieldState.Statements.Clear();
                    yieldState.Statements.Add(Cs.Try().WithBlock(Cs.Block(statements)).WithCatches(SyntaxFactory.List(new[] {
                        SyntaxFactory.CatchClause(SyntaxFactory.CatchDeclaration(SyntaxFactory.ParseTypeName("System.Exception"), exceptionName), null, gotoFinally) })));
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
                currentState.Add(YieldThisFixer.Fix(node));
            }
            else
            {
                MaybeCreateNewState();

                var nextState = GetNextState(node);

                var conditionState = new State(this) { BreakState = nextState };

                var iterationState = currentState;

                conditionState.Add(Cs.If(YieldThisFixer.Fix(node.Condition), ChangeState(iterationState), ChangeState(nextState)));
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
                currentState.Add(YieldThisFixer.Fix(node));
            }
            else
            {
                MaybeCreateNewState();

                var nextState = GetNextState(node);
                var iterationState = currentState;
                iterationState.NextState = nextState;
                iterationState.BreakState = nextState;

                node = node.WithStatement(SyntaxFactory.Block(CaptureState(node.Statement, iterationState, nextState)));
                iterationState.Statements.Add(node);

                Close(iterationState);

                currentState = nextState;
            }
        }

        public override void VisitForStatement(ForStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(YieldThisFixer.Fix(node));
            }
            else
            {
                var semanticModel = compilation.GetSemanticModel(node.SyntaxTree);

                // Convert the variable declarations in the for loop
                if (node.Declaration != null)
                {
                    foreach (var variable in node.Declaration.Variables.Where(x => x.Initializer != null))
                    {
                        var assignment = SyntaxFactory.IdentifierName(variable.Identifier.ToString()).Assign(variable.Initializer.Value);
                        currentState.Add(Cs.Express(assignment));

                        var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);

                        // Hoist the variable into a field
                        node = (ForStatementSyntax)HoistVariable(node, variable.Identifier, SyntaxFactory.ParseTypeName(symbol.Type.GetFullName()));
                    }
                }
                foreach (var initializer in node.Initializers)
                {
                    currentState.Add(Cs.Express(YieldThisFixer.Fix(initializer)));
                }

                MaybeCreateNewState();

                var nextState = GetNextState(node);
                var iterationState = currentState;

                // postState determines where the flow goes after each iteration.  If there are incrementors, it goes
                // to a state that handles the incrementing, then goes back to the iteration state.  Otherwise, the 
                // iteration state just points back to itself like the while loop.
                State postState;
                if (node.Incrementors.Any())
                {
                    postState = new State(this);
                    postState.NextState = iterationState;

                    foreach (var incrementor in node.Incrementors)
                    {
                        postState.Add(Cs.Express(YieldThisFixer.Fix(incrementor)));
                    }
                    Close(postState);
                }
                else
                {
                    postState = iterationState;
                }
                iterationState.NextState = nextState;
                iterationState.BreakState = nextState;

                var forStatement = SyntaxFactory.WhileStatement(node.Condition ?? Cs.True(), SyntaxFactory.Block(CaptureState(node.Statement, postState, nextState)));
                iterationState.Statements.Add(forStatement);

                Close(iterationState);

                currentState = nextState;
            }
        }

        public override void VisitForEachStatement(ForEachStatementSyntax node)
        {
            if (!YieldChecker.HasSpecialStatement(node))
            {
                currentState.Add(YieldThisFixer.Fix(node));
            }
            else
            {
                // Convert the variable declaration in the for loop
                var semanticModel = compilation.GetSemanticModel(node.SyntaxTree);
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, node);
                var targetType = ModelExtensions.GetTypeInfo(semanticModel, node.Expression);

                // Hoist the variable into a field
                node = (ForEachStatementSyntax)HoistVariable(node, node.Identifier, symbol.Type.ToTypeSyntax());

                // Hoist the enumerator into a field
                var enumerator = SyntaxFactory.Identifier(node.Identifier + "$enumerator");
                var genericEnumeratorType = compilation.FindType("System.Collections.Generic.IEnumerable`1");
                var elementType = targetType.ConvertedType.GetGenericArgument(genericEnumeratorType, 0);
                var enumeratorType = elementType == null ?
                    SyntaxFactory.ParseTypeName("System.Collections.IEnumerator") :
                    SyntaxFactory.ParseTypeName("System.Collections.Generic.IEnumerator<" + elementType.ToDisplayString() + ">");
                node = (ForEachStatementSyntax)HoistVariable(node, enumerator, enumeratorType);
                currentState.Add(Cs.Express(SyntaxFactory.IdentifierName(enumerator).Assign(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, YieldThisFixer.Fix(node.Expression), SyntaxFactory.IdentifierName("GetEnumerator"))))));

                // Mostly the same as while loop from here (key word, "mostly"; hence the lack of factoring here)
                MaybeCreateNewState();

                var nextState = GetNextState(node);
                var iterationState = currentState;

                iterationState.NextState = iterationState;
                iterationState.BreakState = nextState;

                var bodyBatch = new State(this, true) { NextState = iterationState.NextState };

                // Assign current item
                bodyBatch.Add(Cs.Express(SyntaxFactory.IdentifierName(node.Identifier).Assign(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, 
                    SyntaxFactory.IdentifierName(enumerator), SyntaxFactory.IdentifierName("Current")))));

                currentState = bodyBatch;
                node.Statement.Accept(this);

                var moveNext = SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(enumerator), SyntaxFactory.IdentifierName("MoveNext")));
                var forStatement = SyntaxFactory.WhileStatement(moveNext, SyntaxFactory.Block(bodyBatch.Statements));
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

                foreach (var section in node.Sections.Select(x => x.WithStatements(SyntaxFactory.List(x.Statements.Select(BreakStatementStripper.StripStatements)))))
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
                ifStatement = ifStatement.WithStatement(SyntaxFactory.Block(CaptureState(node.Statement, ifState.NextState, nextState)));

                if (node.Else != null)
                {
                    ifStatement = ifStatement.WithElse(SyntaxFactory.ElseClause(SyntaxFactory.Block(CaptureState(node.Else, ifState.NextState, nextState))));
                }

                ifState.Statements.Add(ifStatement);

                Close(ifState);
                currentState = nextState;
            }
        }

        public override void VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            currentState.Add(YieldThisFixer.Fix(node));
        }

        public override void VisitThrowStatement(ThrowStatementSyntax node)
        {
            currentState.Add(YieldThisFixer.Fix(node));
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
            currentState.Add(YieldThisFixer.Fix(node)); 
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
