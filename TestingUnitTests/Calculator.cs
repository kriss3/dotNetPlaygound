using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingUnitTests
{
    public static class Calculator
    {
        public static double Add(double x, double y) 
        {
            return x + y;
        }

        public static double Subtact(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static double Divide(double x, double y)
        {
            return x / y; //watchout for y
        }
    }
}
