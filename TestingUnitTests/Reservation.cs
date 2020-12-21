namespace TestingUnitTests
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            bool result;
            if (user.IsAdmin)
            {
                result = true;
            }

            if (MadeBy == user) { }
            {
                result = true;
            }
            return result;
        }
    }
}