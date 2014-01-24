using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace WootzJs.Compiler
{
/*
    public class LoopTransformer2 : SyntaxRewriter
    {
        public const string EscapeTypeField = "type";
        public const string EscapeValueField = "value";
        public const string EscapeLabelField = "label";
        public const string EscapeDepthField = "depth";
        public const int Return = 1;
        public const int Continue = 2;
        public const int Break = 3;

        private Idioms idioms;
        private int loopDepth;
        private StatementSyntax loop;
        private List<EscapeStatement> escapeStatements = new List<EscapeStatement>();
        private CsJsni jsni;

        public LoopTransformer2(Idioms idioms, int loopDepth)
        {
            this.idioms = idioms;
            this.loopDepth = loopDepth;
            jsni = new CsJsni(idioms.context);
        }

        public StatementSyntax TransformLoop(StatementSyntax loop)
        {
            var result = (StatementSyntax)loop.Accept(this);
            return result;
        }

        private StatementSyntax TransformBody(StatementSyntax body)
        {
            var block = body is BlockSyntax ? (BlockSyntax)body : Cs.Block(body);

            if (!escapeStatements.Any())
            {
                return Cs.Express(block.Wrap());
            }
            else
            {
                if (!(block.Statements.Last() is ReturnStatementSyntax))
                    block = block.AddStatements(Cs.Return(jsni.Object(Cs.Anonymous(
                        new Tuple<string, ExpressionSyntax>(EscapeTypeField, Cs.Integer(0))
                    ))));
                var wrapped = block.Wrap();
                var outerBlock = Cs.Block();
                VariableDeclaratorSyntax loopResult;
                outerBlock = outerBlock.Local("$loopResult", wrapped, out loopResult);
                if (escapeStatements.Any(x => x.Type == Return))
                {
                    outerBlock = outerBlock.If(loopResult.Reference().Member(EscapeTypeField))
                    outerBlock.If(loopResult.GetReference().Member(EscapeTypeField).EqualTo(Js.Primitive(Return)), 
                        Js.Return(loopResult.GetReference().Member(EscapeValueField)));
                }
                if (escapeStatements.Any(x => x.Type == Continue))
                {
                    var escapes = escapeStatements.Where(x => x.Type == Continue).Distinct();
                    JsStatement ifTrue;
                    if (!escapes.Any(x => x.Label != null))
                    {
                        ifTrue = Js.Continue();
                    }
                    else
                    {
                        ifTrue = Js.Switch(loopResult.GetReference().Member(EscapeLabelField), 
                            escapes.Select(x => Js.Section(Js.Primitive(x.Label)).Statements(
                                Js.If(loopResult.GetReference().Member(EscapeDepthField).EqualTo(Js.Primitive(loopDepth)), 
                                    Js.Continue(x.Label),
                                    Js.Return(loopResult.GetReference()))
                            )).ToArray());
                    }
                    outerBlock.If(loopResult.GetReference().Member(EscapeTypeField).EqualTo(Js.Primitive(Continue)), 
                        ifTrue);
                }
                if (escapeStatements.Any(x => x.Type == Break))
                {
                    var escapes = escapeStatements.Where(x => x.Type == Break).Distinct();
                    JsStatement ifTrue;
                    if (!escapes.Any(x => x.Label != null))
                    {
                        ifTrue = Js.Break();
                    }
                    else
                    {
                        ifTrue = Js.Switch(loopResult.GetReference().Member(EscapeLabelField), 
                            escapes.Select(x => Js.Section(Js.Primitive(x.Label)).Statement(Js.Break(x.Label))).ToArray());
                    }
                    outerBlock.If(loopResult.GetReference().Member(EscapeTypeField).EqualTo(Js.Primitive(Break)), 
                        ifTrue);
                }
                return outerBlock;
            }
        }

        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
        {
            if (loop != null)
                return node;
            loop = node;

            node = node.WithStatement(TransformBody((StatementSyntax)node.Statement.Accept(this)));
            return node;
        }

        public override SyntaxNode VisitForStatement(ForStatementSyntax node)
        {
            if (loop != null)
                return node;
            loop = node;

            node = node.WithStatement(TransformBody((StatementSyntax)node.Statement.Accept(this)));
            return node;
        }

        public override SyntaxNode VisitDoStatement(DoStatementSyntax node)
        {
            if (loop != null)
                return node;
            loop = node;

            node = node.WithStatement(TransformBody((StatementSyntax)node.Statement.Accept(this)));
            return node;
        }

        public override SyntaxNode VisitWhileStatement(WhileStatementSyntax node)
        {
            if (loop != null)
                return node;
            loop = node;

            node = node.WithStatement(TransformBody((StatementSyntax)node.Statement.Accept(this)));
            return node;
        }

        public override SyntaxNode VisitGotoStatement(GotoStatementSyntax node)
        {
/*
            var isContinueGoto = node.Expression

            escapeStatements.Add(new EscapeStatement { Type = Continue, Label = node.Label });
            return Js.Return(Js.Object(
                Js.Item(EscapeTypeField, Js.Primitive(Continue)),
                Js.Item(EscapeLabelField, node.Label != null ? Js.Primitive(node.Label) : Js.Null()),
                Js.Item(EscapeDepthField, Js.Primitive(loopDepth))
            ).Compact());
            return Cs.Return(jsni.Object(Cs.Anonymous(
                Tuple.Create<string, ExpressionSyntax>(EscapeTypeField, Cs.Integer(Continue)),
                Tuple.Create<string, ExpressionSyntax>(EscapeValueField, Cs.Null()),
                Tuple.Create<string, ExpressionSyntax>(EscapeDepthField, Cs.Integer(loopDepth))
            ), true));
#1#
            return node;
        }

        public override SyntaxNode VisitContinueStatement(ContinueStatementSyntax node)
        {
            escapeStatements.Add(new EscapeStatement { Type = Continue });
            return Cs.Return(jsni.Object(Cs.Anonymous(
                Tuple.Create<string, ExpressionSyntax>(EscapeTypeField, Cs.Integer(Continue)),
                Tuple.Create<string, ExpressionSyntax>(EscapeValueField, Cs.Null()),
                Tuple.Create<string, ExpressionSyntax>(EscapeDepthField, Cs.Integer(loopDepth))
            ), true));
        }

        public override SyntaxNode VisitBreakStatement(BreakStatementSyntax node)
        {
            escapeStatements.Add(new EscapeStatement { Type = Break });
            return Cs.Return(jsni.Object(Cs.Anonymous(
                Tuple.Create<string, ExpressionSyntax>(EscapeTypeField, Cs.Integer(Break)),
                Tuple.Create<string, ExpressionSyntax>(EscapeValueField, Cs.Null()),
                Tuple.Create<string, ExpressionSyntax>(EscapeDepthField, Cs.Integer(loopDepth))
            ), true));
        }

        public override SyntaxNode VisitReturnStatement(ReturnStatementSyntax node)
        {
            escapeStatements.Add(new EscapeStatement { Type = Return });
            return Cs.Return(jsni.Object(Cs.Anonymous(
                Tuple.Create<string, ExpressionSyntax>(EscapeTypeField, Cs.Integer(Return)),
                Tuple.Create<string, ExpressionSyntax>(EscapeValueField, node.Expression != null ? node.Expression : Cs.Null()),
                Tuple.Create<string, ExpressionSyntax>(EscapeDepthField, Cs.Integer(loopDepth))
            ), true));
        }

        public class EscapeStatement
        {
            public int Type { get; set; }
            public string Label { get; set; }

            protected bool Equals(EscapeStatement other)
            {
                return Type == other.Type && string.Equals(Label, other.Label);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((EscapeStatement)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (Type*397) ^ (Label != null ? Label.GetHashCode() : 0);
                }
            }
        }
         
    }
*/
}