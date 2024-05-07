using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class TanFunc : Token
    {
        public TanFunc() : base(0, true, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            //Invalid expression
            if (inputStack.Count == 0) { throw new InvalidOperationException(); }

            double value = inputStack.Pop().eval(inputStack);

            if(value % Math.PI == Math.PI/2) //Throws exception when undefined, i.e when the angle is a multiple of 90 degrees
            {
                throw new Exception();
            }

            return Math.Tan(value);
        }

        public override string ToString()
        {
            return "Tan";
        }
    }
}
