using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeWaiter.Data
{
    public class Printer
    {
        [Key]
        public string PrinterID {get;set;}
        public string PrinterType { get; set;}
        public string Name { get; set; }
        public string Desc { get; set;}
        public string ApiURL { get; set; }

    }
}
