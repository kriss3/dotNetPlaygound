using Microsoft.Extensions.Options;
using PlayingWithHttpClient.Models;

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
