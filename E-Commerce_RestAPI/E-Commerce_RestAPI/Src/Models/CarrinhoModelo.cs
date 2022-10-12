using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce_RestAPI.Src.Models
{
    [Table("tb_carrinho")]
    public class CarrinhoModelo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("fk_usuario")]
        public UsuarioModelo Comprador { get; set; }

        [ForeignKey("fk_produto")]
        public ProdutoModelo Produto { get; set; }
        
        public Status StatusDoPagamento { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Status
        {
            AGUARDANDO,
            CANELADO,
            PAGO
        }
    }
}
