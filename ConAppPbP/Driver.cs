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

            SortAndReverseArray();

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
    }
}
