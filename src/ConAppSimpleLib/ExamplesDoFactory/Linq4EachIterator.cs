using static System.Console;

namespace ConAppSimpleLib.ExamplesDoFactory;
public class Linq4EachIterator
{
	public static void DriveUsingSimple4Each() 
	{
		var numbers = GetNumbers();
		var index = 0;

		foreach (var item in numbers)
		{
			WriteLine($"Index: {index}. Value: {item}");
			index++;
		}
	}

	public static void DriveUsingLinq() 
	{
		var numbers = GetNumbers().Select((index, item) => new { item, index}).ToList();

		numbers.ForEach(x => WriteLine($"Index: {x.index} and Value: {x.item}."));

		//foreach (var x in numbers) 
		//{
		//	WriteLine($"{x.index} and {x.item}");
		//}
	}


	private static IEnumerable<int> GetNumbers()
	{
		return [1, 2, 3, 4, 8, 10];
	}
}