using Microsoft.Win32;using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingUnitTests
{
    public class Reservation
    {
        public User MadeBy { get; set; }

        public bool CanBeCanceledBy(User user) 
        {
            bool result;
            if (user.isAdmin)
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
