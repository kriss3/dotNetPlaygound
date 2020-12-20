﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Console;
namespace ConAppPbP
{
    class Driver
    {
        static void Main()
        {
            WriteLine("=================");
            WriteLine("===== START =====");
            DisplayMenu();
            WriteLine("Bye!!");
        }

        private static void DisplayMenu() {
            Action funcToRun = null;
            string answer;
            do
            {
                Clear();
                Write("==================\n");
                Write("1. Execute InputValues()\n");
                Write("2. Execute ArrayWork()\n");
                Write("3. Execute SortAndReverseArray()\n");
                Write("4. Execute ManualSeak()\n");
                Write("5. Execute FindDuplicateCharacters()\n");
                Write("6. Execute StrReverseWithoutFnct()\n");
                Write("7. Execute GetSentenceWordCount()\n");
                Write("8. Execute WordLetterCount()\n");
                Write("9. Execute SwapNumbers()\n");
                Write("10. Execute RunSingleton()\n");
                Write("11. Execute CountFactorial()\n");
                Write("12. Execute PrintStarTraingles()\n");
                Write("13. Execute SimpleLinkedList()\n");
                Write("14. Execute NumberReverseOrder()\n");
                Write("15. Execute InsertToBinarchSearch()\n");
                Write("=======================\n");
                Write("Your choice is: ");

                var choice = int.Parse(ReadLine());
                WriteLine($"Executing: {choice}");
                switch (choice)
                {
                    case 1:
                        funcToRun = InputValues;
                        break;
                    case 2:
                        funcToRun = ArrayWork;
                        break;
                    case 3:
                        funcToRun = SortAndReverseArray;
                        break;
                    case 4:
                        funcToRun = ManualSeak;
                        break;
                    case 5: 
                        funcToRun = FindDuplicateCharacters;
                        break;
                    case 6:
                        funcToRun = StrReverseWithoutFnct;
                        break;
                    case 7:
                        funcToRun = GetSentenceWordCount;
                        break;
                    case 8:
                        funcToRun = WordLetterCount;
                        break;
                    case 9:
                        funcToRun = SwapNumbers;
                        break;
                    case 10:
                        funcToRun = RunSingleton;
                        break;
                    case 11:
                        funcToRun = CountFactorial;
                        break;
                    case 12: 
                        funcToRun = PrintStarTraingles;
                        break;
                    case 13:
                        funcToRun = SimpleLinkedList;
                        break;
                    case 14:
                        funcToRun = NumberReverseOrder;
                        break;
                    case 15:
                        funcToRun = BTSTreeImplementation;
                        break;
                    default:
                        WriteLine("Unknown choice.");
                        break;
                }

                funcToRun();

                Write("Again? [y/n]:\t");
                answer = ReadLine();
            }
            while (answer.ToUpper() == "Y");
        }

        private static void InputValues()
        {
            Clear();
            PrintMethodHeader("InputValues()");
            Write("Enter string: ");
            string s = ReadLine();
            WriteLine();
            Write("Enter Double: ");
            string d = ReadLine();
            WriteLine();
            Write("Enter Integer:  ");
            string i = ReadLine();
            WriteLine();

            WriteLine($"String is: {s.Trim()}");
            WriteLine($"Double is: {d:2}");
            WriteLine($"Int is: {i}");
        }

        private static void ArrayWork()
        {
            Clear();
            PrintMethodHeader("ArrayWork()");
            int[] myArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            for (int i = myArr.Length - 1; i >= 0; i--)
            {
                //only drew even number of stars;
                PrintStar(myArr[i]);
                WriteLine();
            }

        }

        private static void PrintStar(int num)
        {
            Clear();
            PrintMethodHeader("PrintStar()");
            for (int i = 0; i < num; i++)
            {
                Write("*");
            }
        }

