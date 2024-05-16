using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class ExpOP : Token
    {
        public ExpOP() : base(2, false, false) { }

        public override double eval(Stack<Token> inputStack)
        {
            (double, double) values = getValues(inputStack);

            if(values.Item2 < 0 && !(Math.Abs(values.Item1 % 1) <= (Double.Epsilon * 100)))
            {
                throw new Exception($"Cannot handle imaginary numbers, attempted to take {values.Item2} to the power of {values.Item1}");
            }

            return Math.Pow(values.Item2, values.Item1);
        }

        public override string ToString()
        {
            return "^";
        }
    }
}
