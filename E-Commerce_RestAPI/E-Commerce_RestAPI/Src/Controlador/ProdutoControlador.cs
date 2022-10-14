using E_Commerce_RestAPI.Src.Models;
using E_Commerce_RestAPI.Src.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace E_Commerce_RestAPI.Src.Controlador
{
    [ApiController]
    [Route("api/Produtos")]
    [Produces("application.json")]
    public class ProdutoControlador :ControllerBase
    {
        #region Atributos
        private readonly IProduto _repositorio;
        #endregion

        #region Construtores
        public ProdutoControlador(IProduto repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos
        [HttpGet]
        public async Task<ActionResult> PegarTodosProdutosAsync()
        {
            var lista = await _repositorio.PegarTodosProdutosAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }


        [HttpGet("id/{idTema}")]
        public async Task<ActionResult> PegarProdutoPeloIdAsync([FromRoute] int idProduto)
        {
            try
            {
                return Ok(await _repositorio.PegarProdutoPeloIdAsync(idProduto));
            }
            catch(Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult> NovoProdutoAsync([FromBody] ProdutoModelo produto)
        {
            await _repositorio.NovoProdutoAsync(produto);

            return Created($"api/Produtos", produto);
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarProduto([FromBody] ProdutoModelo produto)
        {
            try
            {
                await _repositorio.AtualizarProdutoAsync(produto);
                return Ok(produto);
            }catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message }); //Passa status 400, informando erro de requisição
            }
        }

        [HttpDelete("deletar/{idRepositorio}")]
        public async Task<ActionResult> DeletarProduto([FromRoute] int idProduto)
        {
            try
            {
                await _repositorio.DeletarProdutoAsync(idProduto);
                return NoContent();
            }catch(Exception ex)
            {
                return NotFound(new { Mensagem = ex.Message });
            }
        }
        #endregion
    }
}
