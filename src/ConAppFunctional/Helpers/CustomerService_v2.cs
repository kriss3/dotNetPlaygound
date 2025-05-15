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

}
