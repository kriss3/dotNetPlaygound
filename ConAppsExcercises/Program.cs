using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using static System.Console;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConAppsExcercises
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyEvents();
            //Run();
            //Run2(10);
            //reverseString("konstantynopolitanczykowna");
            //removeVowels("HellO");
            //FindDelimiterOccurance("ABCDE", "DC");
            //ReverseSentence("Ala ma kota");
            //CardDeckShuffler();
            //GetDataFromDb();
            //Task.Run(async () => await getPeopleFromWeb());
            //reverseArrayCheck(10);
            //stringsOperations("pasta");
            //Shuffle(new int[52]);
            //getMoreUsers();
            //var res = getMatchingPairs();
            // getMatchingPairs2();
            //IntArrayExcercises();
            FindElementInSorterArray(3);
            ReadLine();
        }

        private static void getMatchingPairs2()
        {
            var k = 10;
            var arr = new int[] { 5, 1, 2, 4, 9, 3, 6, 7, 8, 3, 5, 1, 3 };
            var diff = new List<int>();
            var res = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                var remaining = k - item;
                if (diff.Contains(remaining))
                {
                    WriteLine($"{item} => {remaining}");
                    res.Add(remaining, item);
                }
                else
                {
                    diff.Add(item);
                }
            }
        }

        private static Dictionary<int, int> getMatchingPairs()
        {
            var k = 10;
            var arr = new int[] { 5, 1, 2, 4, 9, 3, 6, 7, 8, 3, 5, 1 };

            var diff = new List<int>();
            var res = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var myKey = k - arr[i];
                if (diff.Contains(myKey))
                {
                    res.Add(myKey, arr[i]);
                }
                else
                {
                    diff.Add(arr[i]);
                }
            }
            return res;
        }

        private static void myEvents()
        {
            NotificationMethods nm = new NotificationMethods();
            nm._shaw += nm__shaw;
            nm.Name = "Kris";
        }

        private static void nm__shaw(object sender, EventArgs args)
        {
            WriteLine($"Name property has changed...");
        }

        public static void Run()
        {
            Helper h = new Helper();
            h.SwapMinMax();
            h.SwapString();
            h.StringsArrays();
            var tz = h.GetTimeZoneId();
            h.WorldClock("2017-11-25 3:32pm", tz);
            h.GetCollapsed("yyyaaa");
            h.UseSingleton();
            var a = h.GetWeekName();
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

        protected virtual void GetDog()
        {
            WriteLine($"This is inside method: {MethodBase.GetCurrentMethod().Name}()");
        }

        protected virtual void GetCat()
        {
            WriteLine($"This is inside method: {MethodBase.GetCurrentMethod().Name}()");
        }

        private static void run2(int val)
        {
            for (int i = val; i >= 0; i--)
            {
                WriteLine($"Back iteration: {i}  == value: {i}");
            }
        }

        private static string reverseString(string testString)
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty(testString))
            {
                var cTest = testString.ToCharArray();
                for (int i = cTest.Length - 1; i >= 0; i--)
                {
                    sb.Append(cTest[i]);
                }
            }
            WriteLine(sb.ToString());
            return sb.ToString();
        }

        private static string[] reverseSentence(string sentence)
        {
            var arr = sentence.ToCharArray();
            var result = new List<string>();
            var t = String.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                var temp = arr[i];
                if (temp != ' ')
                {
                    t += sentence[i];
                }
                else
                {
                    result.Add(t);
                    t = String.Empty;
                }
            }
            result.Add(t);
            t = String.Empty;
            result.ForEach(x => WriteLine(x));
            return result.ToArray();
        }

        private static void removeVowels(string cTest)
        {
            var test = cTest.Where(c => "aeiouAEIOU".Contains(c)).Distinct();

            foreach (var item in test)
            {
                WriteLine($"Test word: {cTest} contains vowels: {item}");
            }

            if (!test.Any())
                WriteLine($"No vowels found in {cTest}");

        }

        private static long findDelimiterOccurance(string s1, string s2)
        {
            var s1Arr = s1.ToCharArray();
            var s2Arr = s2.ToCharArray();
            var res = 0;
            for (int i = 0; i < s1Arr.Length; i++)
            {
                for (int j = 0; j < s2Arr.Length; j++)
                {
                    if (s1Arr[i] == s2Arr[j])
                    {
                        var tempIndex = Array.IndexOf(s1Arr, s1Arr[i]);
                        if (tempIndex > res)
                            res = tempIndex;
                    }
                }
            }
            WriteLine(res + 1);
            return res + 1;
        }

        private static void cardDeckShuffler()
        {
            var arr = new int[] { 2, 5, 6 };

            var randVal = new Random();
            var t = randVal.Next(0, arr.Length);

            var results = new int[2];
            for (int i = 0; i < arr.Length; i++)
            {
                while (true)
                {
                    t = randVal.Next(0, arr.Length);
                    if (arr[t] == 0)
                    {
                        arr[t] = arr[i];
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }

        private static void getDataFromDb()
        {
            var hp = new Helper();
            var res = hp.GetAllItems();
            var item = hp.GetItemById(35902);
        }

        private static async Task getPeopleFromWeb()
        {
            var hp = new Helper();
            var t = await hp.GetPeopleFromWeb();
        }

        private static void reverseArrayCheck(int index)
        {
            var myArr = new int[index];
            var elements = myArr.Length;

            for (int i = 0; i < myArr.Length; i++)
            {
                myArr[i] = i + 1;
            }

            for (var val = myArr.Length - 1; val >= 0; val--)
            {
                myArr[val] = val;
            }
        }

        private static void stringsOperations(string val)
        {
            var t = val.Length;
            for (int i = 0; i < val.Length; i++)
            {
                Debug.WriteLine(val[i]);
            }
            Debug.WriteLine("");
            for (var m = val.Length - 1; m >= 0; m--)
            {
                Debug.WriteLine(val[m]);
            }
            Debug.WriteLine("");
            for (var m = (val.Length - 1) / 2; m >= 0; m--)
            {
                Debug.WriteLine(val[m]);
            }
            Debug.WriteLine("");
            Debug.WriteLine(val.Count());
            Debug.WriteLine(val.Length);
            var k = val.OrderBy(x => x.ToString());
        }

        static public void Shuffle(int[] deck)
        {
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i + 1;
            }
            var r = new Random();
            for (int n = deck.Length - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                int temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }

        private static List<int> getMoreUsers()
        {
            var result = new List<int>();

            var listA = new List<int> { 1, 2, 3, 4 };
            var listB = new List<int> { 40, 50, 1, 60 };
            var listC = new List<int> { 2 };

            for (int i = 0; i < listA.Capacity; i++)
            {
                result.Add(listA[i]);
                result.Add(listB[i]);
                result.Add(listC[i]);

                result.Distinct();
            }

            return result;
        }

        public static void IntArrayExcercises()
        {
            int[] myArr = { 1,3, 4,6,7,8};
            var a = myArr.Length -1;
            while (a >= 0 )
            {
                WriteLine(myArr[a]);
                a--;
            }
        }

        public static Dictionary<int, int> FindKeyPairsInStaticArray1()
        {
            var result = new Dictionary<int, int>();
            var k = 10;
            var current = 0;
            var arr = new int[] { 1, 9 };
            var diff = new List<int>();
            for (var i = 0; i > arr.Length; i++)
            {
                var temp = arr[i];
                current = temp;
                diff.Add(k - temp);
                var diffVal = k - arr[i];
                if (diff.Contains(diffVal))
                {
                    result.Add(diffVal, current);
                }
            }

            foreach (KeyValuePair<int, int> kvp in result)
            {
                WriteLine("Key: " + kvp.Key + " and Value: " + kvp.Value);
            }

            return result;
        }

        // solution
        private static void getMatchingPairs03()
        {
            var k = 10;
            var arr = new int[] { 5, 1, 2, 4, 9, 3, 6, 7, 8, 3, 5, 1, 3 };
            var diff = new List<int>();
            var res = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                var remaining = k - item;
                if (diff.Contains(remaining))
                {
                    WriteLine($"{item} => {remaining}");
                    res.Add(remaining, item);
                }
                else
                {
                    diff.Add(item);
                }
            }
        }

        private static Dictionary<int, int> GetMatchingPairs04()
        {
            var k = 10;
            var arr = new int[] { 5, 1, 2, 4, 9, 3, 6, 7, 8, 3, 5, 1 };

            var diff = new List<int>();
            var res = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var myKey = k - arr[i];
                if (diff.Contains(myKey))
                {
                    res.Add(myKey, arr[i]);
                }
                else
                {
                    diff.Add(arr[i]);
                }
            }
            return res;
        }

        private static void FindElementInSorterArray(int elem2Find)
        {
            int[] t = { 1,3,5,8,11,4};
            Array.Sort(t);
            WriteLine();
            var result = Array.FindIndex(t, x => x == elem2Find);
            WriteLine($"Element to Search is: {elem2Find} and it is at the position: {result}");

        }

    }
}
