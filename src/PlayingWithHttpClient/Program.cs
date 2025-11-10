using Microsoft.Extensions.Options;
using PlayingWithHttpClient.Models;
using PlayingWithHttpClient.Services;

namespace PlayingWithHttpClient;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		if (builder.Environment.IsDevelopment())
			builder.Configuration.AddUserSecrets<Program>();

		// Use this option when used simples version of IHttpClientFactory, for more look at below config:
		builder.Services.AddHttpClient();

		builder.Services.AddHttpClient("gitHub", (serviceProvider, httpClient) =>
		{
			var gitHubSettings = serviceProvider.GetRequiredService<IOptions<GitHubSettings>>().Value;

			httpClient.DefaultRequestHeaders.Add("Authorization", gitHubSettings.AccessToken);
			httpClient.DefaultRequestHeaders.Add("User-Agent", gitHubSettings.UserAgent);
			httpClient.BaseAddress = new Uri("https://api.github.com");
		});

		// Typed HttpClient, HttpClient tight to the GitHubService.
		// REMEMBER: This is Transient service registreation with DI.
		// If using Typed client make sure to configure PrimaryMessageHandler when u want to use Transient service from Singleton.
		builder.Services.AddHttpClient<GitHubService>((serviceProvider, httpClient) =>
		{
			var gitHubSettings = serviceProvider.GetRequiredService<IOptions<GitHubSettings>>().Value;

			httpClient.DefaultRequestHeaders.Add("Authorization", gitHubSettings.AccessToken);
			httpClient.DefaultRequestHeaders.Add("User-Agent", gitHubSettings.UserAgent);
			httpClient.BaseAddress = new Uri("https://api.github.com");
		})
		.ConfigurePrimaryHttpMessageHandler(() => 
		{
			return new SocketsHttpHandler { PooledConnectionIdleTimeout = TimeSpan.FromMinutes(5) };
		})
		.SetHandlerLifetime(Timeout.InfiniteTimeSpan);

		builder.Services.AddControllers();
		builder.Services.AddOpenApi();

		builder.Services.AddOptions<GitHubSettings>()
			.BindConfiguration(GitHubSettings.ConfigurationSection)
			.ValidateDataAnnotations()
			.ValidateOnStart();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
