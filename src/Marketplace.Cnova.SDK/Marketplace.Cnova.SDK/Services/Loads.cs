using Marketplace.Cnova.SDK.Constants;
using Marketplace.Cnova.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Services
{
    public class Loads : APIServiceBase, ILoads
    {
        #region ctor

        public Loads() 
            : base() 
        { 
        }
        public Loads(string clientId, string accessToken, bool sandbox = false) 
            : base(clientId, accessToken, sandbox)
        { 
        }

        #endregion

        public APIResult Products(Models.LoadProductsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (Sandbox)
            {
                //in sandbox, move fixed category 'Teste>API'
                foreach (var item in request.Items)
                {
                    item.categories.Clear();
                    item.categories.Add("Teste>API");
                }
            }

            APIResult apiResult = new APIResult();

            try
            {
                object data = request.Items;
                string json = data.ToJSON();
                byte[] requestBody = json.CompressWithGzip();

                var webRequest = CreateWebRequest();
                webRequest.SetContentType(Keys.APPLICATION_GZIP);
                using (var webResponse = webRequest.POST("/loads/products", requestBody))
                {
                    apiResult.StatusCode = webResponse.StatusCode;

                    if (webResponse.StatusCode != HttpStatusCode.Created)
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
    }
}
