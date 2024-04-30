using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class CombinationsOP : Token
    {
        public CombinationsOP() : base(3, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            (double, double) values = getValues(inputStack);
            //n = values.item2
            //k = values.item1

            if (values.Item2 < values.Item1) { throw new Exception(); }  //If you attempt to pick more things than available
            else if (values.Item2 < 0) { throw new Exception(); }        //If the total of items are negative
            else if (values.Item1 < 0) { throw new Exception(); }        //If the number of items being picked are negative

            return Factorial.Process(values.Item2) / (Factorial.Process(values.Item2 - values.Item1)*Factorial.Process(values.Item1));
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
