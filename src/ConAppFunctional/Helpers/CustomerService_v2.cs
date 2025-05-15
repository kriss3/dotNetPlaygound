using ConAppFunctional.BaseModels;
using Cova.Functional;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppFunctional.Helpers;
public class CustomerService_v2
{
	public void CreateCustomer(string name) 
	{
		var address = new Address("someAddress");
		var customer = new  Customer(name, address);
		KwsResult res = SaveCustomer(customer);

		if (res.IsFailure) 
		{
			Console.WriteLine(res.Error);
		}
	
	}


	private static KwsResult SaveCustomer(Customer customer)
	{
		try
		{

			List<Customer> customerCtx = [];
			customerCtx.Add(customer);
			return KwsResult.Ok();
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

	private KwsResult<Customer> GetCustomer(int id) 
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
