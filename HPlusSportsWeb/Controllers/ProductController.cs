using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HPlusSportsWeb.Controllers
{
    /// <summary>
    /// Displays list of products as well as product details page
    /// for adding to the cart
    /// </summary>
    public class ProductController : Controller
    {
        HttpClient client;

        public ProductController(HttpClient apiClient)
        {
            client = apiClient;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var response = await client.GetStringAsync("product");
            var products = JArray.Parse(response);
            return View(products);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var response = await client.GetStringAsync($"product/{id}");

            var product = JObject.Parse(response);
            return View(product);
        }
    }
}
