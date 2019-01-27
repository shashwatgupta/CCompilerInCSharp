using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCompiler
{
    public class CParser
    {
        public Node ParseIt(List<Token> tokens)
        {
            var tokenIterator = tokens.GetEnumerator();
            return Parse_Program(tokenIterator);
        }

        public Node Parse_Program(List<Token>.Enumerator tokenIterator)
        {
            Node programNode = new Node();
            programNode.NodeValue = "PRG";
            programNode.NodeType = "PROGRAM";
            programNode.childNodes = new List<Node>();
            programNode.childNodes.Add(Parse_function(ref tokenIterator));
            return programNode;
        }

        public Node Parse_function(ref List<Token>.Enumerator tokenIterator)
        {
            tokenIterator.MoveNext();
            Node functionNode = new Node();
            functionNode.NodeType = "FUNCTION";

            if (tokenIterator.Current.tokenType != TokenType.Patternint)
            {
                Fail();
            }

            tokenIterator.MoveNext();

            if (tokenIterator.Current.tokenType != TokenType.PatternFunIdenti)
            {
                Fail();
            }
            functionNode.NodeValue = tokenIterator.Current.tokenValue;
            tokenIterator.MoveNext();


            if (tokenIterator.Current.tokenType != TokenType.PatternOpenParen)
            {
                Fail();
            }

            tokenIterator.MoveNext();

            if (tokenIterator.Current.tokenType != TokenType.PatternCloseParen)
            {
                Fail();
            }

            tokenIterator.MoveNext();

            if (tokenIterator.Current.tokenType != TokenType.PatternOpenBrace)
            {
                Fail();
            }


            functionNode.childNodes = new List<Node>();
            functionNode.childNodes.Add( Parse_Statement(ref tokenIterator));
            tokenIterator.MoveNext();

            if (tokenIterator.Current.tokenType != TokenType.PatternCloseBrace)
            {
                Fail();
            }

            return functionNode;
        }

        public Node Parse_Statement(ref List<Token>.Enumerator tokenIterator)
        {
            Node statementNode = new Node();
            statementNode.NodeValue = "RET";
            statementNode.NodeType = "RETURN";

            tokenIterator.MoveNext();

            if (tokenIterator.Current.tokenType != TokenType.Patternreturn)
            {
                Fail();
            }
            statementNode.childNodes = new List<Node>();
            statementNode.childNodes.Add(Parse_Number(ref tokenIterator));
            return statementNode;
        }

        public Node Parse_Number(ref List<Token>.Enumerator tokenIterator)
        {
            tokenIterator.MoveNext();

            if (tokenIterator.Current.tokenType != TokenType.PatternInteger)
            {
                Fail();
            }


            Node numberNode = new Node();
            numberNode.NodeValue = tokenIterator.Current.tokenValue;
            numberNode.childNodes = null;
            numberNode.NodeType = "CONSTANT";


            tokenIterator.MoveNext();

            if (tokenIterator.Current.tokenType != TokenType.PatternSemiCol)
            {
                Fail();
            }

            return numberNode;
        }

        public void Fail()
        {
            throw new Exception("Invalid Program");
        }
    }
}
