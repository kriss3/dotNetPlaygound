namespace PlayingWithTranslink.Gtfs.Models;

public sealed record StopTime(string TripId, string ArrivalTime, string DepartureTime, string StopId, int StopSequence);
