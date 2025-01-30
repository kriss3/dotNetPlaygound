
using Cova.Functional;
using Cova.ServiceErrors.Errors;
using PlayingWithDDD.App.src.DomainLayer.Primitives;

namespace PlayingWithDDD.App.src.InfraLayer;

public interface IExternalApiClient
{
	Task<Result<string, ServiceError>> CallExternalApiAsync(CompanyId companyId, LocationId locationId);
}

public class ExternalApiClient(HttpClient httpClient) : IExternalApiClient
{
	private readonly HttpClient _httpClient = httpClient;

	public async Task<Result<string, ServiceError>> CallExternalApiAsync(CompanyId companyId, LocationId locationId)
	{
		var requestPayload = new
		{
			CompanyId = companyId.Value,
			LocationId = locationId.Value
		};

		var response = await _httpClient.PostAsJsonAsync("endpoint", requestPayload);

        var content = await response.Content.ReadAsStringAsync();
		return Result.Create(response.IsSuccessStatusCode,
		() => content,
		() => UnexpectedError.Create("An unexpected error occurred."));

	}
}

