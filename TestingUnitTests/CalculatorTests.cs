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
        public void Subtrac_SubtracksCorrectlyTwoNumber_ReturnsNumber()
        {
            //Arrange
            double expected = 20;
            //Act
            var actual = Calculator.Subtack(30, 10);
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
