namespace PlayingWithTranslink.Gtfs.Models;

public sealed record StopTime
{
	public required string TripId { get; init; }
	public required string ArrivalTime { get; init; }
	public required string DepartureTime { get; init; }
	public required string StopId { get; init; }
	public int StopSequence { get; init; }
}