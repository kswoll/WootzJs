using System.Collections.Generic;
using System.Text;

namespace System
{
    public class DateTimeFormatter
    {
        private List<Token> tokens;

        public DateTimeFormatter(string pattern)
        {
            tokens = new List<Token>();
            for (var i = 0 ; i < pattern.Length; i++)
            {
                var c = pattern[i];
                var secondC = i < pattern.Length - 1 ? (char?)pattern[i + 1] : null;
                var thirdC = i < pattern.Length - 2 ? (char?)pattern[i + 2] : null;
                var fourthC = i < pattern.Length - 3 ? (char?)pattern[i + 3] : null;
                switch (c)
                {
                    case 'd':
                        if (secondC == 'd')
                        {
                            tokens.Add(new Token { Type = TokenType.DayOfMonthTwoDigit });                            
                            i++;
                        }
                        else
                            tokens.Add(new Token { Type = TokenType.DayOfMonth });
                        break;
                    case 'M':
                        if (secondC == 'M')
                        {
                            tokens.Add(new Token { Type = TokenType.MonthTwoDigit });
                            i += 1;
                        }
                        else
                            tokens.Add(new Token { Type = TokenType.Month });
                        break;
                    case 'y':
                        if (secondC == 'y' && thirdC == 'y' && fourthC == 'y')
                        {
                            tokens.Add(new Token { Type = TokenType.YearFourDigit });
                            i += 3;
                        }
                        else if (secondC == 'y')
                        {
                            tokens.Add(new Token { Type = TokenType.DayOfMonthTwoDigit });                            
                            i++;
                        }
                        else
                            tokens.Add(new Token { Type = TokenType.Year });
                        break;
                    default:
                        tokens.Add(new Token { Type = TokenType.Literal, Literal = c.ToString() });
                        break;
                }
            }
        }

        public string Format(DateTime dateTime)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.Type)
                {
                    case TokenType.DayOfMonthTwoDigit:
                        builder.Append(Pad(dateTime.Day, 2, 2));
                        break;
                    case TokenType.DayOfMonth:
                        builder.Append(Pad(dateTime.Day, 1, 2));
                        break;
                    case TokenType.MonthTwoDigit:
                        builder.Append(Pad(dateTime.Month, 2, 2));
                        break;
                    case TokenType.Month:
                        builder.Append(Pad(dateTime.Month, 1, 2));
                        break;
                    case TokenType.YearFourDigit:
                        builder.Append(Pad(dateTime.Year, 4, 4));
                        break;
                    case TokenType.YearTwoDigit:
                        builder.Append(Pad(dateTime.Year, 2, 2));
                        break;
                    case TokenType.Year:
                        builder.Append(Pad(dateTime.Year, 1, 2));
                        break;
                    case TokenType.Literal:
                        builder.Append(token.Literal);
                        break;
                }
            }
            return builder.ToString();
        }

        private string Pad(int value, int minDigits, int maxDigits)
        {
            var s = value.ToString();
            while (s.Length < minDigits)
                s = '0' + s;
            while (s.Length > maxDigits)
                s = s.Substring(1);
            return s;
        }

        public class Token
        {
            public TokenType Type { get; set; }
            public string Literal { get; set; }
        } 

        public enum TokenType
        {
            DayOfMonth,
            DayOfMonthTwoDigit,
            Month,
            MonthTwoDigit,
            Year,
            YearTwoDigit,
            YearFourDigit,
            Literal
        }
    }
}