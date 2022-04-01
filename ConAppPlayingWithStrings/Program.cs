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
            //CompareStrings();
            //FindAnagrams();
            //SortAndRemoveDuplicatesFromString();
            PrintStarPattern();
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

        private static void ShowStringPaddingAndSubstring()
        {
            Sop.StringPaddingAndSubstring();
        }

        private static void FindAnagrams() 
        {
            Sop.FindAnagrams();
        }

        private static void SortAndRemoveDuplicatesFromString() 
        {
            //string example = "aacbkimp"
            WriteLine($"The result of the string operation: {Sop.SortAndRemoveStringWord()}");
        }

        private static void PrintStarPattern() 
        {
            Sop.PrintStarPattern(8);
        }
    }
}
