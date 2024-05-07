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
using Calculator.View;
using System.Windows.Automation;
using System.Reflection;

namespace CalculatorTests.ViewTests
{
    public class MainWindowTests
    {
        [Fact]
        public void TestNumericButton_Click()
        {
            // Arrange
            var mainWindow = new MainWindow();
            var viewModel = (viewModel)mainWindow.DataContext;

            Button numericButton1 = mainWindow.FindName("btn1") as Button;

            // Act
            mainWindow.num_Click(numericButton1, new RoutedEventArgs(Button.ClickEvent));

            // Assert
            viewModel.Expression.Should().Be("1"); // Check if the expression in the view model is updated correctly
        }
    }
}
