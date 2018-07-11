using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace AFNDAntlr
{
    public class AFNDVisitor : AFNDBaseVisitor<object>{

        List<Estado> estados = new List<Estado>();
        String inicial;
        List<String> finais = new List<String>();

        public override object VisitVEst([NotNull] AFNDParser.VEstContext context)
        {
            var est = context.ESTADO(0);
            for (int i = 0; est != null; i++){
                
                est = context.ESTADO(i);
                if (est != null) {
                    estados.Add(new Estado(est.ToString()));
                }
            }

            return base.VisitVEst(context);
        }

        public override object VisitVFinais([NotNull] AFNDParser.VFinaisContext context)
        {
            var est = context.ESTADO(0);
            for (int i = 0; est != null; i++) {
                est = context.ESTADO(i);
                if (est != null) {
                    finais.Add(est.ToString());
                }
            }

            return base.VisitVFinais(context);
        }

        public override object VisitVInicial([NotNull] AFNDParser.VInicialContext context)
        {
            var est = context.ESTADO();
            inicial = est.ToString();
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

  

        public String GetInicial()
        {
            return inicial;
        }

        public List<String> GetFinais()
        {
            return finais;
        }

        public List<Estado> GetEstados()
        {
            return estados;
        }
    }
}
