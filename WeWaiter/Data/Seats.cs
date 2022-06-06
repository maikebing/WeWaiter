using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeWaiter.Data
{

    public class Seat
    {
        /// <summary>
        /// 座位编码
        /// </summary>
        [Key]
        public string SeatId { get; set; }

        public int SeatNumber { get; set; }
        /// <summary>
        /// 卖家编码
        /// </summary>
        [JsonIgnore]
        public string Seller { get; set; }
        /// <summary>
        /// 座位人数
        /// </summary>
        public int Seats { get; set; }
        /// <summary>
        /// 是否有人
        /// </summary>
         public bool Sit { get; set; }
    }
}
