
using Cova.Functional;
using Cova.ServiceErrors.Errors;
using static System.Console;

namespace ConAppFunctional;

public class Program
{
	static async Task Main()
	{
		await Task.CompletedTask;
		WriteLine("Let's play with CS Functional!");
	}

	static async Task<Result<int, ServiceError>> PerformanceOperationAsync() 
	{
		//Delay
		await Task.Delay(2000);
		//Success
		return Result.Success<int, ServiceError>(42);
	}

	static async Task<Result<int, ServiceError>> ErrorOperationAsync()
	{
		//Delay
		await Task.Delay(2000);
		//Error
		return Result.Failure<int, ServiceError>(new ConcreteServiceError("Error", "Error message"));
	}

	//Simple division function that returns a Result (either success or failure)
	//This is one way of returning two different types from a function: string or int
	Result<int, string> Divide(int x, int y) => y == 0
	? Result.Failure<int, string>("Division by zero")
	: Result.Success<int, string>(x / y);
}

public class ConcreteServiceError(string code, string message) : 
	ServiceError(code, new Exception(message))
{
	public override string ErrorType { get; } = "ConcreteServiceError";
	public override IEnumerable<ErrorCode> ErrorCodes { get; } = [];

	public override T Match<T>(
		Func<PersistenceDataError, T> persistenceDataError,
		Func<UnexpectedError, T> unexpectedError,
		Func<ValidationError, T> validationError,
		Func<MappingError, T> mappingError,
		Func<AuthorizationError, T> authorizationError,
		Func<AuthenticationError, T> authenticationError,
		Func<CustomError, T> customError)
	{
		// Implement the match logic here
		throw new NotImplementedException();
	}

}

//playing with Result, Bind, BindToFailure and Success


