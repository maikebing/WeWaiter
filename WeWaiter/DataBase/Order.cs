using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeWaiter.DataBase
{
    public class Order
    {
        [Key]
        public string OrderID { get; set; }
        public string SellerID { get; set; }
        public string UserID { get; set; }

        public int SellerOrderIndex { get; set; }
        public DateTime Create { get; set; }
        public decimal Payable { get; set; }
        public decimal ActPay { get; set; }
        public string PayOrderID { get; set; }
        public string PayType { get; set; }
    }
}
