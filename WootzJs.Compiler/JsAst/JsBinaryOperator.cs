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

namespace WootzJs.Compiler.JsAst
{
    public enum JsBinaryOperator
    {
        Add, Subtract, Multiply, Divide, Modulus, Equals, NotEquals, GreaterThan, LessThan, GreaterThanOrEqual,
        LessThanOrEqual, LogicalAnd, LogicalOr, BitwiseAnd, BitwiseOr, ShiftLeft, ShiftRight, Assign, 
        AddAssign, SubtractAssign, MultiplyAssign, DivideAssign, ModulusAssign, ExclusiveOr, LeftShiftAssign,
        RightShiftAssign, BitwiseOrAssign, BitwiseAndAssign, ExclusiveOrAssign
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
                case JsBinaryOperator.LeftShiftAssign: return "<<=";
                case JsBinaryOperator.RightShiftAssign: return ">>=";
                case JsBinaryOperator.BitwiseAndAssign: return "&=";
                case JsBinaryOperator.BitwiseOrAssign: return "|=";
                case JsBinaryOperator.ExclusiveOrAssign: return "^=";
                default: throw new Exception();
            }
        }
    }
}
