using Cova.Functional;

namespace ConAppFunctional.BaseModels;
public class UserWelcome
{
	public static Result<User, string> FetchUserData(int userId)
	{
		// Simulate different outcomes based on userId
		if (userId == 1)
			return Result.Success<User, string>(new User { Name="Alice", Age=30});
		else if (userId == 2)
			return Result.Failure<User, string>("User not found.");
		else
			return Result.Failure<User, string>("Unexpected error occurred.");
	}
}

public record User
{
	public string? Name { get; init; }
	public int Age { get; init; }
}
