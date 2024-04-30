﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tokens
{
    public class Pi : Token
    {
        public Pi() : base(-1, true) { }

        public override double eval(Stack<Token> inputStack)
        {
            return Math.PI;
        }

        public override string ToString()
        {
            return "π";
        }
    }
}
