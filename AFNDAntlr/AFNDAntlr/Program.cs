using System;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using System.IO;

namespace AFNDAntlr
{
    class Program
    {
        static void Main(string[] args)
        {
            string stream = "M=({a, b}, {Q0, Q1}, Q0, {Q1})";
            AntlrInputStream input = new AntlrInputStream(stream);
            ITokenSource lexer = new AFNDLexer(input);
            ITokenStream token = new CommonTokenStream(lexer);
            AFNDParser parser = new AFNDParser(token);
            parser.BuildParseTree = true;
            IParseTree tree = parser.expr();

            Console.WriteLine(tree.ToStringTree(parser));

            Console.ReadKey();
            
            
        }
    }
}
