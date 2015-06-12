using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Cnova.SDK.Models
{
    public class LoadProductsRequest
    {
        ICollection<Item> _items;
        public IEnumerable<Item> Items
        {
            get { return _items ?? (_items = new List<Item>()); }
        }

        public void AddItem(Item item)
        {
            if (item == null)
                return;
            if (Items.Any(x => x.skuSellerId == item.skuSellerId))
                return;

            _items.Add(item);
        }

        public void Clear()
        {
            if (_items != null)
            {
                _items.Clear();
            }
        }

        public class Item
        {
            /// <summary>
            /// (string, optional): SKU ID do produto no Marketplace - utilizado para realizar associação de produtos
            /// </summary>
            public string skuId { get; set; }
            
            /// <summary>
            /// (string): SKU ID do produto do Lojista.
            /// </summary>
            public string skuSellerId { get; set; }
            
            /// <summary>
            /// (string, optional): ID do produto do lojista para fazer o agrupamento de SKUs.
            /// </summary>
            public string productSellerId { get; set; }            
            
            /// <summary>
            /// (string): Nome no Marketplace. Ex Televisor de LCD Sony Bravia 40”
            /// </summary>
            public string title { get; set; }
            
            /// <summary>
            /// (string): Descrição do produto. Aceita tags HTML para formatar a apresentação da descrição, no entanto há algumas tags restritas (tags para acesso a conteúdo externo): img, object, script e iframe.
            /// </summary>
            public string description { get; set; }
            
            /// <summary>
            ///  (string): Marca. Ex Sony.
            /// </summary>
            public string brand { get; set; }
            
            /// <summary>
            /// (Array[string], optional): Lista que pode conter tanto o código EAN do produto (código de barras) quanto códigos ISBN (geralmente utilizados para livros).
            /// </summary>
            public string[] gtin { get; set; }
            
            /// <summary>
            /// (price): Informações de preço do produto.
            /// </summary>
            public Price price { get; set; }
            
            /// <summary>
            /// (stock): Informações de estoque do produto.
            /// </summary>
            public Stock stock { get; set; }
            
            /// <summary>
            /// (dimensions): Informações de dimensões do produto.
            /// </summary>
            public Dimensions dimensions { get; set; }

            /// <summary>
            /// (giftWrap, optional): Informações de embrulho para presente.
            /// </summary>
            public GiftWrap giftWrap { get; set; }

            /// <summary>
            /// Array[string]): Lista de categorias.
            /// </summary>
            public List<string> categories
            {
                get { return _categories ?? (_categories = new List<string>()); }
                set { _categories = value; }
            }
            List<string> _categories;

            /// <summary>
            /// (Array[string]): Lista de URLs de imagens. Pelo menos uma imagem precisa ser informada.
            /// </summary>
            public List<string> images
            {
                get { return _images ?? (_images = new List<string>()); }
                set { _images = value; }
            }
            List<string> _images;

            /// <summary>
            /// (Array[string], optional): Lista de URLs de vídeos.
            /// </summary>
            public List<string> videos
            {
                get { return _videos ?? (_videos = new List<string>()); }
                set { _videos = value; }
            }
            List<string> _videos;

            /// <summary>
            /// (Array[attributes]): Características do produto.
            /// </summary>
            public List<Attribute> attributes
            {
                get { return _attributes ?? (_attributes = new List<Attribute>()); }
                set { _attributes = value; }
            }
            List<Attribute> _attributes;

            public class Price
            {
                /// <summary>
                /// Preço “de” do produto no Marketplace.
                /// </summary>
                public double? @default { get; set; }

                /// <summary>
                /// Preço real de venda. Preço “por” do produto no Marketplace
                /// </summary>
                public double offer { get; set; }
            }

            public class Stock
            {
                /// <summary>
                /// Quantidade de produtos disponíveis
                /// </summary>
                public int quantity { get; set; }

                /// <summary>
                /// Tempo de preparação/fabricação do produto. Esse tempo é incluído no cálculo de frete
                /// </summary>
                public int crossDockingTime { get; set; }
            }

            public class Dimensions
            {
                /// <summary>
                /// Peso do produto, em quilos. Não pode ser 0 (zero) e deve ter no máximo duas casas decimais
                /// </summary>
                private decimal? _weight;
                public decimal? weight
                {
                    get { return _weight.HasValue ? Decimal.Round(_weight.Value, 2) : Decimal.Zero; }
                    set { _weight = value; }
                }

                /// <summary>
                /// Comprimento do produto, em metros. Não pode ser 0 (zero) e deve ter no máximo duas casas decimais
                /// </summary>
                private decimal? _length;
                public decimal? length
                {
                    get { return _length.HasValue ? Decimal.Round(_length.Value, 2) : Decimal.Zero; }
                    set { _length = value; }
                }

                /// <summary>
                /// Largura do produto, em metros. Não pode ser 0 (zero) e deve ter no máximo duas casas decimais
                /// </summary>
                private decimal? _width;
                public decimal? width
                {
                    get { return _width.HasValue ? Decimal.Round(_width.Value, 2) : Decimal.Zero; }
                    set { _width = value; }
                }

                /// <summary>
                /// Altura do produto, em metros. Não pode ser 0 (zero) e deve ter no máximo duas casas decimais
                /// </summary>
                private decimal? _height;
                public decimal? height
                {
                    get { return _height.HasValue ? Decimal.Round(_height.Value, 2) : Decimal.Zero; }
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
}
