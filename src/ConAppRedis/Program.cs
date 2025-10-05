using Microsoft.Extensions.Configuration;
using static System.Console;
using ConAppRedis.Extensions;
using ConAppRedis.ApiOperations.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Distributed;

WriteLine("Hello, World!");
WriteLine("Getting Configuration");

ConfigurationBuilder configuration = new();
configuration.SetBasePath(Directory.GetCurrentDirectory())
	.AddJsonFile("appsettings.json");

var config = configuration.Build();

var builder = Host.CreateDefaultBuilder();

//using MsIHost host = MsHost.CreateDefaultBuilder()
//	.ConfigureServices((context, services) =>
//	{
//		services.AddSingleton<CharacterService>();
//		services.AddStackExchangeRedisCache(opt =>
//		{
//			opt.InstanceName = "ConAppRedis_";
//			opt.Configuration = config.GetConnectionString("Redis");
//		});
//	})
//	.Build();

await LoadData(host.Services);

await host.RunAsync();

WriteLine($"Redis connectionString is: {config.GetConnectionString("Redis")}");
WriteLine("Load Data...");

ReadLine();

static async Task LoadData(IServiceProvider services)
{
	using IServiceScope serviceScope = services.CreateScope();
	IServiceProvider provider = serviceScope.ServiceProvider;

	IEnumerable<Character>? data;
	string recordKey = $"DataKey_{DateTime.Now:yyyyMMdd_hhmm}";

	IDistributedCache cache = provider.GetRequiredService<IDistributedCache>();
	CharacterService svc = provider.GetRequiredService<CharacterService>();

	data = await cache.GetRecordAsync<Character[]>(recordKey);

	if (data is null)
	{
		WriteLine("Getting data from the service.");
		data = await svc.GetCharacterAsync();
		await cache.SetRecordAsync(recordKey, data);
	}
	else
	{
		WriteLine("Data retrieved from cache.");
	}
}