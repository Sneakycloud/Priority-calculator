using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class DivOP : Token
    {
        // the constructor DivOP with priority order 1
        public DivOP() : base(1) { }

        public override double eval(Stack<Token> inputStack)
        {
            (double, double) values = getValues(inputStack);

            //Divide by 0 check
            if(values.Item1 == 0)
            {
                throw new Exception();
            }

            // return the quota of the two evaluated tokens
            return values.Item2 / values.Item1;
        }


        // override to return a string representation of the div token
        public override string ToString()
        {
            return "/";
        }
    }
}
