using ConAppPlayingWithInMemoryCache.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Text.Json;

using static System.Console;

namespace ConAppPlayingWithInMemoryCache.Services;

public interface IMemoryCacheHelper
{
	Task<List<Product>> GetProductsWithCache();
	Task<List<Product>> GetProducts();
}
public class MemoryCacheHelper(IMemoryCache memCache) : IMemoryCacheHelper
{
	private readonly IMemoryCache _memoryCache = memCache;

	public List<Product>? Products { get; set; }

	public async Task<List<Product>> GetProducts()
	{
		try
		{
			HttpClient client = new();
			var baseUrl = GetBaseUrl();
			var endpoint = $"{baseUrl}/products";
			var streamTask = client.GetStreamAsync(endpoint);
			var products = await JsonSerializer.DeserializeAsync<List<Product>>(await streamTask);
			return products!;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"An error occurred while fetching products: {ex.Message}");
			return new List<Product>();
		}
	}

	public async Task<List<Product>> GetProductsOrCache() 
	{
		var cacheKey = "productsList";
		//var products = new List<Product>();

		if (!_memoryCache.TryGetValue(cacheKey, out List<Product>? products))
		{
			//no key in the cache, get data;
			products = await GetProducts();
			//set the cache options
			var cacheEntryOptions = new MemoryCacheEntryOptions 
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(50),
				Priority = CacheItemPriority.High,
				SlidingExpiration = TimeSpan.FromSeconds(20)
			};

			_memoryCache.Set(cacheKey, products, cacheEntryOptions);
		}

		return products ?? [];
	}

	private static string GetBaseUrl()
	{
		return @"https://northwind.now.sh/api";
	}

	//This would be the external facing "driver" methos.
	public async Task<List<Product>> GetProductsWithCache()
	{
		var t1 = Stopwatch.StartNew();
		t1.Start();
		var products = await GetProductsOrCache();

		t1.Stop();
		var elapsed = t1.ElapsedMilliseconds;
		
		DisplayProducts(products);
		WriteLine($"Elapsed time: {elapsed / 1000.0} seconds");
		return products;
	}

	private void DisplayProducts(List<Product> products)
	{
		foreach (var product in products)
		{
			WriteLine($"Product Id: {product.Id}");
			WriteLine($"Product Name: {product.Name}");
			WriteLine($"Product Quantity Per Unit: {product.QuantityPerUnit}");
			WriteLine($"Product Unit Price: {product.UnitPrice}");
			WriteLine();
		}
	}
}
