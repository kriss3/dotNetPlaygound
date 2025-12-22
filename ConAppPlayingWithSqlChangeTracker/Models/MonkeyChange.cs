namespace ConAppPlayingWithSqlChangeTracker.Models;

public class MonkeyChange
{
	public int MonkeyId { get; set; }
	public string? Operation { get; set; } // I, U, D
	public long ChangeVersion { get; set; }
	public string? ChangedColumns { get; set; }
	public Monkey? CurrentData { get; set; }
}
