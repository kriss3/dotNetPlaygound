using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cova.Functional;
using Cova.ServiceErrors.Errors;

namespace ConAppFunctional;
public class UserWelcome
{
	public Result<User, string> FetchUserData(int userId)
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
