using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFNDAntlr
{
    class Automato{
        Estado inicial;
        String entrada;
        bool reconhecida;

        public Automato(){
            reconhecida = false;
        }

        public void addInicial(Estado est){
            inicial = est;
        }

        public void avaliar(int i, Estado est){
            if (i >= entrada.Length){
                if (est.final){
                    reconhecida = true;
                }
                return;
            }
              
            Console.WriteLine("Estado: " + est.getNome() + " Letra: " + entrada[i]);
            if (est.getDestino(entrada[i]) != null){
                foreach (Estado e in est.getDestino(entrada[i])){
                    Console.WriteLine("Vai para: " + e.getNome());
                    avaliar(i + 1, e);
                }
            }            
        }

        public void executar(String entrada)
        {
            reconhecida = false;
            int i = 0;
            this.entrada = entrada;
            avaliar(i, inicial);
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
