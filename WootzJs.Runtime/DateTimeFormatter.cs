using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace System
{
    public class DateTimeFormatter
    {
        private List<Token> tokens;
        private CultureInfo culture;

        public DateTimeFormatter(string pattern, CultureInfo culture = null)
        {
            tokens = new List<Token>();
            this.culture = culture ?? CultureInfo.CurrentCulture;
            for (var i = 0 ; i < pattern.Length; i++)
            {
                var c = pattern[i];
                var secondC = i < pattern.Length - 1 ? (char?)pattern[i + 1] : null;
                var thirdC = i < pattern.Length - 2 ? (char?)pattern[i + 2] : null;
                var fourthC = i < pattern.Length - 3 ? (char?)pattern[i + 3] : null;
                switch (c)
                {
                    case 'd':
                        if (secondC == 'd' && thirdC == 'd' && fourthC == 'd')
                        {
                            tokens.Add(new Token { Type = TokenType.DayOfWeekName });
                            i += 3;
                        }
                        else if (secondC == 'd')
                        {
                            tokens.Add(new Token { Type = TokenType.DayOfMonthTwoDigit });                            
                            i++;
                        }
                        else
                            tokens.Add(new Token { Type = TokenType.DayOfMonth });
                        break;
                    case 'M':
                        if (secondC == 'M' && thirdC == 'M' && fourthC == 'M')
                        {
                            tokens.Add(new Token { Type = TokenType.MonthName });
                            i += 3;
                        }
                        else if (secondC == 'M' && thirdC == 'M')
                        {
                            tokens.Add(new Token { Type = TokenType.MonthNameAbbreviated });
                            i += 2;
                        }
                        else if (secondC == 'M')
                        {
                            tokens.Add(new Token { Type = TokenType.MonthTwoDigit });
                            i += 1;

                            if (thirdC == 'M' && fourthC == 'M')
                            {
                                i += 2;
                            }
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
                            tokens.Add(new Token { Type = TokenType.YearTwoDigit });                            
                            i++;
                        }
                        else
                            tokens.Add(new Token { Type = TokenType.Year });
                        break;
                    case 'h':
                        if (secondC == 'h')
                        {
                            tokens.Add(new Token { Type = TokenType.HourTwoDigit });
                            i++;
                        }
                        else
                            tokens.Add(new Token { Type = TokenType.Hour });
                        break;
                    case 'm':
                        if (secondC == 'm')
                        {
                            tokens.Add(new Token { Type = TokenType.MinuteTwoDigit });
                            i++;
                        }
                        else 
                            tokens.Add(new Token { Type = TokenType.Minute });
                        break;
                    case 's':
                        if (secondC == 's')
                        {
                            tokens.Add(new Token { Type = TokenType.SecondTwoDigit });
                            i++;
                        }
                        else
                            tokens.Add(new Token { Type = TokenType.Second });
                        break;
                    case 'f':
                        if (secondC == 'f' && thirdC == 'f')
                        {
                            tokens.Add(new Token { Type = TokenType.Millisecond });
                            i += 3;
                        }
                        else if (secondC == 'f')
                        {
                            tokens.Add(new Token { Type = TokenType.HundredthSecond });
                            i++;
                        }
                        else
                            tokens.Add(new Token { Type = TokenType.TenthSecond });
                        break;
                    case 't':
                        if (secondC == 't')
                        {
                            tokens.Add(new Token { Type = TokenType.AmPm });
                            i++;
                        }
                        else 
                            tokens.Add(new Token { Type = TokenType.AmPmSingleDigit });
                        break;
                    case '\\':
                        if (secondC == null)
                            throw new Exception("Escape character found with no character to escape");
                        tokens.Add(new Token { Type = TokenType.Literal, Value = secondC.Value });
                        i++;
                        break;
                    default:
                        tokens.Add(new Token { Type = TokenType.Literal, Value = c });
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
                    case TokenType.DayOfWeekName:
                        builder.Append(culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek));
                        break;
                    case TokenType.MonthTwoDigit:
                        builder.Append(Pad(dateTime.Month, 2, 2));
                        break;
                    case TokenType.Month:
                        builder.Append(Pad(dateTime.Month, 1, 2));
                        break;
                    case TokenType.MonthName:
                        builder.Append(culture.DateTimeFormat.GetMonthName(dateTime.Month));
                        break;
                    case TokenType.MonthNameAbbreviated:
                        builder.Append(culture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month));
                        break;
                    case TokenType.YearFourDigit:
                        builder.Append(Pad(dateTime.Year, 4, 4));
                        break;
                    case TokenType.YearTwoDigit:
                        builder.Append(Pad(int.Parse(dateTime.Year.ToString().Substring(2)), 2, 2));
                        break;
                    case TokenType.Year:
                        builder.Append(Pad(int.Parse(dateTime.Year.ToString().Substring(2)), 1, 2));
                        break;
                    case TokenType.HourTwoDigit:
                        builder.Append(Pad(dateTime.Hour % 12 == 0 ? 12 : dateTime.Hour % 12, 2, 2));
                        break;
                    case TokenType.Hour:
                        builder.Append(Pad(dateTime.Hour % 12 == 0 ? 12 : dateTime.Hour % 12, 1, 2));
                        break;
                    case TokenType.MinuteTwoDigit:
                        builder.Append(Pad(dateTime.Minute, 2, 2));
                        break;
                    case TokenType.Minute:
                        builder.Append(Pad(dateTime.Minute, 1, 2));
                        break;
                    case TokenType.SecondTwoDigit:
                        builder.Append(Pad(dateTime.Second, 2, 2));
                        break;
                    case TokenType.Second:
                        builder.Append(Pad(dateTime.Second, 1, 2));
                        break;
                    case TokenType.TenthSecond:
                        builder.Append(dateTime.Millisecond / 100);
                        break;
                    case TokenType.HundredthSecond:
                        builder.Append(dateTime.Millisecond / 10);
                        break;
                    case TokenType.Millisecond:
                        builder.Append(dateTime.Millisecond);
                        break;
                    case TokenType.AmPmSingleDigit:
                        builder.Append(dateTime.Hour >= 12 ? 'P' : 'A');
                        break;
                    case TokenType.AmPm:
                        builder.Append(dateTime.Hour >= 12 ? "PM" : "AM");
                        break;
                    case TokenType.Literal:
                        builder.Append(token.Value);
                        break;
                    case TokenType.Escape:
                        builder.Append(token.Value);
                        break;
                }
            }
            return builder.ToString();
        }

        public DateTime Parse(string s)
        {
            var year = 0;
            var month = 0;
            var day = 0;
            var hour = 0;
            var minute = 0;
            var second = 0;
            var millisecond = 0;
            var remainingCharacters = new Queue<char>(s);
            Action throwException = () =>
            {
                throw new FormatException("The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar");
            };
            Func<int, int> getNextDigit = maxDigits =>
            {
                if (!remainingCharacters.Any())
                    throwException();
                if (maxDigits < 1 || maxDigits > 4)
                    throw new Exception("Invalid max digits");

                var firstCharacter = remainingCharacters.Dequeue();
                if (maxDigits == 1)
                {
                    return int.Parse(firstCharacter.ToString());
                }
                var secondCharacter = remainingCharacters.Any() ? (char?)remainingCharacters.Peek() : null;
                var thirdCharacter = remainingCharacters.Count > 1 ? (char?)remainingCharacters.Peek(1) : null;
                var fourthCharacter = remainingCharacters.Count > 2 ? (char?)remainingCharacters.Peek(2) : null;
                int value = 0;

                if (secondCharacter != null && char.IsDigit(secondCharacter.Value))
                {
                    if (maxDigits > 2 && thirdCharacter != null && char.IsDigit(thirdCharacter.Value))
                    {
                        if (maxDigits > 3 && fourthCharacter != null && char.IsDigit(fourthCharacter.Value))
                        {
                            value += int.Parse(fourthCharacter.ToString());
                            value += int.Parse(thirdCharacter.ToString()) * 10;
                            value += int.Parse(secondCharacter.ToString()) * 100;
                            value += int.Parse(firstCharacter.ToString()) * 1000;
                            remainingCharacters.Dequeue();
                            remainingCharacters.Dequeue();
                            remainingCharacters.Dequeue();
                        }
                        else
                        {
                            value += int.Parse(thirdCharacter.ToString());
                            value += int.Parse(secondCharacter.ToString()) * 10;
                            value += int.Parse(firstCharacter.ToString()) * 100;
                            remainingCharacters.Dequeue();
                            remainingCharacters.Dequeue();
                        }
                    }
                    else
                    {
                        value += int.Parse(secondCharacter.ToString());
                        value += int.Parse(firstCharacter.ToString()) * 10;
                        remainingCharacters.Dequeue();                        
                    }
                }
                else if (char.IsDigit(firstCharacter))
                {
                    value += int.Parse(firstCharacter.ToString());
                }
                else
                {
                    throwException();
                }

                return value;
            };

            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case TokenType.DayOfMonthTwoDigit:
                    case TokenType.DayOfMonth:
                        day = getNextDigit(2);
                        break;
                    case TokenType.MonthTwoDigit:
                    case TokenType.Month:
                        month = getNextDigit(2);
                        break;                        
                    case TokenType.YearFourDigit:
                    case TokenType.YearTwoDigit:
                    case TokenType.Year:
                        year = getNextDigit(token.Type == TokenType.YearFourDigit ? 4 : 2);
                        if (year < 1000)
                        {
                            year += (DateTime.Now.Year / 100) * 100;
                        }
                        break;
                    case TokenType.HourTwoDigit:
                    case TokenType.Hour:
                        hour += getNextDigit(2);
                        break;
                    case TokenType.MinuteTwoDigit:
                    case TokenType.Minute:
                        minute = getNextDigit(2);
                        break;
                    case TokenType.SecondTwoDigit:
                    case TokenType.Second:
                        second = getNextDigit(2);
                        break;
                    case TokenType.TenthSecond:
                        millisecond = getNextDigit(1) * 100;
                        break;
                    case TokenType.HundredthSecond:
                        millisecond = getNextDigit(2) * 10;
                        break;
                    case TokenType.Millisecond:
                        millisecond = getNextDigit(3);
                        break;
                    case TokenType.AmPmSingleDigit:
                    case TokenType.AmPm:
                    {
                        var firstCharacter = remainingCharacters.Dequeue();
                        var secondCharacter = remainingCharacters.Any() ? (char?)remainingCharacters.Peek() : null;
                        if (token.Type == TokenType.AmPm)
                        {
                            remainingCharacters.Dequeue();
                            if (secondCharacter != 'M')
                            {
                                throwException();
                            }                            
                        }
                        switch (firstCharacter)
                        {
                            case 'P':
                                if (hour != 12)
                                    hour += 12;
                                break;
                            case 'A':
                                hour = hour == 12 ? 0 : hour;
                                break;
                            default:
                                throwException();
                                break;
                        }
                        break;                        
                    }
                    case TokenType.Literal:
                    case TokenType.Escape:
                    {
                        var current = remainingCharacters.Dequeue();
                        if (current != token.Value)
                            throwException();
                        break;
                    }
                }
            }
            return new DateTime(year, month, day, hour, minute, second, millisecond);
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
            public char Value { get; set; }
        } 

        public enum TokenType
        {
            DayOfMonth,
            DayOfMonthTwoDigit,
            DayOfWeekName,
            Month,
            MonthTwoDigit,
            MonthName,
            MonthNameAbbreviated,
            Year,
            YearTwoDigit,
            YearFourDigit,
            Hour,
            HourTwoDigit,
            Minute,
            MinuteTwoDigit,
            Second,
            SecondTwoDigit,
            TenthSecond,
            HundredthSecond,
            Millisecond,
            AmPm,
            AmPmSingleDigit,
            Escape,
            Literal
        }
    }
}