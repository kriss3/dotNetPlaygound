using ConAppPlayingWithProxyPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace ConAppPlayingWithProxyPattern.ApiService;
public class CachedApiProxy : IApiService
{
	public Task<string> GetDataAsync(string url)
	{
		throw new NotImplementedException();
	}
}
