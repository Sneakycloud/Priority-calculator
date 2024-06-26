﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class ModuloOP : Token
    {
        public ModuloOP() : base(1, true, false) { }

        public override double eval(Stack<Token> inputStack)
        {
            (double, double) values = getValues(inputStack);
            if(values.Item1 == 0) { throw new Exception($"Undefined"); }
            return values.Item2 % values.Item1;
        }

        public override string ToString()
        {
            return "%";
        }
    }
}
