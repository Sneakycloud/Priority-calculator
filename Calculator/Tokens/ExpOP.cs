using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class ExpOP : Token
    {
        public ExpOP() : base(2) { }

        public override double eval(Stack<Token> inputStack)
        {
            (double, double) values = getValues(inputStack);
            return Math.Pow(values.Item2, values.Item1);
        }

        public override string ToString()
        {
            return "^";
        }
    }
}
