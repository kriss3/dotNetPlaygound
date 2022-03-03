
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

        [Fact]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsFalse() 
        {
            //Arrange
            Reservation res = new Reservation { MadeBy = new User()};
            //Act
            var actual = res.CanBeCancelledBy(new User());
            //Assert
            Assert.False(actual);
        }

        [Fact]
        public void CanBeCancelledBy_MadeByIsSameUser_ReturnsTrue() 
        {
            //Arrange
            User usr = new User();
            Reservation res = new Reservation { MadeBy = usr};
            //Act
            var actual = res.CanBeCancelledBy(usr);
            //Assert
            Assert.True(actual);
        }
    }
}
