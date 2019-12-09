using ProAgilEmpresa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProAgilEmpresa.Domain.Interfaces.IRepositories
{
    public interface IProdutoRepository : IRepositoryRead<Produto>, IRepositoryWrite<Produto>
    {

    }
}
