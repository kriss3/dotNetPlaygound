using ConAppPlayingWithProxyPattern.Interfaces;

using static System.Console;

namespace ConAppPlayingWithProxyPattern.ApiService;
public class CachedApiProxy : IApiService
{
	private readonly RealApiService _realApiService;
	private readonly Dictionary<string, (string Data, DateTime Expiry)> _cachedData = [];
	private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(10);

	public async Task<string> GetDataAsync(string url)
	{
		if (_cachedData.TryGetValue(url, out var cachedResponse) && DateTime.UtcNow < cachedResponse.Expiry) 
		{
			WriteLine("Returning cached data");
			return cachedResponse.Data;
		}
		else
		{
			WriteLine("Fetching data from external source");
			var data = await _realApiService.GetDataAsync(url);
			_cachedData[url] = (data, DateTime.UtcNow.Add(_cacheDuration));
			return data;
		}
	}
}
