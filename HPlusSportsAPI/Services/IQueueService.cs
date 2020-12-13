using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Services
{
    public interface IQueueService
    {
        Task SendMessageAsync<T>(T item);
    }
}
