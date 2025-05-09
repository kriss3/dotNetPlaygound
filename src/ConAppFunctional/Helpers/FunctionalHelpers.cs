using ConAppFunctional.ModelTypes;
using Cova.Functional;
using Cova.ServiceErrors.Errors;
using System.Net;
using ConAppFunctional.BaseModels;

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
		var res = string.IsNullOrWhiteSpace(input)
			? Result.Failure<string, ServiceError>(UnexpectedError.Create("A valid input is required."))
			: Result.Success<string, ServiceError>(input);
		return res;
	}

	public static Result<int, ServiceError> ParseInput(string input)
	{
		var res = int.TryParse(input, out var number)
			? Result.Failure<int, ServiceError>(UnexpectedError.Create("Input must be a number."))
			: Result.Success<int, ServiceError>(number);
		return res;
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

	public static ResponseWithDetails<User, ApiError> GetUserById(string id)
	{
		if (string.IsNullOrWhiteSpace(id))
		{
			return new ResponseWithDetails<User, ApiError>(
				IsSuccess: false,
				Code: HttpStatusCode.BadRequest,
				Message: "Invalid user ID.",
				Success: null!,
				Failure: new ApiError { Reason = "ValidationError", Detail = "ID cannot be empty." });
		}

		if (id != "123")
		{
			return new ResponseWithDetails<User, ApiError>(
				IsSuccess: false,
				Code: HttpStatusCode.NotFound,
				Message: "User not found.",
				Success: null!,
				Failure: new ApiError { Reason = "NotFound", Detail = $"No user with ID {id}" });
		}



		return new ResponseWithDetails<User, ApiError>(IsSuccess: true,
		Code: HttpStatusCode.OK,
		Message: "User retrieved successfully.",
		Success: new User { Id = 123, Name = "Alice" },
		Failure: null!);
	}

	public static ResponseWithDetails<DiscountResult, DiscountError> CalculateDiscount(int customerAge)
	{
		if (customerAge < 0)
		{
			return new ResponseWithDetails<DiscountResult, DiscountError>(
				IsSuccess: false,
				Code: HttpStatusCode.BadRequest,
				Message: "Invalid age.",
				Success: null!,
				Failure: new DiscountError { Reason = "Age cannot be negative" });
		}

		if (customerAge < 18)
		{
			return new ResponseWithDetails<DiscountResult, DiscountError>(
				IsSuccess: false,
				Code: HttpStatusCode.Forbidden,
				Message: "Discount not allowed for minors.",
				Success: null!,
				Failure: new DiscountError { Reason = "PolicyRestriction" });
		}

		var discount = new DiscountResult { DiscountAmount = 10.0m };

		return new ResponseWithDetails<DiscountResult, DiscountError>(
			IsSuccess: true,
			Code: HttpStatusCode.OK,
			Message: "Discount applied.",
			Success: discount,
			Failure: null!);
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
			_customer = new Customer(name, _address!);
		}

		private void SaveCustomer()
		{
			if (_customer is null)
			{
				throw new InvalidOperationException("Customer cannot be null");
			}

			var repo = new CustomerRepository();
			repo.SaveCustomer(_customer);

		}
	}

	public class CustomerRepository
	{
		private readonly List<Customer> _customers = [];

		public void SaveCustomer(Customer customer)
		{
			_customers.Add(customer);
		}
	}



	//----------- Updates and working with Immutable data:
	// Below implementation removes temporal coupling and prevents from miss-ordering execution.
	// The compiler will barf when order of Business Logic execution is incorrect.
	// In the above type, mutable type, it is easy to move execution logic around as those executions rely on internal state.
	public class ImmutableCustomer
	{
		public static void Process(string customerName, string addressString)
		{
			var address = CreateAddress(addressString);
			var customer = CreateCustomer(customerName, address);
			SaveCustomer(customer);
		}

		private static Address CreateAddress(string addressString)
		{
			return new Address(addressString);
		}

		private static Customer CreateCustomer(string name, Address address)
		{
			return new Customer(name, address);
		}

		private static void SaveCustomer(Customer customer)
		{
			if (customer is null)
			{
				throw new InvalidOperationException("Customer cannot be null");
			}

			var repo = new CustomerRepository();
			repo.SaveCustomer(customer);
		}
	}
}

