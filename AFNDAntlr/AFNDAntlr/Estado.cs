using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;

namespace AFNDAntlr
{
    
    public class Estado{
        


        private Dictionary<char, List<Estado>> dic;
        public bool final;
        private String nome;

        public Estado(String nome)
        {
            dic = new Dictionary<char, List<Estado>>();
            
            this.nome = nome;
            this.final = final;
        }

        public void addTransicao(char c, Estado e)
        {
            if (dic.ContainsKey(c))
            {
                dic[c].Add(e);
            }
            else
            {
                dic.Add(c, new List<Estado>());
                dic[c].Add(e);
            }
        }

        public List<Estado> getDestino(char carac)
        {
            if (dic.ContainsKey(carac))
            {
                return dic[carac];
            }
            return null;
        }

        public String getNome()
        {
            return nome;
        }
    }

    
}
