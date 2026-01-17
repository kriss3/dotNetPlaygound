using static System.Console;

namespace PlayingWithTranslink.Gtfs.Infrastructure.Helpers;

public static class GtfsHelper
{
	// ------------------------------------------------
	// Small prompt helpers (keep Main clean)
	// ------------------------------------------------
	public static string Prompt(string label, string defaultValue)
	{
		Write($"{label} [{defaultValue}]: ");
		var input = ReadLine();
		return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
	}

	public static int PromptInt(string label, int defaultValue)
	{
		Write($"{label} [{defaultValue}]: ");
		var input = ReadLine();
		return int.TryParse(input, out var value) ? value : defaultValue;
	}

	public static TimeSpan PromptTime(string label, TimeSpan defaultValue)
	{
		Write($"{label} [{defaultValue:hh\\:mm}]: ");
		var input = ReadLine();

		return TimeSpan.TryParse(input, out var time)
			? time
			: defaultValue;
	}
}
