using Marketplace.Cnova.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Services
{
    public interface IOrders
    {
        OrderResult GetById(string orderId);
        APIResult TrackingSent(TrackingUpdateRequest request);
    }
}
