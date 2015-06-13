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
    public class Orders : APIServiceBase, IOrders
    {
        #region ctor

        public Orders()
            : base()
        {
        }
        public Orders(string clientId, string accessToken, bool sandbox = false)
            : base(clientId, accessToken, sandbox)
        {
        }

        #endregion

        public OrderResult GetById(string orderId)
        {
            if (String.IsNullOrWhiteSpace(orderId))
            {
                throw new ArgumentNullException("orderId");
            }

            OrderResult apiResult = new OrderResult();

            try
            {
                var webRequest = CreateWebRequest();
                using (var webResponse = webRequest.GET(String.Format("/orders/{0}", orderId)))
                {
                    apiResult.StatusCode = webResponse.StatusCode;

                    if (webResponse.StatusCode == HttpStatusCode.OK)
                    {
                        using (var stream = new StreamReader(webResponse.GetResponseStream()))
                        {
                            apiResult.Order = JsonConvert.DeserializeObject<Order>(stream.ReadToEnd());
                        }
                    }
                    else
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

        public APIResult TrackingSent(TrackingUpdateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            APIResult apiResult = new APIResult();

            try
            {
                string requestBody = request.ToJSON();
                var webRequest = CreateWebRequest();
                string resource = String.Format("/orders/{0}/trackings/sent", request.orderId);
                using (var webResponse = webRequest.POST(resource, requestBody))
                {
                    apiResult.StatusCode = webResponse.StatusCode;

                    if (webResponse.StatusCode != HttpStatusCode.Created)
                    {
                        apiResult.Errors = GetErrors(webResponse);
                    }

                    return apiResult;
                }
            }
            catch (Exception ex)
            {
                apiResult = ThreatException(ex, apiResult);
            }

            return apiResult;
        }

        public APIResult TrackingDelivered(TrackingUpdateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            APIResult apiResult = new APIResult();

            try
            {
                string requestBody = request.ToJSON();
                var webRequest = CreateWebRequest();
                string resource = String.Format("/orders/{0}/trackings/delivered", request.orderId);
                using (var webResponse = webRequest.POST(resource, requestBody))
                {
                    apiResult.StatusCode = webResponse.StatusCode;

                    if (webResponse.StatusCode != HttpStatusCode.Created)
                    {
                        apiResult.Errors = GetErrors(webResponse);
                    }

                    return apiResult;
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
