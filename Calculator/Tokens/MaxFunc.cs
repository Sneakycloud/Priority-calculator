using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class MaxFunc : Token
    {
        public MaxFunc() : base(0,true,true) { }

        public override double eval(Stack<Token> inputStack)
        {
            (double, double) values = getValues(inputStack);
            return values.Item1 > values.Item2 ? values.Item1 : values.Item2;
        }
        public override string ToString()
        {
            return "Max";
        }
    }
}
