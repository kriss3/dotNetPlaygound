using System;
using Xunit;

using ConAppsExercises;

namespace TestingUnitTests 
{
    public class BankAccountTests
    {
        [Fact]
        public void TestExceptionThrowing()
        {
            //setup
            BankAccount ba = new("Kris", 0);
            //init
            try
            {
                ba.Debit(2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.Contains(e.Message, "Amount <=0 or Amount > Balanc");
                return;
            }
            catch (Exception e)
            {
                Assert.Contains(e.Message, "Balance is 0");
                return;
            }
            //assert
            Assert.Fail("No exception was thrown.");
        }
    }

}


