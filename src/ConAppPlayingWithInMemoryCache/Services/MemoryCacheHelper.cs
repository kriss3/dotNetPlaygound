using ConAppPlayingWithInMemoryCache.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithInMemoryCache.Services;

public interface IMemoryCacheHelper
{
	Task<List<Product>> GetProductsWithCache();
	Task<List<Product>> GetProducts();
}
public class MemoryCacheHelper : IMemoryCacheHelper
{
	public List<Product>? Products { get; set; }

	public Task<List<Product>> GetProducts()
	{
		throw new NotImplementedException();
	}

	public Task<List<Product>> GetProductsWithCache()
	{
		throw new NotImplementedException();
	}
}
