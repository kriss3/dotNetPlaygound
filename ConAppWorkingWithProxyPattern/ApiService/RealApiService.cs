using ConAppPlayingWithProxyPattern.Interfaces;

using static System.Console;

namespace ConAppPlayingWithProxyPattern.ApiService;
public class RealApiService : IApiService
{
	private readonly HttpClient _httpClient;

	public RealApiService(HttpClient httpClient)
	{
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	}

	public Task<string> GetDataAsync(string url)
	{
		WriteLine($"Fetching data from external source, URL: {url}");
		var response = _httpClient.GetStringAsync(url);
		return response;
	}
}
