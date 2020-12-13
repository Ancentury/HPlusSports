using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HPlusSportsWeb.Models
{
    public class OrderItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

	[DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Size { get; set; }
    }
}
