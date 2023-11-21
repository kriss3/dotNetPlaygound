
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using static System.Console;



namespace PlayingWithAsb;

public class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, World!");
        var host = CreateHostBuilder(args).Build();
        var svc = ActivatorUtilities.CreateInstance<SbClient>(host.Services);
        svc.SendMessage().Wait();
    }

    static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appSettings.json", optional: true);
                config.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<SbClient>();
            });
    }
}
