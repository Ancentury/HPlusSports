using System;
using System.Collections.Generic;
using System.Text;

namespace HplusFunctions
{
    public class TableOrderItem : OrderItem
    {
        public TableOrderItem()
        {}
        public TableOrderItem(OrderItem item)
        {
            base.Id = item.Id;
            base.Name = item.Name;
            base.Size = item.Size;
            base.Quantity = item.Quantity;
        }
        public string PartitionKey { get; set; }

        public string RowKey { get; set; }
    }
}
