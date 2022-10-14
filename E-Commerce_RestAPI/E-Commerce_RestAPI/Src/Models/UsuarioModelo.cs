using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace E_Commerce_RestAPI.Src.Models
{
    [Table("tb_usuarios")] //Define que a classe usuário será representada no banco de dados como  'tb_usuarios'
    public class UsuarioModelo
    {
        #region atributos

        [Key] //Define a primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Define que o atributo ID será auto-incrementável
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }



        [JsonIgnore, InverseProperty("Comprador")]
        public List<CarrinhoModelo> Compras { get; set; }
        #endregion
    }
}
