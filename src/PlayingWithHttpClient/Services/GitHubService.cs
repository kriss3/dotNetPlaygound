namespace PlayingWithHttpClient.Services;

public sealed class GitHubService
{
	private readonly HttpClient _client;

	public GitHubService(HttpClient client)
	{
		_client = client;
	}

}
