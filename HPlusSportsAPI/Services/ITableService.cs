using HPlusSportsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Services
{
    public interface ITableService
    {
        Task<List<OrderHistoryItem>> GetOrderHistoryAsync();
    }
}
