using ConAppPlayingWithSqlChangeTracker.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using static System.Console;

namespace ConAppPlayingWithSqlChangeTracker.Services;

public class MonkeyChangeMonitorService(string connectionString)
{
	private readonly string _connectionString = connectionString;
	private SqlConnection? _connection;
	private bool _monitoring;

	public event EventHandler<MonkeyChange>? ChangeDetected;

	public async Task StartMonitoringAsync()
	{
		if (_monitoring)
			return;

		WriteLine("Starting SqlDependency...");
		SqlDependency.Start(_connectionString);

		_monitoring = true;
		await EstablishDependency();

		WriteLine("✅ Monkey change monitoring started!");
		WriteLine("Monitoring for INSERT, UPDATE, DELETE operations on dbo.Monkeys...");
		WriteLine();
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

	private async Task ProcessChanges()
	{
		try
		{
			using var connection = new SqlConnection(_connectionString);
			await connection.OpenAsync();

			// Get the last processed version
			var lastVersion = await GetLastProcessedVersion(connection);

			// Query change tracking for new changes
			using var command = new SqlCommand(@"
                    SELECT 
                        CT.MonkeyId,
                        CT.SYS_CHANGE_VERSION,
                        CT.SYS_CHANGE_OPERATION,
                        CT.SYS_CHANGE_COLUMNS,
                        M.Name,
                        M.Location,
                        M.Details,
                        M.Image,
                        M.Population,
                        M.Latitude,
                        M.Longitude,
                        M.CreatedDate
                    FROM CHANGETABLE(CHANGES dbo.Monkeys, @lastVersion) AS CT
                    LEFT OUTER JOIN dbo.Monkeys AS M ON M.MonkeyId = CT.MonkeyId
                    ORDER BY CT.SYS_CHANGE_VERSION", connection);

			command.Parameters.AddWithValue("@lastVersion", lastVersion);

			using var reader = await command.ExecuteReaderAsync();
			long maxVersion = lastVersion;

			while (await reader.ReadAsync())
			{
				var change = new MonkeyChange
				{
					MonkeyId = reader.GetInt32("MonkeyId"),
					Operation = reader.GetString("SYS_CHANGE_OPERATION"),
					ChangeVersion = reader.GetInt64("SYS_CHANGE_VERSION"),
					ChangedColumns = reader.IsDBNull("SYS_CHANGE_COLUMNS") ? null : reader.GetString("SYS_CHANGE_COLUMNS")
				};

				// For non-deleted records, get current data
				if (change.Operation != "D" && !reader.IsDBNull("Name"))
				{
					change.CurrentData = new Monkey
					{
						MonkeyId = change.MonkeyId,
						Name = reader.GetString("Name"),
						Location = reader.GetString("Location"),
						Details = reader.GetString("Details"),
						Image = reader.GetString("Image"),
						Population = reader.GetInt32("Population"),
						Latitude = reader.GetDecimal("Latitude"),
						Longitude = reader.GetDecimal("Longitude"),
						CreatedDate = reader.GetDateTime("CreatedDate")
					};
				}

				maxVersion = Math.Max(maxVersion, change.ChangeVersion);

				// Raise the event
				ChangeDetected?.Invoke(this, change);
			}

			// Update the last processed version
			if (maxVersion > lastVersion)
			{
				await UpdateLastProcessedVersion(connection, maxVersion);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine($"❌ Error processing changes: {ex.Message}");
		}
	}

	private static async Task<long> GetLastProcessedVersion(SqlConnection connection)
	{
		using var command = new SqlCommand(
			"SELECT LastProcessedVersion FROM dbo.ChangeTrackingVersions WHERE TableName = 'Monkeys'",
			connection);

		var result = await command.ExecuteScalarAsync();
		return result != null
            ? (long)result
            : 0;
	}

	private static async Task UpdateLastProcessedVersion(SqlConnection connection, long version)
	{
		using var command = new SqlCommand(@"
                UPDATE dbo.ChangeTrackingVersions 
                SET LastProcessedVersion = @version, LastUpdated = GETDATE() 
                WHERE TableName = 'Monkeys'", connection);

		command.Parameters.AddWithValue("@version", version);
		await command.ExecuteNonQueryAsync();
	}
}
