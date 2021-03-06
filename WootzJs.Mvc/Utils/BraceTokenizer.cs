﻿using System;
using System.Collections.Generic;

namespace WootzJs.Mvc.Utils
{
    public static class BraceTokenizer
    {
        public static IEnumerable<IToken> BraceTokenize(this string s)
        {
            int index = 0;
            while (index < s.Length)
            {
                var lastIndex = index;
                index = s.IndexOf('{', lastIndex);
                if (index == -1)
                {
                    if (lastIndex < s.Length)
                    {
                        yield return new Literal { Value = s.Substring(lastIndex) };
                    }
                    yield break;
                }
                if (index > lastIndex)
                {
                    yield return new Literal { Value = s.Substring(lastIndex, index - lastIndex) };
                }
                var start = index + 1;
                if (start >= s.Length)
                    throw new Exception("No ending brace found");

                var end = s.IndexOf('}', start);
                if (end == -1)
                    throw new Exception("No ending brace found");

                var variable = s.Substring(start, end - start);
                var variableParts = variable.Split(':');
                yield return new Variable { Id = variableParts[0], Value = variableParts[1] };

                index = end + 1;
            }
        }
        
        public interface IToken
        {
            string Literal { get; }
            string VariableId { get; }
            string VariableValue { get; }
        }

        public class Literal : IToken
        {
            public string Value { get; set; }

            string IToken.Literal
            {
                get { return Value;  }
            }

            string IToken.VariableId
            {
                get { return null; }
            }

            string IToken.VariableValue
            {
                get { return null; }
            }
        }

        public class Variable : IToken
        {
            public string Id { get; set; }
            public string Value { get; set; }

            string IToken.Literal
            {
                get { return null;  }
            }

            string IToken.VariableId
            {
                get { return Id; }
            }

            string IToken.VariableValue
            {
                get {  return Value; }
            }
        }
    }
}