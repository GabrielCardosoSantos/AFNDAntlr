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
            {
                Estado e = estados.Find(n => n.getNome().Equals(s1));
                e.final = true;
                Console.WriteLine("Defini o estado " + e.getNome() + " como final.");
            }
                

            return base.VisitVFinais(context);
        }

        public override object VisitDet([NotNull] AFNDParser.DetContext context)
        {
            //q0,a=q0
            //q1,b = q0
            var est = context.GetText();
            string[] split = est.Split(new char[] { ',', '=', ' ' });
            
            Estado e = estados.Find(n => n.getNome().Equals(split[0]));

            if(e != null)
            {
                e.addTransicao(split[1][0], estados.Find(n => n.getNome().Equals(split[2])));   
                return base.VisitDet(context);
            }
            else
            {
                Console.WriteLine("Erro no automato.");
                return null;
            }

        }

        public override object VisitVInicial([NotNull] AFNDParser.VInicialContext context)
        {
            var est = context.GetText();
            automato.AddInicial(estados.Find(n => n.getNome().Equals(est)));
            return base.VisitVInicial(context);
        }

        public override object VisitNdet([NotNull] AFNDParser.NdetContext context)
        {
            var est = context.GetText();
            if (est != null)
            {
                string[] split = est.Split(new char[] { '{', '}', ',', '=', ' ' });
                Estado e = estados.Find(n => n.getNome().Equals(split[0]));
                for (int i = 2; i < split.Length; i++)
                {
                    if (!String.IsNullOrEmpty(split[i]))
                    {
                        e.addTransicao(split[1][0], estados.Find(n => n.getNome().Equals(split[i])));
                    }
                }
                automato.valido = true;
            }

            /*var origem = context.ESTADO(0);
            char carac = context.LETRA().GetText()[0];

            int i = 1;
            var dest = context.ESTADO(i);
            while (dest != null) {
                Estado e = estados.Find(n => n.getNome().Equals(origem.ToString()));
                if(e!=null)
                    e.addTransicao(carac, estados.Find(n => n.getNome().Equals(dest.ToString())));
                i++;
                dest = context.ESTADO(i);
            }*/
           
            return base.VisitNdet(context);
        }

        public Automato GetAutomato()
        {
            return automato;
        }
    }
}
