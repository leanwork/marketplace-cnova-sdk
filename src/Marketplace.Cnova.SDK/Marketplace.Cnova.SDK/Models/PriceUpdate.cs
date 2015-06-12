using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class PriceUpdate
    {
        public string skuSellerId { get; set; }

        public double @default { get; set; }

        public double offer { get; set; }

        public string site { get; set; }
    }
}
