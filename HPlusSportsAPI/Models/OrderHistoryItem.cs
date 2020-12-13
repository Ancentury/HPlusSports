using Microsoft.Azure.Cosmos.Table;

namespace HPlusSportsAPI.Models
{
    /// <summary>
    /// An item to represent a row in an Azure Table
    /// </summary>
    public class OrderHistoryItem : TableEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }
    }
}
