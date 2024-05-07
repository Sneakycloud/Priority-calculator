using Calculator.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml.Schema;

namespace CalculatorTests.TokenTests
{
    public class TokenFactoryTests
    {
        //Test for the operators
        [Theory]

        [InlineData("+", typeof(AddOP))]
        [InlineData("-", typeof(SubOP))]
        [InlineData("*", typeof(MultOP))]
        [InlineData("/", typeof(DivOP))]
        [InlineData("%", typeof(ModuloOP))]
        [InlineData("^", typeof(ExpOP))]
        [InlineData("!", typeof(FactorialOP))]
        [InlineData("(", typeof(LeftParentheses))]
        [InlineData(")", typeof(RightParentheses))]
        [InlineData("π", typeof(Pi))]
        [InlineData("e", typeof(e))]
        [InlineData("npr", typeof(PermutationOP))]
        [InlineData("ncr", typeof(CombinationsOP))]
        [InlineData("sin", typeof(SinFunc))]
        [InlineData("cos", typeof(CosFunc))]
        [InlineData("tan", typeof(TanFunc))]
        [InlineData("arcsin", typeof(ArcSinFunc))]
        [InlineData("arccos", typeof(ArcCosFunc))]
        [InlineData("arctan", typeof(ArcTanFunc))]
        [InlineData("max", typeof(MaxFunc))]
        [InlineData("min", typeof(MinFunc))]
        [InlineData("ln", typeof(LnFunc))]
        [InlineData("log", typeof(LogFunc))]

        public void testTokenFactory_returnsExpectedType(string testInput, Type expectedType)
        {
            //Arrange

            //Act
            Token token = TokenFactory.createToken(testInput);

            //Assert
            Assert.IsType(expectedType, token);
        }




        //Test for Num
        [Theory]
        [InlineData(123)]
        [InlineData(4567)]
        [InlineData(0)]
        
        public void testTokenFactory_NumTest_returnsExpectedType(double numTestInput)
        {
            //Arrange
            Token expectedToken = new Num(numTestInput);

            //Act
            Token token = TokenFactory.createToken(numTestInput.ToString());

            //Assert
            token.Should().Be(expectedToken);
        }




        //Test that will fail
        [Theory]
        [InlineData("abc", typeof(AddOP))]
        [InlineData("abc", typeof(MultOP))]
        public void testTokenFactory_failTest_returnsFail(string failTestInput, Type expectedType)
        {
            //Arrange

            //Act
            Action test = () => { Token token = TokenFactory.createToken(failTestInput); };

            //Assert
            test.Should().Throw<Exception>();

        }
    }
}

