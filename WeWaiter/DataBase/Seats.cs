using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeWaiter.DataBase
{

    public class Seat
    {
        [Key]
        public string SeatId { get; set; }
        public string Seller { get; set; }
        public int Seats { get; set; }
        public bool Sit { get; set; }
    }
}
