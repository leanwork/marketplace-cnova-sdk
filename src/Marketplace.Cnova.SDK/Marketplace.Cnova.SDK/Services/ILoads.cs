using Marketplace.Cnova.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Services
{
    public interface ILoads
    {
        APIResult Products(LoadProductsRequest request);
    }
}
