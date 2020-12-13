using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Services
{
    public interface IBlobService
    {
        Task<string> UploadBlobAsync(string blobName, Stream imageStream);
    }
}
