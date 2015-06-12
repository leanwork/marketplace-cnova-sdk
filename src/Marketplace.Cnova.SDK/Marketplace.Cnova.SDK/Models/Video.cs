using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class Video
    {
        /// <summary>
        /// Nome do vídeo
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Formato do vídeo
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// URL do vídeo do produto
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// URL de thumbnail
        /// </summary>
        public string thumbnail { get; set; }

        /// <summary>
        /// URL embedded do vídeo
        /// </summary>
        public string embedded { get; set; }
    }
}
