using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Models
{
    /// <summary>
    /// A single item in an order. It may have size so we 
    /// include it here.
    /// </summary>
    public class OrderItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }
    }
}
