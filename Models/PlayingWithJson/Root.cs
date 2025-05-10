using System.Text.Json.Serialization;

namespace Models.PlayingWithJson;

public class Root
{
	public Invoice Invoice { get; set; }
}

public class Invoice
{
	[JsonPropertyName("InvoiceID")]
	public string? InvoiceId { get; set; }
	public List<InventoryItem> Inventory { get; set; }
	public List<PaymentItem> Payment { get; set; }
}
