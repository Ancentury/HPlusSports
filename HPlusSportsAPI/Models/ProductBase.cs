using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Models
{
    /// <summary>
    /// The base class for products containing the core
    /// attributes
    /// </summary>
    public class ProductBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
    }
}
