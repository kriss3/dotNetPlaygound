using System;
using System.Collections.Generic;
using System.Text;

namespace ConAppPlayingWithSqlChangeTracker.Services;

public class MonkeyChangeMonitorService
{
	private readonly string _connectionString;
	private SqlConnection _connection;
	private bool _monitoring;
}
