
using static System.Console;
using System.IO;

namespace ConAppPlayingWithFiles;

public class Program
{
	static async Task Main()
	{
		WriteLine("Hello, World!");
		await Run();
	}

	private static Task Run() 
	{
		string rootPath = @"C:\temp\TimCorey_Files";
		string[] dirs = Directory.GetDirectories(rootPath);

		dirs.ToList().ForEach(d => WriteLine($"Directory Name: {d}"));
		return Task.CompletedTask;
    }
}
