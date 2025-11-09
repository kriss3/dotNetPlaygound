using PlayingWithHttpClient.Models;

namespace PlayingWithHttpClient.Services;

public sealed class GitHubService(HttpClient client)
{
	private readonly HttpClient _client = client;

	public async Task<GitHubUser?> GetByUsernameAsync(string username) 
	{
		var content = await _client.GetFromJsonAsync<GitHubUser>($"users/{username}");

		return content;
	}
}
