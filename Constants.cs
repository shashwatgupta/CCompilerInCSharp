using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCompiler
{
    class Constants
    {
        public const string  PatternOpenBrace = @"{";
        public const string  PatternCloseBrace = @"}";
        public const string  PatternOpenParen = @"\(";
        public const string  PatternCloseParen = @"\)";
        public const string  PatternSemiCol = @";";
        public const string  Patternint = @"int";
        public const string  Patternreturn = @"return";
        public const string  PatternIdenti = @"[a-zA-Z]\w*";
        public const string  PatternInteger = @"[0-9]+";
    }
}
