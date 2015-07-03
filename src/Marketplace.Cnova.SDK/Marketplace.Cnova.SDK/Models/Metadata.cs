using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class Metadata
    {
        /// <summary>
        /// (string): Chave de identificação do atributo.
        /// </summary>
        public string key { get; set; }

        /// <summary>
        /// (string): Valor do atributo.
        /// </summary>
        public string value { get; set; }
    }
}
