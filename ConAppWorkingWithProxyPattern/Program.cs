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

public class ImageProxy : IImage
{
	// this class should implement a common interface and "wrap" the intended object.
	private readonly string _fileName;
	private RealImage? _realImage;

	public ImageProxy(string fileName)
	{
		_fileName = fileName;
	}

	public void DisplayImage()
	{
		_realImage ??= new RealImage(_fileName);
		//if (_realImage is null)
		//{
		//	_realImage = new RealImage(_fileName);
		//}
		//_realImage.DisplayImage();
	}	

}

