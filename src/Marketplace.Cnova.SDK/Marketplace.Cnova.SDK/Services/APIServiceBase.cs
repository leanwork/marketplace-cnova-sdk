using Marketplace.Cnova.SDK.Configuration;
using Marketplace.Cnova.SDK.Constants;
using Marketplace.Cnova.SDK.Models;
using Marketplace.Cnova.SDK.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Marketplace.Cnova.SDK.Services
{
    /// <summary>
    /// API Service Base
    /// </summary>
    public abstract class APIServiceBase
    {
        string _clientId;
        string _accessToken;

        public bool Sandbox { get; set; }
        
        internal ISimpleRequest SimpleRequest
        {
            get { return _simpleRequest ?? new SimpleRequest(); }
            set { _simpleRequest = value; }
        }
        ISimpleRequest _simpleRequest;

        #region ctor

        public APIServiceBase()
        {
            this.Sandbox = APISettings.Sandbox;
            this._clientId = APISettings.ClientId;
            this._accessToken = APISettings.AccessToken;
        }

        public APIServiceBase(string clientId, string accessToken, bool sandbox = false)
            : base()
        {
            if (String.IsNullOrWhiteSpace(clientId))
                throw new ArgumentNullException("clientId");
            if (String.IsNullOrWhiteSpace(accessToken))
                throw new ArgumentNullException("accessToken");

            this._clientId = clientId;
            this._accessToken = accessToken;
            this.Sandbox = sandbox;
        }

        #endregion

        protected ISimpleRequest CreateWebRequest()
        {
            var request = this.SimpleRequest;
            request.SetHost(GetHost());
            request.AddHeader(Keys.CLIENT_ID, this._clientId);
            request.AddHeader(Keys.ACCESS_TOKEN, this._accessToken);
            return request;
        }

        protected ICollection<Error> GetErrors(HttpWebResponse response)
        {
            string error = string.Empty;
            using (var stream = new StreamReader(response.GetResponseStream()))
            {
                return JsonConvert.DeserializeObject<ICollection<Error>>(stream.ReadToEnd());
            }
        }

        protected void ValidateSandboxRequest()
        {
            if (this.Sandbox == false)
            {
                throw new InvalidOperationException("Você não tem permissão para executar esta operação em ambiente de produção. Só é permitido em ambiente Sanbox.");
            }
        }

        protected T ThreatException<T>(Exception exception, T response) where T : APIResult
        {
            if (response == null)
            {
                response = Activator.CreateInstance<T>();
            }

            string message = null;

            try
            {
                var webException = exception as WebException;
                if (webException != null)
                {
                    using (var stream = new StreamReader(webException.Response.GetResponseStream()))
                    {
                        message = stream.ReadToEnd();
                        response.Errors = JsonConvert.DeserializeObject<ICollection<Error>>(stream.ReadToEnd());
                    }

                    return response;
                }
            }
            catch (Exception)
            {
                response.Errors.Add(new Error
                {
                    message = message ?? exception.GetBaseException().Message
                });
            }

            return response;
        }

        #region privates

        private string GetHost()
        {
            return this.Sandbox ? Hosts.SANDBOX : Hosts.PRODUCTION;
        }

        #endregion
    }
}
