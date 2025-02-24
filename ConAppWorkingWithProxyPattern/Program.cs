namespace ConAppPlayingWithProxyPattern;

using static System.Console;


public class Program
{
	static void Main()
	{
		WriteLine("Working with Proxy Design Pattern!");

		// Comment and implementation of RealImage and ImageProxy:
		/*
			The Proxy design pattern is a structural design pattern.
			It provides a surrogate or placeholder for another object to control access to it. 
			It's useful for scenarios like lazy initialization, access control, logging, and security.

			Other use cases for Proxy Design Pattern: 
			A common use case is lazy initialization, where the proxy defers the creation of a resource until it's actually needed.
		 */

		Run();

	}

	private static void  Run() 
	{
		ImageProxy myNewImageProxy = new("someInterestingFile.jpg");

		WriteLine("The file is not yet loaded...");

		//Loading ima/file from the disk happens at exact, controlled moment rather then during object creation.
		myNewImageProxy.DisplayImage();
	}
}
