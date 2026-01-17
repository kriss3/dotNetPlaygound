using PlayingWithTranslink.Gtfs.Infrastructure;
using PlayingWithTranslink.Gtfs.Infrastructure.Maps;
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
		var stops = GtfsCsv.LoadSmall<Stop, StopMap>(stopsPath);

		query ??= string.Empty;

		return [.. stops
			.Where(s => s.StopName.Contains(query, StringComparison.OrdinalIgnoreCase))
			.Take(take)];
	}

	public IReadOnlyList<string> GetNextScheduledDepartures(string stopId, TimeSpan now, int take = 10)
	{
		var stopTimesPath = Path.Combine(_gtfsFolder, "stop_times.txt");

		return [.. GtfsCsv.StreamBig<StopTime, StopTimeMap>(stopTimesPath)
			.Where(st => st.StopId == stopId)
			.Select(st => (raw: st.DepartureTime, time: GtfsTime.ParseGtfsTime(st.DepartureTime)))
			.Where(x => x.time is not null && x.time.Value >= now)
			.OrderBy(x => x.time)
			.Take(take)
			.Select(x => x.raw)];
	}

	public IReadOnlyList<string> GetNextDeparturesWithRoute(string stopId, TimeSpan now, int take = 10)
	{
		var routesPath = Path.Combine(_gtfsFolder, "routes.txt");
		var tripsPath = Path.Combine(_gtfsFolder, "trips.txt");
		var stopTimesPath = Path.Combine(_gtfsFolder, "stop_times.txt");

		var routes = GtfsCsv.LoadSmall<Route, RouteMap>(routesPath).ToDictionary(r => r.RouteId);
		var trips = GtfsCsv.LoadSmall<Trip, TripMap>(tripsPath).ToDictionary(t => t.TripId);

		var results = new List<(TimeSpan time, string line)>(200);

		foreach (var st in GtfsCsv.StreamBig<StopTime, StopTimeMap>(stopTimesPath))
		{
			if (st.StopId != stopId) continue;

			var t = GtfsTime.ParseGtfsTime(st.DepartureTime);
			if (t is null || t.Value < now) continue;

			if (!trips.TryGetValue(st.TripId, out var trip)) continue;
			if (!routes.TryGetValue(trip.RouteId, out var route)) continue;

			results.Add((t.Value, $"{st.DepartureTime}  {route.RouteShortName}  {trip.TripHeadSign}"));
		}

		return [.. results
			.OrderBy(r => r.time)
			.Take(take)
			.Select(r => r.line)];
	}
}
