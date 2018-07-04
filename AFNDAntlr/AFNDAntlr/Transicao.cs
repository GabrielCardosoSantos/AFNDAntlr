using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AFNDAntlr
{
    class Transicao{
        private Estado origem;
        private Estado[] destino;
        private int nEstado;

        private char carac;

        public Transicao(){

        }

        public Transicao(Estado origem, Estado[] destino, int n, char letra){
            this.origem = origem;
            this.destino = destino;
            nEstado = n;
            carac = letra;
        }

        public char getCaracter()
        {
            return carac;
        }

    }
}
