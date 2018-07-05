using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace AFNDAntlr
{
    public class AFNDVisitor : AFNDBaseVisitor<object>{

        List<Estado> estados = new List<Estado>();
        Estado inicial;
        List<Estado> finais = new List<Estado>();

        public override object VisitVEst([NotNull] AFNDParser.VEstContext context)
        {
            var est = context.ESTADO(0);
            if (est != null)
            {
                estados.Add(new Estado(est.GetText()));
            }
            for(int i=1;est != null; i++)
            {
                est = context.ESTADO(i);
            }
            return base.VisitVEst(context);
        }

        public override object VisitVFinais([NotNull] AFNDParser.VFinaisContext context)
        {
            var est = context.GetText();
            string s = est.Trim(new Char[] { '{', '}' });
            String[] split = s.Split(',');
            foreach (string s1 in split)
                finais.Add(new Estado(s1));

            return base.VisitVFinais(context);
        }

        public override object VisitVInicial([NotNull] AFNDParser.VInicialContext context)
        {
            var est = context.GetText();
            inicial = new Estado(est);
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

        public Estado GetInicial()
        {
            return inicial;
        }

        public List<Estado> GetFinais()
        {
            return finais;
        }


        public List<Estado> GetEstados()
        {
            return estados;
        }
    }
}
