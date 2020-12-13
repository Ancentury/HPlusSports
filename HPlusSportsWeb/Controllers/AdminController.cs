using HPlusSportsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace HPlusSportsWeb. Controllers
{
    public class AdminController : Controller
    {
        HttpClient client;

        public AdminController(HttpClient apiClient)
        {
            client = apiClient;
        }
        //Add Product
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddNutritional(NutritionalProduct newProduct)
        {
            //Call API to add new product
            var response = 
                await client.PostAsJsonAsync<NutritionalProduct>("product/Nutritional", newProduct);
            
            //check response for errors
            if(response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<NutritionalProduct>();
                ViewData["NutritionalModel"] = model;
                ViewData["NewProductId"] = model.Id;
                ViewData["ProgressMessage"] = "Product Created";
                return View("Index");
            }
            else
            {
                throw new ApplicationException(response.ReasonPhrase);
            }

        }

        /// <summary>
        /// Add a clothing item product to the catalog
        /// </summary>
        /// <param name="newProduct">The new clothing product</param>
        /// <returns></returns>
        public async Task<IActionResult> AddClothing(ClothingProduct newProduct)
        {
            //Call API to add new product
            var response =
                await client.PostAsJsonAsync<ClothingProduct>("product/Clothing", newProduct);

            //check response for errors
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadAsAsync<ClothingProduct>();
                ViewData["ClothingModel"] = model;
                ViewData["NewProductId"] = model.Id;
                ViewData["ProgressMessage"] = "Product Created";
                return View("Index");
            }
            else
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
        }

        /// <summary>
        /// Add a new image and associate it with a product
        /// </summary>
        /// <param name="imageFile">The posted image file</param>
        /// <returns></returns>
        public async Task<IActionResult> NewImage(IFormFile imageFile)
        {
            //product ID from query string
            string id = Request.Form["imageProductId"];
            if(imageFile.Length > 0)
            {
                //create form payload to pass to web API
                var imageContent = new StreamContent(imageFile.OpenReadStream());
                imageContent.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                    {
                        Name = "imageFile",
                        FileName = imageFile.FileName
                    };

                var postContent = new MultipartFormDataContent();
                postContent.Add(imageContent,"imageFile");

                //call web api passing multipart form data
                var result = await client.PostAsync($"product/image/{id}", postContent);

                if(result.IsSuccessStatusCode)
                {
                    ViewData["ProgressMessage"] = "Image Added";
                    return View("Index");
                }
                else
                {
                    throw new ApplicationException(result.ReasonPhrase);
                }
            }
            else
            {
                return BadRequest();
            }

        }
    }
}