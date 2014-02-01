using System;

namespace WootzJs.Mvc.ExpressionTrees
{
    public class GenericMath
    {
        private static bool IsInteger(Type type)
        {
            return type == typeof(byte) || type == typeof(short) || type == typeof(int) || type == typeof(long);
        }

        private static bool IsBinaryFloat(Type type)
        {
            return type == typeof(float) || type == typeof(double);
        }

        private static bool IsDecimal(Type type)
        {
            return false;
        }

        private static Type GetWidestType(Type type1, Type type2)
        {
            if (type1 == type2)
                return type1;

            if (IsInteger(type1))
                return type2;

            if (IsBinaryFloat(type1))
            {
                if (!IsDecimal(type2))
                    return type1;
            }

            if (IsDecimal(type1))
            {
                if (!IsBinaryFloat(type2))
                    return type1;
            }

            throw new InvalidOperationException("There is no implicit conversion between " + type1.FullName + " and " + type2.FullName);
        }

        public static object Add(object left, object right)
        {
            var widestType = GetWidestType(left.GetType(), right.GetType());
            left = Convert.ChangeType(left, widestType);
            right = Convert.ChangeType(right, widestType);

            if (left is byte)
                return (byte)left + (byte)right;
            else if (left is short)
                return (short)left + (short)right;
            else if (left is int)
                return (int)left + (int)right;
            else if (left is long)
                return (long)left + (long)right;
            else if (left is float)
                return (float)left + (float)right;
            else if (left is decimal)
                return (decimal)left + (decimal)right;
            else
                return (double)left + (double)right;
        }

        public static object Subtract(object left, object right)
        {
            var widestType = GetWidestType(left.GetType(), right.GetType());
            left = Convert.ChangeType(left, widestType);
            right = Convert.ChangeType(right, widestType);
            
            if (left is byte)
                return (byte)left - (byte)right;
            else if (left is short)
                return (short)left - (short)right;
            else if (left is int)
                return (int)left - (int)right;
            else if (left is long)
                return (long)left - (long)right;
            else if (left is float)
                return (float)left - (float)right;
            else if (left is decimal)
                return (decimal)left - (decimal)right;
            else
                return (double)left - (double)right;
        }

        public static object Multiply(object left, object right)
        {
            var widestType = GetWidestType(left.GetType(), right.GetType());
            left = Convert.ChangeType(left, widestType);
            right = Convert.ChangeType(right, widestType);
            
            if (left is byte)
                return (byte)left * (byte)right;
            else if (left is short)
                return (short)left * (short)right;
            else if (left is int)
                return (int)left * (int)right;
            else if (left is long)
                return (long)left * (long)right;
            else if (left is float)
                return (float)left * (float)right;
            else if (left is decimal)
                return (decimal)left * (decimal)right;
            else
                return (double)left * (double)right;
        }

        public static object Divide(object left, object right)
        {
            var widestType = GetWidestType(left.GetType(), right.GetType());
            left = Convert.ChangeType(left, widestType);
            right = Convert.ChangeType(right, widestType);
            
            if (left is byte)
                return (byte)left / (byte)right;
            else if (left is short)
                return (short)left / (short)right;
            else if (left is int)
                return (int)left / (int)right;
            else if (left is long)
                return (long)left / (long)right;
            else if (left is float)
                return (float)left / (float)right;
            else if (left is decimal)
                return (decimal)left / (decimal)right;
            else
                return (double)left / (double)right;
        }

        public static object Modulus(object left, object right)
        {
            var widestType = GetWidestType(left.GetType(), right.GetType());
            left = Convert.ChangeType(left, widestType);
            right = Convert.ChangeType(right, widestType);
            
            if (left is byte)
                return (byte)left % (byte)right;
            else if (left is short)
                return (short)left % (short)right;
            else if (left is int)
                return (int)left % (int)right;
            else if (left is long)
                return (long)left % (long)right;
            else if (left is float)
                return (float)left % (float)right;
            else if (left is decimal)
                return (decimal)left % (decimal)right;
            else
                return (double)left % (double)right;
        }
    }
}