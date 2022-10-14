using E_Commerce_RestAPI.Src.Models;
using System.Threading.Tasks;

namespace E_Commerce_RestAPI.Src.Repositorios
{
    /// <summary>
    /// Resumo: Responsável por representar as ações de CRUD de usuário
    /// </summary>
    public interface IUsuario
    {
        Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email);

        Task NovoUsuarioAsync(UsuarioModelo usuario);
    }
}
