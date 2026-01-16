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
					Console.Write("Search text (e.g. 'commercial'): ");
					var query = Console.ReadLine() ?? "";

					var matches = svc.SearchStops(query);

					Console.WriteLine();
					Console.WriteLine($"Matches ({matches.Count}):");
					foreach (var s in matches)
						Console.WriteLine($"{s.StopId} | {s.StopName} | {s.StopLatitude},{s.StopLongitute}");
					break;
				}
			default:
				break;
		}
	}
}
