using E_Commerce_RestAPI.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_RestAPI.Src.Contexto
{
    //Classe responsável por dar características de um repositório para suas classes filhas
    

    public class EcommerceContexto :DbContext
    {
        #region Atributos
        //Utilizada para gerar comandos de pesquisa para o repositório e pode ser utilizada com o LINQ
        
        public DbSet<UsuarioModelo> Usuarios { get; set; }
        public DbSet<CarrinhoModelo> Carrinho { get; set; }
        public DbSet<ProdutoModelo> Produtos { get; set; }

        /*indica que a opção de contexto a ser criada é um
        BlogPessoalContexto e passa para a classe Pai   
        */
        #region Construtores

        public EcommerceContexto(DbContextOptions<EcommerceContexto> opt) : base(opt)
        {

        }
        #endregion
        #endregion
    }
}
