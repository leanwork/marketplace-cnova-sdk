using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class Order
    {
        /// <summary>
        ///  ID do pedido gerado para o lojista
        /// </summary>
        public string id { get; set; }
        
        /// <summary>
        /// ID do pedido gerado pelo Marketplace para o cliente
        /// </summary>
        public string orderMarketplaceId { get; set; }
        
        /// <summary>
        /// Código do meio de pagamento. Consulte todos os tipos de pagamento disponíveis em GET /orders/{orderId}
        /// </summary>
        public int paymentType { get; set; }

        /// <summary>
        /// Data da compra
        /// </summary>
        public DateTime purchasedAt { get; set; }
        
        /// <summary>
        ///Data de aprovação de pagamento do pedido
        /// </summary>
        public DateTime? approvedAt { get; set; }

        /// <summary>
        /// Última data de atualização do pedido
        /// </summary>
        public DateTime updatedAt { get; set; }

        /// <summary>
        /// Status atual do pedido
        /// </summary>
        public string status { get; set; }

        /// <summary>
        ///  Total do pedido
        /// </summary>
        public double totalAmount { get; set; }

        /// <summary>
        /// Total de descontos do pedido
        /// </summary>
        public double totalDiscountAmount { get; set; }

        /// <summary>
        ///  Site para o qual o pedido foi criado. Consulte a lista completa de sites disponíveis no serviço GET /sites
        /// </summary>
        public string site { get; set; }

        /// <summary>
        ///  Informações de cobrança
        /// </summary>
        public Address billing { get; set; }

        /// <summary>
        ///  Informações do cliente
        /// </summary>
        public Customer customer { get; set; }

        /// <summary>
        ///  Informações de frete do pedido
        /// </summary>
        public Freight freight { get; set; }

        /// <summary>
        /// Lista de itens do pedido
        /// </summary>
        public IEnumerable<Item> items { get; set; }

        /// <summary>
        /// Informações de envio do pedido
        /// </summary>
        public Address shipping { get; set; }

        /// <summary>
        /// Informações de tracking do pedido
        /// </summary>
        public IEnumerable<Tracking> trackings { get; set; }

        public double GetSubTotal()
        {
            return (totalAmount - freight.chargedAmount);
        }

        public class Item
        {
            /// <summary>
            /// ID do item no pedido
            /// </summary>
            public string id { get; set; }

            /// <summary>
            /// SKU ID do produto do Lojista
            /// </summary>
            public string skuSellerId { get; set; }

            /// <summary>
            /// Nome do produto
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// Preço de venda unitário
            /// </summary>
            public double salePrice { get; set; }

            /// <summary>
            /// Flag que indica se o produto já foi enviado
            /// </summary>
            public bool sent { get; set; }

            /// <summary>
            ///  Informações sobre o frete do produto
            /// </summary>
            public ItemFreight freight { get; set; }

            /// <summary>
            /// Informações de embrulho para presente
            /// </summary>
            public GiftWrap giftWrap { get; set; }
        }

        public class Address
        {
            /// <summary>
            /// Endereço (nome da rua, avenida ... )
            /// </summary>
            public string address { get; set; }

            /// <summary>
            /// Número do endereço
            /// </summary>
            public string number { get; set; }

            /// <summary>
            /// Informações adicionais
            /// </summary>
            public string complement { get; set; }

            /// <summary>
            /// Bairro
            /// </summary>
            public string quarter { get; set; }

            /// <summary>
            /// Pontos de referência
            /// </summary>
            public string reference { get; set; }

            /// <summary>
            /// Cidade
            /// </summary>
            public string city { get; set; }

            /// <summary>
            /// Estado
            /// </summary>
            public string state { get; set; }

            /// <summary>
            /// Identificação do País. Baseado na ISO-3166, padrão alpha 2. Ex.: BR, US, AR
            /// </summary>
            public string countryId { get; set; }

            /// <summary>
            /// Código de Endereçamento Postal - CEP
            /// </summary>
            public string zipCode { get; set; }
        }

        public class Customer
        {
            /// <summary>
            /// Identificador do cliente
            /// </summary>
            public string id { get; set; }

            /// <summary>
            /// Data de cadastro do cliente
            /// </summary>
            public DateTime? createdAt { get; set; }

            /// <summary>
            /// Nome completo do cliente
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// Documento do cliente
            /// </summary>
            public string documentNumber { get; set; }

            /// <summary>
            /// ['PF' or 'PJ']: Tipo de cliente: Pessoa Física ou Jurídica
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// Email do cliente
            /// </summary>
            public string email { get; set; }

            /// <summary>
            /// Lista de telefones do cliente
            /// </summary>
            public IEnumerable<Telephone> phones { get; set; }
        }

        public class Telephone
        {
            /// <summary>
            /// Número do telefone
            /// </summary>
            public string number { get; set; }

            /// <summary>
            ///  ['HOME' or 'CELLPHONE' or 'BUSINESS']: Tipo do telefone
            /// </summary>
            public string type { get; set; }
        }

        public class Freight
        {
            /// <summary>
            ///  Valor nominal do frete (sem descontos e abatimentos, com margem comercial)
            /// </summary>
            public double actualAmount { get; set; }

            /// <summary>
            /// Valor cobrado pelo frete
            /// </summary>
            public double chargedAmount  { get; set; }

            /// <summary>
            /// ['NORMAL' or 'EXPRESSA' or 'AGENDADA']: Tipo de frete
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// Data de agendamento da entrega
            /// </summary>
            public DateTime? scheduledAt { get; set; }

            /// <summary>
            /// ['MANHÃ' or 'TARDE' or 'NOITE']: Período que a entrega foi agendada
            /// </summary>
            public string scheduledPeriod { get; set; }
        }

        public class ItemFreight : Freight
        {
            /// <summary>
            /// Prazo de transporte para entrega do produto em dias úteis
            /// </summary>
            public int transitTime { get; set; }

            /// <summary>
            /// Tempo de preparação/fabricação do produto. Esse tempo é incluído no cálculo de frete
            /// </summary>
            public int crossDockingTime { get; set; }

            /// <summary>
            ///  Informações adicionais sobre a entrega. Pode ser utilizado para informar o nome da transportadora, por exemplo
            /// </summary>
            public string additionalInfo { get; set; }
        }

        public class GiftWrap
        {
            /// <summary>
            /// Flag que indica se existe embrulho para presente para o produto
            /// </summary>
            public bool available { get; set; }

            /// <summary>
            /// Valor cobrado pelo embrulho
            /// </summary>
            public double value { get; set; }

            /// <summary>
            /// Flag que indica se é possível incluir uma mensagem
            /// </summary>
            public bool? messageSupport { get; set; }

            /// <summary>
            /// Mensagem que deverá ser enviada juntamente com o embrulho de presente
            /// </summary>
            public GiftCard giftCard { get; set; }
        }

        public class GiftCard
        {
            /// <summary>
            /// Nome de quem está dando o presente
            /// </summary>
            public string from { get; set; }

            /// <summary>
            /// Nome de quem irá receber o presente
            /// </summary>
            public string to { get; set; }

            /// <summary>
            /// Mensagem que deverá ser enviada no cartão juntamente com o embrulho de presente
            /// </summary>
            public string message { get; set; }
        }
        
        public class Tracking
        {
            /// <summary>
            /// Lista de produtos comprados no pedido
            /// </summary>
            public IEnumerable<Link> items { get; set; }

            /// <summary>
            /// Status do pedido. Veja o serviço GET /orders/{orderId} para consultar todos os controlPoits existentes.
            /// </summary>
            public string controlPoint { get; set; }

            /// <summary>
            ///  Descrição adicional sobre tracking
            /// </summary>
            public string description { get; set; }

            /// <summary>
            /// Data da ocorrência
            /// </summary>
            public DateTime occurredAt { get; set; }

            /// <summary>
            /// Informações sobre transportadora
            /// </summary>
            public Carrier carrier { get; set; }

            /// <summary>
            /// Url para consulta na transportadora
            /// </summary>
            public string url { get; set; }

            /// <summary>
            /// ID do objeto na transportadora
            /// </summary>
            public string number { get; set; }

            /// <summary>
            /// ID único da entrega para o lojista no parceiro, não pode haver repetição deste ID
            /// </summary>
            public string sellerDeliveryId { get; set; }

            /// <summary>
            /// Conhecimento de Transporte Eletrônico
            /// </summary>
            public string cte { get; set; }

            /// <summary>
            /// Informações sobre a Nota Fiscal da compra
            /// </summary>
            public Invoice invoice { get; set; }
        }
        
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
            public DateTime? issuedAt { get; set; }

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
