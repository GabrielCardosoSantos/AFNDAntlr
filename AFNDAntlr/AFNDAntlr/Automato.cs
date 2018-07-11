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
            alfabeto = new List<string>();
        }

        public void AddAlfabeto(String s)
        {
            alfabeto.Add(s);
        }

        public void AddInicial(Estado est)
        {
            inicial = est;
        }

        public void Avaliar(int i, Estado est){
            if (i >= entrada.Length - 1)
            {
                if (est.final){
                    reconhecida = true;
                }
                return;
            }
              
            Console.WriteLine("Estado: " + est.getNome() + " Letra: " + entrada[i]);

            if (est.getDestino(entrada[i]) != null)
            {
                foreach (Estado e in est.getDestino(entrada[i])){
                    Console.WriteLine("Vai para: " + e.getNome());
                    Avaliar(i + 1, e);
                }
            }            
        }

        public void Executar(String entrada)
        {
            reconhecida = false;
            int i = 0;
            this.entrada = entrada;
            Avaliar(i, inicial);
            if (reconhecida)
            {
                Console.WriteLine("Palavra reconhecida");
            }
            else
            {
                Console.WriteLine("Palavra nao reconhecia");
            }
        }

    }
}
