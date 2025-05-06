using ConAppFunctional.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppFunctional.Helpers;

public class CustomerService
{
	public void Process(string customerName, string addressString)
	{
		Address address = CreateAddress(addressString);
		Customer customer = CreateCustomer(customerName, address);
		SaveCustomer(customer);
	}
	private Address CreateAddress(string addressString)
	{
		return new Address(addressString);
	}
	private Customer CreateCustomer(string name, Address address)
	{
		return new Customer(name, address);
	}
	private void SaveCustomer(Customer customer)
	{
		var repository = new Repository();
		repository.Save(customer);
	}

}
