namespace ConAppSimpleLib.ExamplesDoFactory;
public class CollectionService
{
	// Combine two collections using collection expressions
	public IEnumerable<int> CombineCollections(List<int> firstList, List<int> secondCollection) =>
		[.. firstList, .. secondCollection];

	//Filter a collection using LINQ and return a collection expression
	public IEnumerable<int> GetEvenNumber(List<int> numbers) =>
		[.. numbers.Where(n => n % 2 == 0)];
}
