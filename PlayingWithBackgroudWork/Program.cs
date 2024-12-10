
using Microsoft.OpenApi.Models;
using PlayingWithBackgroudWork;
using PlayingWithBackgroudWork.Services;

namespace WebAppPlayingWithBackgroudWork;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		builder.Services.AddControllers();
		builder.Services.AddOpenApi();
		builder.Services.AddSwaggerGen(c => // Add this configuration
		{
			c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
		});
		builder.Services.AddSingleton<SampleData>();
		builder.Services.AddHostedService<BackgroundRefresh>();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
			app.UseSwagger();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
