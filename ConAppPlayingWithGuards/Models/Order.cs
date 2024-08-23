namespace ConAppPlayingWithGuards.Models;
public class Order
{
    public DateTime OrderDate { get; set; }
    public Customer? Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}

public class OrderItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
}
