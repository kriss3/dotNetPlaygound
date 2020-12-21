
using System;
using Xunit;

namespace TestingUnitTests
{
    public class ReservationTests
    {
        [Fact]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //Arrange
            Reservation res = new Reservation();
            //Act
            var actual = res.CanBeCancelledBy(new User { IsAdmin = true});
            //Assert
            Assert.True(actual);
        }
    }
}
