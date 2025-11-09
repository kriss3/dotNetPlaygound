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

	public GitHubController(IHttpClientFactory clientFactory, IOptions<GitHubSettings> settings)
	{
		_settings = settings.Value;

		// By adding _httpClientFactory I change the way HttpClient is instantiated.
		//_httpClient = new HttpClient
		//{
		//	BaseAddress = new Uri("https://api.github.com")
		//};

		_httpClient = clientFactory.CreateClient() ??
			throw new InvalidOperationException("Http Client, for some reason is not instantiated.");

		_httpClient.DefaultRequestHeaders.Add("Authorization", _settings.AccessToken);
		_httpClient.DefaultRequestHeaders.Add("User-Agent", _settings.UserAgent);
		_httpClient.BaseAddress = new Uri("https://api.github.com");
	}

	[HttpGet("users/v1/{username}")]
	public async Task<IActionResult> GetUserAsync(string userName) 
	{
		try
		{
			var user = await _httpClient.GetFromJsonAsync<GitHubUser>($"users/{userName}");
			if (user is null)
				return NotFound($"User '{userName}' not found on GitHub.");

			return Ok(user);
		}
		catch (HttpRequestException ex)
		{
			return StatusCode(500, $"Error retrieving user '{userName}': {ex.Message}");
		}
	}

	/*
	 *  Both v1 and v2 implemention suffer from an issue where details of the clinet 
	 *  have to be configured per request. I'll address this after finished v2 endpoint. 
	*/
	[HttpGet("users/v2/{username}")]
	public async Task<IActionResult> GetUserV2Async(string userName) 
	{
		try
		{
			var user = await _httpClient.GetFromJsonAsync<GitHubUser>($"users/{userName}");
			if (user is null)
				return NotFound($"User '{userName}' not found on GitHub.");

			return Ok(user);
		}
		catch (HttpRequestException ex)
		{
			return StatusCode(500, $"Error retrieving user '{userName}': {ex.Message}");
		}
	}
}
