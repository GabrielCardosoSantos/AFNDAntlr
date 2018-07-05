using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace AFNDAntlr
{
    public class AFNDVisitor : AFNDBaseVisitor<object>{
        private List<Estado> listaEst;
        private List<String> listaFinais;
        private String inicial;
        public void iniciar() {
            listaEst = new List<Estado>();
            listaFinais = new List<String>();
        }

        public List<Estado> getEstados() {
            return listaEst;
        }

        public List<string> getFinais() {
            return listaFinais;
        }

        public String getInicial() {
            return inicial;
        }

        public override object VisitVEst([NotNull] AFNDParser.VEstContext context)
        {
            var est = context.ESTADO(0);
            if (est != null)
            {
                Estado e = new Estado(est.ToString());
                listaEst.Add(e);
                Console.WriteLine(e.getNome());
            }
            for(int i=1;est != null; i++)
            {
                est = context.ESTADO(i);
                Console.WriteLine(est);
            }
            return base.VisitVEst(context);
        }

        public override object VisitVFinais([NotNull] AFNDParser.VFinaisContext context) {
            var est = context.ESTADO(0);
            if (est != null) {
                
                listaFinais.Add(est.ToString());
                Console.WriteLine(est.ToString());
            }
            for (int i = 1; est != null; i++) {
                est = context.ESTADO(i);
                Console.WriteLine(est);
            }
            return base.VisitVFinais(context);
        }

        public override object VisitVInicial([NotNull] AFNDParser.VInicialContext context) {
            
            var est = context.ESTADO();
            if(est != null) {
                inicial = est.ToString();
                Console.WriteLine(est);
            }
            return base.VisitVInicial(context);
        }

        public override object VisitNdet([NotNull] AFNDParser.NdetContext context)
        {
            var est = context.ESTADO(2);
            if (est != null) {
                Console.WriteLine("Eh um AFND");
            }
            return base.VisitNdet(context);
        }
    }
}
