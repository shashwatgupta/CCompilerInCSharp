using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCompiler
{
    public class AssemblyCode
    {
        public List<string> ReturnStatement(Node node)
        {
            if (node.childNodes.Count != 1)
            {
                throw new InvalidOperationException();
            }

            List<string> x = new List<string>();
            x.Add(string.Format(" movl    ${0}, %eax", node.childNodes[0].NodeValue));
            x.Add("leave");
            x.Add("ret");
            return x;
        }

        public List<string> FunctionStatements(Node node)
        {
            if (node.childNodes.Count != 1)
            {
                throw new InvalidOperationException();
            }
            List<string> x = new List<string>();
            x.Add(string.Format("_{0}:",node.NodeValue));
            x.Add("pushl %ebp");
            x.Add("movl %esp, %ebp");
            x.Add("andl $-16, %esp");
            x.Add(string.Format("call ___{0}",node.NodeValue));
            x.AddRange(ReturnStatement(node.childNodes[0]));
            return x;
        }

        public List<string> ProgramNode(Node node)
        {
            if (node.childNodes.Count != 1)
            {
                throw new InvalidOperationException();
            }
            List<string> x = new List<string>();
            x.Add(".file \"test.c\"");
            x.Add(".text");
            x.Add(".def ___main;.scl 2; .type 32; .endef");
            x.Add(".p2align 4,,15");
            x.Add(".globl _main");
            x.Add(".def _main; .scl 2; .type 32; .endef");
            x.AddRange(FunctionStatements(node.childNodes[0]));
            return x;
        }

    }
}
