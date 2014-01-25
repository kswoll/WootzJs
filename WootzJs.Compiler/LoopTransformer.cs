using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class LoopTransformer : JsRewriter
    {
        public const string EscapeTypeField = "type";
        public const string EscapeValueField = "value";
        public const string EscapeLabelField = "label";
        public const string EscapeDepthField = "depth";
        public const int Return = 1;
        public const int Continue = 2;
        public const int Break = 3;

        private JsTransformer transformer;
        private Idioms idioms;
        private int loopDepth;
        private StatementSyntax body;
        private StatementSyntax loopNode;
        private JsStatement loop;
        private List<EscapeStatement> escapeStatements = new List<EscapeStatement>();

        public LoopTransformer(JsTransformer transformer, StatementSyntax loop, int loopDepth, StatementSyntax body)
        {
            this.transformer = transformer;
            idioms = transformer.idioms;
            this.loopDepth = loopDepth;
            this.body = body;
            loopNode = loop;
        }

        public JsStatement TransformLoop(JsStatement loop)
        {
            if (loopNode.GetContainingType().Name.StartsWith("YieldEnumerator$"))
                return loop;
            if (!LambdaChecker.HasLambdasWithClosedVariables(body))
                return loop;

            var result = (JsStatement)loop.Accept(this);
            return result;
        }

        private JsStatement TransformBody(JsStatement body)
        {
            var block = body is JsBlockStatement ? (JsBlockStatement)body : Js.Block(body);

            if (!escapeStatements.Any())
            {
                return Js.Express(idioms.Wrap(block));
            }
            else
            {
                if (!(block.Statements.Last() is JsReturnStatement))
                    block.Return(Js.Object(Js.Item(EscapeTypeField, Js.Primitive(0))).Compact());
                var wrapped = idioms.Wrap(block);
                var outerBlock = new JsBlockStatement();
                var loopResult = outerBlock.Local("$loopResult", wrapped);
                if (escapeStatements.Any(x => x.Type == Return))
                {
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
                        ifTrue = Js.Switch(
                            loopResult.GetReference().Member(EscapeLabelField), 
                            escapes
                                .Where(x => x.Label == null)
                                .Select(x => Js.Section(Js.Null()).Statement(Js.Continue()))
                                .Concat(escapes
                                    .Where(x => x.Label != null && transformer.GetLabelDepth(x.Label) == loopDepth)
                                    .Select(x => Js.Section(Js.Primitive(x.Label)).Statement(Js.Continue(x.Label))))
                                .Concat(new[] { Js.Section(Js.DefaultLabel()).Statements(Js.Return(loopResult.GetReference())) })
                                .ToArray());
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

        public override JsNode Visit(JsForStatement node)
        {
            if (loop != null)
                return node;
            loop = node;

            node.Body = TransformBody((JsStatement)node.Body.Accept(this));
            return node;
        }

        public override JsNode Visit(JsDoWhileStatement node)
        {
            if (loop != null)
                return node;
            loop = node;

            node.Body = TransformBody((JsStatement)node.Body.Accept(this));
            return node;
        }

        public override JsNode Visit(JsWhileStatement node)
        {
            if (loop != null)
                return node;
            loop = node;

            node.Body = TransformBody((JsStatement)node.Body.Accept(this));
            return node;
        }

        public override JsNode Visit(JsContinueStatement node)
        {
            escapeStatements.Add(new EscapeStatement { Type = Continue, Label = node.Label });
            return Js.Return(Js.Object(
                Js.Item(EscapeTypeField, Js.Primitive(Continue)),
                Js.Item(EscapeLabelField, node.Label != null ? Js.Primitive(node.Label) : Js.Null()),
                Js.Item(EscapeDepthField, node.Label != null ? Js.Primitive(transformer.GetLabelDepth(node.Label)) : Js.Primitive(0))
            ).Compact());
        }

        public override JsNode Visit(JsBreakStatement node)
        {
            escapeStatements.Add(new EscapeStatement { Type = Break, Label = node.Label });
            return Js.Return(Js.Object(
                Js.Item(EscapeTypeField, Js.Primitive(Break)),
                Js.Item(EscapeLabelField, node.Label != null ? Js.Primitive(node.Label) : Js.Null()),
                Js.Item(EscapeDepthField, node.Label != null ? Js.Primitive(transformer.GetLabelDepth(node.Label)) : Js.Primitive(0))
            ).Compact());
        }

        public override JsNode Visit(JsReturnStatement node)
        {
            escapeStatements.Add(new EscapeStatement { Type = Return });
            return Js.Return(Js.Object(
                Js.Item(EscapeTypeField, Js.Primitive(Return)),
                Js.Item(EscapeValueField, node.Expression != null ? node.Expression : Js.Null()),
                Js.Item(EscapeDepthField, Js.Primitive(loopDepth))
            ).Compact());
        }

        public override JsNode Visit(JsFunction node)
        {
            return node;  // Don't traverse into inner functions since they have their own escapes
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
}