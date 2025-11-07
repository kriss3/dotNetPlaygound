using PlayingWithHttpClient.Models;

namespace PlayingWithHttpClient;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

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
