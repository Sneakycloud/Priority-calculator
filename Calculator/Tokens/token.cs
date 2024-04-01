using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    abstract class token
    {
        public int priority { get; set; }

        public abstract double eval(Stack<token> inputStack);
        
    }
}
