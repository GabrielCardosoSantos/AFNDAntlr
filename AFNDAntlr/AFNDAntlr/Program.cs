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
            List<Estado> estados;
            String inicial;
            List<String> finais;

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
         
            estados = visitor.GetEstados();
            inicial = visitor.GetInicial();
            finais = visitor.GetFinais();
            
            foreach(String f in finais) {
                foreach(Estado e in estados) {
                    if(e.getNome() == f) {
                        e.final = true;
                    }
                }
            }

            Automato aut = new Automato();

            foreach(Estado e in estados) {
                if(e.getNome() == inicial) {
                    aut.addInicial(e);
                }
            }
            
            
            Console.WriteLine("Informe a frase teste: ");
            string s = Console.ReadLine();

            aut.executar(s);



            Console.ReadKey();
            
            
        }
    }
}
