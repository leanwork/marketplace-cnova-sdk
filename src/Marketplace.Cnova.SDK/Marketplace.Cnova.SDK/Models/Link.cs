using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class Link
    {
        /// <summary>
        /// ID do recurso
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Link para acesso ao recurso
        /// </summary>
        public string href { get; set; }
    }
}
