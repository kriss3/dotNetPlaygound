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
	public string Code { get; set; }
	
	[JsonProperty(PropertyName = "Data")]
	public string Data { get; set; }
	[JsonProperty(PropertyName = "Error")]
	public string Error { get; set; }
	[JsonProperty(PropertyName = "ErrorResource")]
	public string ErrorResource { get; set; }
	[JsonProperty(PropertyName = "ErrorResourceID")]
	public string ErrorResourceId { get; set; }
	[JsonProperty(PropertyName = "ErrorSrc")]
	public string ErrorSrc { get; set; }
}