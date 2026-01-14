namespace PlayingWithTranslink.Gtfs.Models;

public sealed record Route(
	string route_id, 
	string route_short_name, 
	string route_long_name);
