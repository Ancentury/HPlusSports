using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HPlusSportsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace HPlusSportsWeb.Controllers
{
    public class CartController : Controller
    {
       HttpClient client;

        public CartController(HttpClient apiClient)
        {
            client = apiClient;
        }
        [HttpGet]
        public IActionResult Index()
        {
            //cart items are shown in the index page using localstorage
            return View();
        }

        /// <summary>
        /// Get the order history from the API
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> History()
        {
            var orderHistory = await client.GetStringAsync("order");
            var historyArray = JArray.Parse(orderHistory);

            return View(historyArray);
        }


        /// <summary>
        /// Handle a cart being submitted as an order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(Order order)
        {
            var respone = await client.PostAsJsonAsync<Order>("order", order);
            if(Response.StatusCode == (int)HttpStatusCode.OK)
            {
                return Ok();
            }
            else
            {
                throw new ApplicationException($"Order failed with status code: {Response.StatusCode}");
            }
            
        }

        /// <summary>
        /// Placholder page for completion success
        /// </summary>
        /// <returns></returns>
        public IActionResult OrderComplete()
        {
            return View();
        }
    }
}