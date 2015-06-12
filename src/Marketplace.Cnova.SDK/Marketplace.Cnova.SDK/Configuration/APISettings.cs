using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Configuration
{
    internal static class APISettings
    {
        public static bool Sandbox
        {
            get
            {
                var value = ConfigurationManager.AppSettings["Marketplace.Cnova.Sandbox"];
                var sandbox = false;
                if (!Boolean.TryParse(value, out sandbox))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.Cnova.Sandbox' não está configurada no appSettings.");
                }
                return sandbox;
            }
        }

        public static string ClientId
        {
            get
            {
                var value = ConfigurationManager.AppSettings["Marketplace.Cnova.ClientId"];
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.Cnova.ClientId' não está configurada no appSettings.");
                }
                return value;
            }
        }

        public static string AccessToken
        {
            get
            {
                var value = ConfigurationManager.AppSettings["Marketplace.Cnova.AccessToken"];
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ConfigurationErrorsException("A chave 'Marketplace.Cnova.AccessToken' não está configurada no appSettings.");
                }
                return value;
            }
        }
    }
}
