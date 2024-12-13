using static System.Console;

namespace ConAppPlayingWithFakeItEasy;

public class Program
{
	static async Task Main()
	{
		await Task.Run(() =>
		{
			WriteLine("Welcome to a Fake World!");
		});
	}
}
