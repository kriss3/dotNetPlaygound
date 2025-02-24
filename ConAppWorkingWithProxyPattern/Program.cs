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


public class RealImage : IImage 
{
	private readonly string _fileName;

	public RealImage(string fileName)
	{
		_fileName = fileName;
		LoadImageFromDisk();
	}

	public void DisplayImage()
	{
		WriteLine($"Displaying {_fileName}");
	}

	private void LoadImageFromDisk()
	{
		WriteLine($"Loading {_fileName} from Disk()");
	}
}

