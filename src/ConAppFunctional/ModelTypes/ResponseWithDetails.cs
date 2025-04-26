using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConAppFunctional.ModelTypes;
public record ResponseWithDetails<TSuccess, TFailure>(
		bool IsSuccess, HttpStatusCode Code, string Message, TSuccess Success, TFailure Failure)
	where TSuccess : class
	where TFailure : class;

public record BioTrackError
{
	[JsonPropertyName("Code")]
	public string? Code { get; set; }
	
	[JsonPropertyName("Data")]
	public string? Data { get; set; }
	
	[JsonPropertyName("Error")]
	public string? Error { get; set; }
	
	[JsonPropertyName("ErrorResource")]
	public string? ErrorResource { get; set; }
	
	[JsonPropertyName("ErrorResourceID")]
	public string? ErrorResourceId { get; set; }
	
	[JsonPropertyName("ErrorSrc")]
	public string? ErrorSrc { get; set; }
}