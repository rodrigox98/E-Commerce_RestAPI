using E_Commerce_RestAPI.Src.Contexto;
using E_Commerce_RestAPI.Src.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Commerce_RestAPI.Src.Repositorios.Implementacoes
{
    /// <summary>
    /// Resumo: Classe responsável por implementar IUsuario.
    /// </summary>
    public class UsuarioRepositorio : IUsuario
    {
        #region Atributos
        private readonly EcommerceContexto _contexto;
        #endregion

        #region Construtores
        public UsuarioRepositorio(EcommerceContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion


        #region Metodos

        public async Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }


        public async Task NovoUsuarioAsync(UsuarioModelo usuario) { 
            await _contexto.Usuarios.AddAsync(
            new UsuarioModelo
            {   
                Email = usuario.Email,
                Nome = usuario.Nome,
                Senha = usuario.Senha
            });
            await _contexto.SaveChangesAsync();
            }
        #endregion
    }
}
