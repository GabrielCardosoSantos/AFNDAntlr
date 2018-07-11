using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace AFNDAntlr
{
    public class AFNDVisitor : AFNDBaseVisitor<object>{
        Automato automato = new Automato();
        List<Estado> estados = new List<Estado>();

        public override object VisitVAlf([NotNull] AFNDParser.VAlfContext context)
        {
            var est = context.GetText();
            string s = est.Trim(new Char[] { '{', '}' });
            String[] split = s.Split(',');

            foreach (String aux in split)
                automato.AddAlfabeto(aux);
            
            return base.VisitVAlf(context);
        }

        public override object VisitVEst([NotNull] AFNDParser.VEstContext context)
        {
            // "{q0,q1,q2,q3}"
            var est = context.GetText();
            if (est != null)
            {
                string s = est.Trim(new Char[] { '{', '}' });
                String[] split = s.Split(',');
                foreach (string s1 in split)
                    estados.Add(new Estado(s1));
            }
            
            return base.VisitVEst(context);
        }

        public override object VisitVFinais([NotNull] AFNDParser.VFinaisContext context)
        {
            var est = context.GetText();
            string s = est.Trim(new Char[] { '{', '}' });
            String[] split = s.Split(',');
            foreach (string s1 in split)
                Console.WriteLine(s1);

            return base.VisitVFinais(context);
        }

        public override object VisitDet([NotNull] AFNDParser.DetContext context)
        {
            //q0,a=q0
            //q1,b = q0
            var est = context.GetText();
            string[] split = est.Split(new char[] { ',', '=', ' ' });
            Console.WriteLine(split);
            //Estado e = estados.Find(n => n.getNome().Equals(split[0]));

            /*if(e != null)
                e.addTransicao(split[1][0], new Estado(split[2]));
            if(inicial != null)
            {
                if (inicial.getNome().Equals(split[0]))
                {
                    inicial.addTransicao(split[1][0], new Estado(split[2]));
                }
            }*/
            return base.VisitDet(context);
        }

        public override object VisitVInicial([NotNull] AFNDParser.VInicialContext context)
        {
            var est = context.GetText();
            automato.AddInicial(new Estado(est));
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

        public Automato GetAutomato()
        {
            return automato;
        }
    }
}
