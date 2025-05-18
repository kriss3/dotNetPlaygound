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
				KwsResult_v2.Fail(ErrorType.DatabaseIsOffline);

			if (ex.Message.Contains("IX_Customer_Name"))
				return KwsResult_v2.Fail(ErrorType.CustomerAlreadyExists);
			throw;
		}
	}

	private static KwsResult_v2<Customer> GetCustomer(int id) 
	{
		try
		{
			List<Customer> customerCtx = [];
			return KwsResult_v2.Ok(customerCtx.Single(c =>c.Id == id));
		}
		catch (Exception ex)
		{
			if (ex.Message == "Unable to open the DB connection.")
				return KwsResult_v2.Fail<Customer>(ErrorType.DatabaseIsOffline);

			if (ex.Message.Contains("IX_Customer_Name"))
				return KwsResult_v2.Fail<Customer>(ErrorType.CustomerAlreadyExists);
			throw;
		}
	}
}

//Next: add enums in the KwsResult type.
