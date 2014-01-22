using System.Collections.Generic;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class AnonymousTypeTransformer : SyntaxWalker
    {
        private Context context;
        private JsBlockStatement body;
        private HashSet<NamedTypeSymbol> processedTypes = new HashSet<NamedTypeSymbol>();
        private Idioms idioms;

        public AnonymousTypeTransformer(Context context, JsBlockStatement body) 
        {
            this.context = context;
            this.body = body;
            this.idioms = new Idioms(context, null);
        }

        public override void VisitAnonymousObjectCreationExpression(AnonymousObjectCreationExpressionSyntax node)
        {
            var jsBlock = new JsBlockStatement();

            var model = context.Compilation.GetSemanticModel(node.SyntaxTree);
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

            body.Aggregate(jsBlock);
        }

        private JsBlockStatement CreateProperty(PropertySymbol property)
        {
            var block = new JsBlockStatement();
            var propertyName = property.GetMemberName();

            var backingField = property.GetBackingFieldName();
            var valueParameter = Js.Parameter("value");

            block.Add(idioms.StoreInPrototype(backingField, Js.Null()));
            block.Add(idioms.StoreInPrototype("get_" + propertyName, Js.Function().Body(Js.Return(Js.This().Member(backingField)))));
            block.Add(idioms.StoreInPrototype("set_" + propertyName, Js.Function(valueParameter).Body(
                Js.Assign(Js.This().Member(backingField), valueParameter.GetReference()))));

            return block;
        }
    }
}
