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
using System.Collections.Generic;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class AnonymousTypeTransformer : SyntaxWalker
    {
        private JsBlockStatement body;
        private List<Tuple<NamedTypeSymbol, Action>> actions;
        private HashSet<NamedTypeSymbol> processedTypes = new HashSet<NamedTypeSymbol>();
        private Idioms idioms;

        public AnonymousTypeTransformer(JsBlockStatement body, List<Tuple<NamedTypeSymbol, Action>> actions) 
        {
            this.body = body;
            this.actions = actions;
            this.idioms = new Idioms(null);
        }

        public override void VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            var jsBlock = new JsBlockStatement();

            var model = Context.Instance.Compilation.GetSemanticModel(node.SyntaxTree);
            var classType = model.GetDeclaredSymbol(node);
            if (processedTypes.Contains(classType))
                return;
            processedTypes.Add(classType);

            JsBlockStatement typeInitializer;
            JsBlockStatement staticInitializer;
            jsBlock.Aggregate(idioms.CreateTypeFunction(classType, out typeInitializer, out staticInitializer));
            
            // Create default constructor
            var constructorBlock = new JsBlockStatement();
            constructorBlock.Express(idioms.InvokeMethodAsThis(classType.BaseType.InstanceConstructors.Single(x => x.Parameters.Count == 0)));
            var constructor = classType.InstanceConstructors.Single();
            typeInitializer.Add(idioms.StoreInPrototype(constructor.GetMemberName(), Js.Function().Body(constructorBlock)));
            typeInitializer.Aggregate(idioms.InitializeConstructor(classType, constructor.GetMemberName(), new ParameterSymbol[0]));
            
            foreach (var property in classType.GetMembers().OfType<PropertySymbol>())
            {
                typeInitializer.Aggregate(CreateProperty(property));
            }

            Action action = () =>
            {
                body.Aggregate(jsBlock);
            };
            actions.Add(Tuple.Create(classType, action));
        }

        private JsBlockStatement CreateProperty(PropertySymbol property)
        {
            var block = new JsBlockStatement();
            var propertyName = property.GetMemberName();

            var backingField = property.GetBackingFieldName();
            var valueParameter = Js.Parameter("value");

            block.Add(idioms.StoreInPrototype(backingField, Js.Null()));
            if (property.GetMethod != null)
                block.Add(idioms.StoreInPrototype(property.GetMethod.GetMemberName(), Js.Function().Body(Js.Return(Js.This().Member(backingField)))));
            if (property.SetMethod != null)
                block.Add(idioms.StoreInPrototype(property.SetMethod.GetMemberName() + propertyName, Js.Function(valueParameter).Body(
                    Js.Assign(Js.This().Member(backingField), valueParameter.GetReference()))));

            return block;
        }
    }
}
