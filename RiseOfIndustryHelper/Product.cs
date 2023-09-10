using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfIndustryHelper
{
    public partial class Product
    {
        [JsonProperty("Product")]
        public string ProductName { get; set; }

        [JsonProperty("Building")]
        public string Building { get; set; }

        [JsonProperty("Level")]
        public string Level { get; set; }

        [JsonProperty("Worktime")]
        public int Workdays { get; set; }

        [JsonProperty("OutputQuantity")]
        public int OutputQuantity { get; set; }

        [JsonProperty("Input1")]
        public string Input1 { get; set; }

        [JsonProperty("Input1_Quantity")]
        public int Input1Quantity { get; set; }

        [JsonProperty("Input2")]
        public string Input2 { get; set; }

        [JsonProperty("Input2_Quantity")]
        public int Input2Quantity { get; set; }

        [JsonProperty("Input3")]
        public string Input3 { get; set; }

        [JsonProperty("Input3_Quantity")]
        public int Input3Quantity { get; set; }
    }
}
