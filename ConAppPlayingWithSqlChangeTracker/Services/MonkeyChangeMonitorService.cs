using ConAppPlayingWithSqlChangeTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ConAppPlayingWithSqlChangeTracker.Services;

public class MonkeyChangeMonitorService(string connectionString)
{
	private readonly string _connectionString = connectionString;
	private SqlConnection _connection;
	private bool _monitoring;

	public event EventHandler<MonkeyChange> ChangeDetected;

	public async Task StartMonitoringAsync()
	{
		if (_monitoring)
			return;

		Console.WriteLine("Starting SqlDependency...");
		SqlDependency.Start(_connectionString);

		_monitoring = true;
		await EstablishDependency();

		Console.WriteLine("✅ Monkey change monitoring started!");
		Console.WriteLine("Monitoring for INSERT, UPDATE, DELETE operations on dbo.Monkeys...");
		Console.WriteLine();
	}

	public void StopMonitoring()
	{
		if (!_monitoring)
			return;

		_monitoring = false;
		_connection?.Close();
		SqlDependency.Stop(_connectionString);

		Console.WriteLine("🛑 Monitoring stopped.");
	}

	private async Task EstablishDependency()
	{
		try
		{
			_connection?.Close();
			_connection = new SqlConnection(_connectionString);

			// Simple query that SqlDependency can monitor
			var command = new SqlCommand(
				"SELECT MonkeyId, Name FROM dbo.Monkeys",
				_connection);

			var dependency = new SqlDependency(command);
			dependency.OnChange += OnDependencyChange;

			await _connection.OpenAsync();
			await command.ExecuteReaderAsync();

			WriteLine($"🔄 Dependency established at {DateTime.Now:HH:mm:ss}");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"❌ Error establishing dependency: {ex.Message}");
			throw;
		}
	}

	private async void OnDependencyChange(object sender, SqlNotificationEventArgs e)
	{
		Console.WriteLine($"🔔 Change notification received at {DateTime.Now:HH:mm:ss}");
		Console.WriteLine($"   Info: {e.Info}, Source: {e.Source}, Type: {e.Type}");

		if (e.Info == SqlNotificationInfo.Insert ||
			e.Info == SqlNotificationInfo.Update ||
			e.Info == SqlNotificationInfo.Delete ||
			e.Info == SqlNotificationInfo.Invalid) // Invalid often means data changed
		{
			await ProcessChanges();
		}

		// Re-establish the dependency for continued monitoring
		if (_monitoring)
		{
			await Task.Delay(1000); // Small delay to avoid rapid re-establishment
			await EstablishDependency();
		}
	}
}
