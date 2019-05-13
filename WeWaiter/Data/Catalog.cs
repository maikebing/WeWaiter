using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeWaiter.Data
{
    public class Catalog
    {
        [Key]
        public string CatalogID { get; set; }
        [JsonIgnore]
        public string SellerID { get; set; }
        public string CatalogName { get; set; }

        [JsonIgnore]
        public int  OrderBy { get; set; }
        [JsonIgnore]
        public bool Deleted { get; set; }
    }
    [JsonObject("Catalog")]
    public class GoodsCatalog:Catalog
    {
        [JsonIgnore]
        private new  bool  Deleted { get; set; }
        [JsonIgnore]
        public  new  string SellerID { get; set; }
        public IEnumerable<Goods> Goods { get; set; }
    }
 
}
