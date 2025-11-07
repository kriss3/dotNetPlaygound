using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PlayingWithHttpClient.Models;

namespace PlayingWithHttpClient.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GitHubController : ControllerBase
{
	private readonly HttpClient _httpClient;
	private readonly GitHubSettings _settings;

	public GitHubController(IOptions<GitHubSettings> settings)
	{
		_settings = settings.Value;

		_httpClient = new HttpClient
		{
			BaseAddress = new Uri("https://api.github.com")
		};
		_httpClient.DefaultRequestHeaders.Add("Authorization", _settings.AccessToken);
		_httpClient.DefaultRequestHeaders.Add("User-Agent", _settings.UserAgent);
	}

	[HttpGet("users/v1/{username}")]
	public async Task<IActionResult> GetUserAsync(string username) 
	{
	}
}
