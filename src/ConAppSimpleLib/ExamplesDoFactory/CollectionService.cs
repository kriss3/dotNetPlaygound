namespace ConAppSimpleLib.ExamplesDoFactory;
public class CollectionService
{
	// 1: Combine two collections using collection expressions
	public IEnumerable<int> CombineCollections(List<int> firstList, List<int> secondCollection) =>
		[.. firstList, .. secondCollection];

	// 2: Filter a collection using LINQ and return a collection expression
	public IEnumerable<int> GetEvenNumbers(List<int> numbers) =>
		[.. numbers.Where(n => n % 2 == 0)];

	// 3: Reverse numbers using Span<T>
	// 4: Get a substring using ReadOnlySpan<T>
}
