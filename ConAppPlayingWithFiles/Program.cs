
using static System.Console;

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
		//SearchDirAtRootLevelOnly();
		//SearchDirAtAllLevels();
		SearchAllFilesAtRoot();

		return Task.CompletedTask;
	}

	private static Task SearchDirAtAllLevels()
	{
		string rootPath = @"C:\temp\TimCorey_Files";
		string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

		dirs.ToList().ForEach(d => WriteLine($"Directory Name: {d}"));

		return Task.CompletedTask;
	}

	private static Task SearchDirAtRootLevelOnly()
	{
		string rootPath = @"C:\temp\TimCorey_Files";
		string[] dirs = Directory.GetDirectories(rootPath);

		dirs.ToList().ForEach(d => WriteLine($"Directory Name: {d}"));
		return Task.CompletedTask;
	}

	private static Task SearchAllFilesAtRoot()
	{
		string rootPath = @"C:\temp\TimCorey_Files";
		var files = Directory.GetFiles(rootPath, "*.*", SearchOption.TopDirectoryOnly);

		files.ToList().ForEach(f => WriteLine($"File names are: {f}"));

		return Task.CompletedTask;
	}

	private static Task SearchAllFiles()
	{
		string rootPath = @"C:\temp\TimCorey_Files";
		var files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);

		files.ToList().ForEach(f => WriteLine($"File names are: {f}"));

		files.ToList().ForEach(f => WriteLine($"File names are: {Path.GetDirectoryName(f)}"));

		files.ToList().ForEach(f => WriteLine($"File names are: {Path.GetFileNameWithoutExtension(f)})"));

		files.ToList().ForEach(f => WriteLine($"File names are: {Path.GetFullPath(f)}"));


		return Task.CompletedTask;
	}
}
