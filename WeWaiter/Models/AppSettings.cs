using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace WeWaiter.Models
{
    public class AppSettings
    {
        public string JwtIssuer { get;  set; }
        public string JwtAudience { get;  set; }
        public string JwtKey { get;  set; }
        public int  JwtExpireMinutes { get;  set; }
        public string ImageHostURL { get;  set; }
    }
}
