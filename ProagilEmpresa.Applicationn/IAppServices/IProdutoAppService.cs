using ProagilEmpresa.Application.Dtos;
using ProAgilEmpresa.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Application.IAppServices
{
    public interface IProdutoAppService : IDisposable
    {
        IEnumerable<ProdutoConsultaDto> ObterTodos();
        ProdutoConsultaDto ObterPorId(int id);
        ProdutoConsultaDto Adicionar(ProdutoCadastroDto produtoDTo);
        void Editar(ProdutoEdicaoDto produtoDTo);
        void Deletar(int id);


    }
}
