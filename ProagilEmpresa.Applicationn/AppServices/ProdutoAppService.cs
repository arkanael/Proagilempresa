using AutoMapper;
using ProagilEmpresa.Application.Dtos;
using ProAgilEmpresa.Application.Dtos;
using ProAgilEmpresa.Application.IAppServices;
using ProAgilEmpresa.Domain.Entities;
using ProAgilEmpresa.Domain.Interfaces.IRepositories;
using ProAgilEmpresa.Domain.Interfaces.IServices;
using ProAgilEmpresa.Domain.Interfaces.IUoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Application.AppServices
{
    public class ProdutoAppService : AppServiceBase, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService, IProdutoRepository produtoRepository, IUnityOfWork unityOfWork, IMapper mapper) : base(unityOfWork)
        {
            _produtoService = produtoService;
            _produtoRepository = produtoRepository;
            _mapper = mapper;

        }

        public ProdutoConsultaDto Adicionar(ProdutoCadastroDto produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            produto = _produtoService.Adicionar(produto);

            if (!SaveChanges())
            {
                throw new Exception();
            }

            return _mapper.Map<ProdutoConsultaDto>(produto);
        }

        public void Deletar(int id)
        {
            var produto = _produtoRepository.ObterPorId(id);

            produto = _produtoService.Remover(produto);

            if (!SaveChanges())
            {
                throw new Exception();
            }
        }


        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

        public void Editar(ProdutoEdicaoDto produtoDto)
        {
            var produtoEditado = _mapper.Map<Produto>(produtoDto);
            var produto = _produtoRepository.ObterPorId(produtoDto.Id);

            produto.AtualizarDados(produtoEditado);

            produto = _produtoService.Atualizar(produto);

            if (!SaveChanges())
            {
                throw new Exception();
            }
        }


        public ProdutoConsultaDto ObterPorId(int id)
        {
            return _mapper.Map<ProdutoConsultaDto>(_produtoRepository.ObterPorId(id));
        }


        public IEnumerable<ProdutoConsultaDto> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoConsultaDto>>(_produtoRepository.ObterTodos());
        }

    }
}


