using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class SubOP : Token
    {
        public SubOP() : base(0, true, false) { }

        public override double eval(Stack<Token> inputStack)
        {
            (double, double) values = getValues(inputStack);
            return values.Item2 - values.Item1;
        }

        public override string ToString()
        {
            return "-";
        }
    }
}
