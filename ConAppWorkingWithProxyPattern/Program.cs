namespace ConAppPlayingWithProxyPattern;

using static System.Console;

public class Program
{
	static Task Main()
	{
		WriteLine("Working with Proxy Design Pattern!");
		return Task.CompletedTask;
	}
}


public interface IImage 
{
	void DisplayImage();
}


public class RealImage(string fileName) : IImage 
{
	private readonly string _fileName = fileName;

	public void DisplayImage()
	{
		WriteLine($"Displaying {_fileName}");
	}
}

