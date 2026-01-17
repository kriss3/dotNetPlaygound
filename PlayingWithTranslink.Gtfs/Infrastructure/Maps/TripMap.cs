using CsvHelper.Configuration;
using PlayingWithTranslink.Gtfs.Models;

namespace PlayingWithTranslink.Gtfs.Infrastructure.Maps;

public sealed class TripMap : ClassMap<Trip>
{
    public TripMap()
    {
		Map(m => m.RouteId).Name("route_id");
		Map(m => m.ServiceId).Name("service_id");
		Map(m => m.TripId).Name("trip_id");
		Map(m => m.TripHeadSign).Name("trip_headsign");
	}
}
