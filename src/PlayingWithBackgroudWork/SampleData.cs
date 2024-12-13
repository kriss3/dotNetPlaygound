using System.Collections.Concurrent;

namespace PlayingWithBackgroudWork;

public record SampleData 
{
	public ConcurrentBag<string> Data { get; init; } = [];
}
