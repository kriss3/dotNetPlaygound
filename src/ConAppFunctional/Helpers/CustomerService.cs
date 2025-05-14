using ConAppFunctional.BaseModels;
using Models;

namespace ConAppFunctional.Helpers;


// This is a typical class with side effects.
public class CustomerService
{
	public static void Process(string customerName, string addressString)
	{
		//Command
		Address address = CreateAddress(addressString);
		Customer customer = CreateCustomer(customerName, address);
		SaveCustomer(customer);
	}

	//Query
	private static Address CreateAddress(string addressString)
	{
		return new Address(addressString);
	}

	//Query
	private static Customer CreateCustomer(string name, Address address)
	{
		return new Customer(name, address);
	}

	//Command
	private static void SaveCustomer(Customer customer)
	{
		var repository = new FunctionalHelpers.CustomerRepository();
		repository.SaveCustomer(customer);
	}

}

public class CustomerService_v2 
{

	// this is the client of the KwsResult
	private static KwsResult<Customer>? GetCustomer(int id)
	{
		//try
		//{
		//	var ctx = new List<Customer>();

		//	return KwsResult.Ok(ctx.Single(x => x.Id == id)); 
		//}
		//catch (Exception)
		//{
		//	throw;
		//}
		return new KwsResult<Customer>(new Customer("", new Address("")), true, "");
	}

	private static KwsResult SaveCustomer(Customer customer) 
	{

		return new KwsResult(false, "");
	}
}

