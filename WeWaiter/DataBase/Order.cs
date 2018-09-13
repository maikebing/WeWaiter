using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public string SeatID { get; set; }
        public int  SeatNumber { get; set; }
        public int OrderIndex { get; set; }
        public DateTime Create { get; set; }
        public decimal Payable { get; set; }
        public decimal ActPay { get; set; }
        public string PayOrderID { get; set; }
        public string PayType { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
    }
    public class Orders
    {
        public Order Order { get; set; }
        public Seller Seller { get; set; }
        public List<BuyItem> BuyItems { get; set; }
    }
    public class NewOrder: Order
    {
        [JsonIgnore]
        private new  int OrderIndex { get; set; }
        [JsonIgnore]
        private new DateTime Create { get; set; }
        [JsonIgnore]
        private new decimal Payable { get; set; }
        [JsonIgnore]
        private new decimal ActPay { get; set; }
        [JsonIgnore]
        private new string PayOrderID { get; set; }
        [JsonIgnore]
        private new string PayType { get; set; }
        [JsonIgnore]
        private new decimal TotalPrice { get; set; }
        [JsonIgnore]
        private new int OrderStatus { get; set; }

        public List<BuyItem> BuyItems { get; set; }
    }
}
