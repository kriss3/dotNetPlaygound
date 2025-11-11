using ConAppDelegates.v1;
using ConAppDelegates.v2;
using ConAppDelegates.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConAppDelegates;


class Program
{
	// This is a delegate definision. This acts as a C# type.
	public delegate IEnumerable<int> GetNumbersDelegate();
	static void Main()
	{
		PhotoProcessingDelegates();
		CustomDelegateExample();
		AdvancedDelegateExamples();

		ReadLine();
	}

	private static void CustomDelegateExample()
	{
		// Delegate instance.
		var myCustomDelegates = new MyCustomDelegates();

		// Connect GetNumbersDeleate with MyCustomDelegate:
		GetNumbersDelegate numberGetter = myCustomDelegates.GetBigNumbers;

		//Invoke the delegage, this is where call happes.
		var bigNumbers = numberGetter();

		WriteLine($"Big numbers found:");
		WriteLine(() => bigNumbers
		.Select(number => number.ToString())
		.ToArray());
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

	private static void AdvancedDelegateExamples()
	{
		var delegates = new AdvancedDelegates();
	}
}
