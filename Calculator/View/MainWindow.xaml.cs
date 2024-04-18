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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void num_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            // add numbers
            tbx.Text += btn.Content;
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            // delete all
            tbx.Text = "";
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            // delete one character
            if (tbx.Text != "")
                tbx.Text = tbx.Text.Remove(tbx.Text.Length - 1, 1);
        }

        private void equ_Click(object sender, RoutedEventArgs e)
        {

            // calculate and output the result
            
        }

        private void op_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            tbx.Text += " " + btn.Content + " ";
        }

    }
}
