using System;
using ConAppsExcercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
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
                StringAssert.Contains(e.Message, "Amount <=0 or Amount > Balanc");
                return;
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Balance is 0");
                return;
            }
            //asert
            Assert.Fail("No exception was thrown.");
        }
    }
}
