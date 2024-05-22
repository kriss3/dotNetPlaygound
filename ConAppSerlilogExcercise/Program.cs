using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using static System.Console;

namespace ConAppSerlilogExcercise;

class Program
{
    static void Main(string[] args)
    {
        WriteLine("Start !");
        SerilogConfigure();

        Log.Information("Starting Main app. Info Log");

        Run();

        try
        {
            var a = 10;
            var b = 0;
            Log.Debug("The value of A is: {A} and value of B is: {B}", a, b);

            int c = a / b;
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message, "Error occured");
        }
        Log.CloseAndFlush();
        WriteLine("Completed");
        ReadKey();
    }

    private static void Run()
    {
        Log.Information("In static Run() method");
        Log.Warning("This is warning Message");

        // Get normal file path of this assembly's permanent directory
        var path = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).LocalPath;
        var user = Environment.UserName;
        Log.Information("Current user is: {UserName}", user);
        Log.Information("Current app path is: {0}", path);
        Log.Information("Exit from Run()");
    }

    private static void SerilogConfigure()
    {
        //get both values from appSettings
        var logDB = "Data Source=ABT101059;Initial Catalog=SerilogsDb;Integrated Security=True";
        var serilogTbl = "Logs";
        var options = new ColumnOptions();
        options.Store.Remove(StandardColumn.Properties);
        options.Store.Add(StandardColumn.LogEvent);
        options.LogEvent.DataLength = 2048;
        options.PrimaryKey = options.TimeStamp;
        options.TimeStamp.NonClusteredIndex = true;

        // how do I use MSSqlServerSinkOptions

        var sinkOptions = new MSSqlServerSinkOptions
        {
            TableName = serilogTbl,
            AutoCreateSqlTable = true,
            BatchPostingLimit = 1000,
            EagerlyEmitFirstEvent = true,
            SchemaName = "dbo",
        };

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo
            .MSSqlServer(connectionString: logDB, sinkOptions: sinkOptions, columnOptions: options)
            .CreateLogger();
    }
}
