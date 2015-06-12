using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class Url
    {
        /// <summary>
        /// ID do produto
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Link do produto no site
        /// </summary>
        public string href { get; set; }

        /// <summary>
        /// Site no qual o produto está disponível. Consulte a lista completa de sites disponíveis no serviço GET /sites
        /// </summary>
        public string site { get; set; }
    }
}
