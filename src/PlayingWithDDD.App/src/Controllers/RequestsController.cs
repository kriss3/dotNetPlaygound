using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayingWithDDD.App.src.ApiLayer.Models;
using PlayingWithDDD.App.src.ApplicationLayer;
using PlayingWithDDD.App.src.ApplicationLayer.Models;
using PlayingWithDDD.App.src.DomainLayer.Interfaces;
using static PlayingWithDDD.App.src.ApplicationLayer.CreateRequestHandlerFactory;

namespace PlayingWithDDD.App.src.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RequestsController(IExternalApiClient apiClient) : ControllerBase
{
	// Bind the API client to the handler
	private readonly CreateRequestHandler _handler = 
		CreateRequestHandlerFactory.Create(apiClient);

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CreateRequestDto dto)
	{
		var command = new CreateRequestCommand(dto.CompanyId, dto.LocationId);

		// Handle the request and map Result to HTTP response
		return await _handler(command)
			.Match(
				success => Ok(new { Message = success }),
				error => BadRequest(new { Error = error })
			);
	}
}
