using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace HPlusSportsWeb.Models
{
    public class ClothingProduct : ProductBase
    {
        [JsonProperty(ItemConverterType = typeof(StringEnumConverter))]
        public SizeType[] Sizes { get; set; }
    }
}
