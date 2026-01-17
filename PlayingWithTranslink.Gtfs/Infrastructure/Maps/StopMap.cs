using CsvHelper.Configuration;
using PlayingWithTranslink.Gtfs.Models;

namespace PlayingWithTranslink.Gtfs.Infrastructure.Maps;

public sealed class StopMap: ClassMap<Stop>
{
    public StopMap()
    {
        Map(m => m.StopId).Name("stop_id");
		Map(m => m.StopName).Name("stop_name");
		Map(m => m.StopLatitude).Name("stop_lat");
		Map(m => m.StopLongitute).Name("stop_lon");
	}
}
