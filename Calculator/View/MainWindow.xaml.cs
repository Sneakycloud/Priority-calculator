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
using System.Windows.Media.Animation;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace Calculator.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private viewModel _vm = new viewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _vm;

            // Delete content in History.txt
            File.WriteAllText(@"C:\Users\Administratör\Source\Repos\Priority-calculator\Calculator\View\History.txt", String.Empty);
        }

        public void num_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            // add numbers
            _vm.Expression += btn.Content;
        }

        private void spc_Click(object sender, RoutedEventArgs e)
        {
            // add space
            _vm.Expression += " ";
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

            // Path to History.txt
            string fullPath = @"C:\Users\Administratör\Source\Repos\Priority-calculator\Calculator\View\History.txt";

            string ex = _vm.Expression + " = ";

            if (rm.IsChecked == true)
                vm.Calculator();
            else
                vm.RPN_Calculator();

            ex += _vm.Expression;
            // Add to History.txt
            using (StreamWriter sw = File.AppendText(fullPath))
            {
                sw.WriteLine(ex);
            }
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
            if ((string)btn.Content == "1st") // 1st state
            {
                btn.Content = "2nd";
                btn_op1.Content = "!";
                btn_op2.Content = "e";
                btn_op3.Content = "π";
                btn_op4.Content = "%";
                btn_op5.Content = "nCr";
                btn_op5.FontSize = 35;
                btn_op6.Content = "nPr";
                btn_op6.FontSize = 35;
                btn_op7.Content = "Max";
                btn_op7.FontSize = 35;
                btn_op8.Content = "Min";
                btn_op8.FontSize = 35;

            }
            else if ((string)btn.Content == "2nd") // 2nd state
            {
                btn.Content = "3rd";
                btn_op1.Content = "sin";
                btn_op1.FontSize = 35;
                btn_op2.Content = "cos";
                btn_op2.FontSize = 35;
                btn_op3.Content = "tan";
                btn_op3.FontSize = 35;
                btn_op4.Content = "log";
                btn_op4.FontSize = 35;
                btn_op5.Content = "arcsin";
                btn_op5.FontSize = 23;
                btn_op6.Content = "arccos";
                btn_op6.FontSize = 23;
                btn_op7.Content = "arctan";
                btn_op7.FontSize = 23;
                btn_op8.Content= "ln";
                btn_op8.FontSize = 35;
            }
            else if ((string)btn.Content == "3rd") // 3rd state
            {
                btn.Content = "1st";
                btn_op1.Content = "+";
                btn_op1.FontSize = 55;
                btn_op2.Content = "-";
                btn_op2.FontSize = 55;
                btn_op3.Content = "^";
                btn_op3.FontSize = 55;
                btn_op4.Content = "(";
                btn_op4.FontSize = 55;
                btn_op5.Content = "*";
                btn_op5.FontSize = 55;
                btn_op6.Content = "/";
                btn_op6.FontSize = 55;
                btn_op7.Content = "√";
                btn_op7.FontSize = 55;
                btn_op8.Content = ")";
                btn_op8.FontSize = 55;
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item.Name == "rm") // Regular mode
            {
                item.IsChecked = true;
                RPNm.IsChecked = false;

                // Space button not enabled
                btn_spc.IsEnabled = false;
                btn_spc.Opacity = 0.85;

                Title = "Calculator";
            }
            else // RPN mode
            {
                item.IsChecked = true;
                rm.IsChecked = false;

                // Space button is enabled
                btn_spc.IsEnabled = true;
                btn_spc.Opacity = 1;

                Title = "RPN Calculator";
            }
        }
    }
}
