using CsvHelper.Configuration;
using PlayingWithTranslink.Gtfs.Models;

namespace PlayingWithTranslink.Gtfs.Infrastructure.Maps;

public sealed class RouteMap: ClassMap<Route>
{
	public RouteMap()
	{
		Map(m => m.RouteId).Name("route_id");
		Map(m => m.RouteShortName).Name("route_short_name");
		Map(m => m.RouteLongName).Name("route_long_name");
	}
}
