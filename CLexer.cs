using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCompiler
{
    public class CLexer
    {

        public List<Token> LexIt(string input)
        {
            List<Token> tokens = new List<Token>();
            string s = string.Empty, d, x;

            foreach (char item in input)
            {
                string singleCharacter = string.Empty;
                singleCharacter += item;
                bool breakPattern = false;
                TokenType tokenType = TokenType.PatternOpenBrace;
                if (MatchPattern(singleCharacter, Constants.PatternOpenBrace, out d))
                {
                    tokenType = TokenType.PatternOpenBrace;
                    breakPattern = true;
                }
                else if (MatchPattern(singleCharacter, Constants.PatternCloseBrace, out d))
                {
                    tokenType = TokenType.PatternCloseBrace;
                    breakPattern = true;
                }
                else if (MatchPattern(singleCharacter, Constants.PatternOpenParen, out d))
                {
                    tokenType = TokenType.PatternOpenParen;
                    breakPattern = true;
                }
                else if (MatchPattern(singleCharacter, Constants.PatternCloseParen, out d))
                {
                    tokenType = TokenType.PatternCloseParen;
                    breakPattern = true;
                }
                else if (MatchPattern(singleCharacter, Constants.PatternSemiCol, out d))
                {
                    tokenType = TokenType.PatternSemiCol;
                    breakPattern = true;
                }

                if(item == ' ' || item == '\n' || item == '\t' || item == '\r')
                {
                    breakPattern = true;
                }

                if (breakPattern)
                {
                    if (MatchPattern(s, Constants.Patternint, out x))
                    {
                        tokens.Add(new Token() { tokenType = TokenType.Patternint, tokenValue = x });
                        s = string.Empty;
                    }
                    else if (MatchPattern(s, Constants.Patternreturn, out x))
                    {
                        tokens.Add(new Token() { tokenType = TokenType.Patternreturn, tokenValue = x });
                        s = string.Empty;
                    }
                    else if (MatchPattern(s, Constants.PatternIdenti, out x))
                    {
                        tokens.Add(new Token() { tokenType = TokenType.PatternFunIdenti, tokenValue = x });
                        s = string.Empty;
                    }
                    else if (MatchPattern(s, Constants.PatternInteger, out x))
                    {
                        tokens.Add(new Token() { tokenType = TokenType.PatternInteger, tokenValue = x });
                        s = string.Empty;
                    }
                    else if (string.IsNullOrWhiteSpace(input))
                    {
                        s = "";
                    }

                    if (!string.IsNullOrWhiteSpace(d))
                    {
                        tokens.Add(new Token() { tokenType = tokenType, tokenValue = d });
                        d = string.Empty;
                    }
                }

                s += item;
            }
      
            return tokens;
        }

        public bool MatchPattern(string s,string regex , out  string d)
        {
            d = string.Empty;
            Match m = Regex.Match(s, regex);
            if (m.Success)
            {
                d = m.Value;
                return true;
            }
            return false;
        }
    }
}
