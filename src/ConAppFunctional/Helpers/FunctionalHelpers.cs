using Cova.Functional;
using Cova.ServiceErrors.Errors;
using System.Net;

namespace ConAppFunctional.Helpers;
public static class FunctionalHelpers
{
	public static async Task<HttpResponseMessage> GetFakeHttpData()
	{
		var fakeResponse = new HttpResponseMessage(HttpStatusCode.OK)
		{
			Content = new StringContent("{\"CustomerId\": 1, \"Name\": \"John Doe\"}", 
			System.Text.Encoding.UTF8, "application/json")
		};

		await Task.Delay(100);
		return fakeResponse;
	}

	public static async Task<HttpResponseMessage> GetFakeHttpData(string customerId)
	{
		var fakeResponse = new HttpResponseMessage(HttpStatusCode.OK)
		{
			Content = new StringContent($"{{\"CustomerId\": {customerId}, \"Name\": \"John Doe\"}}", 
			System.Text.Encoding.UTF8, "application/json")
		};

		await Task.Delay(100);
		return fakeResponse;
	}

	public static Result<string, ServiceError> ValidateInput(string input) 
	{
		return string.IsNullOrWhiteSpace(input)
			? Result.Failure<string, ServiceError>(UnexpectedError.Create("A valid input is required."))
			: Result.Success<string, ServiceError>(input);
	}

	public static Result<int, ServiceError> ParseInput(string input)
	{
		return int.TryParse(input, out var number)
			? Result.Failure<int, ServiceError>(UnexpectedError.Create("Input must be a number."))
			: Result.Success<int, ServiceError>(number);
	}

	public static Result<string, ServiceError> ProcessNumber(int number)
	{
		return number % 2 == 0
			? Result.Success<string, ServiceError>($"Even number: {number}")
			: Result.Failure<string, ServiceError>(UnexpectedError.Create("Only even numbers are allowed."));
	}
}
