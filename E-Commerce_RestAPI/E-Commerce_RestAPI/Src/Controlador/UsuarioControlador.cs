using E_Commerce_RestAPI.Src.Models;
using E_Commerce_RestAPI.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_RestAPI.Src.Controlador
{

    [ApiController] //Informa o sistema que a classe notada é um controlador
    [Route("api/Usuarios")] //Define o endpoint para o controlador
    [Produces("application/json")] //define o tipo de saída que o controlador irá fornercer para 
                                   //O cliente que solicita seus recursos  
    public class UsuarioControlador : ControllerBase
    {
        #region atributos
        private readonly IUsuario _repositorio;
        #endregion

        #region Construtores
        public UsuarioControlador(IUsuario repositorio)
        {
            _repositorio = repositorio;
        }
        #endregion

        #region métodos 
        [HttpGet("email/{emailUsuario}")] /*Notação responsavel por informar que o método será acessado por uma requisição 
                                             do tipo GET para o endpoint email/ passando como
                                             parâmetro de rota um emailUsuario  */
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario) //Responsável por pegar 
                                                                                                    //o emailUsuario passado pela 
                                                                                                    //rota e jogar dentro do método
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(emailUsuario);
            //Responsável por passar status 404 que rota com usuário não foi encontrada no servidor
            if (usuario == null) return NotFound(new { Mensagem = "Usuario não encontrado " });

            return Ok(usuario); // Responsável por passar status 200 com um objeto usuario na transferência
        }


        [HttpPost]//Notação responsável por informar que o método será acessado por uma requisição do tipo POST


        //Responsável por pegar o NovoUsuarioDTO passado pelo corpo da requisição feita pelo cliente.
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] UsuarioModelo usuario){


            await _repositorio.NovoUsuarioAsync(usuario);
               
            return Created($"api/Usuarios/{usuario.Email}", usuario); //Responsável de passar status 201 com usuário na transferência;

        }

        #endregion
    }
    }

