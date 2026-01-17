namespace PlayingWithTranslink.Gtfs.Models;

public sealed record Route
{
	public required string RouteId { get; init; }
	public required string RouteShortName { get; init; }
	public required string RouteLongName { get; init; }
}
