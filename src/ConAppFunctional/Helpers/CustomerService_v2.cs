using ConAppFunctional.BaseModels;
using Cova.Functional;
using Models;

namespace ConAppFunctional.Helpers;
public class CustomerService_v2
{
	public static void CreateCustomer(string name) 
	{
		var address = new Address("someAddress");
		var customer = new  Customer(name, address);
		KwsResult_v2 result = SaveCustomer(customer);

		if (result.IsFailure) 
		{
			switch (result.ErrorType)
		}
	}


	private static KwsResult_v2 SaveCustomer(Customer customer)
	{
		try
		{

			List<Customer> customerCtx = [];
			customerCtx.Add(customer);
			return KwsResult_v2.Ok();
		}
		catch (Exception ex)
		{
			if (ex.Message == "")
				KwsResult.Fail("Unable to open Db.");

			if (ex.Message.Contains("IX_Customer_Name"))
				return KwsResult.Fail("Customer with such a name already exists.");
			throw;
		}
	}

	private static KwsResult<Customer> GetCustomer(int id) 
	{
		try
		{
			List<Customer> customerCtx = [];
			return KwsResult.Ok(customerCtx.Single(c =>c.Id == id));
		}
		catch (Exception ex)
		{
			if (ex.Message == "Unable to open Db.")
				return KwsResult.Fail<Customer>("Db is off-line.");
			throw;
		}
	}
}

//Next: add enums in the KwsResult type.
