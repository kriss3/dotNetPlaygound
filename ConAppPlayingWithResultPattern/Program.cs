namespace ConAppPlayingWithResultPattern;

public class Program
{
	static async Task Main()
	{
		await Task.Run(Console.WriteLine);
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
