using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class TrackingUpdateRequest
    {
        /// <summary>
        /// ID do pedido
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// Lista de IDs dos produtos comprados no pedido e que irão ser atualizados pela operação de tracking
        /// </summary>
        public IList<string> items
        {
            get { return _items ?? (_items = new List<string>()); }
            set { _items = value; }
        }
        IList<string> _items;

        /// <summary>
        /// Data da ocorrência
        /// </summary>
        public DateTime occurredAt { get; set; }

        /// <summary>
        /// Url para consulta na transportadora
        /// </summary>
        public string url { get; set; }

        /// <summary>
        ///  ID do objeto na transportadora
        /// </summary>
        public string number { get; set; }

        /// <summary>
        /// ID de entrega do Lojista. Esse ID deve ser único para um pedido, não podendo haver repetição entre pedidos
        /// </summary>
        public string sellerDeliveryId { get; set; }

        /// <summary>
        /// Conhecimento de Transporte Eletrônico
        /// </summary>
        public string cte { get; set; }

        /// <summary>
        ///  Informações sobre a transportadora
        /// </summary>
        public Carrier carrier { get; set; }

        /// <summary>
        /// Informações sobre a Nota Fiscal da compra
        /// </summary>
        public Invoice invoice { get; set; }

        public class Carrier
        {
            /// <summary>
            /// Nome da transportadora
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// CNPJ da transportadora
            /// </summary>
            public string cnpj { get; set; }
        }

        public class Invoice
        {
            /// <summary>
            /// CNPJ responsável pelo envio dos produtos. Pode ser diferente caso a empresa possua diversos Centros de Distribuição (CDs)
            /// </summary>
            public string cnpj { get; set; }

            /// <summary>
            /// Número da Nota Fiscal
            /// </summary>
            public string number { get; set; }

            /// <summary>
            /// Número de serie da Nota Fiscal
            /// </summary>
            public string serie { get; set; }

            /// <summary>
            /// Data de emissão da Nota Fiscal
            /// </summary>
            public DateTime? issueAt { get; set; }

            /// <summary>
            /// Número da chave de acesso à nota fiscal. A chave possui 44 dígitos e contém todas as informações da DANFE
            /// </summary>
            public string accessKey { get; set; }

            /// <summary>
            /// Url para consulta da NFE
            /// </summary>
            public string linkXML { get; set; }

            /// <summary>
            /// Url para consulta da DANFE
            /// </summary>
            public string linkDanfe { get; set; }
        }
    }
}
