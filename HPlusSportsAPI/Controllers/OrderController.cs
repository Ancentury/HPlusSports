using HPlusSportsAPI.Services;
using HPlusSportsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Controllers
{
    /// <summary>
    /// Handles submitting orders to the queue and 
    /// retrieving order history
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IQueueService qService;
        ITableService tService;

        public OrderController(IQueueService queueService, ITableService tableService)
        {
            qService = queueService;
            tService = tableService;
        }

        /// <summary>
        /// Creates an order on an Azure Queue for processing.
        /// </summary>
        /// <param name="order">the order to write</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await qService.SendMessageAsync<Order>(order);

            return Ok();
        }

        /// <summary>
        /// Retrieves order history from an Azure table.
        /// </summary>
        /// <returns></returns>
       [HttpGet]
       public async Task<IActionResult> GetOrderHistory()
        {
            var items = await tService.GetOrderHistoryAsync();
            return new JsonResult(items);
        }
    }
}