using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeWaiter.Data
{

    /// <summary>
    ///   PAYERROR--支付失败(其他原因，如银行返回失败)
    /// </summary>
    public enum TradeState : int
    {
        NOTPAY = 0,//—未支付
        USERPAYING = 2,//--用户支付中
        SUCCESS = 1,//—支付成功 
        REFUND = 3,//—转入退款 
        REVOKED = 4,//—已撤销（刷卡支付） 
        CLOSED = 5// 已关闭 
    }
    public class Order
    {
        [Key]
        public string OrderID { get; set; }
        public string SellerID { get; set; }
        public string UserID { get; set; }
        public string SeatID { get; set; }
        public int  SeatNumber { get; set; }
        /// <summary>
        /// 当天票号
        /// </summary>
        public int OrderIndex { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime Create { get; set; }

        /// <summary>
        /// 应付的
        /// </summary>
        public decimal Payable { get; set; }

        /// <summary>
        /// 实际支付金额 从微信来
        /// </summary>
        public decimal ActPay { get; set; }

        /// <summary>
        /// 微信交易代码
        /// </summary>
        [JsonIgnore]
        public string TransactionId { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayType { get; set; }

       /// <summary>
       /// 总价格
       /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 支付状态， 默认为 0 未支付，  更新跟随微信状态更新
        /// </summary>
        public TradeState OrderStatus { get; set; }

        /// <summary>
        /// 微信支付人ID
        /// </summary>
        [JsonIgnore]
        public string OpenID { get;  set; }
        /// <summary>
        /// 预支付ID,用于查询订单支付状态
        /// </summary>
        [JsonIgnore]
        public string PrepayId { get; set; }
        /// <summary>
        /// 从微信返回来的支付时间，但返回异常情况下为 回调时间
        /// </summary>
        public DateTime PayDateTime { get; set; }


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
        private  string PayOrderID { get; set; }
        [JsonIgnore]
        private new string PayType { get; set; }
        [JsonIgnore]
        private new decimal TotalPrice { get; set; }
        [JsonIgnore]
        private new int OrderStatus { get; set; }

        public List<BuyItem> BuyItems { get; set; }
    }
}
