
using Microsoft.Extensions.DependencyInjection;

using static System.Console;

namespace ConAppPlayingWithInMemoryCache;

public class Program
{
	static Task Main()
	{
		WriteLine("In-Memory Cache exercise!");
		ConfigureDependency();

		return Task.CompletedTask;
	}

	private static void ConfigureDependency()
	{
		

		var services = new ServiceCollection();
		services.AddMemoryCache();
	}
}
