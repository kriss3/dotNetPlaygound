namespace ConAppPlayingWithProxyPattern.DelayedFileLoading;

using static System.Console;

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

