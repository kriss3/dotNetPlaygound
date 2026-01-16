using PlayingWithTranslink.Gtfs.Infrastructure;
using PlayingWithTranslink.Gtfs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayingWithTranslink.Gtfs.Services;

public sealed class GtfsService(string gtfsFolder)
{
	private readonly string _gtfsFolder = gtfsFolder ?? throw new ArgumentNullException(nameof(gtfsFolder));

	public IReadOnlyList<Stop> SearchStops(string query, int take = 20)
	{
		var stopsPath = Path.Combine(_gtfsFolder, "stops.txt");
		var stops = GtfsCsv.LoadSmall<Stop>(stopsPath);

		query ??= string.Empty;

		return [.. stops
			.Where(s => s.StopName.Contains(query, StringComparison.OrdinalIgnoreCase))
			.Take(take)];
			
	}

	public IReadOnlyList<string> GetNextScheduledDepartures(string stopId, TimeSpan now, int take = 10)
	{
		var stopTimesPath = Path.Combine(_gtfsFolder, "stop_times.txt");

		return [.. GtfsCsv.StreamBig<StopTime>(stopTimesPath)
			.Where(st => st.stop_id == stopId)
			.Select(st => (raw: st.departure_time, time: GtfsTime.ParseGtfsTime(st.departure_time)))
			.Where(x => x.time is not null && x.time.Value >= now)
			.OrderBy(x => x.time)
			.Take(take)
			.Select(x => x.raw)];
	}

	public IReadOnlyList<string> GetNextDeparturesWithRoute(string stopId, TimeSpan now, int take = 10)
	{
	}
}
