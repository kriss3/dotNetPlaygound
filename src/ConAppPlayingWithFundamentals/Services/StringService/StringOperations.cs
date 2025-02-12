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
}
