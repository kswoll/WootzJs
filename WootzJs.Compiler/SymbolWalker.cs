using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
    public class SymbolWalker : SymbolVisitor
    {
        public override void VisitAlias(AliasSymbol symbol)
        {
            base.VisitAlias(symbol);
        }

        public override void VisitArrayType(ArrayTypeSymbol symbol)
        {
            base.VisitArrayType(symbol);
        }

        public override void VisitAssembly(AssemblySymbol symbol)
        {
            base.VisitAssembly(symbol);
            symbol.GlobalNamespace.Accept(this);
        }

        public override void VisitDynamicType(DynamicTypeSymbol symbol)
        {
            base.VisitDynamicType(symbol);
        }

        public override void VisitEvent(EventSymbol symbol)
        {
            base.VisitEvent(symbol);
        }

        public override void VisitField(FieldSymbol symbol)
        {
            base.VisitField(symbol);
        }

        public override void VisitLabel(LabelSymbol symbol)
        {
            base.VisitLabel(symbol);
        }

        public override void VisitLocal(LocalSymbol symbol)
        {
            base.VisitLocal(symbol);
        }

        public override void VisitMethod(MethodSymbol symbol)
        {
            base.VisitMethod(symbol);
        }

        public override void VisitModule(ModuleSymbol symbol)
        {
            base.VisitModule(symbol);
        }

        public override void VisitNamedType(NamedTypeSymbol symbol)
        {
            base.VisitNamedType(symbol);
            foreach (var item in symbol.GetMembers())
            {
                item.Accept(this);
            }
            foreach (var item in symbol.GetTypeMembers())
            {
                item.Accept(this);
            }
        }

        public override void VisitNamespace(NamespaceSymbol symbol)
        {
            base.VisitNamespace(symbol);
            foreach (var item in symbol.GetTypeMembers())
            {
                item.Accept(this);
            }
            foreach (var item in symbol.GetNamespaceMembers())
            {
                item.Accept(this);
            }
        }

        public override void VisitParameter(ParameterSymbol symbol)
        {
            base.VisitParameter(symbol);
        }

        public override void VisitPointerType(PointerTypeSymbol symbol)
        {
            base.VisitPointerType(symbol);
        }

        public override void VisitProperty(PropertySymbol symbol)
        {
            base.VisitProperty(symbol);
        }

        public override void VisitRangeVariable(RangeVariableSymbol symbol)
        {
            base.VisitRangeVariable(symbol);
        }

        public override void VisitTypeParameter(TypeParameterSymbol symbol)
        {
            base.VisitTypeParameter(symbol);
        }
    }
}