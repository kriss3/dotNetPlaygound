namespace ConAppPlayingWithSqlChangeTracker.Models;

public class Monkey
{
	public int MonkeyId { get; set; }
	public string? Name { get; set; }
	public string? Location { get; set; }
	public string? Details { get; set; }
	public string? Image { get; set; }
	public int Population { get; set; }
	public decimal Latitude { get; set; }
	public decimal Longitude { get; set; }
	public DateTime CreatedDate { get; set; }
}
