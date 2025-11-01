using PlayingWithBackgroudWork.Services;

namespace PlayingWithBackgroudWork;

public class Program
{
	public static void Main()
	{
		var builder = WebApplication.CreateBuilder();

		builder.Services.AddControllers();
		builder.Services.AddOpenApi();
		builder.Services.AddSwaggerGen();
		builder.Services.AddSingleton<SampleData>();
		builder.Services.AddHostedService<BackgroundRefresh>();

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
