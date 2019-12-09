using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProAgilEmpresa.Domain.Interfaces.IRepositories
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterPorNome(string nome);
    }
}


