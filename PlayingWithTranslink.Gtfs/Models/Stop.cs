namespace PlayingWithTranslink.Gtfs.Models;

public sealed record Stop(
	string StopId, 
	string StopName, 
	double StopLlatitude, 
	double StopLongitute);

