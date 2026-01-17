namespace PlayingWithTranslink.Gtfs.Models;

public sealed record Stop
{
	public required string StopId { get; init; }
	public required string StopName { get; init; }
	public double StopLatitude { get; init; }
	public double StopLongitude { get; init; }
}
