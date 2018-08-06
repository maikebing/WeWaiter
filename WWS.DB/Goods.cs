using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WWS.DB
{
    public class Goods
    {
        [Key]
        public string GoodsID { get; set; }
        public string BarCode { get; set; }
        public string QRCode { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string PictureURL { get; set; }

        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }

        public decimal MinSellingPrice { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string Description { get; set; }

        public int Status { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public int Stock { get; set; }
        /// <summary>
        /// 已售出
        /// </summary>
        public int SoldOut { get; set; }
    }
}
