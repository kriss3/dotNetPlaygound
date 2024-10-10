using System.Collections.Generic;

namespace ConAppsExercises.Models;

public class Order
{
    public int OrderId { get; set; }
    public int OrderTotal { get; set; }
    public List<OrderLine> OrderLines { get; set; }
    public Order()
    {

    }

    

}
