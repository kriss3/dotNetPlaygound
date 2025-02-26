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

	public Task<string> GetDataAsync(string url)
	{
		throw new NotImplementedException();
	}
}
