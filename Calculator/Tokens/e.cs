using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class e : Token
    {
        public e() : base(-1, true, false) { }

        public override double eval(Stack<Token> inputStack)
        {
            return Math.E;
        }

        public override string ToString()
        {
            return "e";
        }
    }
}
