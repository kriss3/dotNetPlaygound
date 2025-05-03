using ConAppFunctional.ModelTypes;
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

	public static Result<ResponseWithDetails<string, BioTrackError>, ServiceError> GetSomeData() 
	{
		ResponseWithDetails<string, BioTrackError> res = new(true, HttpStatusCode.OK, "Some 200 Success", "Success Data", null!);
		var functionResult = Result.Success<ResponseWithDetails<string, BioTrackError>, ServiceError>(res);
		return functionResult;
		//finished here ... 2morrow start with handling both Success and Failure rather than just Success.
	}
}


// From Vladimir Khorikov course: Ch3
public class NonImmutableCustomer
{
	private Address? _address;
	private Customer? _customer;

	public void Process(string customerName, string addressString)
	{
		CreateAddress(addressString);
		CreateCustomer(customerName);
		SaveCustomer();
	}

	private void CreateAddress(string addressString)
	{
		_address = new Address(addressString);
	}

	private void CreateCustomer(string name)
	{
		_customer = new Customer(name);
	}

	private void SaveCustomer()
	{
		var repo = new CustomerRepository();
		repo.SaveCustomer(_customer);
	}
}

public class Address(string addressString)
{
	private readonly string _addressString = addressString;
}

public class Customer(string customer) 
{
	private readonly string _addressString = customer;
}

public class CustomerRepository 
{
	private List<Customer> _customers = [];

	public void SaveCustomer(Customer customer) 
	{
		_customers.Add(customer);
	}
}



//----------- Updates and working with Immutable data:
public class ImmutableCustomer 
{ 

}


