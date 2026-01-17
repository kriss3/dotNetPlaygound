using PlayingWithTranslink.Gtfs.Services;
using PlayingWithTranslink.Gtfs.Infrastructure.Helpers;
using static System.Console;

namespace PlayingWithTranslink.Gtfs;

public class Program
{
    static void Main(string[] args)
    {
        WriteLine("Playing with BC Translink GTFS system API.");
		var gtfsFolder = Path.Combine(AppContext.BaseDirectory, "Gtfs");

		if (!Directory.Exists(gtfsFolder))
		{
			WriteLine($"Missing GTFS folder: {gtfsFolder}");
			return;
		}

		var service = new GtfsService(gtfsFolder);
		RunMenu(service);
	}

	// ------------------------------------------------
	// Simple menu
	// ------------------------------------------------
	private static void RunMenu(GtfsService service)
	{
		while (true)
		{
			WriteLine();
			WriteLine("GTFS Experiment Menu");
			WriteLine("--------------------");
			WriteLine("1 - Search stops by name");
			WriteLine("2 - Next scheduled departures (static)");
			WriteLine("3 - Next departures with route & headsign");
			WriteLine("Q - Quit");
			WriteLine();
			Write("Choose an option: ");

			var choice = Console.ReadLine()?.Trim();

			WriteLine();

			switch (choice)
			{
				case "1":
					Experiment_SearchStops(service);
					break;

				case "2":
					Experiment_NextDepartures(service);
					break;

				case "3":
					Experiment_NextDeparturesWithRoutes(service);
					break;

				case "q":
				case "Q":
					WriteLine("Goodbye 👋");
					return;

				default:
					WriteLine("Unknown option. Please choose 1, 2, 3, or Q.");
					break;
			}
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
		var stopId = GtfsHelper.Prompt("Enter stop_id", "60980");
		var now = GtfsHelper.PromptTime("Current time (HH:mm)", DateTime.Now.TimeOfDay);
		var take = GtfsHelper.PromptInt("Max departures", 10);

		WriteLine();
		WriteLine($"Next scheduled departures for stop {stopId}");
		WriteLine();

		var departures = service.GetNextScheduledDepartures(stopId, now, take);

		if (departures.Count == 0)
		{
			WriteLine("No upcoming departures found.");
			return;
		}

		foreach (var d in departures)
			WriteLine(d);
	}

	// ------------------------------------------------
	// Experiment 3
	// ------------------------------------------------
	private static void Experiment_NextDeparturesWithRoutes(GtfsService service)
	{
		var stopId = GtfsHelper.Prompt("Enter stop_id", "60980");
		var now = GtfsHelper.PromptTime("Current time (HH:mm)", DateTime.Now.TimeOfDay);
		var take = GtfsHelper.PromptInt("Max departures", 10);

		WriteLine();
		WriteLine($"Next scheduled departures for stop {stopId}");
		WriteLine();

		var departures = service.GetNextDeparturesWithRoute(stopId, now, take);

		if (departures.Count == 0)
		{
			WriteLine("No upcoming departures found.");
			return;
		}

		foreach (var line in departures)
			WriteLine(line);
	}
}