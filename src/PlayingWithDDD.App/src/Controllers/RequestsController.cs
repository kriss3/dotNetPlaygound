using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayingWithDDD.App.src.ApplicationLayer;
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
}
