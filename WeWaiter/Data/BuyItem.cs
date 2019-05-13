using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeWaiter.Data
{
    public class BuyItem
    {
        [Key]
        public string BuyItemID { get; set; }
        public string OrderID { get; set; }
        public string GoodsID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public decimal Total { get; set; }
        public string GoodsName { get; set; }
        public string Icon { get; internal set; }
        public string Image { get; internal set; }
    }
  
}
