using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;

namespace AFNDAntlr
{
    public class AFNDVisitor : AFNDBaseVisitor<String>
    {
        MultiMap<String, String> memory = new MultiMap<string, string>();
        
    }
}
