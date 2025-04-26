using System.Text.Json.Serialization;

namespace ConAppFunctional.ModelTypes;

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