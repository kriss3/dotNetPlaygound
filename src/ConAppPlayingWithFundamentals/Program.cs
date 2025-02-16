using ConAppPlayingWithFundamentals.Models;
using ConAppPlayingWithFundamentals.Services.DelegateService;
using ConAppPlayingWithFundamentals.Services.NotificationService;
using ConAppPlayingWithFundamentals.Services.StringService;
using ConAppsExercises.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Console;

namespace ConAppPlayingWithFundamentals;

class Program
{
	static async Task Main()
	{
		while (true)
		{
			DisplayMenu();
			var choice = ReadLine();
			if (choice == "q")
			{
				WriteLine("Exiting...");
				break;
			};
			await ExecuteChoice(choice);
		}
		ParamsCollectionsCheck();

		ReadLine();
	}

	private static void DisplayMenu()
	{
		WriteLine("Choose an option:");
		WriteLine("1. ParamsCollectionsCheck");
		WriteLine("2. ShowDefaultsForTypes");
		WriteLine("3. FindNumberOfAsInAString");
		WriteLine("4. MinStepsToEqualizeIntArray");
		WriteLine("5. JumpOverThunderHeads");
		WriteLine("6. CountNumberOfValleys");
		WriteLine("7. Run");
		WriteLine("8. Setup");
		WriteLine("9. StringSplitByMaxInt");
		WriteLine("10. MyEvents");
		WriteLine("11. LongProcess");
		WriteLine("12. PredicateDelegateExample");
		WriteLine("13. ActionDelegateExample");
		WriteLine("14. FuncDelegateExample");
		WriteLine("15. FizzBuzzAttempt");
		WriteLine("16. SerializeUsingMsLibrary");
		WriteLine("17. PaddingWithZeros");
		WriteLine("18. CapitalizeEveryOtherCharter");
		WriteLine("19. Compare2List");
		WriteLine("20. LinqQuery");
		WriteLine("21. Run2DArray");
		WriteLine("22. GetFibonacciSeq");
		WriteLine("23. GetMatchingPairs2");
		WriteLine("24. GetMatchingPairs");
		WriteLine("25. Run2");
		WriteLine("26. ReverseString");
		WriteLine("27. ReverseSentence");
		WriteLine("28. RemoveVowels");
		WriteLine("29. FindDelimiterOccurrence");
		WriteLine("30. CardDeckShuffler");
		WriteLine("31. ");
		WriteLine("32. ");
		WriteLine("33. ");
		WriteLine("34. ");
		WriteLine("35. ");
		WriteLine("36. ");
		WriteLine("37. ");
		WriteLine("38. ");
		WriteLine("39. ");
		WriteLine("40. ");
		WriteLine("41. ");
		WriteLine("42. ");
		WriteLine("43. ");
		WriteLine("44. ");
		WriteLine("45. ");
		WriteLine("46. ");


		WriteLine("0. Exit");
		Write("Enter your choice: ");
	}

