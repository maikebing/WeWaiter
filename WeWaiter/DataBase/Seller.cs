using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WeWaiter.DataBase
{
    public class Seller
    {
        [Key]
        public string SellerID { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}
        public int Score { get; set; }
        public int ServiceScore { get; set; }
        public int FoodScore { get; set; }
        public int RankRate { get; set; }
        public float MinPrice { get; set; }
        public int SellCount { get; set; }
        public int RatingCount { get; set; }
        public string Bulletin { set; get; }
        public int TableNumber { get; set; }

        public string Avatar  { get; set; }
        public  string[] Pics { get; set; }

        public string PrintID { get; set; }
        public bool Deleted { get; set; }
    }
}
