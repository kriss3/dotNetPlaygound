using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PlayingWithBackgroudWork.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BackgroundController(SampleData data) : ControllerBase
{
	private readonly SampleData _data = data;

	[HttpGet]
	public IActionResult Get()
	{
		return Ok(_data.Data.Order());
	}
}
