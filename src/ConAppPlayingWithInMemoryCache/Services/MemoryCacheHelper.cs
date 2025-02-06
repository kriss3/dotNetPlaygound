using ConAppPlayingWithInMemoryCache.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Text.Json;

using static System.Console;

namespace ConAppPlayingWithInMemoryCache.Services;

public interface IMemoryCacheHelper
{
	Task<ProductResult> GetProductsWithCache();
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
			WriteLine($"An error occurred while fetching products: {ex.Message}");
			return [];
		}
	}

	public async Task<ProductResult> GetProductsOrCache() 
	{
		var cacheKey = "productsList";
		string from;
		
		if (!_memoryCache.TryGetValue(cacheKey, out List<Product>? products))
		{
			//no key in the cache, get data;
			from = "API";
			products = await GetProducts();
			//set the cache options
			var cacheEntryOptions = new MemoryCacheEntryOptions 
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(50),
				Priority = CacheItemPriority.High,
				SlidingExpiration = TimeSpan.FromSeconds(20)
			};

			_memoryCache.Set(cacheKey, products, cacheEntryOptions);
			return new ProductResult(from, products);
		}

		return new ProductResult("Cache", products ?? []);
	}

	private static string GetBaseUrl()
	{
		return @"https://northwind.now.sh/api";
	}

	//This would be the external facing "driver" methos.
	public async Task<ProductResult> GetProductsWithCache()
	{
		var products = await GetProductsOrCache();
		return products;
	}

	public static void DisplayProducts(ProductResult products)
	{
		WriteLine($"Products from: {products.From}");	
		WriteLine($"Available Product: {products.Products.Count}");
	}
}
