using System.Text.Json.Serialization;

namespace ConAppPlayingWithInMemoryCache.Models;
public record Product
{
	[JsonPropertyName("id")]
	public int Id { get; init; }

	[JsonPropertyName("quantityPerUnit")]
	public string? QuantityPerUnit { get; set; }

	[JsonPropertyName("unitPrice")]
	public decimal? UnitPrice { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }
}

public record ProductResult(string From, List<Product> Products);
