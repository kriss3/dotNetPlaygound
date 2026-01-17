using CsvHelper.Configuration;
using PlayingWithTranslink.Gtfs.Models;

namespace PlayingWithTranslink.Gtfs.Infrastructure.Maps;

public sealed class StopTimeMap : ClassMap<StopTime>
{
    public StopTimeMap()
    {
		Map(m => m.TripId).Name("trip_id");
		Map(m => m.ArrivalTime).Name("arrival_time");
		Map(m => m.DepartureTime).Name("departure_time");
		Map(m => m.StopId).Name("stop_id");
		Map(m => m.StopSequence).Name("stop_sequence");
	}
}
