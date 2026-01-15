namespace PlayingWithTranslink.Gtfs.Infrastructure;

public static class GtfsTime
{
	public static TimeSpan? ParseGtfsTime(string hhmmss)
	{
		var parts = hhmmss.Split(':');
		if (parts.Length != 3) return null;

		if (!int.TryParse(parts[0], out var h)) return null;
		if (!int.TryParse(parts[1], out var m)) return null;
		if (!int.TryParse(parts[2], out var s)) return null;

		if (m is < 0 or > 59) return null;
		if (s is < 0 or > 59) return null;
		if (h < 0) return null;

		return new TimeSpan(h, m, s);
	}
}
