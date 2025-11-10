using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PlayingWithHttpClient.Models;
using System.Net.Http;

namespace PlayingWithHttpClient.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GitHubController : ControllerBase
{
	//private readonly HttpClient _httpClient;
	//private readonly GitHubSettings _settings;

	public GitHubController(IHttpClientFactory clientFactory, IOptions<GitHubSettings> settings)
	{
		//_settings = settings.Value;

		//_httpClient = clientFactory.CreateClient("gitHub") ??
		//	throw new InvalidOperationException("Http Client, for some reason is not instantiated.");
	}

	[HttpGet("users/v1/{username}")]
	public async Task<IActionResult> GetUserAsync(
		string userName,
		IHttpClientFactory factory,
		IOptions<GitHubSettings> settings) 
	{
		try
		{
			var httpClient = factory.CreateClient();

			httpClient.DefaultRequestHeaders.Add("Authorization", settings.Value.AccessToken);
			httpClient.DefaultRequestHeaders.Add("User-Agent", settings.Value.UserAgent);
			httpClient.BaseAddress = new Uri("https://api.github.com");


			var user = await httpClient.GetFromJsonAsync<GitHubUser>($"users/{userName}");
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
	public async Task<IActionResult> GetUserV2Async(
		string userName,
		IHttpClientFactory factory) 
	{
		try
		{
			var httpClient = factory.CreateClient("gitHub");
			var user = await httpClient.GetFromJsonAsync<GitHubUser>($"users/{userName}");
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