	private static async Task ExecuteChoice(string choice)
	{
		switch (choice)
		{
			case "1":
				ParamsCollectionsCheck();
				break;
			case "2":
				ShowDefaultsForTypes();
				break;
			case "3":
				StringOperations.FindNumberOfAsInAString();
				break;
			case "4":
				MinStepsToEqualizeIntArray();
				break;
			case "5":
				JumpOverThunderHeads();
				break;
			case "6":
				CountNumberOfValleys();
				break;
			case "7":
				StringOperations.Run();
				break;
			case "8":
				Setup();
				break;
			case "9":
				StringOperations.StringSplitByMaxInt("13");
				break;
			case "10":
				EventsHelper.MyEvents();
				break;
			case "11":
				await LongProcess();
				break;
			case "12":
				PredicateDelegateExample();
				break;
			case "13":
				ActionDelegateExample();
				break;
			case "14":
				DelegateHelper.FuncDelegateExample();
				break;
			case "15":
				FizzBuzzAttempt();
				break;
			case "16":
				SerializeUsingMsLibrary();
				break;
			case "17":
				StringOperations.PaddingWithZeros();
				break;
			case "18":
				StringOperations.CapitalizeEveryOtherCharter();
				break;
			case "19":
				Compare2List();
				break;
			case "20":
				LinqQuery();
				break;
			case "21":
				Run2DArray();
				break;
			case "22":
				GetFibonacciSeq(10);
				break;
			case "23":
				GetMatchingPairs2();
				break;
			case "24":
				GetMatchingPairs();
				break;
			case "25":
				StringOperations.Run2(10);
				break;
			case "26":
				var word = "konstantynopolitanczykowna";
				StringOperations.ReverseString(ref word);
				break;
			case "27":
				var sentence = "Ala ma kota";
				StringOperations.ReverseSentence(sentence);
				break;
			case "28":
				var exampleWord = "HellO";
				StringOperations.RemoveVowels(exampleWord);
				break;
			case "29":
				var inputExample1 = "ABCDE";
				var inputExample2 = "DC";
				StringOperations.FindDelimiterOccurrence(inputExample1, inputExample2);
				break;
			case "30":
				CardDeckShuffler();
				break;
			case "31":
				GetDataFromDb();
				break;
			case "32":
				await GetPeopleFromWeb();
				break;
			case "33":
				ReverseArrayCheck(10);
				break;
			case "34":
				GtMoreUsers();
				break;
			case "35":
				GetMatchingPairs03();
				break;
			case "36":
				GetMatchingPairs04();
				break;
			case "37":
				var input = 3;
				FindElementInSorterArray(input);
				break;
			case "38":
				FindPairs();
				break;
			case "39":
				ValleyCount();
				break;
			case "40":
				var input1 = 2;
				var input2 = 5;
				OddNumbers(input1, input2);
				break;
			case "41":
				var inputForBreakPalindrome = "acca";
				StringOperations.BreakPalindrome(inputForBreakPalindrome);
				break;
			case "42":
				MySortingBubble();
				break;
			case "43":
				TwoDMatrixOps();
				break;
			case "44":
				Magnitude();
				break;
			case "45":
				IntArray();
				break;
			case "46":
				PrintFactorial();
				break;
			default:
				WriteLine("Invalid choice. Please try again.");
				break;
		}
	}

	private static void ParamsCollectionsCheck()
	{
		List<string> list = ["admin", "user", "god"];
		PrintVariableLength(list);
	}

	private static void PrintVariableLength(params List<string> input) => 
		input.ForEach(x => WriteLine(x));

	private static void ShowDefaultsForTypes()
	{
		// Make a call to the default Type value check.
		DisplayDefault<int>();
		DisplayDefault<int?>();
		DisplayDefault<string>();
		DisplayDefault<Point>();
		DisplayDefault<decimal>();
		DisplayDefault<bool>();
		DisplayDefault<object>();
	}

