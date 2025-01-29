
using Cova.Functional;
using Cova.ServiceErrors.Errors;
using PlayingWithDDD.App.src.InfraLayer;

namespace PlayingWithDDD.App.src.DomainLayer.Interfaces;

public interface IExternalApiClient
{
	Task<Result<ValidationResource, ServiceError>> CallExternalApiAsync(CompanyId companyId, LocationId locationId);
}

public record class ValidationResource(string Message, bool IsValid);
