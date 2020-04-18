using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppsExcercises.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderTotal { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public Order()
        {

        }

        

    }
}
