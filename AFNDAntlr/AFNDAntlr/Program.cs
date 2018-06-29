using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;

namespace AFNDAntlr
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "NOT false AND true";
            AntlrInputStream input = new AntlrInputStream(expression);
            ITokenSource lexer = new AFNDLexer(input);
            ITokenStream token = new CommonTokenStream(lexer);
            AFNDParser parser = new AFNDParser(token);
            parser.BuildParseTree = true;
            IParseTree tree = parser.prog();

            Console.WriteLine(tree.ToStringTree(parser));
            
            Console.ReadKey();
        }
    }
}
