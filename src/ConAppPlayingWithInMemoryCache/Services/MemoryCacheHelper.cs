using ConAppPlayingWithInMemoryCache.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

	private static string GetBaseUrl()
	{
		return @"https://northwind.now.sh/api";
	}

	public Task<List<Product>> GetProductsWithCache()
	{
		// var products = _memoryCache.Get<List<Product>>("products");
		throw new NotImplementedException();
	}
}
