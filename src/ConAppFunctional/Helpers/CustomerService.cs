using ConAppFunctional.BaseModels;

namespace ConAppFunctional.Helpers;


// This is a typical class with side effects.
public class CustomerService
{
	public void Process(string customerName, string addressString)
	{
		//Command
		Address address = CreateAddress(addressString);
		Customer customer = CreateCustomer(customerName, address);
		SaveCustomer(customer);
	}

	//Query
	private Address CreateAddress(string addressString)
	{
		return new Address(addressString);
	}

	//Query
	private Customer CreateCustomer(string name, Address address)
	{
		return new Customer(name, address);
	}

	//Command
	private void SaveCustomer(Customer customer)
	{
		var repository = new CustomerRepository();
		repository.SaveCustomer(customer);
	}

}

