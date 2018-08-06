using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WWS.DB
{
    public class User
    {
        [Key]
        public string WeixinID { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }
        public DateTime JoinIn { get; set; }
        public DateTime LastActive { get; set; }

    }
}
