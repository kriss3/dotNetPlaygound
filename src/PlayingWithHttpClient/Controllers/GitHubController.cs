using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayingWithHttpClient.Models;

namespace PlayingWithHttpClient.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GitHubController : ControllerBase
{
	private readonly HttpClient _httpClient;
	private readonly GitHubSettings _settings;

	public GitHubController()
	{
		
	}

}
