namespace ConAppPlayingWithProxyPattern;

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

