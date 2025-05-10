namespace Models.PlayingWithJson;

public class Root
{
	public Invoice Invoice { get; set; }
}

public class Invoice
{
	public string InvoiceID { get; set; }
	public List<InventoryItem> Inventory { get; set; }
	public List<PaymentItem> Payment { get; set; }
}
