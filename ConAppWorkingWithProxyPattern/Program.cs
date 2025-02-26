

using ConAppPlayingWithProxyPattern.AccessControl;
using ConAppPlayingWithProxyPattern.ApiService;
using ConAppPlayingWithProxyPattern.DelayedFileLoading;
using static System.Console;

namespace ConAppPlayingWithProxyPattern;

public class Program
{
	static async Task Main()
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

		RunLazyLoadingExample();
		RunDataAccessExample();
		await RunApiServiceProxyExample();
		await RunRedisCacheProxyExample();

	}

	private static void  RunLazyLoadingExample() 
	{
		ImageProxy myNewImageProxy = new("someInterestingFile.jpg");

		WriteLine("Image is created but the file had not yet been loaded...");

		//Loading ima/file from the disk happens at exact, controlled moment rather then during object creation.
		myNewImageProxy.DisplayImage();
	}

	private static void RunDataAccessExample()
	{
		var dataAccess = new DataServiceProxy();

		WriteLine("Accessing data as Guest.../nUser: Guest");
		dataAccess.FetchData("Guest");

		WriteLine("Accessing data as Admin.../nUser: Admin");
		dataAccess.FetchData("Admin");
	}

	private static async Task RunApiServiceProxyExample() 
	{
		string urlToFetchedData = "https://jsonplaceholder.typicode.com/todos/1";
		var apiService = new CachedApiProxy();

		WriteLine("First request:");
		string response1 = await apiService.GetDataAsync(urlToFetchedData);
		WriteLine(response1);


		WriteLine("\nSecond request (should return cached data):");
		string response2 = await apiService.GetDataAsync(urlToFetchedData);
		WriteLine(response2);

		WriteLine("\nWaiting 35 seconds for cache to expire...");
		await Task.Delay(35000);

		WriteLine("\nThird request (should fetch fresh data):");
		string response3 = await apiService.GetDataAsync(urlToFetchedData);
		WriteLine(response3);
	}

	private static async Task RunRedisCacheProxyExample()
	{
		throw new NotImplementedException();
	}
}
