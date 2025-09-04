namespace ConAppSimpleLib.ExamplesDoFactory;
public class PostRequest
{
	private static readonly HttpClient client = new();

	public static async Task<string> PostViaHttp() 
	{
		var values = new Dictionary<string, string>
		{
		   { "thing1", "hello" },
		   { "thing2", "world" }
		};

		var content = new FormUrlEncodedContent(values);

		var response = await client.PostAsync("http://www.example.com/postable.aspx", content);

		var result = await response.Content.ReadAsStringAsync();
		return result;
	}
}
