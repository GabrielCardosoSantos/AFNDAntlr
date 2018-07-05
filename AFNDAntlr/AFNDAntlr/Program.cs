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
            using (StreamReader arq = new StreamReader("gramatica.txt")) {
                stream = arq.ReadLine();
            }
            List<Estado> est = new List<Estado>();

            //M=({a, b}, {q0, q1, q2, q3}, T, q0, {q1, q2}) T={q0,a=q0; q1,b=q0; q2,c={q1,q2}}

            AntlrInputStream input = new AntlrInputStream(stream);
            ITokenSource lexer = new AFNDLexer(input);
            ITokenStream token = new CommonTokenStream(lexer);
            AFNDParser parser = new AFNDParser(token);
            parser.BuildParseTree = true;
            IParseTree tree = parser.expr();
            AFNDVisitor visitor = new AFNDVisitor();
            visitor.iniciar();
            Console.WriteLine(tree.ToStringTree(parser));
            visitor.Visit(tree);

            est = visitor.getEstados();


            Estado q0 = new Estado("q0");
            Estado q1 = new Estado("q1");
            Estado q2 = new Estado("q2");
            Estado q3 = new Estado("q3");


            q0.addTransicao('a', q1);
            
            q1.addTransicao('a', q1);
            q1.addTransicao('b', q1);

            q0.addTransicao('a', q2);

            q1.addTransicao('c', q3);
            q3.addTransicao('a', q1);

            q2.addTransicao('c', q1);

            Automato aut = new Automato();
            aut.addInicial(q0);

            aut.executar("acbaca");



            Console.ReadKey();
            
            
        }
    }
}
