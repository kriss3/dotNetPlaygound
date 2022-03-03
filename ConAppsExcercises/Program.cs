using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.Json;
using ConAppsExcercises.Models;


using static System.Console;
using Microsoft.Identity.Client;

namespace ConAppsExcercises
{
    public class Dependent
    {
        public string PolicyNumber { get; set; }
        public string DivisionNumber { get; set; }
        public string Category { get; set; }
    }

    class Program
    {
        static void Main()
        {
            //MyEvents();
            //Run();
            //Run2(10);
            //var t = "konstantynopolitanczykowna";
            //ReverseString(ref t);
            //RemoveVowels("HellO");
            //FindDelimiterOccurance("ABCDE", "DC");
            //ReverseSentence("Ala ma kota");
            //CardDeckShuffler();
            //GetDataFromDb();
            //Task.Run(async () => await GetPeopleFromWeb());
            //ReverseArrayCheck(10);
            //StringsOperations("pasta");
            //Shuffle(new int[52]);
            //GtMoreUsers();
            //var res = GetMatchingPairs();
            //GetMatchingPairs2();
            //IntArrayExcercises();
            //FindElementInSorterArray(3);
            //FindPairs();
            //ValeyCount();
            //OddNumbers(2,5);
            //BreakPalindrom("acca");
            //MySortingBubble();
            //GetFibonachiSeq(12);
            //PrintStarPattern(8);
            //Run2DArray();
            //VowelsString();
            //StrStats();
            //WorkWithStrings();
            //IntArray();
            //ReverseWordsInString();
            //LinqQuery();
            //Compare2List();
            //StringPaddingAndSubstring();
            //var result = CallAzureService();
            //CapitalizeEveryOtherCharter();
            //PaddingWithZeros();
            //SerializeUsingMsLibrary();
            //FizzBuzzAttempt();
            //FuncDelegateExample();
            ActionDelegateExample();
            //PredicateDelegateExample();

            ReadLine();
        }

        private static void PredicateDelegateExample()
        {
            throw new NotImplementedException();
        }

        private static void ActionDelegateExample()
        {
            Action<int> printAValue = i => WriteLine($"The parameter passed to the Actin Del is: {i}");
            printAValue(10);
        }

        private static void FuncDelegateExample()
        {
            Func<int, int, int> myResult = myDelegateFnct;

            var res = myResult(5, 5);

            WriteLine($"Func can take 0 to 16 params and returns a value: {res}");
        }



        private static int myDelegateFnct(int val1, int val2) 
        {
            return val1 + val2;
        }
        private static void FizzBuzzAttempt()
        {
            var n = 15; // 1,2,Fizz,4,Buzz
            var results = new Dictionary<int, string>();
            for (int i = 1; i <=n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    results.Add(i, "FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    results.Add(i, "Fizz");
                }
                else if (i % 5 == 0)
                {
                    results.Add(i, "Buzz");
                }
                else {
                    results.Add(i, i.ToString());
                }
            }

            // in case we want to return just an array
            var arr1 = results.Values.ToArray(); 
            var myResult = new StringBuilder(results.Keys.Count);
            foreach (var item in results.Values)
            {
                 myResult.Append($"{item},");
            }

            Write(myResult.ToString().TrimEnd(','));

        }

        private static void SerializeUsingMsLibrary()
        {
            string _example = @"{""PolicyNumber"":""1000007897"",
                                                ""DivisionNumber"":""0001"",
                                                ""Category"":""Spouse"" }";

            var result = JsonSerializer.Deserialize<Dependent>(_example);
            WriteLine($"Policy Number: {result.PolicyNumber}\nDivision Number: {result.DivisionNumber}\nCategory: {result.Category}");
        }

        private static void PaddingWithZeros()
        {
            int numberOfAvailSpaces = 2;
            int value = 2;
            string result = $"{value.ToString().PadLeft(numberOfAvailSpaces, '0')}";
            WriteLine($"The DB2 value is {result} but the code will deal with value: {value}");
        }

