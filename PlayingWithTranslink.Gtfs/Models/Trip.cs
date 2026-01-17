namespace PlayingWithTranslink.Gtfs.Models;

public sealed record Trip
{
	public required string RouteId { get; init; }
	public required string ServiceId { get; init; }
	public required string TripId { get; init; }
	public required string TripHeadSign { get; init; }
}