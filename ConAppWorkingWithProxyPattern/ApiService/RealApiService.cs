using ConAppPlayingWithProxyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace ConAppPlayingWithProxyPattern.ApiService;
public class RealApiService : IApiService
{
	private readonly HttpClient _httpClient;

	public Task<string> GetDataAsync(string url)
	{
		WriteLine($"Fetching data from external source, URL: {url}");
		var response = _httpClient.GetStringAsync(url);
		return response;
	}
}
