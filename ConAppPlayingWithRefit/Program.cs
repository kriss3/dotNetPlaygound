using ConAppPlayingWithRefit.Service;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;

using Refit;
using ConAppPlayingWithRefit.MonkeyClient;


namespace ConAppPlayingWithRefit;

public class Program
{
    static async Task Main()
    {
        WriteLine("Hello, Monkey World!");
        var serviceProvide = ConfigureServices();
        var monkeyService = serviceProvide.GetRequiredService<MonkeyService>();
        var myMonkeys = await monkeyService.GetMonkeys();
        ReadKey();
    }

    private static ServiceProvider ConfigureServices() 
    {
        var serviceProvider = new ServiceCollection()
            .AddHttpClient()
            .AddTransient(provider => {
                var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient();
                httpClient.BaseAddress = new Uri("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/");

                return RestService.For<IMonkeyApi>(httpClient);
            })
            .AddTransient<MonkeyService>()
            .BuildServiceProvider();

        return serviceProvider;

    }
}


