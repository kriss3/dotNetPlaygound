using System;
using static System.Console;

namespace ConAppPlayingWithStrings
{
    internal class Program
    {
        private static StringOperations Sop { get; set; }
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
            Sop = new StringOperations();
            VowelsStringOperation();           
        }

        private static void VowelsStringOperation() 
        {
            WriteLine(Sop.VowelsString());
        }
    }
}
