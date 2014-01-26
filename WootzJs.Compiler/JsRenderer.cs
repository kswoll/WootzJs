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
using System.Linq;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public class JsRenderer : JsVisitor
    {
        private IndentStringBuilder output = new IndentStringBuilder();

        protected override void DefaultVisit<T>(T node, Action<T> action)
        {
            if (!node.IsCompacted)
            {
                base.DefaultVisit(node, action);
            }
            else
            {
                var isCompacting = output.IsCompacting;
                output.IsCompacting = true;
                base.DefaultVisit(node, action);
                output.IsCompacting = isCompacting;
            }
        }

        public IndentStringBuilder Builder
        {
            get { return output; }
        }

        public string Output
        {
            get { return output.ToString(); }
        }

        private void WriteMaybeBlock(JsStatement statement, bool newLine)
        {
            if (statement is JsBlockStatement)
            {
                output.Append(" ");
                statement.Accept(this);
                if (newLine)
                    output.AppendLine();
            }
            else
            {
                output.AppendLine();
                output.CurrentIndentLevel++;
                statement.Accept(this);
                output.CurrentIndentLevel--;
            }            
        }

        public override void VisitCompilationUnit(JsCompilationUnit compilationUnit)
        {
            if (compilationUnit.UseStrict) 
            {
                output.AppendLine("\"use strict\";");
            }

            foreach (var statement in compilationUnit.Body.Statements)
            {
                statement.Accept(this);
                if (statement is JsBlockStatement)
                    output.AppendLine();
            }
        }

        public override void VisitInvocationExpression(JsInvocationExpression node)
        {
            node.Target.Accept(this);
            output.Append("(");

            var pastThreshold = node.Arguments.Count > 3;
            if (pastThreshold)
            {
                output.AppendLine();
                output.CurrentIndentLevel++;
            }

            for (var i = 0; i < node.Arguments.Count; i++)
            {
                var argument = node.Arguments[i];
                argument.Accept(this);
                if (i < node.Arguments.Count - 1)
                    output.Append(", ");
                if (pastThreshold)
                    output.AppendLine();
            }

            if (pastThreshold)
            {
                output.CurrentIndentLevel--;
            }
            output.Append(")");
        }

        public override void VisitObjectItem(JsObjectItem node)
        {
            output.Append(node.Name);
            output.Append(": ");
            node.Value.Accept(this);
        }

        public override void VisitVariableReferenceExpression(JsVariableReferenceExpression node)
        {
            output.Append(node.Name);
        }

        public override void VisitLocalVariableDeclaration(JsLocalVariableDeclaration node)
        {
            node.Declaration.Accept(this);
            output.AppendLine(";");
        }

        public override void VisitVariableDeclaration(JsVariableDeclaration node)
        {
            output.Append("var ");
            for (var i = 0; i < node.Declarations.Count; i++)
            {
                var declaration = node.Declarations[i];
                declaration.Accept(this);
                if (i < node.Declarations.Count - 1)
                {
                    output.Append(", ");
                }
            }
        }

        public override void VisitVariableDeclarator(JsVariableDeclarator node)
        {
            output.Append(node.Name);
            if (node.Initializer != null)
            {
                output.Append(" = ");
                node.Initializer.Accept(this);
            }
        }

        public override void VisitReturnStatement(JsReturnStatement node)
        {
            output.Append("return");

            if (node.Expression != null)
            {
                output.Append(" ");
                node.Expression.Accept(this);
            }

            output.AppendLine(";");
        }

        public override void VisitParentheticalExpression(JsParentheticalExpression node)
        {
            output.Append("(");
            node.Expression.Accept(this);
            output.Append(")");
        }

        public override void VisitObjectExpression(JsObjectExpression node)
        {
            if (!node.Items.Any())
            {
                output.Append("{}");
            }
            else
            {
                output.AppendLine("{");
                output.CurrentIndentLevel++;
                for (var i = 0; i < node.Items.Count; i++)
                {
                    var item = node.Items[i];
                    item.Accept(this);

                    if (i < node.Items.Count - 1)
                    {
                        output.Append(",");
                    }
                    output.AppendLine();
                }
                output.CurrentIndentLevel--;
                output.Append("}");
            }
        }

        public override void VisitMemberReferenceExpression(JsMemberReferenceExpression node)
        {
            node.Target.Accept(this);
            output.Append(".");
            output.Append(node.Name);
        }

        public override void VisitFunction(JsFunction node)
        {
            output.Append("function");
            if (node.Name != null)
            {
                output.Append(" ");
                output.Append(node.Name);
            }
            output.Append("(");
            for (var i = 0; i < node.Parameters.Count; i++)
            {
                var argument = node.Parameters[i];
                output.Append(argument.Name);

                if (i < node.Parameters.Count - 1)
                {
                    output.Append(", ");
                }
            }
            output.Append(") ");
            node.Body.Accept(this);
        }

        public override void VisitFunctionDeclaration(JsFunctionDeclaration node)
        {
            node.Function.Accept(this);
            output.AppendLine();
        }

        public override void VisitExpressionStatement(JsExpressionStatement node)
        {
            node.Expression.Accept(this);
            output.AppendLine(";");
        }

        public override void VisitBlockStatement(JsBlockStatement node)
        {
            if (node.Statements.Count == 0)
            {
                output.Append("{}");
                return;
            }

            if (!node.Inline)
            {
                output.AppendLine("{");
                output.CurrentIndentLevel++;
            }
            foreach (var statement in node.Statements)
            {
                statement.Accept(this);
                if (statement is JsBlockStatement)
                    output.AppendLine();
            }
            if (!node.Inline)
            {
                output.CurrentIndentLevel--;
                output.Append("}");
            }
        }

        public override void VisitBinaryExpression(JsBinaryExpression node)
        {
            node.Left.Accept(this);
            output.Append(" ");
            output.Append(node.Operator.GetToken());
            output.Append(" ");
            node.Right.Accept(this);
        }

        public override void VisitParameter(JsParameter node)
        {
            output.Append(node.Name);
        }

        public override void VisitPrimitiveExpression(JsPrimitiveExpression node)
        {
            if (node.Value == null)
            {
                output.Append("null");
            }
            else if (node.Value is string)
            {
                output.Append("\"");
                output.Append(StringEscaper.EscapeString((string)node.Value));
                output.Append("\"");
            }
            else if (node.Value is int || node.Value is short || node.Value is byte || node.Value is long || node.Value is sbyte || node.Value is ushort || 
                node.Value is uint || node.Value is ulong || node.Value is float || node.Value is double || node.Value is decimal)
            {
                output.Append(node.Value.ToString());
            }
            else if (node.Value is bool)
            {
                output.Append((bool)node.Value ? "true" : "false");
            }
            else if (node.Value is char)
            {
                output.Append("\"");
                output.Append(((char)node.Value));
                output.Append("\"");
            }
            else
            {
                throw new InvalidOperationException("Unexpected primitive expression value: " + node.Value);
            }
        }

        public override void VisitThisExpression(JsThisExpression node)
        {
            output.Append("this");
        }

        public override void VisitNewExpression(JsNewExpression node)
        {
            output.Append("new ");
            node.Expression.Accept(this);
        }

        public override void VisitIfStatement(JsIfStatement node)
        {
            output.Append("if (");
            node.Condition.Accept(this);
            output.Append(")");
            WriteMaybeBlock(node.IfTrue, true);
            if (node.IfFalse != null)
            {
                output.Append("else");
                WriteMaybeBlock(node.IfFalse, true);
            }
        }

        public override void VisitUnaryExpression(JsUnaryExpression node)
        {
            switch (node.Operator)
            {
                case JsUnaryOperator.Negate:
                    output.Append("-");
                    node.Operand.Accept(this);
                    break;
                case JsUnaryOperator.LogicalNot:
                    output.Append("!");
                    node.Operand.Accept(this);
                    break;
                case JsUnaryOperator.PostDecrement:
                    node.Operand.Accept(this);
                    output.Append("--");
                    break;
                case JsUnaryOperator.PostIncrement:
                    node.Operand.Accept(this);
                    output.Append("++");
                    break;
                case JsUnaryOperator.PreDecrement:
                    output.Append("--");
                    node.Operand.Accept(this);
                    break;
                case JsUnaryOperator.PreIncrement:
                    output.Append("++");
                    node.Operand.Accept(this);
                    break;
                default:
                    throw new Exception();
            }
        }

        public override void VisitNativeStatement(JsNativeStatement node)
        {
            var code = node.Code.Trim();
            var lines = code.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                output.AppendLine(line);
            }
        }

        public override void VisitNewArrayExpression(JsNewArrayExpression node)
        {
            output.Append("new Array(");
            node.Size.Accept(this);
            output.Append(")");
        }

        public override void VisitForStatement(JsForStatement node)
        {
            output.Append("for (");
            if (node.Declaration != null)
            {
                node.Declaration.Accept(this);
            }
            else
            {
                for (var i = 0; i < node.Initializers.Count; i++)
                {
                    var initializer = node.Initializers[i];
                    initializer.Accept(this);
                    if (i < node.Initializers.Count - 1)
                        output.Append(", ");
                }
            }
            output.Append("; ");
            node.Condition.Accept(this);
            output.Append("; ");
            for (var i =  0; i < node.Incrementors.Count; i++)
            {
                node.Incrementors[i].Accept(this);
                if (i < node.Incrementors.Count - 1)
                    output.Append(", ");
            }
            output.Append(")");

            WriteMaybeBlock(node.Body, true);
        }

        public override void VisitIndexExpression(JsIndexExpression node)
        {
            node.Target.Accept(this);
            output.Append("[");
            node.Index.Accept(this);
            output.Append("]");
        }

        public override void VisitRegexExpression(JsRegexExpression node)
        {
            output.Append("/");
            output.Append(node.Pattern);
            output.Append("/");
        }

        public override void VisitArrayExpression(JsArrayExpression node)
        {
            var pastThreshold = node.Elements.Count > 3;

            output.Append("[");
            if (pastThreshold)
            {
                output.AppendLine();
                output.CurrentIndentLevel++;
            }
            for (var i = 0; i < node.Elements.Count; i++)
            {
                var element = node.Elements[i];
                element.Accept(this);

                if (i < node.Elements.Count - 1) 
                    output.Append(", ");
                if (pastThreshold)
                    output.AppendLine();
            }
            if (pastThreshold)
            {
                output.CurrentIndentLevel--;
            }
            output.Append("]");
        }

        public override void VisitThrowStatement(JsThrowStatement node)
        {
            output.Append("throw ");
            node.Expression.Accept(this);
            output.AppendLine(";");
        }

        public override void VisitSwitchStatement(JsSwitchStatement node)
        {
            output.Append("switch (");
            node.Expression.Accept(this);
            output.AppendLine(") {");
            output.CurrentIndentLevel++;

            foreach (var section in node.Sections)
            {
                section.Accept(this);
            }

            output.CurrentIndentLevel--;
            output.AppendLine("}");
        }

        public override void VisitSwitchSection(JsSwitchSection node)
        {
            foreach (var label in node.Labels)
            {
                label.Accept(this);
            }
            output.CurrentIndentLevel++;

            foreach (var statement in node.Statements)
            {
                statement.Accept(this);
            }

            output.CurrentIndentLevel--;
        }

        public override void VisitSwitchLabel(JsSwitchLabel node)
        {
            if (node.IsDefault)
                output.Append("default");
            else
            {
                output.Append("case ");
                node.Value.Accept(this);
            }
            output.AppendLine(":");
        }

        public override void VisitWhileStatement(JsWhileStatement node)
        {
            output.Append("while (");
            node.Condition.Accept(this);
            output.Append(")");
            WriteMaybeBlock(node.Body, true);
        }

        public override void VisitDoWhileStatement(JsDoWhileStatement node)
        {
            output.Append("do");
            WriteMaybeBlock(node.Body, true);
            output.Append("while (");
            node.Condition.Accept(this);
            output.AppendLine(");");
        }

        public override void VisitBreakStatement(JsBreakStatement node)
        {
            output.Append("break");

            if (node.Label != null)
            {
                output.Append(" ");
                output.Append(node.Label);
            }

            output.AppendLine(";");
        }

        public override void VisitLabeledStatement(JsLabeledStatement node)
        {
            output.Append(node.Label);
            output.AppendLine(":");
            node.Statement.Accept(this);
        }

        public override void VisitEmptyStatement(JsEmptyStatement node)
        {
            output.AppendLine(";");
        }

        public override void VisitCatchClause(JsCatchClause node)
        {
            output.Append("catch ");
            if (node.Declaration != null)
            {
                output.Append("(");
                node.Declaration.Accept(this);
                output.Append(") ");
            }
            node.Body.Accept(this);
        }

        public override void VisitTryStatement(JsTryStatement node)
        {
            output.Append("try ");
            node.Body.Accept(this);
            output.AppendLine();
            if (node.Catch != null)
            {
                node.Catch.Accept(this);
                output.AppendLine();
            }
            if (node.Finally != null)
            {
                output.Append("finally ");
                node.Finally.Accept(this);
                output.AppendLine();
            }
        }

        public override void VisitConditionalExpression(JsConditionalExpression node)
        {
            node.Condition.Accept(this);
            output.Append(" ? ");
            node.IfTrue.Accept(this);
            output.Append(" : ");
            node.IfFalse.Accept(this);
        }

        public override void VisitDeleteExpression(JsDeleteExpression node)
        {
            output.Append("delete ");
            node.Target.Accept(this);
        }

        public override void VisitForInStatement(JsForInStatement node)
        {
            output.Append("for (");
            node.Declaration.Accept(this);
            output.Append(" in ");
            node.Target.Accept(this);
            output.Append(")");
            WriteMaybeBlock(node.Body, true);
        }

        public override void VisitTypeOfExpression(JsTypeOfExpression node)
        {
            output.Append("typeof ");
            node.Target.Accept(this);
        }

        public override void VisitContinueStatement(JsContinueStatement node)
        {
            output.Append("continue");
            
            if (node.Label != null)
            {
                output.Append(" ");
                output.Append(node.Label);
            }

            output.AppendLine(";");
        }

        public override void VisitDeclarationReferenceExpression(JsDeclarationReferenceExpression node)
        {
            output.Append(node.Declaration.Name);
        }

        public override void VisitInstanceOfExpression(JsInstanceOfExpression node)
        {
            node.Expression.Accept(this);
            output.Append(" instanceof ");
            node.Type.Accept(this);
        }
    }
}
