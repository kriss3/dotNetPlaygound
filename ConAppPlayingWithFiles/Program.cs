
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

	private static async Task Run() 
	{
		string rootPath = @"C:\temp\TimCorey_Files";
		string[] dirs = Directory.GetDirectories(rootPath);

        foreach (var dir in dirs)
        {
            WriteLine($"Dir: {dir}");
        }
    }
}
