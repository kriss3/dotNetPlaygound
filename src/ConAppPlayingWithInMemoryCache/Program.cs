
using ConAppPlayingWithInMemoryCache.Models;
using ConAppPlayingWithInMemoryCache.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
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

		Write("How many time to run?\t");
		var times = int.Parse(ReadLine());

		while (times-- > 0)
			await RunAndReport(memoryCacheHelper.GetProductsOrCache);

		ReadLine();
	}

	private static async Task RunAndReport(Func<Task<ProductResult>> getFromApiOrCache) 
	{
		var t1 = Stopwatch.StartNew();
		var result = await getFromApiOrCache();
		t1.Stop();
		MemoryCacheHelper.DisplayProducts(result);
		WriteLine($"Time taken to fetch products: {t1.ElapsedMilliseconds} m.sec.");

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
