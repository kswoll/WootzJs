using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class AsyncClassGenerator
    {
        private Compilation compilation;
        private MethodDeclarationSyntax node;
        private MethodSymbol method;
        
        public const string state = "$state";
        public const string builder = "$builder";

        public AsyncClassGenerator(Compilation compilation, MethodDeclarationSyntax node)
        {
            this.compilation = compilation;
            this.node = node;

            method = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
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
                constructorParameters.Add(Syntax.Parameter(Syntax.Identifier("$this")).WithType(thisField.Declaration.Type));
            }
            constructorParameters.AddRange(node.ParameterList.Parameters.Select(x => Syntax.Parameter(x.Identifier).WithType(x.Type)));                

            var constructor = Syntax.ConstructorDeclaration(className)
                .AddModifiers(Cs.Public())
                .WithParameterList(constructorParameters.ToArray())
                .WithBody(
                    Syntax.Block(
                        // Assign fields
                        constructorParameters.Select(x => Cs.Express(Cs.This().Member(x.Identifier).Assign(Syntax.IdentifierName(x.Identifier))))
                    )
                    .AddStatements(
                        Cs.Express(Cs.This().Member(state).Assign(Cs.Integer(-1))),
                        Cs.Express(Cs.This().Member(builder).Assign(builderField.Declaration.Type.New())),
                        Cs.Express(Cs.This().Member(builder).Member("Start").Invoke(Cs.This()))
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
            var moveNextBody = Syntax.LabeledStatement("$top", Cs.While(Cs.True(), 
                Cs.Switch(Cs.This().Member(state), states.Select((x, i) => 
                    Cs.Section(Cs.Integer(i), x.Statements.ToArray())).ToArray())));
            var moveNext = Syntax.MethodDeclaration(Cs.Bool(), "MoveNext")
                .AddModifiers(Cs.Public())
                .WithBody(Syntax.Block(moveNextBody));
            members.Add(moveNext);

            var asyncStateMachine = Syntax.ParseTypeName("System.Runtime.CompilerServices.IAsyncStateMachine");
            var baseTypes = new[] { asyncStateMachine };
            var result = Syntax.ClassDeclaration(className).WithBaseList(baseTypes).WithMembers(members.ToArray());

            if (method.TypeParameters.Any())
            {
                result = result.WithTypeParameterList(node.TypeParameterList);
            }

            return result;
        }
         
    }
}