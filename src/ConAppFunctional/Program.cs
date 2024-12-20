
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

		SecondAttempt(100);

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

		// Playing with Map again:
		// Use Map when you have a Result<TSuccess, TFailure> and want to change the TSuccess type,
		// or transform the TSuccess value, while keeping the Result as a success or failure.
		// Map operates only on the success path(or with MapFailure on the failure path)
		// but does not handle chaining a new Result.
		var result_v6 = await FetchStrainAsync("some-id")
			.Map(strain => strain.WithAdditionalInfo("Extra Info")); // Transforms the Strain only if success

		// Chain only if FetchStrainAsync succeeds
		var result_v7 = await FetchStrainAsync("some-id")
			.Bind<Strain, ServiceError, ProcessedStrain>(static strain =>
				ProcessStrain(strain));

		var result_v8 = await FetchStrainAsync("some-id")
			.Map(strain => strain.WithAdditionalInfo("Extra Info")) // Map to add info if successful
			.Bind(strain => (ProcessStrain(strain))) // Bind to process strain if success
			.Match(success: (strain) => strain, failure: (error) => default(ProcessedStrain));

		// Continue discoverhing Result with Map and Bind:
		Option<int> maybeNumber = Option.Some(5);
		Option<int> noNumber = Option.None<int>();

		Option<int> doubledNumber = maybeNumber.Map(number => number * 2); // Some(10)
		Option<int> noDoubledNumber = noNumber.Map(number => number * 2); // None

		// Start with Option.Some
		Option<int> maybeANumber = Option.Some(5);
		Option<int> result_8 = maybeANumber
			.Bind(CheckIfPositive);  // Result: Option.Some(5)

		// Option.None
		Option<int> notANumber = Option.None<int>();
		Option<int> resultNone = notANumber
			.Bind(CheckIfPositive); // Result: Option.None<int>

		// With a negative number
		Option<int> negativeNumber = Option.Some(-3);
		Option<int> resultNegative = negativeNumber
			.Bind(CheckIfPositive); // Result: Option.None<int>


		// Chaining using Bind
		Option<int> maybeSomeNewNumber = Option.Some(16);
		Option<double> result_9 = maybeSomeNewNumber
			.Bind(CheckIfPositive)		// Checks if positive
			.Bind(GetSquareRoot);       // Gets the square root if positive

		// Starting with Option.None
		Option<int> noANumber = Option.None<int>();
		Option<double> resultOfNone = noNumber
			.Bind(CheckIfPositive)
			.Bind(GetSquareRoot);        // Result: Option.None<double>

		// With a negative number
		Option<int> negativeANumber = Option.Some(-9);
		Option<double> resultANegative = negativeNumber
			.Bind(CheckIfPositive)       // Fails at this step, so resultNegative is Option.None
			.Bind(GetSquareRoot);

		// To Recap:
		// Map returns a monad by wrapping the transformed result back into the same monadic structure.
		// Bind expects the function itself to return a monad and avoids additional wrapping,
		// preserving the single monadic structure.


		// This will be a successful result with user "Alice"
		UserWelcome userWelcome = new();
		Result<User, string> result_v10 = userWelcome.FetchUserData(1);

		// Use Map to transform the User object to a string
		Result<string, string> formattedResult = result_v10
			.Map(user => $"Name: {user.Name}, Age: {user.Age}");

		WriteLine(formattedResult.Match(
			success => success,
			failure => $"Error: {failure}"
		));

		// Map Failure:
		// Let's create mapFailure:
		Result<User, string> result_11 = userWelcome.FetchUserData(2);

		// Use MapFailure to add more context to the error message
		Result<User, string> detailedError = result_11.MapFailure(error => $"Fetch failed: {error}");

		// Output: "Fetch failed: User not found."
		WriteLine(detailedError.Match(
			success => $"Fetched User: {success.Name}",
			failure => failure
		));

		// Combina map and mapFailure:
		int userId = 2; // Trying with userId that will cause a failure
		Result<User, string> result_12 = userWelcome.FetchUserData(userId);

		// Chain Map and MapFailure to handle both success and failure cases
		Result<string, string> finalResult = result_12
			.Map(user => $"Welcome, {user.Name}! You are {user.Age} years old.")
			.MapFailure(error => $"Error occurred while fetching user data: {error}");

		// Output: "Error occurred while fetching user data: User not found."
		WriteLine(finalResult.Match(
			success => success,
			failure => failure));
	}

	private static void SecondAttempt(int v)
	{
		Option<int> maybeNumber = Option.Some(v);
		//apply a transformation:
		Option<int> doubledNumber = maybeNumber.Map(number => number * 2);
		var squaredValue = doubledNumber.Map(number => number * number);
		WriteLine($"Map Result: {squaredValue.Match<int, string>(() => "None", v => v.ToString())}");

	}

	static Option<double> GetSquareRoot(int x) => x >= 0 
		? Option.Some(Math.Sqrt(x)) 
		: Option.None<double>();

	static Option<int> CheckIfPositive(int x) => x > 0 
		? Option.Some(x) 
		: Option.None<int>();

	static async Task<Result<Strain, ServiceError>> FetchStrainAsync(string id)
	{
		try
		{
			// Simulate an async operation
			await Task.Delay(1000);

			// Example of creating a successful result
			var strain = new Strain { Id = id, Name = "Example Strain" };
			return Result.Success<Strain, ServiceError>(strain);
		}
		catch (Exception ex)
		{
			// Example of creating a failure result
			var error = new ConcreteServiceError("FetchError", ex.Message);
			return Result.Failure<Strain, ServiceError>(error);
		}
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

	static Result<ProcessedStrain, ServiceError> ProcessStrain(Strain strain)
	{
		if (string.IsNullOrEmpty(strain.Id) || string.IsNullOrEmpty(strain.Name))
		{
			return Result.Failure<ProcessedStrain, ServiceError>(
				new ConcreteServiceError("InvalidStrain", "Strain ID or Name is missing"));
		}

		var processedStrain = new ProcessedStrain
		{
			// Assuming ProcessedStrain has similar properties to Strain
			Id = strain.Id,
			Name = strain.Name,
			Description = strain.Description + " - Processed"
		};

		return Result.Success<ProcessedStrain, ServiceError>(processedStrain);
	}
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
