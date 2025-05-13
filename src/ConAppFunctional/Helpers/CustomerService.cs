using ConAppFunctional.BaseModels;

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

