using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WWS.DB
{
    public class BuyItem
    {
        [Key]
        public string BuyItemID { get; set; }
        public string OrderID { get; set; }
        public string GoodsID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
        public int Total { get; set; }
       
    }
}
