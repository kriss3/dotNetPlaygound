using LanguageExt;
using static LanguageExt.Prelude;

using static System.Console;

namespace ConAppPlayingWithResultPattern;

public class Program
{
	static async Task Main()
	{
		await Task.Run(Console.WriteLine);



	}

	public static Option<FirstName> ValidateFirstName(string name)
	{
		var firstNameOption = FirstName.Create(name);

		firstNameOption.Match(
			Some: firstName => WriteLine($"First name created: {firstName.Value}"),
			None: () => WriteLine("Invalid first name.")
		);


		return firstNameOption;
	}


	public static Result DeleteProduct(int id)
	{
		List<Product> productList = [];
		productList.Add(new Product(0, "test1"));
		productList.Add(new Product(1, "test2"));

		if (id < 0)
			return Result.Failed($"The value of {nameof(id)} is invalid: {id}");

		Product ToDelete = productList.Single(x => x.Id == id);
		productList.Remove(ToDelete);

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

public record Product(int Id, string Name);