        public static void SortAndReverseArray()
        {
            Clear();
            PrintMethodHeader("SortAndReverseArray()");
            int[] arr = { 7, 4, 6, 3, 5, 8, 11, 2, 15, 1 };

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
            Clear();
            PrintMethodHeader("ManualSeak()");
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


            while (low <= high)
            {
                if (arr[midIdx] < find)
                {
                    low = midIdx + 1;
                }
                else if (arr[midIdx] == find)
                {
                    Write($"Element to find: {find} was found on position: {midIdx}");
                    break;
                }
                else
                {
                    high = midIdx - 1;
                }
                midIdx = (low + high) / 2;
            }

            if (low > high)
            {
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
            Clear();
            PrintMethodHeader("FindDuplicateCharacters()");
            string tstStr = "Konstantynopolitanczykiewiczowna";

            StringBuilder res = new StringBuilder();
            StringBuilder duplicates = new StringBuilder();

            foreach (var item in tstStr)
            {
                if (res.ToString().IndexOf(item.ToString().ToLower()) == -1)
                {
                    res.Append(item);
                }
                else
                {
                    duplicates.Append(item);
                }
            }
            //Count no of duplicates without removing current reoccuring charactes in duplicates;
            //improve using dictionary of letter and cout of occurance;
            WriteLine($"Number of duplicates: {duplicates.Length} and they are: {duplicates}.");
        }

        private static void WordLetterCount()
        {
            Clear();
            PrintMethodHeader("WordLetterCount()");
            string example = "Brzeczyszczykiewicz";

            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach (var item in example)
            {
                if (!result.ContainsKey(item))
                {
                    result.Add(item, 1);
                }
                else
                {
                    result[item]++;
                }

            }

            WriteLine();
            WriteLine($"Word to analyse is: {example}");
            foreach (var item in result)
            {
                WriteLine($"Letter: {item.Key} occurses {item.Value} times");
            }

        }

        private static void StrReverseWithoutFnct()
        {
            Clear();
            PrintMethodHeader("StrReverseWithoutFnct()");
            string example = "PleaseReverseThisString";
            string result = string.Empty;
            for (int i = example.Length - 1; i >= 0; i--)
            {
                result += example[i];
            }

            WriteLine();
            Write($"The reverse of {example} is: {result}");
        }

        private static void GetSentenceWordCount()
        {
            Clear();
            PrintMethodHeader("GetSentenceWordCount()");
            string example = "Please test this sentence";
            example = example.Trim();
            var result = example.Split(' ').Length;
            WriteLine($"The sentence: {example} has {result} words.");
        }

        private static void SwapNumbers()
        {
            Clear();
            PrintMethodHeader("SwapNumbers()");
            Write("Supply value x: ");
            int x = int.Parse(ReadLine());
            Write("Supply value y: ");
            int y = int.Parse(ReadLine());
            WriteLine();
            Write($"Value x: {x} and value y: {y}");

            x = x + y;
            y = x - y;
            x = x - y;

            WriteLine($"Values of x and y after the swap without temp variable, x = {x} and y = {y}");

        }

        private static void RunSingleton()
        {
            Clear();
            PrintMethodHeader("RunSingleton()");
            var res1 = SingletonExample.Instance();
            var res2 = SingletonExample.Instance();

            //Testing
            if (res1 == res2)
            {
                WriteLine($"Objects res1 and res2 of type {res1.GetType().Name} are the same instance");
            }
        }

        private static void SimpleLinkedList() 
        {
            Clear();
            PrintMethodHeader("SimpleLinkedList() ");
            LinkedList<string> _linkedLst = new LinkedList<string>();

            _linkedLst.AddLast("Kris");
            _linkedLst.AddLast("Peter");
            _linkedLst.AddLast("Mat");
            _linkedLst.AddLast("Aga");
            _linkedLst.AddLast("Robin");
            _linkedLst.AddLast("Kris");

            WriteLine("Initial list of LinkedList elements:");

            foreach (var item in _linkedLst)
            {
                WriteLine($"The name is: {item}");
            }

            _linkedLst.Remove(_linkedLst.First);

            foreach (var item in _linkedLst)
            {
                WriteLine($"The name is: {item}");
            }

            _linkedLst.RemoveLast();

            foreach (var item in _linkedLst)
            {
                WriteLine($"The name is: {item}");
            }

            var elemToFind = "Peter";
            var numberOfElemsFound = 0;
            foreach (var item in _linkedLst)
            {
                if (item.Equals(elemToFind)) 
                {
                    WriteLine($"Found {elemToFind}...Increment");
                    numberOfElemsFound++;
                }
            }

            WriteLine($"Number of items with Value: {elemToFind} is {numberOfElemsFound}");
        }

        public static void PrintStarTraingles()
        {
            Clear();
            Write("Enter number of rows:\t");
            int rows = int.Parse(ReadLine());

            int spc = rows + 3;
            for (int i = 1; i <= rows; i++)
            {
                for (int j = spc; j >= 1; j--)
                {
                    Write(" ");
                }

                for (int k = 1; k <= i; k++)
                {
                    Write("* ");
                }
                Write("\n");
                spc--;
            }

        }

        private static void CountFactorial() 
        {
            Clear();
            PrintMethodHeader("CountFactorial()");
            Write("Enter factorial base to count: ");
            int val = int.Parse(ReadLine());
            int fac = 1;
            for (int i = 1; i <= val; i++)
            {
                fac *= i;
            }
            WriteLine($"The results of factorial of the base: {val} is {fac}");
        }

        private static void NumberReverseOrder() 
        {
            Clear();
            PrintMethodHeader("NumberReverseOrder");
            Write("Enter number to reverse: ");
            var input = ReadLine();
            char[] inputC = input.ToArray();
            Array.Reverse(inputC);

            foreach (var i in inputC) 
            {
                Write(i);
            }
        }

        private static void BTSTreeImplementation() 
        {
            Clear();
            PrintMethodHeader(MethodBase.GetCurrentMethod().Name);
            Node root = null;
            InsertToBinaryTree(ref root, 50);
            InsertToBinaryTree(ref root, 17);
            InsertToBinaryTree(ref root, 23);
            InsertToBinaryTree(ref root, 12);
            InsertToBinaryTree(ref root, 19);
            InsertToBinaryTree(ref root, 54);
            InsertToBinaryTree(ref root, 9);
            InsertToBinaryTree(ref root, 14);
            InsertToBinaryTree(ref root, 67);
            InsertToBinaryTree(ref root, 76);
            InsertToBinaryTree(ref root, 72);
        }


        private static void InsertToBinaryTree(ref Node root, int nodeVal) 
        {
      
            Node newNode = new Node { Data = nodeVal};

            if (root == null)
            {
                root = newNode;
            }
            else 
            {
                Node current = root;
                Node parent;

                while (true) 
                {
                    parent = current;
                    if (nodeVal < current.Data)
                    {
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            WriteLine($"Inserted Node with {parent.Left.DisplayNode()}");
                            break;
                        }
                    }
                    else
                    {
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            WriteLine($"Inserted Node with {parent.Right.DisplayNode()}");
                            break;
                        }
                    }
                 }
            }
        }

        private static void PrintMethodHeader(string s) 
        {
            WriteLine($"========= {s} ==========");
        }

    }
}
