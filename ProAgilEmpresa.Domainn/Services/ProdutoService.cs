using ProAgilEmpresa.Domain.Entities;
using ProAgilEmpresa.Domain.Interfaces.IRepositories;
using ProAgilEmpresa.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto Adicionar(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
            return produto;
        }

        public Produto Atualizar(Produto produto)
        {
            _produtoRepository.Atualizar(produto);
            return produto;
        }
        public Produto Remover(Produto produto)
        {
            _produtoRepository.Remover(produto);
            return produto;
        }
        public void Dispose()
        {
            _produtoRepository.Dispose();
        }


    }
}