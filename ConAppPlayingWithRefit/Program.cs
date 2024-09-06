using Microsoft.Extensions.DependencyInjection;
using static System.Console;
namespace ConAppPlayingWithRefit;

public class Program
{
    static async Task Main()
    {
        WriteLine("Hello, World!");
        await Task.CompletedTask;
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient("monkeyClient", client =>
        {
            client.BaseAddress = new Uri("https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/");
        });

        // Add Refit client
        services.AddTransient(provider => MonkeyApiFactory.CreateMonkeyApi(provider));
    }
}


