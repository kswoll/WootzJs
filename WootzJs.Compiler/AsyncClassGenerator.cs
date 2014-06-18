using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WootzJs.Compiler
{
    public class AsyncClassGenerator
    {
        private Compilation compilation;
        private MethodDeclarationSyntax node;
        private IMethodSymbol method;
        
        public const string state = "$state";
        public const string builder = "$builder";

        public AsyncClassGenerator(Compilation compilation, MethodDeclarationSyntax node)
        {
            this.compilation = compilation;
            this.node = node;

            method = (IMethodSymbol)ModelExtensions.GetDeclaredSymbol(compilation.GetSemanticModel(node.SyntaxTree), node);
        }

        public ClassDeclarationSyntax CreateStateMachine()
        {
            var members = new List<MemberDeclarationSyntax>();
            FieldDeclarationSyntax thisField = null;
            if (!method.IsStatic)
            {
                thisField = Cs.Field(method.ContainingType.ToTypeSyntax(), "$this");
                members.Add(thisField);                
            }

            var stateGenerator = new AsyncStateGenerator(compilation, node);
            stateGenerator.GenerateStates();
            var states = stateGenerator.States;

            var stateField = Cs.Field(Cs.Int(), state);
            members.Add(stateField);

            var builderField = Cs.Field(Context.Instance.AsyncVoidMethodBuilder.ToTypeSyntax(), builder);
            members.Add(builderField);

            foreach (var parameter in node.ParameterList.Parameters)
            {
                var parameterField = Cs.Field(parameter.Type, parameter.Identifier);
                members.Add(parameterField);
            }
            foreach (var variable in stateGenerator.HoistedVariables)
            {
                var variableField = Cs.Field(variable.Item2, variable.Item1);
                members.Add(variableField);
            }

            var className = "Async$" + method.GetMemberName();

            var constructorParameters = new List<ParameterSyntax>();
            if (!method.IsStatic)
            {
                constructorParameters.Add(SyntaxFactory.Parameter(SyntaxFactory.Identifier("$this")).WithType(thisField.Declaration.Type));
            }
            constructorParameters.AddRange(node.ParameterList.Parameters.Select(x => SyntaxFactory.Parameter(x.Identifier).WithType(x.Type)));                

            var asyncStateMachine = SyntaxFactory.ParseTypeName("System.Runtime.CompilerServices.IAsyncStateMachine");

            IMethodSymbol asyncMethodBuilderCreate;
            IMethodSymbol asyncMethodBuilderStart;

            if (method.ReturnsVoid)
            {
                asyncMethodBuilderCreate = Context.Instance.AsyncVoidMethodBuilderCreate;
                asyncMethodBuilderStart = Context.Instance.AsyncVoidMethodBuilderStart;
            }
            else if (method.ReturnType.Equals(Context.Instance.Task))
            {
                asyncMethodBuilderCreate = Context.Instance.AsyncTaskMethodBuilderCreate;
                asyncMethodBuilderStart = Context.Instance.AsyncTaskMethodBuilderStart;
            }
            else if (method.ReturnType.Equals(Context.Instance.TaskT))
            {
                asyncMethodBuilderCreate = Context.Instance.AsyncTaskTMethodBuilderCreate;
                asyncMethodBuilderStart = Context.Instance.AsyncTaskTMethodBuilderStart;
            }
            else
            {
                throw new Exception();
            }

            var constructor = SyntaxFactory.ConstructorDeclaration(className)
                .AddModifiers(Cs.Public())
                .WithParameterList(constructorParameters.ToArray())
                .WithBody(
                    SyntaxFactory.Block(
                        // Assign fields
                        constructorParameters.Select(x => Cs.Express(Cs.This().Member(x.Identifier).Assign(SyntaxFactory.IdentifierName(x.Identifier))))
                    )
                    .AddStatements(
                        Cs.Express(Cs.This().Member(state).Assign(Cs.Integer(1))),
                        Cs.Express(Cs.This().Member(builder).Assign(asyncMethodBuilderCreate.Invoke())),
                        Cs.Local(asyncStateMachine, "$self", Cs.This()),
                        Cs.Express(Cs.This().Member(builder).Member("Start").Invoke(SyntaxFactory.Argument(Cs.IdentifierName("$self")).WithRefOrOutKeyword(Cs.Ref())))
                    )
                );
            members.Add(constructor);

            // Generate the MoveNext method, which looks something like:
            // $top:
            // while (true)
            // {
            //     switch (state) 
            //     {
            //         case 0: ...
            //         case 1: ...
            //     }
            // }
            var moveNext = SyntaxFactory.MethodDeclaration(Cs.Void(), "MoveNext")
                .AddModifiers(Cs.Public())
                .WithBody(SyntaxFactory.Block(
                    Cs.Try()
                        .WithBlock(Cs.Block(
                            Cs.Switch(Cs.This().Member(StateGenerator.state), states.Select((x, i) => 
                                Cs.Section(Cs.Integer(i), x.Statements.ToArray())).ToArray())
                        ))
                        .WithCatch(Context.Instance.Exception.ToTypeSyntax(), "ex")
                ));
            members.Add(moveNext);

            // Generate the SetStateMachine(IAsyncStateMachine) method.  This will *never* be invoked.
            var setStateMachine = SyntaxFactory.MethodDeclaration(Cs.Void(), "SetStateMachine")
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithParameterList(
                    SyntaxFactory.Parameter(SyntaxFactory.Identifier("stateMachine")).WithType(asyncStateMachine)
                )
                .WithBody(SyntaxFactory.Block());
            members.Add(setStateMachine);

            var baseTypes = new[] { asyncStateMachine };
            var result = SyntaxFactory.ClassDeclaration(className).WithBaseList(baseTypes).WithMembers(members.ToArray());

            if (method.TypeParameters.Any())
            {
                result = result.WithTypeParameterList(node.TypeParameterList);
            }

            return result;
        }
         
    }
}