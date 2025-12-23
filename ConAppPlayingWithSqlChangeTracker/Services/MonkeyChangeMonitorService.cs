using ConAppPlayingWithSqlChangeTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

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

}
