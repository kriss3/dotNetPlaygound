namespace PlayingWithTranslink.Gtfs;

using PlayingWithTranslink.Gtfs.Services;
using static System.Console;

public class Program
{
    static void Main()
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
	}
}
