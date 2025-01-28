
namespace PlayingWithDDD.App;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
		builder.Services.AddOpenApi();

		builder.Services.AddHttpClient<IExternalApiClient, ExternalApiClient>(client =>
		{
			client.BaseAddress = new Uri("https://external-api.example.com/");
		});

		var app = builder.Build();

		// Configure the HTTP request pipeline.
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
