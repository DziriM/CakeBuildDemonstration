using System;
using Xunit;

namespace MyLibrary.Tests
{
    public class CalculatorTests
    {
        private readonly ICalculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Theory]
        [InlineData(5, 4, 9)]
        [InlineData(2, 8, 10)]
        [InlineData(11, 2, 13)]
        [InlineData(1, 2, 3)]
        public void Add_ShouldWork(double x, double y, double expected)
        {
            double actual = _calculator.Add(x, y);
            
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(5, 4, 1)]
        [InlineData(10, 8, 2)]
        [InlineData(13, 2, 11)]
        [InlineData(1, 2, -1)]
        public void Subtract_ShouldWork(double x, double y, double expected)
        {
            double actual = _calculator.Subtract(x, y);
            
            Assert.Equal(expected, actual);
        }
    }
}