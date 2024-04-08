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

            if (btnS == "C")
                tbx.Text = "";
            else if (btnS == "+" || btnS == "-" || btnS == "*" || btnS == "/")
                tbx.Text += " " + btn.Content + " ";
            //else if (btnS == "DEL")
                //tbx.Text = tbx.Text.Remove(TextBox.Text.LastIndexOf(','), 1);
            else
                tbx.Text += btn.Content;
        }
    }
}
