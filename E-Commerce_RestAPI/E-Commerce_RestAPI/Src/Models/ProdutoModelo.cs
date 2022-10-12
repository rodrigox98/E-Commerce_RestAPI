using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce_RestAPI.Src.Models
{
    [Table("tb_produtos")]
    public class ProdutoModelo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public float Preço { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
        public Categoria CategoriaDoProduto { get; set; }

        [JsonIgnore, InverseProperty("Produto")]
        public List<CarrinhoModelo> Carrinho { get; set; }



        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Categoria
        {
            PRATOS,
            COPOS,
            POTES,
            TALHERES
        }
    }
}
