using System.Net;

namespace ConAppFunctional.Helpers;
public static class FunctionalHelpers
{
	public static async Task<HttpResponseMessage> GetFakeHttpData()
	{
		var fakeResponse = new HttpResponseMessage(HttpStatusCode.OK)
		{
			Content = new StringContent("{\"CustomerId\": 1, \"Name\": \"John Doe\"}", System.Text.Encoding.UTF8, "application/json")
		};

		await Task.Delay(100);
		return fakeResponse;
	}

	public static async Task<HttpResponseMessage> GetFakeHttpData(string customerId)
	{
		var fakeResponse = new HttpResponseMessage(HttpStatusCode.OK)
		{
			Content = new StringContent($"{{\"CustomerId\": {customerId}, \"Name\": \"John Doe\"}}", System.Text.Encoding.UTF8, "application/json")
		};

		await Task.Delay(100);
		return fakeResponse;
	}
}
