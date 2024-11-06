﻿
using Cova.Functional;
using Cova.ServiceErrors.Errors;
using System.Drawing;
using System.Reflection.Metadata;
using static System.Console;

namespace ConAppFunctional;

public class Program
{
	static async Task Main()
	{
		await Task.CompletedTask;
		WriteLine("Let's play with CS Functional!");

		var result = Divide(10, 2)
			.Bind(MultiplyByTwo).Match(
				success: value => $"Result: {value}",
				failure: error => $"Error: {error}"
			);
		WriteLine(result);

		// Handles the failure by returning a default success value
		var result_v2 = Divide(10, 0)
			.BindFailure(error => Result.Success<int, string>(-1));
		WriteLine(result_v2);

		// What about MapFailure function?
		//MapFailure transforms the failure value (TFailure) to a different type,
		//allowing you to adapt the error for specific cases or add more context to it.
		//If the Result is successful, it skips this function.
		var result_v3 = Divide(10, 0)
			.MapFailure(error => "Division by zero");

		var result_v4 = Divide(10, 0)
			.MapFailure(error => "Division by zero in _v4")
			.Match(
				success: value => $"Result: {value}",
				failure: error => $"Error: {error}"
			);
		WriteLine(result_v4);

		// DoOnFailure function
		// DoOnFailure allows you to execute a side effect when a failure occurs.
		// It doesn’t transform the Result; instead, it’s often used for logging or debugging purposes.
		Divide(10, 0)
			.DoOnFailure(error => WriteLine($"Failed with error: {error} in _v5"));

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

	//Playing with Result, Bind, BindToFailure and Success
	//Simple division function that returns a Result (either success or failure)
	//This is one way of returning two different types from a function: string or int
	//Once function is declared it is ready to be used.
	static Result<int, string> Divide(int x, int y) => y == 0
	? Result.Failure<int, string>("Division by zero")
	: Result.Success<int, string>(x / y);

	//This is a second function that returns a Result (either success or failure)
	static Result<int, string> MultiplyByTwo(int number) => 
		Result.Success<int, string>(number * 2);

	static Result<int, string> Divide_v2(int x, int y) => y == 0
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
