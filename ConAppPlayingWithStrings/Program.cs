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
            //VowelsStringOperation();
            CompareStrings();
        }

        private static void VowelsStringOperation() 
        {
            WriteLine(Sop.VowelsString());
        }

        private static void CompareStrings() 
        {
            WriteLine($"The string provided and reversed is the same: {Sop.IsReversedStringTheSame()}");
        }

        private static void ReverseWordsInString()
        {
            WriteLine($"The reversed string is: {Sop.ReverseWordsInString()}");
        }
    }
}
