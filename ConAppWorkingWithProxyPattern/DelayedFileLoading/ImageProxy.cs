using ConAppPlayingWithProxyPattern.Interfaces;

namespace ConAppPlayingWithProxyPattern.DelayedFileLoading;

public class ImageProxy(string fileName) : IImage
{
	// this class should implement a common interface and "wrap" the intended object.
	private readonly string _fileName = fileName;
	private RealImage? _realImage;

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

