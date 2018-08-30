using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WeWaiter.DataBase
{
    public class Goods
    {
        [Key]
        public string GoodsID { get; set; }
        public string Seller { get; set; }
        public string BarCode { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public string Icon { get; set; }

        public int Rating { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }

        public decimal MinSellingPrice { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        [JsonIgnore]
        public bool Visible { get; set; }

        [JsonIgnore]
        public bool Deleted { get; set; }
    }
}
