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
}
