
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
		var t1 = Stopwatch.StartNew();

		var products = await memoryCacheHelper.GetProductsOrCache();

		t1.Stop();
		WriteLine($"Time taken to fetch products: {t1.ElapsedMilliseconds / 1000} sec.");

		MemoryCacheHelper.DisplayProducts(products);
	}

	private static IHost ConfigureDependency()
	{
		var host = Host.CreateDefaultBuilder();

		host.ConfigureServices((ctx, svc) => {
			svc.AddMemoryCache();

		});

		return host.Build();
	}

	private void RunAndReport(Func<List<Product>> getFromApiOrCache) 
	{
		var t1 = Stopwatch.StartNew();
		var result = getFromApiOrCache();
		t1.Stop();
		MemoryCacheHelper.DisplayProducts(result);
		WriteLine($"Time taken to fetch products: {t1.ElapsedMilliseconds / 1000} sec.");

	}
}
