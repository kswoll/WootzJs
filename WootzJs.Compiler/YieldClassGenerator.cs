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

using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class YieldClassGenerator 
    {
        private Compilation compilation;
        private ClassDeclarationSyntax classDeclarationSyntax;
        private MethodDeclarationSyntax node;
        private MethodSymbol method;
        
        public const string isStarted = "$isStarted";
        public const string state = "$state";

        public YieldClassGenerator(Compilation compilation, ClassDeclarationSyntax classDeclarationSyntax, MethodDeclarationSyntax node)
        {
            this.compilation = compilation;
            this.classDeclarationSyntax = classDeclarationSyntax;
            this.node = node;

            method = compilation.GetSemanticModel(node.SyntaxTree).GetDeclaredSymbol(node);
        }

        public ClassDeclarationSyntax CreateEnumerator()
        {
            var members = new List<MemberDeclarationSyntax>();
            FieldDeclarationSyntax thisField = null;
            if (!method.IsStatic)
            {
                thisField = Cs.Field(method.ContainingType.ToTypeSyntax(), "$this");
                members.Add(thisField);                
            }

            var stateGenerator = new YieldStateGenerator(compilation, node);
            stateGenerator.GenerateStates();
            var states = stateGenerator.States;

            var isStartedField = Cs.Field(Cs.Bool(), isStarted);
            members.Add(isStartedField);

            var stateField = Cs.Field(Cs.Int(), state);
            members.Add(stateField);

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

            var className = "YieldEnumerator$" + method.GetMemberName();

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
                        constructorParameters.Select(x => Cs.Express(Cs.Assign(Cs.This().Member(x.Identifier), Syntax.IdentifierName(x.Identifier))))
                    )
                    .AddStatements(
                        Cs.Express(Cs.Assign(Cs.This().Member(state), Cs.Integer(1)))
                    )
                );
            members.Add(constructor);

            var elementType = ((NamedTypeSymbol)method.ReturnType).TypeArguments[0];
            var ienumerable = Syntax.ParseTypeName("System.Collections.Generic.IEnumerable<" + elementType.ToDisplayString() + ">");
            var ienumerator = Syntax.ParseTypeName("System.Collections.Generic.IEnumerator<" + elementType.ToDisplayString() + ">");

            var getEnumerator = Syntax.MethodDeclaration(ienumerator, "GetEnumerator")
                .AddModifiers(Cs.Public(), Cs.Override())
                .WithBody(Cs.Block(Cs.If(
                    Syntax.IdentifierName(isStarted), 
                    Cs.Return(Cs.This().Member("Clone").Invoke().Member("GetEnumerator").Invoke()), 
                    Cs.Return(Cs.This()))));
            members.Add(getEnumerator);

            // Generate the MoveNext method, which looks something like:
            // while (true)
            // {
            //     switch (state) 
            //     {
            //         case 0: ...
            //         case 1: ...
            //     }
            // }
            
            var moveNextBody = Cs.Block(
                Cs.Express(Syntax.IdentifierName(isStarted).Assign(Cs.True())),
                Syntax.LabeledStatement("$top", Cs.While(Cs.True(), 
                    Cs.Switch(Cs.This().Member(state), states.Select((x, i) => 
                        Cs.Section(Cs.Integer(i), x.Statements.ToArray())).ToArray()))));
            var moveNext = Syntax.MethodDeclaration(Cs.Bool(), "MoveNext")
                .AddModifiers(Cs.Public(), Cs.Override())
                .WithBody(Syntax.Block(moveNextBody));
            members.Add(moveNext);

            TypeSyntax classNameWithTypeArguments = Syntax.IdentifierName(className);
            if (method.TypeParameters.Any())
            {
                classNameWithTypeArguments = Syntax.GenericName(
                    Syntax.Identifier(className), 
                    Syntax.TypeArgumentList(Syntax.SeparatedList(
                        method.TypeParameters.Select(x => Syntax.ParseTypeName(x.Name)),
                        method.TypeParameters.Select(x => x).Skip(1).Select(_ => Syntax.Token(SyntaxKind.CommaToken)))
                    ));
            }

            var cloneBody = Cs.Block(
                Cs.Return(classNameWithTypeArguments.New(
                    constructorParameters.Select(x => Syntax.IdentifierName(x.Identifier)).ToArray()
                ))
            );
            var clone = Syntax.MethodDeclaration(ienumerable, "Clone")
                .AddModifiers(Cs.Public())
                .WithBody(Syntax.Block(cloneBody));
            members.Add(clone);

            var baseTypes = new[] { Syntax.ParseTypeName("System.YieldIterator<" + elementType.ToDisplayString() + ">") };
            var result = Syntax.ClassDeclaration(className).WithBaseList(baseTypes).WithMembers(members.ToArray());

            if (method.TypeParameters.Any())
            {
                result = result.WithTypeParameterList(node.TypeParameterList);
            }

            return result;
        }
    }
}
