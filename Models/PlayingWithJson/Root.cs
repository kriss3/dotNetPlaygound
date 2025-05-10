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

public class InventoryItem
{
	public int ID { get; set; }
	public string InvoiceID { get; set; }
	public string InventoryID { get; set; }
	public bool Deleted { get; set; }
	public decimal Amount { get; set; }
	public decimal Price { get; set; }
	public int TransactionID { get; set; }
}
