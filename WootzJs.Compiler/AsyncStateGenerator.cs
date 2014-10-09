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
        private Dictionary<HostedVariableKey, TypeSyntax> hoistedVariables = new Dictionary<HostedVariableKey, TypeSyntax>();
            private static Dictionary<ISymbol, string> globalRenames = new Dictionary<ISymbol, string>();
//        private Dictionary<ISymbol, TypeSyntax> globalHoistedVariables = new Dictionary<ISymbol, TypeSyntax>();
        private Stack<AsyncState> breakStates = new Stack<AsyncState>();
        private Stack<AsyncState> continueStates = new Stack<AsyncState>();
        private List<HoistedVariableScope> hoistedVariableScopes = new List<HoistedVariableScope>();
        private List<MethodDeclarationSyntax> additionalHostMethods = new List<MethodDeclarationSyntax>();
        private IMethodSymbol method;
        private List<Tuple<string, ITypeSymbol>> parameterList;

        public AsyncStateGenerator(Compilation compilation, CSharpSyntaxNode node, IMethodSymbol method, List<Tuple<string, ITypeSymbol>> parameterList) : base(compilation, node)
        {
            this.method = method;
            this.parameterList = parameterList;
            decomposer = new AsyncExpressionDecomposer(this);
            hoistedVariableScopes.Add(new HoistedVariableScope());
        }

        public IEnumerable<MethodDeclarationSyntax> AdditionalHostMethods
        {
            get { return additionalHostMethods; }
        }

        private string GetIdentifier(HostedVariableKey id)
        {
            for (var i = hoistedVariableScopes.Count - 1; i >= 0; i--)
            {
                var scope = hoistedVariableScopes[i];
                var newIdentifier = scope.GetIdentifier(id);
                if (newIdentifier != null)
                    return newIdentifier;
            }
            return id.Identifier;
        }

        private static string GetGlobalIdentifier(ISymbol id)
        {
            string @new;
            if (globalRenames.TryGetValue(id, out @new))
            {
                return @new;
            }
            return id.Name;
        }

        private string GenerateNewName(HostedVariableKey symbol)
        {
            var counter = 2;
            do
            {
                var currentName = symbol.Identifier + counter++;
                if (!hoistedVariables.ContainsKey(new HostedVariableKey(SyntaxFactory.Identifier(currentName))))
                {
                    return currentName;
                }
            }
            while (true);
        }

        protected SyntaxToken HoistVariable(HostedVariableKey symbol, TypeSyntax type)
        {
            SyntaxToken identifier = SyntaxFactory.Identifier(symbol.Identifier);
            if (hoistedVariables.ContainsKey(symbol) || hoistedVariables.ContainsKey(new HostedVariableKey(symbol.Identifier)))
            {
                var newName = GenerateNewName(symbol);
                var newIdentifier = SyntaxFactory.Identifier(newName);
                hoistedVariableScopes.Last().DeclareRename(symbol, newIdentifier.ToString());
                identifier = newIdentifier;
                symbol = new HostedVariableKey(identifier, symbol.Symbol);
            }
            hoistedVariables[symbol] = type;
//            if (symbol.Symbol != null)
//                globalHoistedVariables[symbol.Symbol] = type;
//            hoistedVariables[new HostedVariableKey(identifier)] = type;
            return identifier;
        }

        public Tuple<SyntaxToken, TypeSyntax>[] HoistedVariables
        {
            get { return hoistedVariables.Select(x => Tuple.Create(SyntaxFactory.Identifier(x.Key.Identifier), x.Value)).ToArray(); }
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
                // Hoist the variable into a field
                var symbol = (ILocalSymbol)ModelExtensions.GetDeclaredSymbol(semanticModel, variable);
                var identifier = HoistVariable(new HostedVariableKey(variable.Identifier, symbol), symbol.Type.ToTypeSyntax());

                if (variable.Initializer != null)
                {
                    var assignment = SyntaxFactory.IdentifierName(identifier.ToString()).Assign((ExpressionSyntax)variable.Initializer.Value.Accept(decomposer));
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

            if (!(CurrentState.Statements.LastOrDefault() is ReturnStatementSyntax) && (method.ReturnsVoid || method.ReturnType.Equals(Context.Instance.Task)))
            {
                SetResult();
//                var returnType = method.ReturnType.GetGenericArgument(Context.Instance.TaskT, 0);
            }
        }

        public override void VisitBlock(BlockSyntax node)
        {
            var scope = new HoistedVariableScope();
            hoistedVariableScopes.Add(scope);
            foreach (var statement in node.Statements)
            {
                AcceptStatement(statement);
            }
            hoistedVariableScopes.Remove(scope);
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
                HoistVariable(new HostedVariableKey(variable.Identifier, symbol), symbol.Type.ToTypeSyntax());
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
            HoistVariable(new HostedVariableKey(node.Identifier, symbol), symbol.Type.ToTypeSyntax());

            // Hoist the enumerator into a field
            var targetType = ModelExtensions.GetTypeInfo(semanticModel, node.Expression);
            var enumerator = SyntaxFactory.Identifier(node.Identifier + "$enumerator");
            var genericEnumeratorType = compilation.FindType("System.Collections.Generic.IEnumerable`1");
            var elementType = targetType.ConvertedType.GetGenericArgument(genericEnumeratorType, 0);
            var enumeratorType = elementType == null ?
                SyntaxFactory.ParseTypeName("System.Collections.IEnumerator") :
                SyntaxFactory.ParseTypeName("System.Collections.Generic.IEnumerator<" + elementType.ToDisplayString() + ">");
            HoistVariable(new HostedVariableKey(enumerator), enumeratorType);
            CurrentState.Add(SyntaxFactory.IdentifierName(enumerator).Assign(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, node.Expression, SyntaxFactory.IdentifierName("GetEnumerator")))).Express());

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
            var exception = node.Expression;
            
            // For naked "throw" statements, we need to find the exception object
            if (exception == null)
            {
                var catchClause = node.FirstAncestorOrSelf<CatchClauseSyntax>();
                exception = SyntaxFactory.IdentifierName(catchClause.Declaration.Identifier);
            }
            CurrentState.Add(Cs.Throw((ExpressionSyntax)exception.Accept(decomposer)));
        }

        public override void VisitTryStatement(TryStatementSyntax node)
        {
            var afterTry = GetNextState();
            var newTryStatement = Cs.Try();

            var tryState = NewSubstate();
            GotoState(tryState);

            // Keep track of exception, if any, so we can rethrow
            var exceptionIdentifier = HoistVariable(new HostedVariableKey(SyntaxFactory.Identifier("$usingex")), Context.Instance.Exception.ToTypeSyntax());
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
                        newIdentifier = HoistVariable(new HostedVariableKey(catchClause.Declaration.Identifier, symbol), symbol.Type.ToTypeSyntax());
                    else
                        newIdentifier = SyntaxFactory.Identifier(GenerateNewName(new HostedVariableKey(SyntaxFactory.Identifier("ex"))));

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
                SyntaxToken caughtExceptionIdentifier = SyntaxFactory.Identifier(GenerateNewName(new HostedVariableKey(SyntaxFactory.Identifier("$caughtex"))));
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
                    SyntaxFactory.List(x.Labels.Select(y => y.Value != null ? SyntaxFactory.SwitchLabel(SyntaxKind.CaseSwitchLabel, (ExpressionSyntax)y.Value.Accept(decomposer)) : SyntaxFactory.SwitchLabel(SyntaxKind.DefaultSwitchLabel))),
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
            var exceptionIdentifier = HoistVariable(new HostedVariableKey(SyntaxFactory.Identifier("$usingex")), Context.Instance.Exception.ToTypeSyntax());
            CurrentState.Add(SyntaxFactory.IdentifierName(exceptionIdentifier).Assign(Cs.Null()).Express());

            // Identifier for caught exception
            var caughtExceptionIdentifier = SyntaxFactory.Identifier(GenerateNewName(new HostedVariableKey(SyntaxFactory.Identifier("$caughtex"))));

            // Hoist the variable into a field
            var disposables = new List<IdentifierNameSyntax>();
            if (node.Declaration != null) 
            {
                foreach (var variable in node.Declaration.Variables)
                {
                    var symbol = (ILocalSymbol)semanticModel.GetDeclaredSymbol(variable);
                    HoistVariable(new HostedVariableKey(variable.Identifier, symbol), symbol.Type.ToTypeSyntax());
                    var name = SyntaxFactory.IdentifierName(variable.Identifier);
                    disposables.Add(name);
                    CurrentState.Add(name.Assign((ExpressionSyntax)variable.Initializer.Value.Accept(decomposer)).Express());
                }
            }
            if (node.Expression != null)
            {
                var identifier = SyntaxFactory.IdentifierName(GenerateNewName(new HostedVariableKey(SyntaxFactory.Identifier("$using"))));
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

            public override SyntaxNode VisitThisExpression(ThisExpressionSyntax node)
            {
                return SyntaxFactory.IdentifierName("$this");
            }

            public override SyntaxNode VisitGenericName(GenericNameSyntax node)
            {
                var symbol = stateGenerator.semanticModel.SyntaxTree.Equals(node.SyntaxTree) ? stateGenerator.semanticModel.GetSymbolInfo(node).Symbol : null;
                if (new[] { SymbolKind.Field, SymbolKind.Event, SymbolKind.Method, SymbolKind.Property }.Contains(symbol.Kind) && !symbol.IsStatic)
                {
                    return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("$this"), node);
                }
                else
                {
                    return base.VisitGenericName(node);
                }
            }

            public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
            {
                var symbol = stateGenerator.semanticModel.SyntaxTree.Equals(node.SyntaxTree) ? stateGenerator.semanticModel.GetSymbolInfo(node).Symbol : null;
                if (!(node.Parent is MemberAccessExpressionSyntax) && (symbol != null && new[] { SymbolKind.Field, SymbolKind.Event, SymbolKind.Method, SymbolKind.Property }.Contains(symbol.Kind) && !symbol.IsStatic) || node.Identifier.ToString().StartsWith("Base$"))
                {
                    var id = stateGenerator.GetIdentifier(new HostedVariableKey(node.Identifier, symbol));
                    return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("$this"), Cs.IdentifierName(id));
                }
                else
                {
                    var id = stateGenerator.GetIdentifier(new HostedVariableKey(node.Identifier, symbol));
                    return base.VisitIdentifierName(Cs.IdentifierName(id));                    
                }
            }

