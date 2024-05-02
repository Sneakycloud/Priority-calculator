using Calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace Calculator.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private viewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = (viewModel)this.DataContext;
        }

        private void num_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            // add numbers
            _vm.Expression += btn.Content;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            // delete all
            _vm.Expression = "";
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            // delete one character
            if (_vm.Expression != "")
                _vm.Expression = _vm.Expression.Remove(_vm.Expression.Length - 1, 1);
        }

        private void equ_Click(object sender, RoutedEventArgs e)
        {

            // calculate and output the result
            viewModel vm = (viewModel)this.DataContext;
            vm.Calculator();

        }

        private void op_Click(object sender, RoutedEventArgs e)
        {
            // register if you click an operation
            Button btn = (Button)sender;
            _vm.Expression += btn.Content;
        }

        private void tog_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if ((string)btn.Content == "1st")
            {
                btn.Content = "2nd";
                btn_op1.Content = "!";
                btn_op2.Content = "e";
                btn_op3.Content = "π";
                
                btn_op5.Content = "nCr";
                btn_op5.FontSize = 35;
                btn_op6.Content = "nPr";
                btn_op6.FontSize = 35;
                btn_op7.Content = "Max";
                btn_op7.FontSize = 35;

            } else if ((string)btn.Content == "2nd")
            {
                btn.Content = "1st";
                btn_op1.Content = "+";
                btn_op2.Content = "-";
                btn_op3.Content = "^";
                btn_op5.Content = "*";

                btn_op5.FontSize = 55;
                btn_op6.Content = "/";
                btn_op6.FontSize = 55;
                btn_op7.Content = "%";
                btn_op7.FontSize = 55;
            }
        }
    }
}
