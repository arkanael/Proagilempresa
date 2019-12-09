using ProAgilEmpresa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Domain.Interfaces.IServices
{
    public interface IProdutoService : IDisposable
    {
        Produto Adicionar(Produto produto);
        Produto Atualizar(Produto produto);
        Produto Remover(Produto produto);
    }
}
