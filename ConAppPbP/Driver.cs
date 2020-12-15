using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
namespace ConAppPbP
{
    class Driver
    {
        static void Main()
        {
            WriteLine("===============");
            WriteLine("===== START =====");

            //InputValues();
            //ArrayWork();
            //SortAndReverseArray();
            //ManualSeak();
            //FindDuplicateCharacters();
            //StrReverseWithoutFnct();
            GetSentenceWordCount();
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


        private static void ArrayWork() {

            int[] myArr = {1,2,3,4,5,6,7,8,9,10};

            for (int i = myArr.Length - 1; i >= 0; i--) {
                //only drew even number of stars;
                PrintStar(myArr[i]);
                WriteLine();
            }
        
        }

        private static void PrintStar(int num) {
            for (int i = 0; i < num; i++) {
                Write("*");
            }
        }

        public static void SortAndReverseArray() 
        {
            int[] arr = {7,4,6,3,5,8,11,2,15,1};

            foreach (var item in arr)
            {
                Write($"{item} ");
            }

            WriteLine();
            WriteLine("==== Sort and Reverse ====\n");
            Array.Sort(arr);
            Array.Reverse(arr);

            foreach (var item in arr)
            {
                Write($"{item} ");
            }
        }

        private static void ManualSeak()
        {
            Write("What number to look for:\t");
            int find = int.Parse(ReadLine());
            int[] arr = { 7, 4, 6, 3, 5, 8, 11, 2, 15, 1 };
            Array.Sort(arr);
            WriteLine();
            foreach (var item in arr)
            {
                Write($"{item} ");
            }
            WriteLine();
            int low = 0;
            int high = arr.Length - 1;

            int midIdx = GetMidArrayIdx(low, high);


            while (low <= high) {
                if (arr[midIdx] < find)
                {
                    low = midIdx + 1;
                }
                else if (arr[midIdx] == find)
                {
                    Write($"Element to find: {find} was found on position: {midIdx}");
                    break;
                }
                else {
                    high = midIdx - 1;
                }
                midIdx = (low + high) / 2;
            }

            if (low > high) {
                Write($"The number: {find} is not part of the given array.");
            }
        }

        private static int GetMidArrayIdx(int low, int high) 
        {
            // int[] arr = { 7, 4, 6, 3, 5, 8, 11, 2, 15, 1 };
            //Sort: 1, 2, 3, 4, 5, 6, 7, 8, 11, 15
            //add check if arr not empty;
            return (low + high) / 2;
        }
        private static void FindDuplicateCharacters() 
        {
            string tstStr = "Konstantynopolitanczykiewiczowna";

            StringBuilder res = new StringBuilder();
            StringBuilder duplicates = new StringBuilder();

            foreach (var item in tstStr)
            {
                if (res.ToString().IndexOf(item.ToString().ToLower()) == -1)
                {
                    res.Append(item);
                }
                else {
                    duplicates.Append(item);
                }
            }
            //Count no of duplicates without removing current reoccuring charactes in duplicates;
            //improve using dictionary of letter and cout of occurance;
            WriteLine($"Number of duplicates: {duplicates.Length} and they are: {duplicates}.");
        }

        private static void StrReverseWithoutFnct() 
        {
            string example = "PleaseReverseThisString";
            string result = string.Empty;
            for (int i = example.Length - 1; i >= 0; i--) {
                result += example[i];
            }

            WriteLine();
            Write($"The reverse of {example} is: {result}");
        }

        private static void GetSentenceWordCount() 
        {
            string example = "Please test this sentence";

            example = example.Trim();

            var result = example.Split(' ').Length;
            WriteLine($"The sentence: {example} has {result} words.");
            
        }
    }
}
