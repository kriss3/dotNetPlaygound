using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConAppSimpleLib.ExamplesDoFactory;
public class Linq4EachIterator
{
	public static void DriveUsingSimple4Each() 
	{
		var numbers = GetNumbers();
		var index = 0;

		foreach (var item in numbers)
		{
			Console.WriteLine($"Index: {index}. Value: {item}");
			index++;
		}
	}


	private static IEnumerable<int> GetNumbers()
	{
		return [1, 2, 3, 4, 8, 10];
	}
}