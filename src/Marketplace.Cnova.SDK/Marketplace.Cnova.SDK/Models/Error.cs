using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class Error
    {
        public string code { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public string skuSellerId { get; set; }
    }
}
