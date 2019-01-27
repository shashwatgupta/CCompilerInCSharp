using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            CLexer clex = new CLexer();
            Console.WriteLine(args[0]);
            var tokens = clex.LexIt(File.ReadAllText(args[0]));
            foreach (var token in tokens)
            {
                Console.WriteLine(token.tokenType + " " + token.tokenValue);
            }


            CParser cParser = new CParser();
            Node x = cParser.ParseIt(tokens);

            AssemblyCode assemblyCode = new AssemblyCode();
            var d = assemblyCode.ProgramNode(x);

            TextWriter tw = new StreamWriter("output.S");

            foreach (String s in d)
                tw.WriteLine(s);

            tw.Close();

        }
    }
}
