using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class AsyncStateGenerator : BaseStateGenerator
    {
        public const string builder = "$builder";

        public AsyncStateGenerator(Idioms idioms, JsBlockStatement stateMachineBody, CSharpSyntaxNode node, IMethodSymbol method, Action<BaseStateGenerator, JsTransformer> nodeAcceptor = null) : 
            base(x => new AsyncExpressionDecomposer((AsyncStateGenerator)x, idioms), node, stateMachineBody, idioms, method, nodeAcceptor)
        {
        }

        public override void VisitReturnStatement(ReturnStatementSyntax node)
        {
            SetResult(node.Expression);
            CurrentState = GetNextState();             // @Todo: make this currentState = currentState.Next
        }

        public void SetResult(ExpressionSyntax result = null)
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

            if (!(CurrentState.Statements.LastOrDefault() is JsReturnStatement) && (Method.ReturnsVoid || Method.ReturnType.Equals(Context.Instance.Task)))
            {
                SetResult();
            }
        }

        class AsyncExpressionDecomposer : JsTransformer
        {
            private BaseStateGenerator stateGenerator;

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