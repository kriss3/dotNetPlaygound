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
	}

	public IReadOnlyList<string> GetNextScheduledDepartures(string stopId, TimeSpan now, int take = 10)
	{
	}

	public IReadOnlyList<string> GetNextDeparturesWithRoute(string stopId, TimeSpan now, int take = 10)
	{
	}
}
