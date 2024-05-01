using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class Num : Token
    {
        private readonly double Value;

        public Num(double input) : base(-1,true, false) {
            Value = input;
        }

        public override double eval(Stack<Token> inputStack)
        {
            return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        //Special test for num to test the actual contained value
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;

            if ((obj as Num) == null || (obj as Num)!.Value != Value) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
