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
            string stream = "M=({a, b}, {q0, q1, q2, q3}, T, q0, {q1, q2}) T={q0,a=q0; q1,b=q0; q2,c={q1,q2}}";
            AntlrInputStream input = new AntlrInputStream(stream);
            ITokenSource lexer = new AFNDLexer(input);
            ITokenStream token = new CommonTokenStream(lexer);
            AFNDParser parser = new AFNDParser(token);
            parser.BuildParseTree = true;
            IParseTree tree = parser.expr();
            AFNDVisitor visitor = new AFNDVisitor();
            Console.WriteLine(tree.ToStringTree(parser));
            visitor.Visit(tree);

            Automato aut = new Automato();



            Console.ReadKey();
            
            
        }
    }
}
