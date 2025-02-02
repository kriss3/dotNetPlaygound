
using ConAppPlayingWithInMemoryCache.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Console;

namespace ConAppPlayingWithInMemoryCache;

public class Program
{
	static async Task Main()
	{
		WriteLine("In-Memory Cache exercise!");
		var host = ConfigureDependency();

		var memCache= host.Services.GetRequiredService<IMemoryCache>();
		var memoryCacheHelper = new MemoryCacheHelper(memCache);

		var products = await memoryCacheHelper.GetProducts();
	}

	private static IHost ConfigureDependency()
	{
		var host = Host.CreateDefaultBuilder();

		host.ConfigureServices((ctx, svc) => {
			svc.AddMemoryCache();

		});

		return host.Build();
	}
}
