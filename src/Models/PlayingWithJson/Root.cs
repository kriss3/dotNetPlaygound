using System.Text.Json.Serialization;
namespace Models.PlayingWithJson;

public class Root
{
	public Invoice? Invoice { get; set; }
}

public class Invoice
{
	[JsonPropertyName("InvoiceID")]
	public string? InvoiceId { get; set; }
	public List<InventoryItem>? Inventory { get; set; }
	public List<PaymentItem>? Payment { get; set; }
}

public class InventoryItem
{
	[JsonPropertyName("ID")]
	public int Id { get; set; }
	[JsonPropertyName("InvoiceID")]
	public string? InvoiceId { get; set; }
	[JsonPropertyName("InventoryID")]
	public string? InventoryId { get; set; }
	public bool Deleted { get; set; }
	public decimal Amount { get; set; }
	public decimal Price { get; set; }
	public int TransactionID { get; set; }
}

public class PaymentItem
{
	[JsonPropertyName("Id")]
	public int PaymentItemId { get; set; }
	public decimal Amount { get; set; }
	[JsonPropertyName("InvoiceID")]
	public string? InvoiceId { get; set; }
	public bool Deleted { get; set; }
	public int TransactionID { get; set; }
	public string? CreatedOn { get; set; }
	public string? UpdatedOn { get; set; }
}
