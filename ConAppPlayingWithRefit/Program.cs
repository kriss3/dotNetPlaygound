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

        // Set up DI and Refit client
        var serviceProvider = new ServiceCollection()
            .AddRefitClient<IMonkeyApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/"))
            .Services
            .AddTransient<MonkeyService>()
            .BuildServiceProvider();

        // Resolve the MonkeyService and call the API
        var monkeyService = serviceProvider.GetRequiredService<MonkeyService>();
        var monkeys = await monkeyService.GetMonkeys();

        // Output the data
        foreach (var monkey in monkeys)
        {
            WriteLine($"{monkey.Name} - {monkey.Location}");
        }
    }
}


