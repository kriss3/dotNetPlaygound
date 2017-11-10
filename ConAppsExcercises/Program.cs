using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConAppsExcercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
            ReadLine();
        }

        public static void Run()
        {
            Helper h = new Helper();
            var r = h.ReverseVowels("Whyeeko");
            var k = h.GetPresidents();
            Write(@"Type word to check if Palindrom: ");
            var s = ReadLine();
            if (h.IsPalindrom(s))
            {
                WriteLine($"Word {s} is palindrom");
            }
            else
            {
                WriteLine($"Word {s} is not a palindrom");
            }
        }
    }
}
