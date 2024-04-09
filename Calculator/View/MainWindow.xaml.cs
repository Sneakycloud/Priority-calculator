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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string btnS = (string)btn.Content;

            // delete all
            if (btnS == "C")
            {
                tbx.Text = "";
            }
            // delete one character
            else if (btnS == "DEL") 
            {
                if (tbx.Text != "")
                    tbx.Text = tbx.Text.Remove(tbx.Text.Length - 1, 1);
            }
            // calculate and output the result
            else if (btnS == "=")
            {
                viewModel.InputExpression = tbx.Text;
                tbx.Text = viewModel.OutputExpression;
            }
            // add the number / operation
            else
            {
                tbx.Text += btn.Content;
            }
        }
    }
}
