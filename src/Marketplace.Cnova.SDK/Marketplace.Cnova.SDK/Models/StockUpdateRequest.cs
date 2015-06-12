using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class StockUpdateRequest
    {
        public string skuSellerId { get; set; }

        public int quantity { get; set; }

        public int? crossDockingTime { get; set; }

        public int? warehouse { get; set; }
    }
}
