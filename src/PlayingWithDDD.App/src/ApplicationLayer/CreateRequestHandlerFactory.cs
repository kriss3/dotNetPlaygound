using PlayingWithDDD.App.src.ApplicationLayer.Models;
using PlayingWithDDD.App.src.DomainLayer.Interfaces;
using PlayingWithDDD.App.src.DomainLayer.Primitives;

using Cova.Functional;
using Cova.ServiceErrors.Errors;

namespace PlayingWithDDD.App.src.ApplicationLayer;

public static class CreateRequestHandlerFactory
{
	public delegate Task<Result<ValidationResource, ServiceError>> 
		CreateRequestHandler(CreateRequestCommand command);
	public static CreateRequestHandler Create(IExternalApiClient apiClient) =>
		async command =>
		{
			// Convert to domain primitives
			var companyId = CompanyId.Create(command.CompanyId);
			var locationId = LocationId.Create(command.LocationId);

			// Pass to the domain service (via abstraction)
			return await apiClient.CallExternalApiAsync(companyId, locationId);
		};
}

