using System.ComponentModel;

namespace Calculator.Tests
{
    public class CalcTests
    {
        [Fact]
        public void Sum_3_and_4_results_7()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(3, 4);

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 2, 3)]
        [InlineData(-5, -2, -7)]
        [InlineData(-5, 12, 7)]
        //[InlineData(-5, 19, 99)]
        [InlineData(0, 13, 13)]
        [InlineData(0, 14, 99)]
        public void Sum(int a, int b, int exp)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(a, b);

            //Assert
            Assert.Equal(exp, result);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }
    }
}