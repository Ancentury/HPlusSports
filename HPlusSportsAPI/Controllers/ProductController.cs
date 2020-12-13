using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HPlusSportsAPI.Services;
using HPlusSportsAPI.Models;

namespace HPlusSportsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IDocumentDBService docService;
        IBlobService blobService;

        public ProductController(IDocumentDBService documentDBService, IBlobService blobStorageService)
        {
            docService = documentDBService;
            blobService = blobStorageService;
        }
        // GET api/product
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            List<ProductBase> products = await docService.GetProductsAsync();

            return new JsonResult(products);
        }

        
        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(string id)
        {
            var product = await docService.GetProductAsync(id);

            return new JsonResult(product);
        }

        [HttpPost]
        [Route("/api/[controller]/Nutritional")]
        public async Task<JsonResult> AddNutritional(NutritionalProduct product)
        {
            var newProduct = await docService.AddProductAsync<NutritionalProduct>(product);
            return new JsonResult(newProduct);
        }

        [HttpPost]
        [Route("/api/[controller]/Clothing")]
        public async Task<JsonResult> AddClothing(ClothingProduct product)
        {
            var newProduct = await docService.AddProductAsync<ClothingProduct>(product);
            return new JsonResult(newProduct);
        }

        [HttpPost]
        [Route("/api/[controller]/Image/{id}")]
        public async Task<IActionResult> AddImage(IFormFile imageFile)
        {
            string id = (string)RouteData.Values["id"];

            if (!Request.HasFormContentType)
                return new UnsupportedMediaTypeResult();

            var filename = $"{id}.jpg";

            Stream imageStream = null;
            try
            {
                imageStream = imageFile.OpenReadStream();

                var blobRef = await blobService.UploadBlobAsync(filename, imageStream);

                await docService.AddImageToProductAsync(id, blobRef);
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (imageStream != null)
                    imageStream.Dispose();
            }

            return Ok();
        }
    }
}
