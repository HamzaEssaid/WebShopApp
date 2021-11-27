using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopUppg.DTOs
{
    public class ItemsDTO
    {
        public string ImgUrl { get; set; }xx§
        [JsonProperty("itemid")]
        public int itemId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        public int CheckOutPriceTotal;

        public int receipt { get; set; }

        [JsonProperty("items")]
        public List<ItemsDTO> Items { get; set; }
    }
}
