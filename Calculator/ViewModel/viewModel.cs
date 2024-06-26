﻿using Calculator.Model;
using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModel
{
    public class viewModel : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Data binding for GUI
        public string _expression = string.Empty;
        public string Expression
        {
            get => _expression;
            set { _expression = value; OnPropertyChanged(); }
        }

        //Uses input expression as input and changes output expression, works as a relay
        public void Calculator()
        {
            try
            {
                double Result = EvaluateExpression(Expression);
                double rounded_result = Math.Round(Result,7);
                Expression = $"{rounded_result.ToString()}";
            }
            catch (Exception ex)
            {
                Expression = "Error: " + ex.Message;
            }
            
        }

        public double EvaluateExpression(string input)
        {
            // split the input expression into token elements and put it in a string queue
            Queue<string> parsedResult = Parser.ParseExpression(input);

            // convert string queue to token queue.
            Queue<Token> tokenQueue = TokenQueueConverter.createTokenQueue(parsedResult);

            // Converts the expression from infix to RPN
            Stack<Token> RPNstack = ShuntingYard.ToRPN(tokenQueue);

            // Starts a pop on th RPNstack which results in a chain reaction that returns the correct double value of the input
            double result = RPNstack.Pop().eval(RPNstack);

            //Check if the expression was completely evaluated
            if (RPNstack.Count >= 1 ) { throw new Exception("Invalid Expression"); }

            return result;
        }

        public void RPN_Calculator()
        {
            try
            {
                double Result = RPN_EvalutateExpression(Expression);
                double rounded_result = Math.Round(Result, 7);
                Expression = $"{rounded_result.ToString()}";
            }
            catch (Exception ex )
            {
                Expression = "Error: " + ex.Message;
            }
            
        }

        public double RPN_EvalutateExpression(string input)
        {
            //Splits
            string[] parsed = input.ToLower().Split(' ');

            //Makes it into a token queue
            Stack<Token> RPNstack = new Stack<Token>();
            foreach (string s in parsed)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    RPNstack.Push(TokenFactory.createToken(s));
                }
            }

            // Starts a pop on th RPNstack which results in a chain reaction that returns the correct double value of the input
            double result = RPNstack.Pop().eval(RPNstack);

            //Check if the expression was completely evaluated
            if (RPNstack.Count >= 1) { throw new Exception("Invalid Expression"); }

            return result;
        }

    }
}