        private static void CapitalizeEveryOtherCharter()
        {
            string example = "this is my example";
            var sb = new StringBuilder();
            foreach (var item in example)
            {
                int itemIndex = example.IndexOf(item);
                if (itemIndex == 0)
                {
                    sb.Append(example[itemIndex].ToString().ToLower());
                    continue;
                }
                    
                if ((itemIndex % 2) != 0)
                    sb.Append(example[itemIndex].ToString().ToUpper());
                else
                    sb.Append(example[itemIndex].ToString().ToLower());
            }
            var result = sb.ToString();
        }

        private static string CallAzureService()
        {
            var clientId = "3f5a81f6-2cfd-4707-8b5e-8e75dea6f481";
            var clientSecret = "dUq7Q~O~_BNUj8XvD8RtHef0pxxBp4VNmBLu.";
            var authority = "";
            var tenantId = "e1718b18-1c6b-4d85-a073-8331407107ce";
            var appIDUri = "api://3f5a81f6-2cfd-4707-8b5e-8e75dea6f481/User.Read/.default";

            IConfidentialClientApplication app;
            app = ConfidentialClientApplicationBuilder.Create(clientId)
                                                      .WithClientSecret(clientSecret)
                                                      .Build();

            var scopes = new[] { appIDUri };
            var result = app.AcquireTokenForClient(scopes).ExecuteAsync().ConfigureAwait(false);
            string jwt = result.GetAwaiter().GetResult().AccessToken;
            return jwt;
        }

        private static void StringPaddingAndSubstring()
        {
            string transName = "C";
            string companyCode = "0";
            string systemCode = "SM";
            string constract = "0000000610001";
            string companyName = "MyNewCompanyName";

            //StringBuilder has Append
            //String has PadRight/PadLeft
            StringBuilder sb = new StringBuilder(transName.PadRight(2));
            sb.Append(companyCode.PadRight(3));
            sb.Append(constract.PadRight(20));
            sb.Append(systemCode.PadRight(42));
            sb.Append(companyName);
            
            sb.ToString();
            
        }

        private static void Compare2List()
        {
            //theirs
            var firstList = new List<string> { "" };
            //the once that have Access; mine
            var secondList = new List<string> { "04009", "04010", "04011", "04012" }; 

            //should return true if both have the same elements
            //var result = firstList.Where(le1 => secondList.Any(le2=>le2 == le1)).ToList();
            hasAccess(firstList, secondList);

        }

        private static bool hasAccess(List<string> theirs, List<string> mine) 
        {
            //test2.Where(t2 => !test1.Any(t1 => t2.Contains(t1)));
            var res = theirs.Intersect(mine).Count() == theirs.Count();
            return res;
        }

        private static void LinqQuery()
        {
            var o = new List<Order>
            {
                new Order 
                { 
                    OrderId=0, 
                    OrderTotal = 1, 
                    OrderLines = new List<OrderLine>{ 
                        new OrderLine 
                        { 
                            OrderId=1, 
                            OrderLineId=0, 
                            ProductName="Prod1", 
                            Quantity=1
                        },
                        new OrderLine
                        {
                            OrderId=1,
                            OrderLineId=1,
                            ProductName="Prod2",
                            Quantity=1
                        }
                    } 
                } 
            };

            var x = o.Select(r => r.OrderLines).ToList();

            //var result1 = o.RemoveAll(lst => lst == 3);
            foreach (var item in x)
            {
                item.RemoveAll(r => r.ProductName.Equals("Prod2"));
            }

            //var res = 3;
        }

        private static void Run2DArray()
        {
            MultiDArray mda = new MultiDArray();
            mda.RunMultiDArray();
        }

