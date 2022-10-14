using E_Commerce_RestAPI.Src.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Commerce_RestAPI.Src.Repositorios
{
    public interface IProduto
    {
        Task<List<ProdutoModelo>> PegarTodosProdutosAsync()>;
        Task<ProdutoModelo> PegarProdutoPeloIdAsync(int id);
        Task NovoProdutoAsync(ProdutoModelo produto);
        Task AtualizarProdutoAsync(ProdutoModelo produto);
        Task DeletarProdutoAsync(int id);
    }
}
