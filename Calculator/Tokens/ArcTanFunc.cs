using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class ArcTanFunc : Token
    {
        public ArcTanFunc() : base(0, true, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            //Invalid expression
            if (inputStack.Count == 0) { throw new InvalidOperationException(); }

            double value = inputStack.Pop().eval(inputStack);

            if(value == double.PositiveInfinity || value == double.NegativeInfinity) {  throw new InvalidOperationException(); }

            return Math.Atan(value);
        }

        public override string ToString()
        {
            return "ArcTan";
        }
    }
}
