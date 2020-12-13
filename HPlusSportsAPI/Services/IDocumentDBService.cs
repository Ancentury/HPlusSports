using HPlusSportsAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Services
{
    public interface IDocumentDBService
    {
        Task<T> AddProductAsync<T>(T product);

        Task<List<ProductBase>> GetProductsAsync();

        Task<ProductBase> GetProductAsync(string id);

        Task AddImageToProductAsync(string id, string imageUri);
    }
}
