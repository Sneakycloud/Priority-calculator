using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class Num : Token
    {
        public double Value { get; set; }

        public Num(double input) : base(-1) {
            this.Value = input;
        }

        public override double eval(Stack<Token> inputStack)
        {
            return this.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
