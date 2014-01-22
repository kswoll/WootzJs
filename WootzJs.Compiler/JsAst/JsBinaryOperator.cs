using System;

namespace WootzJs.Compiler.JsAst
{
    public enum JsBinaryOperator
    {
        Add, Subtract, Multiply, Divide, Modulus, Equals, NotEquals, GreaterThan, LessThan, GreaterThanOrEqual,
        LessThanOrEqual, LogicalAnd, LogicalOr, BitwiseAnd, BitwiseOr, ShiftLeft, ShiftRight, Assign, 
        AddAssign, SubtractAssign, MultiplyAssign, DivideAssign, ModulusAssign, ExclusiveOr
    }

    public static class JsBinaryOperators
    {
        public static string GetToken(this JsBinaryOperator op)
        {
            switch (op)
            {
                case JsBinaryOperator.Add: return "+";
                case JsBinaryOperator.AddAssign: return "+=";
                case JsBinaryOperator.Assign: return "=";
                case JsBinaryOperator.BitwiseAnd: return "&";
                case JsBinaryOperator.BitwiseOr: return "|";
                case JsBinaryOperator.Divide: return "/";
                case JsBinaryOperator.DivideAssign: return "/=";
                case JsBinaryOperator.Equals: return "==";
                case JsBinaryOperator.GreaterThan: return ">";
                case JsBinaryOperator.GreaterThanOrEqual: return ">=";
                case JsBinaryOperator.LessThan: return "<";
                case JsBinaryOperator.LessThanOrEqual: return "<=";
                case JsBinaryOperator.LogicalAnd: return "&&";
                case JsBinaryOperator.LogicalOr: return "||";
                case JsBinaryOperator.Modulus: return "%";
                case JsBinaryOperator.ModulusAssign: return "%=";
                case JsBinaryOperator.Multiply: return "*";
                case JsBinaryOperator.MultiplyAssign: return "*=";
                case JsBinaryOperator.NotEquals: return "!=";
                case JsBinaryOperator.ShiftLeft: return "<<";
                case JsBinaryOperator.ShiftRight: return ">>";
                case JsBinaryOperator.Subtract: return "-";
                case JsBinaryOperator.SubtractAssign: return "-=";
                case JsBinaryOperator.ExclusiveOr: return "^";
                default: throw new Exception();
            }
        }
    }
}
