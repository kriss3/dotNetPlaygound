namespace ConAppPlayingWithSqlChangeTracker;

using ConAppPlayingWithSqlChangeTracker.Models;
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

	private static void OnMonkeyChanged(object sender, MonkeyChange change)
	{
		Console.WriteLine();
		Console.WriteLine("🔥 CHANGE DETECTED!");
		Console.WriteLine($"   Operation: {GetOperationName(change.Operation)}");
		Console.WriteLine($"   MonkeyId: {change.MonkeyId}");
		Console.WriteLine($"   Version: {change.ChangeVersion}");
		Console.WriteLine($"   Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

		if (!string.IsNullOrEmpty(change.ChangedColumns))
		{
			Console.WriteLine($"   Changed Columns: {change.ChangedColumns}");
		}

		if (change.CurrentData != null)
		{
			Console.WriteLine($"   Current Data: {change.CurrentData.Name} - {change.CurrentData.Location}");
		}
		else if (change.Operation == "D")
		{
			Console.WriteLine($"   Record was deleted");
		}

		Console.WriteLine();

		// Here you can add your custom logic to handle the change
		// For example: send notifications, update caches, trigger workflows, etc.
		HandleChange(change);
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

	private static void HandleChange(MonkeyChange change)
	{
		// Your custom change handling logic here
		switch (change.Operation)
		{
			case "I": // Insert
				Console.WriteLine($"   👉 Custom Handler: New monkey added - {change.CurrentData?.Name}");
				break;
			case "U": // Update
				Console.WriteLine($"   👉 Custom Handler: Monkey updated - {change.CurrentData?.Name}");
				break;
			case "D": // Delete
				Console.WriteLine($"   👉 Custom Handler: Monkey deleted - ID {change.MonkeyId}");
				break;
		}
	}

	private static string GetOperationName(string operation)
	{
		return operation switch
		{
			"I" => "INSERT",
			"U" => "UPDATE",
			"D" => "DELETE",
			_ => operation
		};
	}
}
