using System;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class JsRewriter : IJsVisitor<JsNode>
    {
        protected virtual JsNode DefaultVisit<T>(T node, Func<T, JsNode> action) where T : JsNode
        {
            return action(node);
        }

        public JsNode Visit(JsCompilationUnit node)
        {
            return DefaultVisit(node, x =>
            {
                node.Body = (JsBlockStatement)x.Body.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsBlockStatement node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Statements.Count; i++)
                {
                    x.Statements[i] = (JsStatement)x.Statements[i].Accept(this);
                }
                return x;
            });
        }

        public JsNode Visit(JsExpressionStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Accept(this);
                return x;
            });
        }

        private JsNode VisitDeclaration(IJsDeclaration declaration)
        {
            if (declaration is JsParameter)
                return ((JsParameter)declaration).Accept(this);
            else if (declaration is JsVariableDeclarator)
                return ((JsVariableDeclarator)declaration).Accept(this);            
            else
                throw new Exception();
        }

        public JsNode Visit(JsFunction node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Parameters.Count; i++)
                {
                    x.Parameters[i] = (IJsDeclaration)VisitDeclaration(x.Parameters[i]);
                }
                x.Body = (JsBlockStatement)x.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsMemberReferenceExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Target = (JsExpression)x.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsObjectExpression node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Items.Count; i++)
                {
                    x.Items[i] = (JsObjectItem)x.Items[i].Accept(this);
                }
                return x;
            });
        }

        public JsNode Visit(JsParentheticalExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsReturnStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsVariableDeclarator node)
        {
            return DefaultVisit(node, x =>
            {
                x.Initializer = (JsExpression)x.Initializer.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsVariableDeclaration node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Declarations.Count; i++)
                {
                    x.Declarations[i] = (JsVariableDeclarator)x.Declarations[i].Accept(this);
                }
                return x;
            });
        }

        public JsNode Visit(JsVariableReferenceExpression node)
        {
            return DefaultVisit(node, x => x);
        }

        public JsNode Visit(JsObjectItem node)
        {
            return DefaultVisit(node, x =>
            {
                x.Value = (JsExpression)x.Value.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsInvocationExpression node)
        {
            return DefaultVisit(node, x =>
            {
                node.Target = (JsExpression)node.Target.Accept(this);
                for (var i = 0; i < node.Arguments.Count; i++)
                {
                    node.Arguments[i] = (JsExpression)node.Arguments[i].Accept(this);
                }
                return x;
            });
        }

        public JsNode Visit(JsParameter node)
        {
            return DefaultVisit(node, x => x);
        }

        public JsNode Visit(JsFunctionDeclaration node)
        {
            return DefaultVisit(node, x =>
            {
                x.Function = (JsFunction)x.Function.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsPrimitiveExpression node)
        {
            return DefaultVisit(node, x => x);
        }

        public JsNode Visit(JsThisExpression node)
        {
            return DefaultVisit(node, x => x);
        }

        public JsNode Visit(JsNewExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsIfStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Condition = (JsExpression)x.Condition.Accept(this);
                x.IfTrue = (JsStatement)x.IfTrue.Accept(this);
                if (x.IfFalse != null)
                    x.IfFalse = (JsStatement)x.IfFalse.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsBinaryExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Left = (JsExpression)x.Left.Accept(this);
                x.Right = (JsExpression)x.Right.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsUnaryExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Operand = (JsExpression)x.Operand.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsNativeStatement node)
        {
            return DefaultVisit(node, x => x);
        }

        public JsNode Visit(JsNewArrayExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Size = (JsExpression)x.Size.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsForStatement node)
        {
            return DefaultVisit(node, x =>
            {
                if (x.Declaration != null)
                    x.Declaration = (JsVariableDeclaration)x.Declaration.Accept(this);
                if (x.Condition != null)
                    x.Condition = (JsExpression)x.Condition.Accept(this);
                for (var i = 0; i < x.Incrementors.Count; i++)
                {
                    x.Incrementors[i] = (JsExpression)x.Incrementors[i].Accept(this);
                }
                x.Body = (JsStatement)x.Body.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsIndexExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Target = (JsExpression)x.Target.Accept(this);
                x.Index = (JsExpression)x.Index.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsLocalVariableDeclaration node)
        {
            return DefaultVisit(node, x =>
            {
                x.Declaration = (JsVariableDeclaration)x.Declaration.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsRegexExpression node)
        {
            return DefaultVisit(node, x => x);
        }

        public JsNode Visit(JsArrayExpression node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Elements.Count; i++)
                {
                    x.Elements[i] = (JsExpression)x.Elements[i].Accept(this);
                }
                return x;
            });
        }

        public JsNode Visit(JsThrowStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsSwitchSection node)
        {
            return DefaultVisit(node, x =>
            {
                for (var i = 0; i < x.Labels.Count; i++)
                {
                    x.Labels[i] = (JsSwitchLabel)x.Labels[i].Accept(this);
                }
                for (var i = 0; i < x.Statements.Count; i++)
                {
                    x.Statements[i] = (JsStatement)x.Statements[i].Accept(this);
                }
                return x;
            });
        }

        public JsNode Visit(JsSwitchStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                for (var i = 0; i < x.Sections.Count; i++)
                {
                    x.Sections[i] = (JsSwitchSection)x.Sections[i].Accept(this);
                }
                return x;
            });
        }

        public JsNode Visit(JsSwitchLabel node)
        {
            return DefaultVisit(node, x =>
            {
                if (x.Value != null)
                    x.Value = (JsExpression)x.Value.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsWhileStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Condition = (JsExpression)x.Condition.Accept(this);
                x.Body = (JsStatement)x.Body.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsBreakStatement node)
        {
            return DefaultVisit(node, x =>
            {
                if (x.Label != null)
                    x.Label = (JsExpression)x.Label.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsEmptyStatement node)
        {
            return DefaultVisit(node, x => x);
        }

        public JsNode Visit(JsCatchClause node)
        {
            return DefaultVisit(node, x =>
            {
                x.Declaration = (JsVariableDeclarator)x.Declaration.Accept(this);
                x.Body = (JsBlockStatement)x.Body.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsTryStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Body = (JsBlockStatement)x.Body.Accept(this);
                if (x.Catch != null)
                    x.Catch = (JsCatchClause)x.Catch.Accept(this);
                if (x.Finally != null)
                    x.Finally = (JsBlockStatement)x.Finally.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsConditionalExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Condition = (JsExpression)x.Condition.Accept(this);
                x.IfTrue = (JsExpression)x.IfTrue.Accept(this);
                x.IfFalse = (JsExpression)x.IfFalse.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsDeleteExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Target = (JsExpression)x.Target.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsForInStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Declaration = (JsVariableDeclaration)x.Declaration.Accept(this);
                x.Target = (JsExpression)x.Target.Accept(this);
                x.Body = (JsStatement)x.Body.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsTypeOfExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Target = (JsExpression)x.Target.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsContinueStatement node)
        {
            return DefaultVisit(node, x =>
            {
                if (x.Label != null)
                    x.Label = (JsExpression)x.Label.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsDeclarationReferenceExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Declaration = (IJsDeclaration)VisitDeclaration(x.Declaration);
                return x;
            });
        }

        public JsNode Visit(JsLabeledStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Statement = (JsStatement)x.Statement.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsDoWhileStatement node)
        {
            return DefaultVisit(node, x =>
            {
                x.Condition = (JsExpression)x.Condition.Accept(this);
                x.Body = (JsStatement)x.Body.Accept(this);
                return x;
            });
        }

        public JsNode Visit(JsInstanceOfExpression node)
        {
            return DefaultVisit(node, x =>
            {
                x.Expression = (JsExpression)x.Expression.Accept(this);
                x.Type = (JsExpression)x.Type.Accept(this);
                return x;
            });
        }
    }
}