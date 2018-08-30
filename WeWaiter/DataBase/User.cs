using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeWaiter.DataBase
{
    public class User
    {
        [Key]
        public string WeixinID { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }
        [JsonIgnore]
        public DateTime JoinIn { get; set; }
        [JsonIgnore]
        public DateTime LastActive { get; set; }

    }
}
