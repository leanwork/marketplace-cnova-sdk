using Marketplace.Cnova.SDK.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Marketplace.Cnova.SDK.Utils
{
    internal class SimpleRequest : ISimpleRequest
    {
        #region fields

        string _host;
        string _contentType;
        Dictionary<string, string> _headers;
        Dictionary<string, string> _parameters;

        #endregion

        #region ctor

        public SimpleRequest()
        {
            this._headers = new Dictionary<string, string>();
            this._parameters = new Dictionary<string, string>();
        }

        #endregion

        public virtual ISimpleRequest SetHost(string host)
        {
            this._host = host;
            return this;
        }

        public virtual ISimpleRequest AddHeader(string key, string value)
        {
            if (_headers.ContainsKey(key))
                _headers[key] = value;
            else
                _headers.Add(key, value);
            
            return this;
        }

        public virtual ISimpleRequest AddParameter(string key, string value)
        {
            if (_parameters.ContainsKey(key))
                _parameters[key] = value;
            else
                _parameters.Add(key, value);

            return this;
        }

        public ISimpleRequest SetContentType(string contentType)
        {
            this._contentType = contentType;
            return this;
        }

        public virtual HttpWebResponse GET(string resource)
        {
            //no cache
            //AddParameter("r", new Random().Next(0, 999999).ToString());

            HttpWebRequest request = CreateRequest(resource);
            request.Method = HttpMethods.GET;

            return Send(request);
        }

        public virtual HttpWebResponse POST(string resource)
        {
            return CreateOrUpdate(HttpMethods.POST, resource);
        }

        public virtual HttpWebResponse POST(string resource, string requestBody)
        {
            return CreateOrUpdate(HttpMethods.POST, resource, requestBody);
        }

        public virtual HttpWebResponse POST(string resource, byte[] requestBody)
        {
            return CreateOrUpdate(HttpMethods.POST, resource, requestBody);
        }

        public virtual HttpWebResponse PUT(string resource)
        {
            return CreateOrUpdate(HttpMethods.PUT, resource);
        }

        public virtual HttpWebResponse PUT(string resource, string requestBody)
        {
            return CreateOrUpdate(HttpMethods.PUT, resource, requestBody);
        }

        public virtual HttpWebResponse PUT(string resource, byte[] requestBody)
        {
            return CreateOrUpdate(HttpMethods.PUT, resource, requestBody);
        }

        public virtual HttpWebResponse DELETE(string resource)
        {
            HttpWebRequest request = CreateRequest(resource);
            request.Method = HttpMethods.DELETE;
            return Send(request);
        }

        #region privates

        private HttpWebResponse CreateOrUpdate(string httpMethod, string resource)
        {
            HttpWebRequest request = CreateRequest(resource);
            request.Method = httpMethod;
            return Send(request);
        }

        private HttpWebResponse CreateOrUpdate(string httpMethod, string resource, string requestBody)
        {
            if (null == requestBody)
            {
                throw new ArgumentNullException("requestBody");
            }

            HttpWebRequest request = CreateRequest(resource);
            request.Method = httpMethod;
            using (var stream = new StreamWriter(request.GetRequestStream()))
            {
                stream.Write(requestBody);
                stream.Flush();
                return Send(request);
            }
        }

        private HttpWebResponse CreateOrUpdate(string httpMethod, string resource, byte[] requestBody)
        {
            if (null == requestBody || requestBody.Length == 0)
            {
                throw new ArgumentNullException("requestBody");
            }

            HttpWebRequest request = CreateRequest(resource);
            request.Method = httpMethod;
            request.ContentLength = requestBody.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(requestBody, 0, requestBody.Length);
                stream.Flush();
                return Send(request);
            }
        }

        private HttpWebResponse Send(HttpWebRequest request)
        {
            return (HttpWebResponse)request.GetResponse();
        }

        private string GetContentType()
        {
            return this._contentType ?? Keys.APPLICATION_JSON;
        }

        private HttpWebRequest CreateRequest(string resource)
        {
            var requestUriString = BuildUrl(resource);
            HttpWebRequest http = WebRequest.CreateHttp(requestUriString);
            http.ContentType = GetContentType();
            foreach (var header in this._headers)
            {
                http.Headers.Add(header.Key, header.Value);
            }
            return http;
        }

        private string BuildUrl(string resource)
        {
            string queryString = this._parameters.ConvertToQueryString();
            if (String.IsNullOrWhiteSpace(queryString))
            {
                return String.Concat(_host, resource);
            }
            return String.Concat(_host, resource, "?", queryString);
        }

        #endregion
    }
}
