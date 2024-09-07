using ConAppPlayingWithRefit.MonkeyClient;
using ConAppPlayingWithRefit.Service;
using Microsoft.Extensions.DependencyInjection;
using static System.Console;
namespace ConAppPlayingWithRefit;

public class Program
{
    static async Task Main()
    {
        WriteLine("Hello, World!");
        var monkeySvc = ConfigureServices();

        var monkeyService = monkeySvc.GetRequiredService<MonkeyService>();
        var monkeys = await monkeyService.GetMonkeys();

        foreach (var monkey in monkeys)
        foreach (var monkey in monkeys)
        {
            WriteLine($"{monkey.Name} - {monkey.Location}");
        }
    }

    public static IServiceProvider ConfigureServices()
    {
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddHttpClient("monkeyClient", client =>
            {
                client.BaseAddress = new Uri("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/");
            })
            .AddTransient<IMonkeyApi, MonkeyApi>()
            .AddTransient<MonkeyService>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}


