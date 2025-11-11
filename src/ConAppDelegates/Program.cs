using ConAppDelegates.v2;
using System;
using static System.Console;

namespace ConAppDelegates;


class Program
{
    static void Main()
	{
		PhotoProcessingDelegates();

		ReadLine();
	}

	private static void CustomDelegateExample()
	{ 
	
	}

	private static void PhotoProcessingDelegates()
	{
		var processor = new PhotoProcessor();
		var filters = new PhotoFilters();
		Action<Photo> filterHandler = PhotoFilters.ApplyBrightness;
		filterHandler += filters.ApplyingContrast;
		filterHandler += filters.Resize;
		filterHandler += RemoveRedEye;
		PhotoProcessor.Process("photo.jpg", filterHandler);
	}

	private static void RemoveRedEye(Photo photo) 
    {
        WriteLine("Removing Red Eye from the photo.");
    }
}
