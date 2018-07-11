using System;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using System.IO;
using System.Collections.Generic;

namespace AFNDAntlr
{
    class Program
    {
        static void Main(string[] args)
        {
            string stream;
            Automato automato;
            bool sair = false;
            using (StreamReader arq = new StreamReader("gramatica.txt"))
                stream = arq.ReadLine();         

            //M=({a, b}, {q0, q1, q2, q3}, T, q0, {q1, q2}) T={q0,a=q0; q1,b=q0; q2,c={q1,q2}}

            AntlrInputStream input = new AntlrInputStream(stream);
            ITokenSource lexer = new AFNDLexer(input);
            ITokenStream token = new CommonTokenStream(lexer);
            AFNDParser parser = new AFNDParser(token);
            parser.BuildParseTree = true;
            IParseTree tree = parser.expr();
            AFNDVisitor visitor = new AFNDVisitor();
            Console.WriteLine(tree.ToStringTree(parser));
            visitor.Visit(tree);

            automato = visitor.GetAutomato();

            if (automato.valido)
            {
                Console.WriteLine("Automato valido.");
                while (!sair)
                {
                    Console.WriteLine("Informe a a frase teste: (S para sair)");
                    string s = Console.ReadLine();

                    if (!s.Equals("S"))
                    {
                        automato.Executar(s);
                    }
                    else
                    {
                        sair = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Automato inválido.");
            }

            Console.ReadKey();            
        }
    }
}
