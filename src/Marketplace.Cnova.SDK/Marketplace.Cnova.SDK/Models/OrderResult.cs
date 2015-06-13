using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class OrderResult : APIResult
    {
        public Order Order { get; set; }
    }
}
