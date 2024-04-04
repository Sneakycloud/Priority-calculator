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
        public string InputExpression { get; set; } = string.Empty;
        public string OutputExpression { get; set; } = "Success";

        //Data binding for GUI
        public string _expression = string.Empty;
        public string Expression
        {
            get => _expression;
            set { _expression = value; OnPropertyChanged(); }
        }

        //Uses input expression as input and changes output expression
        public void calculator()
        {

            // split the input expression into token elements and put it in a string queue
            Queue<string> parsedResult = Parser.ParseExpression(InputExpression);

            // convert string queue to token queue.
            Queue<Token> tokenQueue = TokenQueueConverter.createTokenQueue(parsedResult);

            //Test for shuntingYard
            /*
            Queue<Token> tokenQueue = new Queue<Token>();
            tokenQueue.Enqueue(new Num(10));
            tokenQueue.Enqueue(new SubOP());
            tokenQueue.Enqueue(new Num(2));
            tokenQueue.Enqueue(new MultOP());
            tokenQueue.Enqueue(new Num(3));

            Stack<Token> RPNstack = ShuntingYard.ToRPN(tokenQueue);
            Console.WriteLine("The value was " + RPNstack.Pop().eval(RPNstack));
            */

        }

    }
}
