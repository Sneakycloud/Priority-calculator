using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// namespace declaration
namespace Calculator.Tokens
{
    // class declaration
    // the class AddOP inherits from the base class Token
    public class AddOP : Token          
    {

        // the constructor with priority order 0
        public AddOP() : base(0) { }


        // method to evaluate the add operation
        public override double eval(Stack<Token> inputStack)
        {
            // pop the first and second token from the inputStack and evaluate them recursively
            double eval1 = inputStack.Pop().eval(inputStack);
            double eval2 = inputStack.Pop().eval(inputStack);

            // return the sum of the two evaluated tokens
            return eval1 + eval2;
        }

        // override to return a string representation of the add token
        public override string ToString()
        {
            return "+";
        }
    }
}
