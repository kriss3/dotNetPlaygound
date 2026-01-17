namespace PlayingWithTranslink.Gtfs;

using PlayingWithTranslink.Gtfs.Services;
using static System.Console;

public class Program
{
    static void Main(string[] args)
    {
        WriteLine("Playing with BC Translink GTFS system API.");
		var gtfsFolder = Path.Combine(AppContext.BaseDirectory, "Gtfs");

		if (!Directory.Exists(gtfsFolder))
		{
			WriteLine($"Missing folder: {gtfsFolder}");
			WriteLine("Make sure Gtfs/*.txt are set to Copy if newer.");
			return;
		}

		var svc = new GtfsService(gtfsFolder);

		var mode = args.Length > 0 ? args[0] : "1";

		switch (mode)
		{
			case "1":
				{
					Write("Search text (e.g. 'commercial'): ");
					var query = ReadLine() ?? "";

					var matches = svc.SearchStops(query);

					WriteLine();
					WriteLine($"Matches ({matches.Count}):");
					foreach (var s in matches)
						WriteLine($"{s.StopId} | {s.StopName} | {s.StopLatitude},{s.StopLongitute}");
					break;
				}
			case "2":
				{
					var stopId = args.ElementAtOrDefault(1) ?? "60980";
					var now = DateTime.Now.TimeOfDay;

					var next = svc.GetNextScheduledDepartures(stopId, now);

					WriteLine($"Next scheduled departures for stop {stopId}:");
					foreach (var t in next) 
						WriteLine(t);

					if (next.Count == 0)
						WriteLine("No upcoming departures found. Try a different stop_id or run at a different time.");
					break;
				}
			case "3":
				{
					var stopId = args.ElementAtOrDefault(1) ?? "60980";
					var now = DateTime.Now.TimeOfDay;
					var next = svc.GetNextDeparturesWithRoute(stopId, now);

					WriteLine($"Next scheduled departures for stop {stopId}:");
					foreach (var line in next) 
						WriteLine(line);

					if (next.Count == 0)
						WriteLine("No upcoming departures found. Try a different stop_id or run at a different time.");
					break;
				}
			default:
				WriteLine("Usage:");
				WriteLine("  dotnet run -- 1");
				WriteLine("  dotnet run -- 2 <stopId>");
				WriteLine("  dotnet run -- 3 <stopId>");
				break;
		}
	}



	// ------------------------------------------------
	// Experiment 1
	// ------------------------------------------------
	private static void Experiment_SearchStops(GtfsService service)
	{
		Write("Enter stop search text: ");
		var query = ReadLine() ?? string.Empty;

		Write("Max results (default 10): ");
		var takeInput = ReadLine();
		var take = int.TryParse(takeInput, out var t) ? t : 10;

		WriteLine();
		WriteLine($"Searching stops for '{query}'");
		WriteLine();

		var stops = service.SearchStops(query, take);

		if (stops.Count == 0)
		{
			WriteLine("No stops found.");
			return;
		}

		foreach (var s in stops)
		{
			WriteLine($"{s.StopId} | {s.StopName}");
		}
	}

	// ------------------------------------------------
	// Experiment 2
	// ------------------------------------------------
	private static void Experiment_NextDepartures(GtfsService service)
	{
		var stopId = Prompt("Enter stop_id", "60980");
		var now = PromptTime("Current time (HH:mm)", DateTime.Now.TimeOfDay);
		var take = PromptInt("Max departures", 10);

		Console.WriteLine();
		Console.WriteLine($"Next scheduled departures for stop {stopId}");
		Console.WriteLine();

		var departures = service.GetNextScheduledDepartures(stopId, now, take);

		if (departures.Count == 0)
		{
			Console.WriteLine("No upcoming departures found.");
			return;
		}

		foreach (var d in departures)
			Console.WriteLine(d);
	}
}