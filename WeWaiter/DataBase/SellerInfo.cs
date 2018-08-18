using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeWaiter.DataBase
{
    public class SellerInfo
    {
        [Key]
        public string SellerID { get; set; }
        public string Address { get; set; }
        public string MapURL { get; set; }
        public string LogoURL { get; set; }

        public string OwnerWeixinID { get; set; }
        public string OwnerPhone { get; set; }
        public string OwnerName { get; set; }
        public string OwnerIDNumber { get; set; }
    }
}
