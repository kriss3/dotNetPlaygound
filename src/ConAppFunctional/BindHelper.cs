using Cova.Functional;
using static System.Console;
namespace ConAppFunctional;
public static class BindHelper
{
	private static Result<int, string> GetInitialResult() 
	{
		return SafeDivide(10, 2);
	}

	public static Result<int, string> GetSquaredResult() 
	{
		var values = GetInitialResult().Map(rec => rec * rec);

		WriteLine($"Map Result: {values.Match(
			success => $"Success: {success}", 
			failure => $"Failure: {failure}")}"
			);

		return values;
	}

	public static Result<int, string> GetFinalResult() 
	{
		var values = GetInitialResult().
			Bind(val => SafeDivide(val, 2)).
			Bind(anotherVal => SafeDivide(100, anotherVal));

		WriteLine($"Bind result: {values.Match(
			success => $"Success is: {success}", failure => $"Failure is: {failure}")
			}");

		return values;
	}

	public static Result<int, string> GetErrorResult() 
	{
		var result = SafeDivideDriver();

		return Result.Create(result is not null, () => 0, () => "");
	}

	private static string? SafeDivideDriver()
	{
		// let's refactor this to a separate class.
		Option<int> value = Option.Some(5);
		Option<int> chainedResult = value.Bind(r => SaveDivideWithOption(10, r));

		var message = chainedResult.Match(
			some: val => $"Successful divide result: {val}",
			none: () => "The division did not go well."
		);

		return message;
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
