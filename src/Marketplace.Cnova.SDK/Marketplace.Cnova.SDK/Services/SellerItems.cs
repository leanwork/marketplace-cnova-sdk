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
