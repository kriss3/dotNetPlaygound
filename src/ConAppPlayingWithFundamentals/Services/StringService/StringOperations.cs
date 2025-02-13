using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace ConAppPlayingWithFundamentals.Services.StringService;
public static class StringOperations
{
	public static void Run()
	{
		Helper.SwapMinMax();
		Helper.SwapString();
		Helper.StringsArrays();
		Helper.GetTimeZoneId();
		Helper.WorldClock("2017-11-25 3:32pm");

		//Helper String statistics
		Helper.GetCollapsed("yyyaaa");

		//Helper Singleton
		Helper.UseSingleton();
		var a = Helper.GetWeekName();
		WriteLine(a);

		var r = Helper.ReverseVowels("Whyeeko");//a e o u i y
		WriteLine(r);

		var k = Helper.GetPresidents();
		WriteLine(k);

		Write(@"Type word to check if Palindrome: ");
		var s = ReadLine();
		if (Helper.IsPalindrome(s))
		{
			WriteLine($"Word {s} is palindrome");
		}
		else
		{
			WriteLine($"Word {s} is not a palindrome");
		}
	}

	public static void Run2(int val)
	{
		for (int i = val; i >= 0; i--)
		{
			WriteLine($"Back iteration: {i}  == value: {i}");
		}
	}

	public static string ReverseString(ref string testString)
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

	public static string[] ReverseSentence(string sentence)
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
		return [.. result];
	}

	public static void RemoveVowels(string cTest)
	{
		var test = cTest.Where(c => "aeiouAEIOU".Contains(c)).Distinct();

		foreach (var item in test)
		{
			WriteLine($"Test word: {cTest} contains vowels: {item}");
		}

		if (!test.Any())
			WriteLine($"No vowels found in {cTest}");

	}

	public static long FindDelimiterOccurrence(string s1, string s2)
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

	public static void CapitalizeEveryOtherCharter()
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

			if (itemIndex % 2 != 0)
				sb.Append(example[itemIndex].ToString().ToUpper());
			else
				sb.Append(example[itemIndex].ToString().ToLower());
		}
		sb.ToString();
	}

	public static void FindNumberOfAsInAString()
	{
		//var result = s.Take(n).Where(c => c == 'a').ToList().Count; //this works when n is within integer
		long n = 2000000000;  //2147483646
		string s = "a";  //this string can be infinite, index can be larger than int32;
		var maxStringArray = new List<string>();

		if (s.Length < n && n < int.MaxValue)
		{
			s = string.Concat(Enumerable.Repeat(s, Convert.ToInt32(n)));
			_ = s.Length;
			_ = CountOfAs(s, n);
		}
		else
		{
			//very large n > int.MaxValue
			while (n > int.MaxValue)
			{
				n = int.MaxValue;
				s = string.Concat(Enumerable.Repeat(s, Convert.ToInt32(n)));
				maxStringArray.Add(s);

				n -= int.MaxValue;
			}
			maxStringArray.Add(string.Concat(Enumerable.Repeat(s, Convert.ToInt32(n))));
			long res = 0;
			foreach (string item in maxStringArray)
			{
				var temp = CountOfAs(item, n);
				res += temp;
			}
		}



		if (maxStringArray.Count > 0)
		{
			foreach (var arr in maxStringArray)
			{
				//do the same as below to find all 'a' letters;
				WriteLine(CountOfAs(arr, n));
			}
		}
	}

	private static long CountOfAs(string s, long n)
	{
		long count = 0;
		long counter = 0;
		var toListChar = s.ToList();
		foreach (char c in toListChar)
		{
			if (counter == n)
				break;
			if (c == 'a')
				count++;
			counter++;
		}
		return count;
	}

	public static IEnumerable<string> StringSplitByMaxInt(string s)
	{
		var partLength = int.MaxValue;
		for (var i = 0; i < s.Length; i += partLength)
			yield return s.Substring(i, Math.Min(partLength, s.Length - i));
	}

	public static void PaddingWithZeros()
	{
		int numberOfAvailSpaces = 2;
		int value = 2;
		string result = $"{value.ToString().PadLeft(numberOfAvailSpaces, '0')}";
		WriteLine($"The DB2 value is {result} but the code will deal with value: {value}");
	}

	public static string BreakPalindrome(string str)
	{
		string result, nStr;

		nStr = str.Replace(str[1], str[^1]);

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
}
