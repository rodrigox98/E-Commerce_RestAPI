using E_Commerce_RestAPI.Src.Contexto;
using E_Commerce_RestAPI.Src.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_RestAPI.Src.Repositorios.Implementacoes
{
    public class ProdutoRepositorio : IProduto
    {
        #region Atributos
        private readonly EcommerceContexto _contexto;
        #endregion
        #region Construtores
        public ProdutoRepositorio(EcommerceContexto contexto) { 

        _contexto = contexto;
        
        }
        #endregion
        public async Task AtualizarProdutoAsync(ProdutoModelo produto)
        {
            var produtoExistente = await PegarProdutoPeloId(produto.Id);
            produtoExistente.Quantidade = produto.Quantidade;
            produtoExistente.Preço = produto.Preço;
            produtoExistente.Descrição = produto.Descrição;
            _contexto.Produtos.Update(produtoExistente);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarProdutoAsync(int id)
        {
            _contexto.Produtos.Remove(await PegarProdutoPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }

        public async Task NovoProdutoAsync(ProdutoModelo produto)
        {
            await _contexto.Produtos.AddAsync(
                new ProdutoModelo
                {
                    Nome = produto.Nome,
                    Descrição = produto.Descrição,
                    Preço = produto.Preço,
                    Quantidade = produto.Quantidade,
                    Imagem = produto.Imagem,
                    CategoriaDoProduto = produto.CategoriaDoProduto
                });
            await _contexto.SaveChangesAsync();
        }

        public async Task<ProdutoModelo> PegarProdutoPeloIdAsync(int id)
        {
            if (!ExisteId(id)) throw new Exception("Id do tema não encontrado");
            
                return await _contexto.Produtos.FirstOrDefaultAsync(p => p.Id == id); 
            
        //Função auxiliar
        bool ExisteId(int id)
        {
            var auxiliar = _contexto.Produtos.FirstOrDefault(t => t.Id == id);
            return auxiliar != null;
        }
        }

        public async Task<List<ProdutoModelo>> PegarTodosProdutosAsync()
        {
            return await _contexto.Produtos.ToListAsync();
        }
    }
}
