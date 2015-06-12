using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class SellerItemsResult : APIResult
    {
        public IEnumerable<SellerItem> sellerItems { get; set; }

        public IEnumerable<Metadata> metadata { get; set; }
    }
}
