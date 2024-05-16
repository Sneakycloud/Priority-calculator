using Calculator.Tokens;
using Calculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests.ViewModelTests
{
    public class ViewModelTests
    {
        [Theory]
        [InlineData("2 3 +", 5)]
        [InlineData("3 12 -", -9)]
        [InlineData("10 3 -", 7)]
        [InlineData("10 3 Max", 10)]
        public void ViewModel_RPN_EvalutateExpression_ReturnsDouble(string expression, double expected)
        {
            //Arrange
            viewModel vm = new viewModel();

            //Act
            double result = vm.RPN_EvalutateExpression(expression);

            //Assert
            result.Should().Be(expected);
        }
    }
}
