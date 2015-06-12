using Marketplace.Cnova.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Services
{
    public class SellerItems : APIServiceBase, ISellerItems
    {
        #region ctor

        public SellerItems() 
            : base() 
        { 
        }
        public SellerItems(string clientId, string accessToken, bool sandbox = false) 
            : base(clientId, accessToken, sandbox)
        { 
        }

        #endregion

        public APIResult UpdateStock(StockUpdateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            APIResult apiResult = new APIResult();

            try
            {
                var data = new
                {
                    quantity = request.quantity,
                    crossDockingTime = request.crossDockingTime,
                    warehouse = request.warehouse
                };
                string requestBody = JsonConvert.SerializeObject(data);
                string resource = String.Format("/sellerItems/{0}/stock", request.skuSellerId);
                var webRequest = CreateWebRequest();
                using (var webResponse = webRequest.PUT(resource, requestBody))
                {
                    apiResult.StatusCode = webResponse.StatusCode;

                    if (webResponse.StatusCode != HttpStatusCode.NoContent)
                    {
                        apiResult.Errors = GetErrors(webResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                apiResult = ThreatException(ex, apiResult);
            }

            return apiResult;
        }

        public APIResult UpdatePrice(PriceUpdateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            APIResult apiResult = new APIResult();

            try
            {
                var data = new
                {
                    @default = request.@default,
                    offer = request.offer,
                    site = request.site ?? String.Empty
                };
                string requestBody = JsonConvert.SerializeObject(data);
                string resource = String.Format("/sellerItems/{0}/prices", request.skuSellerId);
                var webRequest = CreateWebRequest();
                using (var webResponse = webRequest.PUT(resource, requestBody))
                {
                    apiResult.StatusCode = webResponse.StatusCode;

                    if (webResponse.StatusCode != HttpStatusCode.NoContent)
                    {
                        apiResult.Errors = GetErrors(webResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                apiResult = ThreatException(ex, apiResult);
            }

            return apiResult;
        }

        public SellerItemsResult GetAll(int offset = 0, int limit = 50)
        {
            SellerItemsResult apiResult = new SellerItemsResult();

            try
            {
                var webRequest = CreateWebRequest();
                webRequest.AddParameter("_offset", offset.ToString());
                webRequest.AddParameter("_limit", limit.ToString());
                using (var webResponse = webRequest.GET("/sellerItems"))
                {
                    apiResult.StatusCode = webResponse.StatusCode;

                    if (webResponse.StatusCode != HttpStatusCode.OK)
                    {
                        apiResult.sellerItems = Enumerable.Empty<SellerItem>();
                    }
                    
                    using (var stream = new StreamReader(webResponse.GetResponseStream()))
                    {
                        apiResult.sellerItems = JsonConvert.DeserializeObject<IEnumerable<SellerItem>>(stream.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                apiResult = ThreatException(ex, apiResult);
            }

            return apiResult;
        }
    }
}
