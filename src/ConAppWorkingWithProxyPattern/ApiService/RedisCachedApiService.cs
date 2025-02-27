using ConAppPlayingWithProxyPattern.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithProxyPattern.ApiService;
public class RedisCachedApiService : IApiService
{
	// Implementing the Proxy with Redis.
	private readonly RealApiService _realApiService;
	private readonly IDatabase _redisDatabase;
	private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(30);

	public RedisCachedApiService()
	{
		var redis = ConnectionMultiplexer.Connect("add azure Redis connection string, after u set it up...");
		_redisDatabase = redis.GetDatabase();
		_realApiService = new RealApiService(new HttpClient());
	}

	public async Task<string> GetDataAsync(string url)
	{
		string cacheKey = $"api_cache:{url}";
		var cachedData = await _redisDatabase.StringGetAsync(cacheKey);

		if (!cachedData.IsNullOrEmpty)
		{
			Console.WriteLine($"Returning cached data from Redis for: {url}");
			return cachedData.ToString();
		}

		var data = await _realApiService.GetDataAsync(url);
		await _redisDatabase.StringSetAsync(cacheKey, data, _cacheDuration);
		return data;
	}
}
