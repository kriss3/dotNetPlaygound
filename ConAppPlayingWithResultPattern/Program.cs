using LanguageExt;
using static LanguageExt.Prelude;

namespace ConAppPlayingWithResultPattern;

public class Program
{
	static async Task Main()
	{
		await Task.Run(Console.WriteLine);
	}

	public Result DeleteProduct(int id)
	{
		if (id < 0)
			return Result.Failed($"The value of {nameof(id)} is invalid: {id}");

		Product ToDelete = ProductList.Products.Single(x => x.Id == id);
		ProductList.Products.Remove(ToDelete);

		return Result.Success();
	}
}

public class Result
{
	public bool IsSuccess { get; set; }
	public string? Message { get; set; }

	private Result(bool isSuccess, string? message)
	{
		IsSuccess = isSuccess;
		Message = message;
	}

	public static Result Success() => new(true, null);
	public static Result Failed(string message) => new(false, message);
}

public class FirstName
{
	public string Value { get; }

	private FirstName(string value)
	{
		Value = value;
	}

	public static Option<FirstName> Create(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return None;
		}

		return new FirstName(value);
	}
}