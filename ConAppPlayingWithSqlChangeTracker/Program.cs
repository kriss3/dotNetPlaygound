namespace ConAppPlayingWithSqlChangeTracker;

using ConAppPlayingWithSqlChangeTracker.Services;
using Microsoft.Extensions.Configuration;
using static System.Console;

public class Program
{
	private static readonly string ConnectionString = GetConnectionStr();
	static async Task Main()
	{
		WriteLine("Change Monitor for SQL Table dbo.Monkeys");

		WriteLine("🐵 Monkey Change Monitor Starting...");
		WriteLine("=====================================");

		var monitor = new MonkeyChangeMonitorService(ConnectionString);



	}

	private static string GetConnectionStr()
	{
		var config = new ConfigurationBuilder()
			.AddUserSecrets<Program>(optional: true)
			.Build();
		var cs = config.GetConnectionString("connString") ?? config["Sql:ConnectionString"];

		if (string.IsNullOrWhiteSpace(cs))
		{
			WriteLine("Connection string not found. Set it via User Secrets:");
			WriteLine("  dotnet user-secrets init");
			WriteLine("  dotnet user-secrets set \"ConnectionStrings:SqlDb\" \"<your-connection-string>\"");
			return string.Empty;
		}

		return cs;
	}
}
