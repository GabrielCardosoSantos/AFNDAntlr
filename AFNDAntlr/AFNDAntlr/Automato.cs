using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFNDAntlr
{
    public class Automato{
        public Estado inicial;
        List<string> alfabeto;
        String entrada;
        public bool reconhecida;
        public bool valido;

        public Automato(){
            reconhecida = false;
            valido = false;
            alfabeto = new List<string>();
        }

        public void AddAlfabeto(String s)
        {
            alfabeto.Add(s);
        }

        public void AddInicial(Estado est)
        {
            Console.WriteLine("Defini o estado " + est.getNome() + " como estado inicial.");
            inicial = est;
        }

        public void Avaliar(int i, Estado est){
            if (i > entrada.Length - 1)
            {
                if (est.final){
                    reconhecida = true;
                    Console.WriteLine("Palavra reconhecida.");
                }
                Console.WriteLine("Fim da palavra.\n");
                return;
            }
             
            if (est.getDestino(entrada[i]) != null)
            {
                foreach (Estado e in est.getDestino(entrada[i])){
                    Console.WriteLine("Estado " + est.getNome() + ". Caracter '" + entrada[i] + "'. Posicao " + (i+1) + ".\nVai para estado " + e.getNome() + ".");
                    Avaliar(i + 1, e);
                }
            }
            else {
                Console.WriteLine("Estado " + est.getNome() + ". Caracter '" + entrada[i] + "'.");
                Console.WriteLine("Nao existe essa transicao.\n");
            }            
        }

        public void Executar(String entrada)
        {
            reconhecida = false;
            int i = 0;
            this.entrada = entrada;
            Console.WriteLine("Comecei a avaliar a palavra '" + entrada + "' a partir do estado " + inicial.getNome() + ".");
            Avaliar(i, inicial);
            if (reconhecida)
            {
                Console.WriteLine("Palavra reconhecida.");
            }
            else
            {
                Console.WriteLine("Palavra nao reconhecia.");
            }
        }

    }
}
