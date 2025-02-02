using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
