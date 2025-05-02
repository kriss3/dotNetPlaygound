using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConAppFunctional.Helpers;
public static class FunctionalHelpers
{
	public static async Task<HttpResponseMessage> GetFakeHttpData() 
	{
		var fakeResponse = new HttpResponseMessage(HttpStatusCode.OK)
		{
			Content = new StringContent("{\"CustomerId\": 1, \"Name\": \"John Doe\"}", System.Text.Encoding.UTF8, "application/json")
		};

		// Simulate the behavior of the actual API call
		await Task.Delay(100); // Simulate network delay
		var response = fakeResponse;
		return response;
	}
}
