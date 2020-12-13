using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
namespace ConAppPbP
{
    class Program
    {
        static void Main()
        {
            WriteLine("===============");
            WriteLine("===== START =====");

            InputValues();

            ReadLine();
        }

        private static void InputValues() 
        {
            string s = ReadLine();
            string d = ReadLine();
            string i = ReadLine();


            WriteLine($"String is: {s.Trim()}");
            WriteLine($"Double is: {d:2}");
            WriteLine($"Int is: {i}");
        }
    }
}
