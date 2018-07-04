using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace AFNDAntlr
{
    public class AFNDVisitor : AFNDBaseVisitor<object>{
        public override object VisitVEst([NotNull] AFNDParser.VEstContext context)
        {
            var est = context.ESTADO(0);
            if (est != null)
            {
                Console.WriteLine(est);
            }
            for(int i=1;est != null; i++)
            {
                est = context.ESTADO(i);
                Console.WriteLine(est);
            }
            return base.VisitVEst(context);
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
