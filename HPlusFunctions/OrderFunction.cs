using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using HplusFunctions;

namespace HPlusFunctions
{
    public static class OrderFunction
    {
        [FunctionName("OrderFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestMessage req,
            [Table("orderhistory")]ICollector<TableOrderItem> items,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string orderId = System.Guid.NewGuid().ToString();

            Order order = await req.Content.ReadAsAsync<Order>();

            foreach (var item in order.Items)
            {
                TableOrderItem tableOrderItem = new TableOrderItem(item);
                tableOrderItem.PartitionKey = "history";
                tableOrderItem.RowKey = $"{orderId} - {item.Id}";
                items.Add(tableOrderItem);
            }
            
            return new OkResult();
        }
    }
}
