using Cova.Functional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;
namespace ConAppFunctional;
public class BindHelper
{
	Result<int, string> GetInitialResult() 
	{
		return SafeDivide(10, 2);
	}

	Result<int, string> GetSquaredResult() 
	{
		var values = GetInitialResult().Map(rec => rec * rec);

		WriteLine($"Map Result: {values.Match(
			success => $"Success: {success}", 
			failure => $"Failure: {failure}")}"
			);

		return values;
	}

	private static Result<int, string> SafeDivide(int numerator, int denominator)
	{
		return denominator == 0
			? Result.Failure<int, string>("Division by zero is not allowed")
			: Result.Success<int, string>(numerator / denominator);
	}

	private static Option<int> SaveDivideWithOption(int numerator, int denominator)
	{
		return denominator == 0
			? Option.None<int>()
			: Option.Some(numerator / denominator);
	}
}
