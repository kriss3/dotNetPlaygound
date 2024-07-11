
using ConAppPlayingWithRestSharp.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;
using System.Runtime.CompilerServices;
using static System.Console;

namespace ConAppPlayingWithRestSharp;

public class Program
{
	static async Task Main(string[] args)
	{
		await Task.Run(() => 
		{ 
			WriteLine("Playing with RestSharp Lib");
            using var host = CreateHostBuilder().Build();
            var exampleUsage = host.Services.GetRequiredService<ExampleUsage>();

            try
			{
                var data = await _apiService.GetAsync<MyDataModel>("endpoint");
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
		});  
	}

    private static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton<IApiService, ApiService>();
                services.AddSingleton<RestClient>();
                services.AddSingleton<ExampleUsage>();
            });


}
