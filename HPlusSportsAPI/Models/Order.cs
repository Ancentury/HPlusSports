using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Models
{
    /// <summary>
    /// Represents an order to be sent to the queue
    /// </summary>
    public class Order
    {
        public List<OrderItem> Items { get; set; }
    }
}
