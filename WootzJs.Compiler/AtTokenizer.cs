using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WootzJs.Compiler.JsAst;

namespace WootzJs.Compiler
{
    public static class AtTokenizer
    {
        public static JsSnippetExpression Interpolate(string pattern, IDictionary<string, JsExpression> argumentsByParameterName)
        {
            var tokens = Tokenize(pattern).ToArray();
            var parts = new List<JsExpression>();
            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case AtTokenType.Literal:
                        parts.Add(new JsNativeExpression(token.Literal));
                        break;
                    case AtTokenType.Variable:
                        if (!argumentsByParameterName.ContainsKey(token.Identifier))
                            throw new Exception("Found '@" + token.Identifier + "' but no parameter with that name was found.");
                        parts.Add(argumentsByParameterName[token.Identifier]);
                        break;
                }
            }
            return new JsSnippetExpression(parts.ToArray());
        }

        public static IEnumerable<AtToken> Tokenize(string s)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                switch (c)
                {
                    case '@':
                        if (i < s.Length - 1 && s[i + 1] == '@')
                        {
                            builder.Append(c);
                            i++;
                        }
                        else
                        {
                            if (builder.Length > 0)
                            {
                                var literal = builder.ToString();
                                var literalToken = new AtToken { Type = AtTokenType.Literal, Literal = literal };
                                yield return literalToken;
                                builder.Length = 0;
                            }
                            i++;
                            for (var j = i; j < s.Length; j++)
                            {
                                var innerC = s[j];
                                if (char.IsLetterOrDigit(innerC))
                                {
                                    i++;
                                    builder.Append(innerC);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            var identifier = builder.ToString();
                            var variableToken = new AtToken { Type = AtTokenType.Variable, Identifier = identifier };
                            yield return variableToken;
                            builder.Length = 0;
                            i--;
                        }
                        break;
                    default:
                        builder.Append(c);
                        break;
                }
            }
            if (builder.Length > 0)
            {
                var literal = builder.ToString();
                var literalToken = new AtToken { Type = AtTokenType.Literal, Literal = literal };
                yield return literalToken;
            }
        }

        public class AtToken
        {
            public AtTokenType Type { get; set; }
            public string Literal { get; set; }
            public string Identifier { get; set; }
        }
 
        public enum AtTokenType
        {
            Literal, Variable
        }
    }
}