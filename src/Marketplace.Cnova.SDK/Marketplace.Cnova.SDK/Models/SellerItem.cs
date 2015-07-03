using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class SellerItem
    {
        /// <summary>
        /// SKU ID do produto do Lojista
        /// </summary>
        public string skuSellerId { get; set; }

        /// <summary>
        /// Nome no Marketplace. Ex Televisor de LCD Sony Bravia 40”...
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Marca. Ex Sony
        /// </summary>
        public string brand { get; set; }

        /// <summary>
        /// Lista que pode conter tanto o código EAN do produto (código de barras) quanto códigos ISBN (geralmente utilizados para livros)
        /// </summary>
        public string[] gtin { get; set; }

        /// <summary>
        /// Status do produto para cada site
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// Informações do catálogo de produtos
        /// </summary>
        public Link product { get; set; }

        /// <summary>
        /// Informações de preço do produto para cada site
        /// </summary>
        public Price prices { get; set; }

        /// <summary>
        /// Informações de estoque do produto para cada site
        /// </summary>
        public Stock stock { get; set; }

        /// <summary>
        ///  Informações de dimensões do produto
        /// </summary>
        public Dimensions dimensions { get; set; }

        /// <summary>
        /// Informações de embrulho para presente
        /// </summary>
        public GiftWrap giftWrap { get; set; }

        /// <summary>
        ///  Características do produto
        /// </summary>
        public List<Attribute> attributes
        {
            get { return _attributes ?? (_attributes = new List<Attribute>()); }
            set { _attributes = value; }
        }
        List<Attribute> _attributes;

        /// <summary>
        /// Lista de imagens do produto
        /// </summary>
        public List<Image> images
        {
            get { return _images ?? (_images = new List<Image>()); }
            set { _images = value; }
        }
        List<Image> _images;

        /// <summary>
        /// Lista de videos do produto
        /// </summary>
        public List<Video> videos
        {
            get { return _videos ?? (_videos = new List<Video>()); }
            set { _videos = value; }
        }
        List<Video> _videos;

        /// <summary>
        /// Lista de urls do produto para cada site no qual o mesmo está disponível
        /// </summary>
        public List<Url> urls
        {
            get { return _urls ?? (_urls = new List<Url>()); }
            set { _urls = value; }
        }
        List<Url> _urls;

        public class Status
        {
            /// <summary>
            /// (boolean): Status do produto,
            /// </summary>
            public bool active { get; set; }

            /// <summary>
            /// (string): Site para o qual o status é considerado. Os possíveis sites são: 'EX','PF','CB', 'EH', 'BT', 'CD'.
            /// </summary>
            public string site { get; set; }
        }

        public class Price
        {
            /// <summary>
            ///  Preço “de” do produto no Marketplace.
            /// </summary>
            public double? @default { get; set; }

            /// <summary>
            /// Preço real de venda. Preço “por” do produto no Marketplace
            /// </summary>
            public double offer { get; set; }

            /// <summary>
            /// Site no qual o produto ficará ou não disponível. Consulte a lista completa de sites disponíveis no serviço GET /sites
            /// </summary>
            public string site { get; set; }
        }

        public class Stock
        {
            /// <summary>
            /// Quantidade de produtos disponíveis
            /// </summary>
            public int quantity { get; set; }

            /// <summary>
            /// Quantidade de produtos que estão reservados (com compras ainda não confirmadas)
            /// </summary>
            public int? reserved { get; set; }

            /// <summary>
            /// Tempo de preparação/fabricação do produto. Esse tempo é incluído no cálculo de frete
            /// </summary>
            public int crossDockingTime { get; set; }

            /// <summary>
            /// ID do depósito no qual o estoque do produto está sendo considerado. Consulte a lista completa de warehouses disponíveis no serviço GET /warehouses
            /// </summary>
            public int? warehouse { get; set; }
        }

        public class Dimensions
        {
            /// <summary>
            /// Peso do produto, em quilos. Não pode ser 0 (zero) e deve ter no máximo duas casas decimais
            /// </summary>
            private decimal _weight;
            public decimal weight
            {
                get { return Decimal.Round(_weight, 2); }
                set { _weight = value; }
            }

            /// <summary>
            /// Comprimento do produto, em metros. Não pode ser 0 (zero) e deve ter no máximo duas casas decimais
            /// </summary>
            private decimal _length;
            public decimal length
            {
                get { return Decimal.Round(_length, 2); }
                set { _length = value; }
            }

            /// <summary>
            /// Largura do produto, em metros. Não pode ser 0 (zero) e deve ter no máximo duas casas decimais
            /// </summary>
            private decimal _width;
            public decimal width
            {
                get { return Decimal.Round(_width, 2); }
                set { _width = value; }
            }

            /// <summary>
            /// Altura do produto, em metros. Não pode ser 0 (zero) e deve ter no máximo duas casas decimais
            /// </summary>
            private decimal _height;
            public decimal height
            {
                get { return Decimal.Round(_height, 2); }
                set { _height = value; }
            }
        }

        public class Attribute
        {
            /// <summary>
            ///  Nome do atributo
            /// </summary>  
            public string name { get; set; }

            /// <summary>
            /// Valor do atributo
            /// </summary>
            public string value { get; set; }
        }
    }
}
