using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class GiftWrap
    {
        /// <summary>
        /// (boolean): Flag que indica se existe embrulho para presente para o produto.
        /// </summary>
        public bool available { get; set; }

        /// <summary>
        /// (number): Valor cobrado pelo embrulho.
        /// </summary>
        public double value { get; set; }

        /// <summary>
        /// (boolean): Flag que indica se é possível incluir uma mensagem.
        /// </summary>
        public bool messageSupport { get; set; }
    }
}
