namespace PlayingWithTranslink.Gtfs.Models;

public sealed record StopTime(string trip_id, string arrival_time, string departure_time, string stop_id, int stop_sequence);
