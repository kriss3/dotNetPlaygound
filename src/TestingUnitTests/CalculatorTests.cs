using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
namespace TestingUnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_AddsCorrectlyTwoNumber_ReturnsNumber() 
        {
            //Arrange
            double expected = 20;
            //Act
            var actual = Calculator.Add(10, 10);
            //Assert
            Assert.Equal(expected, actual);

        }
        [Fact]
        public void Subtrac_SubtractCorrectlyTwoNumber_ReturnsNumber()
        {
            //Arrange
            double expected = 20;
            //Act
            var actual = Calculator.Subtact(30, 10);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Multiply_MultiplyCorrectlyTwoNumber_ReturnsNumber()
        {
            //Arrange
            double expected = 300;
            //Act
            var actual = Calculator.Multiply(30, 10);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_DivideCorrectlyTwoNumber_ReturnsNumber()
        {
            //Arrange
            double expected = 10;
            //Act
            var actual = Calculator.Divide(100, 10);
            //Assert
            Assert.Equal(expected, actual);
        }


    }
}
