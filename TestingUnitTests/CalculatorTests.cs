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
            var actual = Calculator.Add(10, 10);
            //Act
            var expected = 20;
            //Assert
            Assert.Equal(expected, actual);

        }
    }
}
