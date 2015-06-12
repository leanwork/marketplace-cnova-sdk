using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class Image
    {
        /// <summary>
        /// Formato da imagem
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Flag que indica se a imagem é a principal
        /// </summary>
        public bool main { get; set; }

        /// <summary>
        /// URL da imagem do produto
        /// </summary>
        public string url { get; set; }
    }
}
