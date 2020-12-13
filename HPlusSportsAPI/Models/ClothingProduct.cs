using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPlusSportsAPI.Models
{
    /// <summary>
    /// A product that represents clothing and therefore 
    /// has a sizes associated with it.
    /// </summary>
    public class ClothingProduct : ProductBase
    {
        public string[] Sizes { get; set; }
    }
}