/*
        public override SyntaxNode VisitGenericName(GenericNameSyntax node)
        {
            if (!(node.Parent is MemberAccessExpressionSyntax) || ((MemberAccessExpressionSyntax)node.Parent).Expression == node)
            {
                if (node.GetContainingMethod() == null)
                {
                    return base.VisitGenericName(node);
                }

                var containingType = node.GetContainingType();
                if (containingType == null || !containingType.Name.StartsWith(enclosingTypeName))
                    return node;

                var symbol = semanticModel.GetSymbolInfo(node).Symbol;
                if (symbol == null || (new[] { SymbolKind.Field, SymbolKind.Event, SymbolKind.Method, SymbolKind.Property }.Contains(symbol.Kind) && !symbol.ContainingType.Name.StartsWith(enclosingTypeName) && !symbol.IsStatic))
                {
                    return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("$this"), node);
                }
            }
            return base.VisitGenericName(node);
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (!(node.Parent is MemberAccessExpressionSyntax) || ((MemberAccessExpressionSyntax)node.Parent).Expression == node)
            {
                if (node.GetContainingMethod() == null)
                {
                    return base.VisitIdentifierName(node);
                }

                var containingType = node.GetContainingType();
                if (containingType == null || !containingType.Name.StartsWith(enclosingTypeName))
                    return node;

                var symbol = semanticModel.GetSymbolInfo(node).Symbol;
                var isObjectInitializer = node.Parent != null && node.Parent.Parent is InitializerExpressionSyntax;
                if (!isObjectInitializer)
                {
                    if (symbol == null || (new[] { SymbolKind.Field, SymbolKind.Event, SymbolKind.Method, SymbolKind.Property }.Contains(symbol.Kind) && !symbol.ContainingType.Name.StartsWith(enclosingTypeName) && !symbol.IsStatic))
                    {
                        return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("$this"), node);
                    }
                }
            }
            return base.VisitIdentifierName(node);
        }
*/


            public override SyntaxNode VisitBinaryExpression(BinaryExpressionSyntax node)
            {
                if (node.CSharpKind() == SyntaxKind.SimpleAssignmentExpression)
                {
                    var left = (IdentifierNameSyntax)node.Left;
                    if (left.SyntaxTree.Equals(stateGenerator.semanticModel.SyntaxTree))
                    {
                        var leftSymbolInfo = stateGenerator.semanticModel.GetSymbolInfo(node.Left);
                        var rightTypeInfo = stateGenerator.semanticModel.GetTypeInfo(node.Right);
                        var parameter = stateGenerator.parameterList.SingleOrDefault(x => x.Item1 == left.Identifier.ToString());
                        if (parameter != null)
                        {
                            var parameterType = parameter.Item2;
                            if (parameterType is INamedTypeSymbol)
                            {
                                var namedParameterType = (INamedTypeSymbol)parameterType;
                                if (namedParameterType.IsGenericType && namedParameterType.OriginalDefinition == Context.Instance.ActionT)
                                {
                                    return left.Invoke(node.Right);
                                }
                            }
                        }                        
                    }
                }

                return base.VisitBinaryExpression(node);
            }

            public override SyntaxNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
            {
                return base.VisitMemberAccessExpression(node);
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
                        awaiterIdentifier = stateGenerator.HoistVariable(new HostedVariableKey(awaiterIdentifier), awaiterType.ToTypeSyntax());
                        var awaiter = SyntaxFactory.IdentifierName(awaiterIdentifier);
                        stateGenerator.CurrentState.Add(awaiter.Assign(operand.Member("GetAwaiter").Invoke()).Express());

                        var nextState = stateGenerator.InsertState();

                        ExpressionSyntax result = null;
                        if (!returnsVoid)
                        {
                            // If the await returns a value, store it in a field
                            var resultIdentifier = SyntaxFactory.Identifier("$result");
                            resultIdentifier = stateGenerator.HoistVariable(new HostedVariableKey(resultIdentifier), expressionInfo.GetResultMethod.ReturnType.ToTypeSyntax());
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

                        return node.WithExpression((ExpressionSyntax)Cs.IdentifierName(baseMethodName).Accept(stateGenerator.decomposer));
                    }
                }            

                return base.VisitInvocationExpression(node);
            }
        }

        class HoistedVariableScope
        {
            private Dictionary<HostedVariableKey, string> renames = new Dictionary<HostedVariableKey, string>();

            public void DeclareRename(HostedVariableKey old, string @new)
            {
                renames[old] = @new;
                renames[new HostedVariableKey(old.Identifier)] = @new;
                if (old.Symbol != null)
                    globalRenames[old.Symbol] = @new;
            }

            public string GetIdentifier(HostedVariableKey id)
            {
                string @new;
                if (renames.TryGetValue(id, out @new))
                {
                    return @new;
                }
                return null;
            }
        }

        protected struct HostedVariableKey
        {
            private readonly string identifier;
            private readonly ISymbol symbol;

            public HostedVariableKey(SyntaxToken identifier, ISymbol symbol)
            {
                this.identifier = identifier.ToString();
                this.symbol = symbol;
            }

            public HostedVariableKey(string identifier, ISymbol symbol)
            {
                this.identifier = identifier;
                this.symbol = symbol;
            }

            public HostedVariableKey(SyntaxToken identifier) : this()
            {
                this.identifier = identifier.ToString();
            }

            public HostedVariableKey(string identifier) : this()
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

            public bool Equals(HostedVariableKey other)
            {
                return string.Equals(identifier, other.identifier) && (Equals(symbol, other.symbol) || symbol == null || other.symbol == null);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is HostedVariableKey && Equals((HostedVariableKey) obj);
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