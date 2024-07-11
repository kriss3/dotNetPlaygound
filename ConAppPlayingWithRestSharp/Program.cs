
using ConAppPlayingWithRestSharp.Model;
using ConAppPlayingWithRestSharp.Service;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;

using static System.Console;

namespace ConAppPlayingWithRestSharp;

public class Program
{
	static async Task Main(string[] args)
	{

			WriteLine("Playing with RestSharp Lib");
            using var host = CreateHostBuilder().Build();
            var _apiService = host.Services.GetRequiredService<ApiService>();

            try
			{
                var data = await _apiService.GetAsync<DataReturnModel>("endpoint");
                if (data != null)
                {
                    WriteLine("Request succeeded");
                }
                else
                {
                    Console.WriteLine("No data returned");
                }
            }
			catch (Exception ex)
			{
                WriteLine($"An error occurred: {ex.Message}");
			}
		  
	}

    private static IHostBuilder CreateHostBuilder() 
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<IApiService, ApiService>();
                services.AddSingleton<RestClient>();
            });
    }
}