	static void DisplayDefault<T>()
	{
		var val = default(T);
		WriteLine($"Default value of {typeof(T)} is {(val == null
			? "null"
			: val.ToString())}");
	}

	//This is done and works
	private static int MinStepsToEqualizeIntArray()
	{
		int result = 0;
		//initial thought: create given array statistics and order by most, same elements
		// int[] a = {3, 3, 2, 1, 3}; answer: 2 => remove value: 2 and 1 
		/*
         * [element, count]
         * [3, 3]
         * [2, 1]
         * [1, 1]
         */

		int[] a = [3, 3, 2, 1, 3];
		Dictionary<int, int> res = [];
		foreach (var num in a)
		{
			if (!res.TryGetValue(num, out int value))
			{
				res.Add(num, 1);
			}
			else
			{
				var currentCount = value;
				currentCount++;
				res[num] = currentCount;
			}
		}

		var sortDictionaryByValue = res.OrderByDescending(x => x.Value).ToDictionary(x => x.Key);
		res.Remove(sortDictionaryByValue.Keys.First());
		result = res.Values.Sum();

		return result;
	}

	//Attempt to solve another HackerRank puzzle
	//given a and array of 0...1, find the shortest path avoiding 1 and jumping on 0 only;
	private static void JumpOverThunderHeads()
	{
		int numberOfJumps = 7;
		List<int> clouds = [0, 0, 1, 0, 0, 1, 0];
		int shortestPath = FindShortestPath(clouds);
		WriteLine($"For given number of Jumps: {numberOfJumps} the " +
			$"shortest path is: {shortestPath}");
	}

	private static int FindShortestPath(List<int> c)
	{
		int sum = 0;

		for (int i = 0; i < c.Count - 1; i++)
		{
			if (c[i] == 0)
			{
				i++;
			}
			sum++;
		}

		return sum;
	}


	//HackerRank = countNumber of valleys
	//SeaLevel, walker always ends up at level 0;
	private static void CountNumberOfValleys()
	{
		int numberOfSteps = 8;
		string path = "UDDDUDUU";
		int result = CountingValleys(path);
		WriteLine($"Number of Steps: {numberOfSteps} with the paths: {path}, " +
			$"the number of values is: {result}");
	}

	public static int CountingValleys(string path)
	{
		//8 steps and path is: DD UUUU DD
		int countOfValleys = 0;
		int level = 0;
		bool newBelow = false;

		for (int i = 0; i < path.Length; i++)
		{
			if (path[i] == 'D')
			{
				level--;
				if (level == -1)
				{
					newBelow = true;
				}
				if (level < -1)
				{
					newBelow = false;
				}
			}
			else if (path[i] == 'U')
			{
				level++;
				if (level > 0)
				{
					newBelow = false;
				}
			}

			if (level < 0 && newBelow)
				countOfValleys++;
		}
		return countOfValleys;
	}

	private static List<KeyValuePair<string, string>> Setup()
	{
		IConfiguration config = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json").Build();
		IEnumerable<KeyValuePair<string, string>> keyValuePairs = config.AsEnumerable();
		return keyValuePairs.ToList();
	}

	private static async Task LongProcess()
	{
		WriteLine("This is the beginning of the long process");
		await Task.Delay(4000);
		WriteLine("Long process Completed.");

	}


	//Takes params and returns a boolean
	//This example will return true for any function taking int param and that param is > 10;
	private static void PredicateDelegateExample()
	{
		static bool predicate(int val)
		{
			if (val > 10)
				return true;
			return false;
		}
		Write("Enter a digit: ");
		int valueReceived = int.Parse(ReadLine());
		Write($"Is the value entered greater than 10? : {predicate(valueReceived)}");
	}

	//Does not return a value take 0 up to 16 params (equivalent to void function)
	private static void ActionDelegateExample()
	{
		static void printAValue(int i) => WriteLine($"The parameter passed to the Actin Delegate is: {i}");
		printAValue(10);
	}
	
	private static void FizzBuzzAttempt()
	{
		var n = 15; // 1,2,Fizz,4,Buzz
		var results = new Dictionary<int, string>();
		for (int i = 1; i <= n; i++)
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
			else
			{
				results.Add(i, i.ToString());
			}
		}

		// in case we want to return just an array
		//var arr1 = results.Values.ToArray(); 
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

	private static void Compare2List()
	{
		//theirs
		var firstList = new List<string> { "" };
		//the once that have Access; mine
		var secondList = new List<string> { "04009", "04010", "04011", "04012" };

		//should return true if both have the same elements
		//var result = firstList.Where(le1 => secondList.Any(le2=>le2 == le1)).ToList();
		HasAccess(firstList, secondList);

	}

	private static bool HasAccess(List<string> theirs, List<string> mine)
	{
		//test2.Where(t2 => !test1.Any(t1 => t2.Contains(t1)));
		var res = theirs.Intersect(mine).Count() == theirs.Count;
		return res;
	}

	private static void LinqQuery()
	{
		var o = new List<Order>
		{
			new()
			{
				OrderId=0,
				OrderTotal = 1,
				OrderLines = [
					new()
					{
						OrderId=1,
						OrderLineId=0,
						ProductName="Prod1",
						Quantity=1
					},
					new()
					{
						OrderId=1,
						OrderLineId=1,
						ProductName="Prod2",
						Quantity=1
					}
				]
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
		MultiDArray.RunMultiDArray();
	}

	private static void GetFibonacciSeq(int n)
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
		int[] arr = [5, 1, 2, 4, 9, 3, 6, 7, 8, 3, 5, 1, 3];
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

	protected virtual void GetDog()
	{
		WriteLine($"This is inside method: {MethodBase.GetCurrentMethod().Name}()");
	}

	protected virtual void GetCat()
	{
		WriteLine($"This is inside method: {MethodBase.GetCurrentMethod().Name}()");
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
		Helper.GetAllItems();
		var item = Helper.GetItemById(35902);
		WriteLine(item);
	}

	private static async Task GetPeopleFromWeb()
	{
		var t = await Helper.GetPeopleFromWeb();
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
			//int temp = deck[n];
			//deck[n] = deck[k];
			//deck[k] = temp;
			(deck[k], deck[n]) = (deck[n], deck[k]);
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

			_ = result.Distinct();
		}

		return result;
	}

	public static void IntArrayExercises()
	{
		int[] myArr = [1, 3, 4, 6, 7, 8];
		var a = myArr.Length - 1;
		while (a >= 0)
		{
			WriteLine(myArr[a]);
			a--;
		}
	}

	public static Dictionary<int, int> FindKeyPairsInStaticArray1()
	{
		Dictionary<int, int> result = [];
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
		int[] arr = [5, 1, 2, 4, 9, 3, 6, 7, 8, 3, 5, 1, 3];
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
		int[] arr = [5, 1, 2, 4, 9, 3, 6, 7, 8, 3, 5, 1];

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
		int[] t = [1, 3, 5, 8, 11, 4];
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

	private static void ValleyCount()
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

		res.ForEach(p =>
		{
			if (p.Key.Equals('D') && p.Value.Equals('U'))
				results++;
		});
	}

	private static void OddNumbers(int l, int r)
	{
		List<int> result = [];
		for (int i = l; i <= r; i++)
		{
			if (i % 2 != 0)
				result.Add(i);
		}
	}

	private static void MySortingBubble()
	{
		int[] myArr = [5, 1, 4, 2, 8];
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

	private static void TwoDMatrixOps()
	{
		/*
         * There's an integer materials implemented in two dimensional array. When met a 0 in any position , 
         * change the whole row and column of that position into 0s  
         * 
         */
	}

	private static void Magnitude()
	{
		/*interface vs abstract class
         * keywords: static, read-only, const
         * TDS protocol
         * static class and static members
         * immutable vs non-immutable class (how to make class immutable)
         * palindrome and its permutations
         * 
         * 
         */
	}

	private static void IntArray()
	{
		var myArr = new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 };

		int myArrSum = myArr.Sum();
		int res = 0;
		for (int i = myArr.Min(); i <= myArr.Max(); i++)
		{
			res += i;
		}

		var fullRes = res - myArrSum;
		WriteLine(fullRes);
	}

	private static void PrintFactorial()
	{
		var x = 5;
		var input = x;
		var res = DoFactorial(x);

		do
		{
			Write($"{x}\t");
			x--;
		}
		while (x > 0);

		WriteLine($"Result of Factorial of {input} is: {res}.");
	}

	private static int DoFactorial(int n)
	{
		if (n == 0) return 1;
		return n * DoFactorial(n - 1);
	}
}
