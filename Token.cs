using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCompiler
{
    public class Token
    {
        public TokenType tokenType;

        public string tokenValue;
    }

    public enum TokenType
    {
        PatternOpenBrace,

        PatternCloseBrace,

        PatternOpenParen,

        PatternCloseParen,

        PatternSemiCol,

        Patternint,

        Patternreturn,

        PatternFunIdenti,

        PatternInteger
    }
}
