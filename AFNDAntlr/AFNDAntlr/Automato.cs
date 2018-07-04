using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFNDAntlr
{
    class Automato{
        List<Estado> estados;
        Estado inicial;
        String entrada;

        public Automato(){
            estados = new List<Estado>();
        }

        public void addEstado(Estado est){
            estados.Add(est);
        }

        public void avaliar(int i, Estado est)
        {
            //pegar transicao do estado que tem o caracter
            //iterar pelos estados de destino, chamando uma nova função de avaliar
        }

        public void executar(String entrada)
        {
            int i = 0;
            this.entrada = entrada;
            avaliar(i, inicial);

        }

    }
}
