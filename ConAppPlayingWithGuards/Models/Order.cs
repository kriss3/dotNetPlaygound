﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithGuards.Models;
public class Order
{
    public DateTime OrderDate { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}
