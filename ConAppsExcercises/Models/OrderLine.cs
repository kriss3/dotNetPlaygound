namespace ConAppsExercises.Models;

public class OrderLine
{
    public int OrderLineId { get; set; }
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}
