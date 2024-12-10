using System.Collections.Concurrent;

namespace PlayingWithBackgroudWork;

public record SampleData(ConcurrentBag<string> Data);