        private static void PrintStarPattern(int n)
        {
            for (int i = n; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Write($"*");
                }
                WriteLine();
            }
        }

        private static void GetFibonachiSeq(int n)
        {
            //0,1,1,2,3,5,8,13,21,34,55,89
            int first = 0;
            int second = 1;
            Write($"{first},{second},");
            for (int i = 2; i < n; i++)
            {
                int next = first + second;
                Write($"{next},");
                first = second;
                second = next;
            }
        }

        private static void GetMatchingPairs2()
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

        private static Dictionary<int, int> GetMatchingPairs()
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

        private static void MyEvents()
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

            //Helper String statistics
            h.GetCollapsed("yyyaaa");

            //Helper Singleton
            h.UseSingleton();
            var a = h.GetWeekName();
            WriteLine(a);

            var r = h.ReverseVowels("Whyeeko");//a e o u i y
            WriteLine(r);

            var k = h.GetPresidents();
            WriteLine(k);

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

        private static void Run2(int val)
        {
            for (int i = val; i >= 0; i--)
            {
                WriteLine($"Back iteration: {i}  == value: {i}");
            }
        }

        private static string ReverseString(ref string testString)
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrEmpty(testString))
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

        private static string[] ReverseSentence(string sentence)
        {
            var arr = sentence.ToCharArray();
            var result = new List<string>();
            var t = string.Empty;
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
                    t = string.Empty;
                }
            }
            result.Add(t);
            t = string.Empty;
            result.ForEach(x => WriteLine(x));
            return result.ToArray();
        }

        private static void RemoveVowels(string cTest)
        {
            var test = cTest.Where(c => "aeiouAEIOU".Contains(c)).Distinct();

            foreach (var item in test)
            {
                WriteLine($"Test word: {cTest} contains vowels: {item}");
            }

            if (!test.Any())
                WriteLine($"No vowels found in {cTest}");

        }

        private static long FindDelimiterOccurance(string s1, string s2)
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

        private static void CardDeckShuffler()
        {
            var arr = new int[] { 2, 5, 6 };

            var randVal = new Random();
            var t = randVal.Next(0, arr.Length);
            WriteLine(t);

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

        private static void GetDataFromDb()
        {
            var hp = new Helper();
            var res = hp.GetAllItems();
            var item = hp.GetItemById(35902);
            WriteLine(item);
        }

        private static async Task GetPeopleFromWeb()
        {
            var hp = new Helper();
            var t = await hp.GetPeopleFromWeb();
            WriteLine(t);
        }

        private static void ReverseArrayCheck(int index)
        {
            var myArr = new int[index];
            
            for (int i = 0; i < myArr.Length; i++)
            {
                myArr[i] = i + 1;
            }

            for (var val = myArr.Length - 1; val >= 0; val--)
            {
                myArr[val] = val;
            }
        }

        private static void StringsOperations(string val)
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

        private static List<int> GtMoreUsers()
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
            int[] myArr = { 1, 3, 4, 6, 7, 8 };
            var a = myArr.Length - 1;
            while (a >= 0)
            {
                WriteLine(myArr[a]);
                a--;
            }
        }

        public static Dictionary<int, int> FindKeyPairsInStaticArray1()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            var k = 10;
            int current;
            var arr = new int[] { 1, 9 };
            var diff = new List<int>();
            for (var i = 0; i > arr.Length; i++)
            {
                int temp = arr[i];
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
        private static void GetMatchingPairs03()
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

            var diff = new List<int>(); //the list will store 
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
            int[] t = { 1, 3, 5, 8, 11, 4 };
            Array.Sort(t);
            WriteLine();
            var result = Array.FindIndex(t, x => x == elem2Find);
            WriteLine($"Element to Search is: {elem2Find} and it is at the position: {result}");

        }

        private static void FindPairs()
        {
            var results = 0;
            var t = new int[] { 10, 20, 20, 10, 10, 30, 50, 10, 20 };

            //10 10 10 10 20 20 20 30 50 
            Array.Sort(t);

            for (int i = 0; i < t.Length; i++)
            {
                for (int j = i + 1; j < t.Length; j++)
                {
                    if (t[i] == t[j])
                    {
                        results++;
                        i += 1;
                        break;
                    }
                }
            }
            WriteLine($"Number of matching pairs: {results}");
        }

        private static void ValeyCount()
        {
            var results = 0;
            /*
             *  _/\       _
             *      \     /
             *       \/\/
             *        
             */

            //var n = 8; //number of steps;
            //var seaLevel = 0;
            var path = "UDDDUDUU";

            var res = new List<KeyValuePair<char, char>>();
            for (int i = 0; i < path.Length; i++)
            {




                if (i + 1 < path.Length - 1)
                    res.Add(new KeyValuePair<char, char>(path[i], path[i + 1]));
            }

            res.ForEach(p => {
                if (p.Key.Equals('D') && p.Value.Equals('U'))
                    results++;
            });
        }

        private static void OddNumbers(int l, int r)
        {
            List<int> result = new List<int>();
            for (int i = l; i <= r; i++)
            {
                if ((i % 2) != 0)
                    result.Add(i);
            }
        }

        private static string BreakPalindrom(string str)
        {
            string result, nStr;

            nStr = str.Replace(str[1], str[str.Length - 1]);

            if (nStr.CompareTo(str) == -1)
                result = nStr;
            else if (nStr.CompareTo(str) == 1)
            {
                Array.Sort(str.ToArray());
                result = str.ToString();
            }
            else
                return "IMPOSSIBLE";
            return result;
        }

        private static void MySortingBubble()
        {
            int[] myArr = new int[] { 5, 1, 4, 2, 8 };
            var move = 0;
            do
            {
                for (int i = 0; i <= myArr.Length - 1; i++)
                {
                    if (i + 1 > myArr.Length - 1)
                        break;
                    int t1 = myArr[i];
                    int t2 = myArr[i + 1];
                    if (t1 > t2)
                    {
                        Swap(ref myArr, ref t1, ref t2);
                        move++;
                    }
                    else
                    {
                        move--;
                    }
                }
            } while (move > 0);

        }
        private static void Swap(ref int[] arr, ref int a, ref int b)
        {
            var inxT1 = Array.IndexOf(arr, a);
            var inxT2 = Array.IndexOf(arr, b);
            arr[inxT1] = b;
            arr[inxT2] = a;
        }

        private void FindAnagrams()
        {
            /*
             * I was asked to write a program to find the anagrams in a list and return the list of anagrams.  
             */

        }

        private void TwoDMatrixOps()
        {
            /*
             * There's an integer materials implemented in two dimensional array. When met a 0 in any position , 
             * change the whole row and column of that position into 0s  
             * 
             */
        }

        private void Magnitude()
        {
            /*interface vs abstract class
             * keywords: static, read-only, const
             * TDS protocol
             * static class and static members
             * immutable vs non-immutable class (how to make class immutable)
             * palindrom and its permutations
             * 
             * 
             */
        }

        private static string VowelsString()
        {
            var strArr = "kaliningrad";  //aeoui  //result=> kaliningrad

            var res = new StringBuilder();
            for (int start = 0, end = strArr.Length - 1; start < strArr.Length; start++)
            {
                if ("aeouiAEOUI".IndexOf(strArr[start]) < 0)
                {
                    res.Append(strArr[start]);
                }
                else
                {
                    while (end > 0 && "aeouiAEOUI".IndexOf(strArr[end]) < 0)
                    {
                        end--;
                    }
                    res.Append(strArr[end]);
                    end--;
                }
            }
            return res.ToString();
        }

        private static void StrStats() //a dictionary of char key and number of reoccuring characters;
        {
            var strArr = "aabbbccccddddd";
            var stats = new Dictionary<char, int>();
            var strCounter = 0;
            foreach (var item in strArr)
            {
                if (!stats.Keys.Contains(item))
                {
                    strCounter = 0;
                    stats.Add(item, ++strCounter);
                }
                else
                {
                    stats[item] = ++strCounter;
                }
            }
        }

        private static bool WorkWithStrings()
        {
            var str = "abba";
            if (!string.IsNullOrEmpty(str))
            {
                return str.SequenceEqual(str.Reverse());
            }
            return false;
        }

        private static void IntArray()
        {
            var myArr = new int[]{1,2,3,4,6,7,8,9,10};

            int myArrSum = myArr.Sum();
            int res = 0;
            for (int i = myArr.Min(); i <=myArr.Max(); i++)
            {
                res += i;
            }

            var fullRes = res - myArrSum;
            WriteLine(fullRes);
        }

        public static void ReverseWordsInString()
        {
            string sent = "ala ma kota";

            var res = sent.Split(' ');
            var sb = new StringBuilder();
            for (int i = res.Length-1; i>=0; i--)
            {
                sb.Append(res[i]);
                sb.Append(" ");
            }
            var result = sb.ToString();
            WriteLine(result);
        }
    }
}
